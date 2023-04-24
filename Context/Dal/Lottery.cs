using wine_lottery_csharp.Enums;

namespace wine_lottery_csharp.Context.Dal
{
    public class Lottery
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int NumberOfTickets { get; set; }
        public byte LotteryStatus { get; set; }

        public LotteryStatus GetLotteryStatus()
        {
            return (LotteryStatus)LotteryStatus;
        }
    }
}
