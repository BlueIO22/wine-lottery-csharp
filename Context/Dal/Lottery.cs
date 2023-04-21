namespace wine_lottery_csharp.Context.Dal
{
    public class Lottery
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public Guid customerId { get; set; } = Guid.Empty;
        public Guid ticketId { get; set; } = Guid.Empty;
        public Guid wineId { get; set; } = Guid.Empty;
    }
}
