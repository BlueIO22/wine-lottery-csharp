using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Enums;
using wine_lottery_csharp.Services.Dto;

namespace wine_lottery_csharp.Handlers.Interfaces
{
    public interface ICustomerHandler
    {
        ResponseStatus RegisterCustomer(CustomerRequest customerRequest);

        Task<Response<CustomerProfile>> GetCustomer(string customerId, bool includeTickets);
    }
}