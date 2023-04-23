using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Enums;

namespace wine_lottery_csharp.Repository.Interfaces
{
    public interface ITicketRepository
    {
        public Task CreateTickets(List<LotteryTicket> tickets);

        public Task<ResponseStatus> CreateTicketsByNumberOfTickets(int number, string lotteryId);

        public List<LotteryTicket> RetrieveTicketsByCustomerId(string customerId);

        public List<LotteryTicket> MarkLotteryTickets(string customerId, int numberOfTickets, string lotteryId);

        public Task RemoveLotteryTicketByNumber(int number, string lotteryId);
    }
}
