namespace wine_lottery_csharp.Context.Dal
{
    public class Lottery
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfTickets { get; set; }
        public Guid WineId { get; set; } = Guid.Empty;
    }
}
