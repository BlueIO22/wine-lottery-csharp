using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dal.Context;
using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Repository.Interfaces;

namespace wine_lottery_csharp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LotteryDbContext _lotteryDbContext;
        public CustomerRepository(LotteryDbContext lotteryContext)
        {
            _lotteryDbContext = lotteryContext;
        }
        public async Task CreateCustomer(Customer customer)
        {
            await _lotteryDbContext.Customer.AddAsync(customer);
        }

        public CustomerProfile? RetrieveCustomer(Guid customerId, bool includeTickets)
        {
            return _lotteryDbContext.Customer.Where(customer => customer.Id == customerId).Select(customer => customer.ToCustomerProfile()).SingleOrDefault();
        }
    }
}
