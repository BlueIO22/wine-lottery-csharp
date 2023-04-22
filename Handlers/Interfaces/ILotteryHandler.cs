using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Enums;

namespace wine_lottery_csharp.Handlers.Interfaces
{
    public interface ILotteryHandler
    {
        ResponseStatus RegisterLottery(LotteryDto lottery);

        Task<Response<LotteryDto>> GetLotteryByName(string lotteryName);

        Task<Response<LotteryResultDto>> RunLottery(string lotteryName);
    }
}