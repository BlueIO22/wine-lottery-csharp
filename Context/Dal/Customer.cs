using wine_lottery_csharp.Dto;

namespace wine_lottery_csharp.Context.Dal
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int PostalCode { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public CustomerProfile ToCustomerProfile()
        {
            return new CustomerProfile
            {
                Id = Id,
                Email = Email,
                Name = Name,
                Address = new Address
                {
                    StreetName = StreetName,
                    City = City,
                    Country = Country,
                    PostalCode = PostalCode
                }
            };
        }
    }
}
