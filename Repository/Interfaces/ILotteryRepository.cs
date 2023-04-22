using wine_lottery_csharp.Context.Dal;

namespace wine_lottery_csharp.Repository.Interfaces
{
    public interface ILotteryRepository
    {
        public Task CreateLottery(Lottery lottery);

        public Lottery? RetrieveLotteryByName(string name);
    }
}
