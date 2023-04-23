using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Dto.Request;
using wine_lottery_csharp.Enums;

namespace wine_lottery_csharp.Handlers.Interfaces
{
    public interface ILotteryHandler
    {
        Task<ResponseStatus> RegisterLottery(LotteryRequest lottery);

        Task<Response<LotteryResponse>> GetLotteryByName(string lotteryName);

        Task<Response<LotteryResult>> RunLottery(string lotteryName);
    }
}