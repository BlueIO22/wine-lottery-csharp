using wine_lottery_csharp.Dto;

namespace wine_lottery_csharp.Context.Dal
{
    public class Ticket
    {
        public Guid Id { get; set; } = Guid.Empty;
        public int Number { get; set; }
        public Guid CustomerId { get; set; } = Guid.Empty;
        public Guid LotteryId { get; set; } = Guid.Empty;

        public LotteryTicket ToLotteryTicket()
        {
            return new LotteryTicket
            {
                Id = Id,
                Number = Number,
                CustomerId = CustomerId
            };
        }
    }
}
