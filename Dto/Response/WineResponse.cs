namespace wine_lottery_csharp.Dto.Request
{
    public class WineResponse
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public Guid LotteryId { get; set; } = Guid.Empty;

    }
}
