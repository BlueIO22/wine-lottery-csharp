namespace wine_lottery_csharp.Repository.Helpers
{
    public class LotteryHelper : ILotteryHelper
    {
        public List<int> GetRandomNumbers(List<int> numbers, int numberOfTickets)
        {
            Random random = new Random();
            return numbers.Select(number => random.Next(numbers.Count)).Take(numberOfTickets).ToList();
        }

        public int GetRandomNumber(List<int> numbers)
        {
            Random random = new Random();
            return random.Next(numbers.Count);
        }

        public int GetRandomNumberForTicket()
        {
            Random random = new Random();
            return random.Next();
        }

        public bool DoesNumberExsistInList(List<int> numbers, int number)
        {
            return numbers.Contains(number);
        }
    }
}
