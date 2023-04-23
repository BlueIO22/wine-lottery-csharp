using wine_lottery_csharp.Dto.Request;
using wine_lottery_csharp.Enums;
using wine_lottery_csharp.Handlers.Interfaces;
using wine_lottery_csharp.Repository.Interfaces;

namespace wine_lottery_csharp.Handlers
{
    public class WineHandler : IWineHandler
    {
        private readonly IWineRepository _wineRepository;

        public WineHandler(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public Task<Response<List<WineResponse>>> GetAllWinesByLotteryId(Guid lotteryId)
        {
            var wines = _wineRepository.RetrieveWinesByLotteryId(lotteryId.ToString());

            if (wines.Count == 0)
            {
                return Task.FromResult(new Response<List<WineResponse>>() { Status = ResponseStatus.NOT_FOUND });
            }

            return Task.FromResult(
                new Response<List<WineResponse>>
                {
                    Data = wines
                });
        }

        public Task RemoveWine(WineResponse wine)
        {
            _wineRepository.RemoveWine(wine.ToWine());

            return Task.CompletedTask;
        }
    }
}
