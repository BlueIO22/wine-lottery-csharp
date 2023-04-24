using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dto;

namespace wine_lottery_csharp.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<string> CreateCustomer(Customer customer);
        public CustomerResponse? RetrieveCustomer(Guid customerId, bool includeTickets);
        public CustomerResponse? RetrieveCustomerByName(string name);
        public List<CustomerResponse> RetrieveCustomersByLotteryId(string id);
    }
}
