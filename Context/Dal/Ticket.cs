namespace wine_lottery_csharp.Context.Dal
{
    public class Ticket
    {
        public Guid Id { get; set; } = Guid.Empty;
        public int Number { get; set; }
        public Guid CustomerId { get; set; } = Guid.Empty;
    }
}
