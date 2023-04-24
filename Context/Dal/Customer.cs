using wine_lottery_csharp.Dto;

namespace wine_lottery_csharp.Context.Dal
{
    public class Customer
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int PostalCode { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public CustomerResponse ToCustomerProfile()
        {
            return new CustomerResponse
            {
                Id = Guid.Parse(Id),
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
