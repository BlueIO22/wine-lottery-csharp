using Stripe;

namespace wine_lottery_csharp.Services.Types
{
    [Serializable]
    public class PaymentRequest
    {

        public long Amount { get; set; }

        public string Currency { get; } = "nok";

        public string Source { get; set; } = "tok_visa";

        public string CustomerId { get; set; } = string.Empty;

        public Customer StripeCustomer { get; set; } = new Customer();

        public string Description { get; set; } = string.Empty;

        public string PaymentMethodId { get; set; } = string.Empty;

        public PaymentIntentCreateOptions ToPaymentIntentCreateOptions()
        {
            return new PaymentIntentCreateOptions
            {
                Amount = Amount,
                Currency = Currency,
                Confirm = true,
                Customer = StripeCustomer.Id,
                Description = Description,
                PaymentMethod = PaymentMethodId
            };
        }
    }
}
