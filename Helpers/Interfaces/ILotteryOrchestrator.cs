using wine_lottery_csharp.Handlers;
using wine_lottery_csharp.Handlers.Interfaces;

namespace wine_lottery_csharp.Helpers
{
    public interface ILotteryOrchestrator
    {
        public Task<Response<List<LotteryResult>>> RunLottery(Guid lotteryId);
    }
}