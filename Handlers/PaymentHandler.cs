using Stripe;
using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Handlers.Interfaces;
using wine_lottery_csharp.services.interfaces;
using wine_lottery_csharp.Services.Types;

namespace wine_lottery_csharp.Handlers
{
    public class PaymentHandler : IPaymentHandler
    {
        private IPaymentService _paymentService; 

        public PaymentHandler (IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<LotteryTicket> PurchaseLotteryTicket(PaymentRequest payment)
        {
            PaymentMethod paymentMethod = await _paymentService.CreatePaymentMethod(payment.PaymentMethod);
            payment.SetPaymentMethodId(paymentMethod.Id);
            PaymentIntent paymentIntent = await _paymentService.CreatePayment(payment);

            if (paymentIntent.Status != Constants.PAYMENT_SUCCESS)
            {
                throw new Exception("Payment was not successfull!");
            }

            return new LotteryTicket();
        }
    }
}
