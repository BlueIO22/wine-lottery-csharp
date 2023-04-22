namespace wine_lottery_csharp.Context.Dal
{
    public class Wine
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = String.Empty;
        public double Price { get; set; }
    }
}
