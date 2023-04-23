using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dto.Request;

namespace wine_lottery_csharp.Repository.Interfaces
{
    public interface IWineRepository
    {
        public Task CreateWine(Wine wine);

        public Wine? RetrieveWineByWineId(string wineId);

        List<WineResponse> RetrieveWinesByLotteryId(string lotteryId);
    }
}
