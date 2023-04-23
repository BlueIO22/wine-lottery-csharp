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
        public async Task<string> CreateCustomer(Customer customer)
        {
            var generatedCustomer = await _lotteryDbContext.Customer.AddAsync(customer);
            await _lotteryDbContext.SaveChangesAsync();
            return generatedCustomer.Entity.Id;
        }

        public CustomerResponse? RetrieveCustomer(Guid customerId, bool includeTickets)
        {
            return _lotteryDbContext.Customer.Where(customer => customer.Id == customerId.ToString()).Select(customer => customer.ToCustomerProfile()).SingleOrDefault();
        }

        public CustomerResponse? RetrieveCustomerByName(string name)
        {
            return _lotteryDbContext.Customer.Where(customer => customer.Name == name).Select(customer => customer.ToCustomerProfile()).SingleOrDefault();
        }
    }
}
