using wine_lottery_csharp.Dto;

namespace wine_lottery_csharp.Repository.Interfaces
{
    public interface ITicketRepository
    {
        public Task CreateTickets(List<LotteryTicket> tickets);

        public Task CreateTicketsByNumberOfTickets(int number, Guid lotteryId);

        public List<LotteryTicket> RetrieveTicketsByCustomerId(Guid customerId);

        public List<LotteryTicket> MarkLotteryTickets(Guid customerId, int numberOfTickets, Guid lotteryId);

        public Task RemoveLotteryTicketByNumber(int number, Guid lotteryId);
    }
}
