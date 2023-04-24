using wine_lottery_csharp.Context.Dal;

namespace wine_lottery_csharp.Dto
{
    [Serializable]
    public class LotteryTicket
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Guid CustomerId { get; set; } = Guid.Empty;

        public bool IsFree()
        {
            return CustomerId == Guid.Empty;
        }

        public Ticket ToTicketDal()
        {
            return new Ticket
            {
                Id = Id.ToString(),
                CustomerId = CustomerId.ToString(),
                Number = Number
            };
        }
    }
}
