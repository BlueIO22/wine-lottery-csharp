using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dto;

namespace wine_lottery_csharp.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        public Task CreateCustomer(Customer customer);

        public CustomerProfile? RetrieveCustomer(Guid customerId, bool includeTickets);
    }
}
