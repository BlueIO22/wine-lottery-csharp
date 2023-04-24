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

            var customerId = Guid.Empty;

            if (Guid.TryParse(CustomerId, out var parsedCusomterId))
            {
                customerId = parsedCusomterId;
            }

            return new LotteryTicket
            {
                Id = Guid.Parse(Id),
                Number = Number,
                CustomerId = customerId
            };
        }
    }
}
