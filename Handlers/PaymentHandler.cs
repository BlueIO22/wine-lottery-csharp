using Stripe;
using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Dto.Request;
using wine_lottery_csharp.Enums;
using wine_lottery_csharp.Handlers.Interfaces;
using wine_lottery_csharp.services.interfaces;
using wine_lottery_csharp.Services.Types;

namespace wine_lottery_csharp.Handlers
{
    public class PaymentHandler : IPaymentHandler
    {
        private IPaymentService _paymentService;
        private ICustomerHandler _customerHandler;
        private ILotteryHandler _lotteryHandler;

        public PaymentHandler(IPaymentService paymentService, ICustomerHandler customerHandler, ILotteryHandler lotteryHandler)
        {
            _paymentService = paymentService;
            _customerHandler = customerHandler;
            _lotteryHandler = lotteryHandler;
        }

        public async Task<Response<List<LotteryTicket>>> PurchaseLotteryTickets(PurchaseTicketRequest payment)
        {
            if (!await IsPurchaseRequestValid(payment))
            {
                return new Response<List<LotteryTicket>>() { Status = ResponseStatus.NOT_ENOUGH_TICKETS };
            }

            PaymentMethod paymentMethod = await _paymentService.CreatePaymentMethod(payment.PaymentMethod);

            string customerId = await GetCustomerId(payment);

            var stripeCustomer = await CreatePaymentCustomer(payment);

            PaymentRequest request = new PaymentRequest()
            {
                Amount = 1000 * payment.AmountOfTickets,
                Description = $"Payment for {payment.AmountOfTickets} to the lottery",
                CustomerId = customerId,
                PaymentMethodId = paymentMethod.Id,
                StripeCustomer = stripeCustomer
            };

            PaymentIntent paymentIntent = await _paymentService.CreatePayment(request);

            if (paymentIntent.Status != Constants.PAYMENT_SUCCESS)
            {
                return new Response<List<LotteryTicket>>() { Status = ResponseStatus.PAYMENT_NOT_SUCCESSFUL };
            }


            return new Response<List<LotteryTicket>> { Data = await GetAndMarkTickets(payment, customerId) };
        }

        private async Task<Customer> CreatePaymentCustomer(PurchaseTicketRequest payment)
        {
            Customer? stripeCustomer = null;

            var foundStripeCustomer = await _paymentService.GetCustomerByName(payment.Customer.Name);

            if (foundStripeCustomer != null)
            {
                return foundStripeCustomer;
            }

            stripeCustomer = await _paymentService.CreateCustomer(payment.Customer);

            if (stripeCustomer == null)
            {
                throw new Exception("Could not create payment customer");
            }

            return stripeCustomer;
        }

        private async Task<bool> IsPurchaseRequestValid(PurchaseTicketRequest request)
        {
            if (request.LotteryId == Guid.Empty)
            {
                return await Task.FromResult(false);
            }

            return await _lotteryHandler.CheckIfLotteryHasAvailableTickets(request.AmountOfTickets, request.LotteryId);
        }

        private async Task<List<LotteryTicket>> GetAndMarkTickets(PurchaseTicketRequest payment, string customerId)
        {
            var ticketResponse = await _lotteryHandler.MarkLotteryTickets(customerId, payment.AmountOfTickets, payment.LotteryId.ToString());

            if (ticketResponse.Status == ResponseStatus.NUMBER_OF_TICKETS_MISMATCH)
            {
                throw new Exception("Tickets received was not successfull");
            }

            return ticketResponse.Data;
        }

        private async Task<string> GetCustomerId(PurchaseTicketRequest payment)
        {
            var customerResponse = await _customerHandler.GetCustomerByName(payment.Customer.Name);

            var customerId = customerResponse.Data?.Id.ToString() ?? string.Empty;

            if (customerResponse.Status == ResponseStatus.NOT_FOUND)
            {
                var foundCustomerResponse = await _customerHandler.RegisterCustomer(payment.Customer);
                customerId = foundCustomerResponse.Data;
            }

            return customerId;
        }
    }
}
