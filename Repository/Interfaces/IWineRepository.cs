using wine_lottery_csharp.Context.Dal;

namespace wine_lottery_csharp.Repository.Interfaces
{
    public interface IWineRepository
    {
        public Task CreateWine(Wine wine);

        public Wine? RetrieveWineByWineId(Guid wineId);
    }
}
