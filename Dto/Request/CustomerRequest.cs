using Stripe;
using CustomerDal = wine_lottery_csharp.Context.Dal.Customer;

namespace wine_lottery_csharp.Services.Dto
{
    public class CustomerRequest
    {
        public string Name { get; set; } = string.Empty;
        public AddressOptions? Address { get; set; }
        public string Email { get; set; } = string.Empty;

        public CustomerCreateOptions ToCustomerCreateOptions()
        {
            return new CustomerCreateOptions
            {
                Name = Name,
                Address = Address,
                Email = Email,
            };
        }

        public CustomerDal ToCustomerDal()
        {
            return new CustomerDal
            {
                Name = Name,
                StreetName = Address?.Line1 ?? Address?.Line2 ?? string.Empty,
                City = Address?.City ?? string.Empty,
                PostalCode = Address != null ? int.Parse(Address.PostalCode) : 0,
                Country = Address?.Country ?? string.Empty,
                Email = Email,
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
