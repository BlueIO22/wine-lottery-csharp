using Stripe;
using wine_lottery_csharp.Services.Dto;
using wine_lottery_csharp.Services.Types;

namespace wine_lottery_csharp.services.interfaces
{
    public interface IPaymentService
    {
        public Task<PaymentMethod> CreatePaymentMethod(PaymentMethodRequest paymentMethodRequest);
        public Task<PaymentIntent> CreatePayment(PaymentRequest payment);
        public Task<Customer> CreateCustomer(CustomerRequest payment);
        public Task<Customer?> GetCustomerByName(string name);
    }
}
