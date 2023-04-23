using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dal.Context;

namespace wine_lottery_csharp.Repository.Interfaces
{
    public class LotteryRepository : ILotteryRepository
    {
        private readonly LotteryDbContext _lotteryDbContext;
        private readonly ITicketRepository _ticketRepository;

        public LotteryRepository(LotteryDbContext lotteryDbContext, ITicketRepository ticketRepository)
        {
            _lotteryDbContext = lotteryDbContext;
            _ticketRepository = ticketRepository;
        }

        public async Task CreateLottery(Lottery lottery)
        {
            await _lotteryDbContext.AddAsync(lottery);
            await _lotteryDbContext.SaveChangesAsync();
        }

        public Lottery? RetrieveLotteryById(string lotteryId)
        {
            return _lotteryDbContext.Lottery.Where(lottery => lottery.Id == lotteryId).FirstOrDefault();
        }

        public Lottery? RetrieveLotteryByName(string name)
        {
            return _lotteryDbContext.Lottery.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
