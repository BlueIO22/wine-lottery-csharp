using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dal.Context;
using wine_lottery_csharp.Enums;

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

        public Task MarkLotteryAsFinished(string lotteryId)
        {
            var lottery = _lotteryDbContext.Lottery.Where(lottery => lottery.Id == lotteryId).SingleOrDefault();
            if (lottery == null)
            {
                return Task.CompletedTask;
            }

            lottery.LotteryStatus = (byte)LotteryStatus.FINISHED;

            _lotteryDbContext.Update(lottery);
            _lotteryDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Lottery? RetrieveLotteryById(string lotteryId)
        {
            return _lotteryDbContext.Lottery.Where(lottery => lottery.Id == lotteryId).FirstOrDefault();
        }

        public Lottery? RetrieveLotteryByName(string name)
        {
            return _lotteryDbContext.Lottery.Where(x => x.Name.ToLower().StartsWith(name.ToLower())).FirstOrDefault();
        }
    }
}
