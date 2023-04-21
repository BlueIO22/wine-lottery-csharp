using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Services.Dto;

namespace wine_lottery_csharp.Handlers.Interfaces
{
    public interface ICustomerHandler
    {
        CustomerProfile RegisterCustomer(CustomerRequest customerRequest);

        CustomerProfile GetCustomer(string customerId);
    }
}
