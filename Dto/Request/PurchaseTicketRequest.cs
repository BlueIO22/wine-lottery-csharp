using wine_lottery_csharp.Services.Dto;
using wine_lottery_csharp.Services.Types;

namespace wine_lottery_csharp.Dto.Request
{
    public class PurchaseTicketRequest
    {
        public int AmountOfTickets { get; set; }
        public CustomerRequest Customer { get; set; } = new CustomerRequest();
        public PaymentMethodRequest PaymentMethod { get; set; } = new PaymentMethodRequest();

        public Guid LotteryId { get; set; } = Guid.Empty;
    }
}

