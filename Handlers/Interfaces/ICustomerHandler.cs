using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Enums;
using wine_lottery_csharp.Services.Dto;

namespace wine_lottery_csharp.Handlers.Interfaces
{
    public interface ICustomerHandler
    {
        Task<ResponseStatus> RegisterCustomer(CustomerRequest customerRequest);

        Task<Response<CustomerResponse>> GetCustomer(string customerId, bool includeTickets);
    }
}