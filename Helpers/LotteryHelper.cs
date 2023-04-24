using wine_lottery_csharp.Context.Dal;

namespace wine_lottery_csharp.Repository.Helpers
{
    public class LotteryHelper : ILotteryHelper
    {
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
