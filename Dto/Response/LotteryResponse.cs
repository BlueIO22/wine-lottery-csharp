using wine_lottery_csharp.Dto.Request;

namespace wine_lottery_csharp.Dto
{
    public class LotteryResponse
    {
        public string Name { get; set; } = string.Empty;
        public int NumberOfTickets { get; set; }
        public List<CustomerResponse> Customers { get; set; } = new List<CustomerResponse>();
        public List<LotteryTicket> Tickets { get; set; } = new List<LotteryTicket>();
        public List<WineResponse> Wines { get; set; } = new List<WineResponse>();
    }
}
