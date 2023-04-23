using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dal.Context;

namespace wine_lottery_csharp.Repository.Interfaces
{
    public class LotteryRepository : ILotteryRepository
    {
        private readonly LotteryDbContext _lotteryDbContext;

        public LotteryRepository(LotteryDbContext lotteryDbContext)
        {
            _lotteryDbContext = lotteryDbContext;
        }

        public async Task CreateLottery(Lottery lottery)
        {
            await _lotteryDbContext.AddAsync(lottery);
            await _lotteryDbContext.SaveChangesAsync();
        }

        public Lottery? RetrieveLotteryByName(string name)
        {
            return _lotteryDbContext.Lottery.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
