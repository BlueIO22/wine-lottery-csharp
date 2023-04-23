using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Enums;
using wine_lottery_csharp.Repository.Interfaces;

namespace wine_lottery_csharp.Handlers
{
    public class TicketHandler : ITicketHandler
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task<Response<List<LotteryTicket>>> GetLotteryTicketsByLotteryId(Guid lotteryId)
        {
            var tickets = _ticketRepository.RetrieveTicketsByLotteryId(lotteryId.ToString());

            if (tickets.Count == 0)
            {
                return Task.FromResult(new Response<List<LotteryTicket>>() { Status = ResponseStatus.NOT_FOUND });
            }

            return Task.FromResult(new Response<List<LotteryTicket>> { Data = tickets });
        }

        public async Task RemoveLotteryTicket(Guid ticketId)
        {
            await _ticketRepository.RemoveLotteryTicketById(ticketId.ToString());
        }
    }
}
