namespace wine_lottery_csharp.Context.Dal
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string City { get; set; }  = string.Empty;
        public int PostalCode { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
