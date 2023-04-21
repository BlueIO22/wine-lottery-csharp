using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Services.Dto;

namespace wine_lottery_csharp.Handlers.Interfaces
{
    public class CustomerHandler : ICustomerHandler
    {
        public CustomerProfile GetCustomer(string customerId)
        {
            throw new NotImplementedException();
        }

        public CustomerProfile RegisterCustomer(CustomerRequest customerRequest)
        {
            throw new NotImplementedException();
        }
    }
}
