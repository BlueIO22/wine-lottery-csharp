using wine_lottery_csharp.Context.Dal;

namespace wine_lottery_csharp.Dto.Request
{
    public class WineResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public Guid LotteryId { get; set; } = Guid.Empty;

        public Wine ToWine()
        {
            return new Wine() { Id = Id.ToString(), Name = Name, Price = (decimal)Price };
        }
    }
}
