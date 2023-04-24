using wine_lottery_csharp.Context.Dal;

namespace wine_lottery_csharp.Repository.Helpers
{
    public interface ILotteryHelper
    {
        public List<Ticket> GenerateLotteryTickets(int numberOfTickets, string lotteryId);
        public string GetStatusString(Enum status);
    }
}