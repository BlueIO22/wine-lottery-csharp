using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Dto.Request;

namespace wine_lottery_csharp.Handlers.Interfaces
{
    public class LotteryResult
    {
        public Guid LotteryId { get; set; }
        public string LotteryName { get; set; } = string.Empty;
        public WineResponse Wine { get; set; } = new WineResponse();
        public LotteryTicket WinnerTicket { get; set; } = new LotteryTicket();
        public CustomerResponse WinnerProfile { get; set; } = new CustomerResponse();
    }
}