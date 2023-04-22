using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dal.Context;
using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Enums;
using wine_lottery_csharp.Repository.Helpers;
using wine_lottery_csharp.Repository.Interfaces;

namespace wine_lottery_csharp.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly LotteryDbContext _lotteryDbContext;
        private readonly ILotteryHelper _lotteryHelper;

        public TicketRepository(LotteryDbContext lotteryContext, ILotteryHelper lotteryHelper)
        {
            _lotteryDbContext = lotteryContext;
            _lotteryHelper = lotteryHelper;
        }

        public async Task CreateTickets(List<LotteryTicket> tickets)
        {
            await _lotteryDbContext.Ticket.AddRangeAsync(tickets.Select(ticket => ticket.ToTicketDal()).ToList());
        }

        public async Task<ResponseStatus> CreateTicketsByNumberOfTickets(int numberOfTickets, Guid lotteryId)
        {
            List<Ticket> tickets = new List<Ticket>();

            for (var i = 0; i < numberOfTickets; i++)
            {
                var ticket = new Ticket
                {
                    CustomerId = Guid.Empty,
                    Id = Guid.NewGuid(),
                    LotteryId = lotteryId,

                };

                var randomNumber = 0;

                while (!_lotteryHelper.DoesNumberExsistInList(tickets.Select(t => t.Number).ToList()))
                {
                    randomNumber = _lotteryHelper.GetRandomNumberForTicket();
                }

                ticket.Number = randomNumber;

                tickets.Add(ticket);
            }

            if (tickets.Count != numberOfTickets)
            {
                return ResponseStatus.NUMBER_OF_TICKETS_MISMATCH;
            }

            await _lotteryDbContext.Ticket.AddRangeAsync(tickets);

            return ResponseStatus.OK;
        }

        public List<LotteryTicket> MarkLotteryTickets(Guid customerId, int numberOfTickets, Guid lotteryId)
        {
            var tickets = _lotteryDbContext.Ticket.Where(ticket => ticket.LotteryId == lotteryId).ToList();

            var numbers = tickets.Select(ticket => ticket.Number).ToList();

            var randomNumbers = _lotteryHelper.GetRandomNumbers(numbers, numberOfTickets);

            var filteredTickets = tickets.Where(ticket => randomNumbers.Contains(ticket.Number)).ToList();

            filteredTickets.ForEach(ticket => ticket.CustomerId = customerId);

            _lotteryDbContext.Ticket.UpdateRange(filteredTickets);

            return _lotteryDbContext.Ticket.Where(ticket => ticket.CustomerId == customerId).Select(ticket => ticket.ToLotteryTicket()).ToList();

        }

        public Task RemoveLotteryTicketByNumber(int number, Guid lotteryId)
        {
            var foundLotteryTicket = _lotteryDbContext.Ticket.Where(ticket => ticket.Number == number && ticket.LotteryId == lotteryId).SingleOrDefault();
            if (foundLotteryTicket == null) { return Task.CompletedTask; }
            _lotteryDbContext.Ticket.Remove(foundLotteryTicket);
            return Task.CompletedTask;
        }

        public List<LotteryTicket> RetrieveTicketsByCustomerId(Guid customerId)
        {
            return _lotteryDbContext.Ticket.Where(ticket => ticket.CustomerId == customerId).Select(ticket => ticket.ToLotteryTicket()).ToList();
        }
    }
}
