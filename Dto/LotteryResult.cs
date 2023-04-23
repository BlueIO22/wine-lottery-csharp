using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dto;

namespace wine_lottery_csharp.Handlers.Interfaces
{
    public class LotteryResult
    {
        public Guid LotteryId { get; set; }
        public string LotteryName { get; set; }
        public Wine Wine { get; set; }
        public LotteryTicket WinnerTicket { get; set; }
        public CustomerResponse WinnerProfile { get; set; }
    }
}