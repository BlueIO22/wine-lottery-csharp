using wine_lottery_csharp.Context.Dal;

namespace wine_lottery_csharp.Repository.Helpers
{
    public interface ILotteryHelper
    {
        public List<int> GetRandomNumbers(List<int> numbers, List<int> takenNumbers, int numberOfTickets);

        public int GetRandomNumber(List<int> numbers);

        public int GetRandomNumberForTicket();

        public bool ListDoesContainNumber(List<int> numbers, int number);

        public List<Ticket> GenerateLotteryTickets(int numberOfTickets, string lotteryId);
    }
}