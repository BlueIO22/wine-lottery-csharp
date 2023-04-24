using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Dto.Request;
using wine_lottery_csharp.Enums;

namespace wine_lottery_csharp.Handlers.Interfaces
{
    public interface ILotteryHandler
    {
        Task<ResponseStatus> RegisterLottery(LotteryRequest lottery);
        Task<Response<LotteryResponse>> GetLotteryByName(string lotteryName);
        public Task<Response<List<LotteryTicket>>> MarkLotteryTickets(string customerId, int numberOfTickets, string lotteryId);
        public Task<bool> CheckIfLotteryHasAvailableTickets(int numberOfTickets, Guid lotteryId);
        public Task<Response<Lottery?>> GetLotteryById(Guid lotteryId);

        public Task<ResponseStatus> ResetLotteryTickets(Guid lotteryId, int numberOfTickets);
        Task MarkLotteryAsFinished(Guid lotteryId);
    }
}