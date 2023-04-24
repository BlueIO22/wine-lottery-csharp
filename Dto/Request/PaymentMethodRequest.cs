using Stripe;

namespace wine_lottery_csharp.Services.Types
{
    [Serializable]
    public class PaymentMethodRequest
    {

        public string Number { get; set; } = string.Empty;

        public int ExpireMonth { get; set; }

        public int ExpireYear { get; set; }

        public string Cvc { get; set; } = string.Empty;

        public PaymentMethodCreateOptions ToPaymentMethodCreateOptions()
        {
            return new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = Number,
                    ExpMonth = ExpireMonth,
                    ExpYear = ExpireYear,
                    Cvc = Cvc
                }
            };
        }
    }
}
