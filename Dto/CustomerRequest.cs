using Stripe;

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
    }
}
