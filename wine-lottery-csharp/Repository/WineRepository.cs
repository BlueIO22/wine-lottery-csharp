using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dal.Context;
using wine_lottery_csharp.Dto.Request;
using wine_lottery_csharp.Repository.Interfaces;

namespace wine_lottery_csharp.Repository
{
    public class WineRepository : IWineRepository
    {
        private readonly LotteryDbContext _context;

        public WineRepository(LotteryDbContext context)
        {
            _context = context;
        }

        public async Task CreateWine(Wine wine)
        {
            await _context.Wine.AddAsync(wine);
            await _context.SaveChangesAsync();
        }

        public Task RemoveWine(Wine wine)
        {
            _context.Wine.Remove(wine);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Wine? RetrieveWineByWineId(string wineId)
        {
            throw new NotImplementedException();
        }

        public List<WineResponse> RetrieveWinesByLotteryId(string lotteryId)
        {
            return _context.Wine.Where(wine => wine.LotteryId == lotteryId).Select(wine => wine.ToWineResponse()).ToList();
        }
    }
}
