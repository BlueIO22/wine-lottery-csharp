using wine_lottery_csharp.Context.Dal;

namespace wine_lottery_csharp.Dto.Request
{
    public class WineRequest
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }

        public Wine ToWineDal(string lotteryId)
        {
            return new Wine
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Price = Price,
                LotteryId = lotteryId
            };
        }
    }
}
