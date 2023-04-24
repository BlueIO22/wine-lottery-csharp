using wine_lottery_csharp.Dto;

namespace wine_lottery_csharp.Handlers
{
    public interface ITicketHandler
    {
        public Task<Response<List<LotteryTicket>>> GetLotteryTicketsByLotteryId(Guid lotteryId);

        public Task RemoveLotteryTicket(Guid ticketId);

    }
}