using Stripe;

namespace wine_lottery_csharp.Services.Types
{
    [Serializable]
    public class PaymentRequest
    {

        public long Amount { get; set; }

        public string Currency { get; } = "nok";

        public string Source { get; set; } = "tok_visa";

        public string CustomerId { get; set; } = String.Empty;

        public string Description { get; set; } = string.Empty;

        public string PaymentMethodId { get; set; } = string.Empty;

        public PaymentMethodRequest PaymentMethod { get; set; } = new PaymentMethodRequest();

        public void SetPaymentMethodId(string id)
        {
            PaymentMethodId = id;
        }

        public PaymentIntentCreateOptions ToPaymentIntentCreateOptions()
        {
            return new PaymentIntentCreateOptions
            {
                Amount = Amount,
                Currency = Currency,
                Confirm = true,
                Customer = CustomerId,
                Description = Description,
                PaymentMethod = PaymentMethodId
            };
        }
    }
}
