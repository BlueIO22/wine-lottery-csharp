using wine_lottery_csharp.Dto;

namespace wine_lottery_csharp.Context.Dal
{
    public class Ticket
    {
        public string Id { get; set; } = string.Empty;
        public int Number { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public string LotteryId { get; set; } = string.Empty;

        public LotteryTicket ToLotteryTicket()
        {
            return new LotteryTicket
            {
                Id = Guid.Parse(Id),
                Number = Number,
                CustomerId = Guid.Parse(CustomerId)
            };
        }
    }
}
