using wine_lottery_csharp.Context.Dal;

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

        public bool ListDoesContainNumber(List<int> numbers, int number)
        {
            return numbers.Contains(number);
        }

        public List<Ticket> GenerateLotteryTickets(int numberOfTickets, string lotteryId)
        {
            List<Ticket> tickets = new List<Ticket>();

            for (var i = 0; i < numberOfTickets; i++)
            {
                var ticket = new Ticket
                {
                    CustomerId = string.Empty,
                    Id = Guid.NewGuid().ToString(),
                    LotteryId = lotteryId,

                };

                ticket.Number = i + 1;

                tickets.Add(ticket);
            }

            return tickets;
        }
    }
}
