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
            await _lotteryDbContext.SaveChangesAsync();
        }

        public async Task<ResponseStatus> CreateTicketsByNumberOfTickets(int numberOfTickets, string lotteryId)
        {
            List<Ticket> tickets = _lotteryHelper.GenerateLotteryTickets(numberOfTickets, lotteryId);

            if (tickets.Count != numberOfTickets)
            {
                return ResponseStatus.NUMBER_OF_TICKETS_MISMATCH;
            }

            await _lotteryDbContext.Ticket.AddRangeAsync(tickets);
            await _lotteryDbContext.SaveChangesAsync();

            return ResponseStatus.OK;
        }

        public List<LotteryTicket> FindUnMarkedTicketsByLotteryId(string lotteryId)
        {
            return _lotteryDbContext.Ticket.Where(ticket => ticket.LotteryId == lotteryId && ticket.CustomerId.Length == 0)
                .Select(ticket => ticket.ToLotteryTicket())
                .ToList();
        }

        public List<LotteryTicket> MarkLotteryTickets(string customerId, int numberOfTickets, string lotteryId)
        {
            var tickets = _lotteryDbContext.Ticket.Where(ticket => ticket.LotteryId == lotteryId && ticket.CustomerId.Length == 0).ToList();

            var filteredTickets = tickets.Take(numberOfTickets).ToList();

            filteredTickets.ForEach(ticket => ticket.CustomerId = customerId);

            _lotteryDbContext.Ticket.UpdateRange(filteredTickets);
            _lotteryDbContext.SaveChanges();

            return _lotteryDbContext.Ticket.Where(ticket => ticket.CustomerId == customerId).Select(ticket => ticket.ToLotteryTicket()).ToList();

        }

        public Task<ResponseStatus> RemoveLotteryTicketById(string lotteryTicketId)
        {
            var foundTicket = _lotteryDbContext.Ticket.Where(ticket => ticket.Id == lotteryTicketId).SingleOrDefault();

            if (foundTicket == null)
            {
                return Task.FromResult(ResponseStatus.NOT_FOUND);
            }

            _lotteryDbContext.Ticket.Remove(foundTicket);
            _lotteryDbContext.SaveChanges();
            return Task.FromResult(ResponseStatus.OK);
        }

        public Task RemoveLotteryTicketByNumber(int number, string lotteryId)
        {
            var foundLotteryTicket = _lotteryDbContext.Ticket.Where(ticket => ticket.Number == number && ticket.LotteryId == lotteryId).SingleOrDefault();
            if (foundLotteryTicket == null) { return Task.CompletedTask; }
            _lotteryDbContext.Ticket.Remove(foundLotteryTicket);
            _lotteryDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public List<LotteryTicket> RetrieveTicketsByCustomerId(string customerId)
        {
            return _lotteryDbContext.Ticket.Where(ticket => ticket.CustomerId == customerId).Select(ticket => ticket.ToLotteryTicket()).ToList();
        }

        public List<LotteryTicket> RetrieveTicketsByLotteryId(string lotteryId)
        {
            return _lotteryDbContext.Ticket.Where(ticket => ticket.LotteryId == lotteryId).Select(ticket => ticket.ToLotteryTicket()).ToList();
        }

        public async Task<ResponseStatus> ResetLotteryTickets(string lotteryId, int numberOfTickets)
        {
            var tickets = _lotteryDbContext.Ticket.Where(ticket => ticket.LotteryId == lotteryId).ToList();
            _lotteryDbContext.Ticket.RemoveRange(tickets);

            var newTickets = _lotteryHelper.GenerateLotteryTickets(numberOfTickets, lotteryId);
            _lotteryDbContext.Ticket.AddRange(newTickets);

            await _lotteryDbContext.SaveChangesAsync();
            return ResponseStatus.OK;
        }
    }
}
