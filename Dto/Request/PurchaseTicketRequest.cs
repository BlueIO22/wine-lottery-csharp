using wine_lottery_csharp.Services.Dto;

namespace wine_lottery_csharp.Dto.Request
{
    public class PurchaseTicketRequest
    {
        public int AmountOfTickets { get; set; }
        public CustomerRequest Customer { get; set; } = new CustomerRequest();
        public CardDto Card { get; set; } = new CardDto();
    }
}

