using wine_lottery_csharp.Dto.Request;

namespace wine_lottery_csharp.Handlers.Interfaces
{
    public interface IWineHandler
    {
        Task<Response<List<WineResponse>>> GetAllWinesByLotteryId(Guid lotteryId);
        Task RemoveWine(WineResponse wine);
    }
}