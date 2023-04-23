using Stripe;
using wine_lottery_csharp.Services.Dto;
using wine_lottery_csharp.Services.Types;

namespace wine_lottery_csharp.services.interfaces
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentIntentService _paymentIntentService;
        private readonly CustomerService _customerService;
        private readonly PaymentMethodService _paymentMethodService;

        public PaymentService(IConfiguration config)
        {
            StripeConfiguration.ApiKey = config.GetValue<string>("Stripe:StripePrivateKey");

            _paymentIntentService = new PaymentIntentService();
            _customerService = new CustomerService();
            _paymentMethodService = new PaymentMethodService();
        }

        public async Task<Customer> CreateCustomer(CustomerRequest customerRequest)
        {
            return await _customerService.CreateAsync(customerRequest.ToCustomerCreateOptions());
        }

        public async Task<PaymentIntent> CreatePayment(PaymentRequest paymentRequest)
        {
            return await _paymentIntentService.CreateAsync(paymentRequest.ToPaymentIntentCreateOptions());
        }

        public async Task<PaymentMethod> CreatePaymentMethod(PaymentMethodRequest paymentMethodRequest)
        {
            return await _paymentMethodService.CreateAsync(paymentMethodRequest.ToPaymentMethodCreateOptions());
        }

        public async Task<Customer?> GetCustomerByName(string name)
        {
            var result = await _customerService.SearchAsync(new CustomerSearchOptions
            {
                Query = $"name:'{name}'"
            });

            return result.FirstOrDefault();
        }
    }
}
