namespace wine_lottery_csharp.Repository.Helpers
{
    public interface ILotteryHelper
    {
        public List<int> GetRandomNumbers(List<int> numbers, int numberOfTickets);

        public int GetRandomNumber(List<int> numbers);

        public int GetRandomNumberForTicket();

        public bool DoesNumberExsistInList(List<int> numbers);
    }
}