using wine_lottery_csharp.Context.Dal;

namespace wine_lottery_csharp.Dto.Request
{
    public class LotteryRequest
    {
        public string Name { get; set; } = string.Empty;
        public int NumberOfTickets { get; set; }
        public List<WineRequest> Wines { get; set; } = new List<WineRequest>();

        public Lottery ToLottery()
        {
            return new Lottery
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                NumberOfTickets = NumberOfTickets
            };
        }
    }
}
