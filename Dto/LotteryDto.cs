using wine_lottery_csharp.Context.Dal;

namespace wine_lottery_csharp.Dto
{
    public class LotteryDto
    {
        public string Name { get; set; } = string.Empty;
        public int NumberOfTickets { get; set; }
        public List<CustomerProfile> Customers { get; set; } = new List<CustomerProfile>();
        public List<LotteryTicket> Tickets { get; set; } = new List<LotteryTicket>();
        public Wine Wine { get; set; }

        public Lottery ToLottery()
        {
            return new Lottery
            {
                Id = Guid.NewGuid(),
                Name = Name,
                NumberOfTickets = NumberOfTickets,
                WineId = Wine.Id
            };
        }
    }
}
