using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Enums;
using wine_lottery_csharp.Repository.Interfaces;
using wine_lottery_csharp.Services.Dto;

namespace wine_lottery_csharp.Handlers.Interfaces
{
    public class CustomerHandler : ICustomerHandler
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITicketRepository _ticketRepository;
        public CustomerHandler(ICustomerRepository customerRepository, ITicketRepository ticketRepository)
        {
            _customerRepository = customerRepository;
            _ticketRepository = ticketRepository;
        }

        public Task<Response<CustomerResponse>> GetCustomer(string customerId, bool includeTickets)
        {
            CustomerResponse? customer = _customerRepository.RetrieveCustomer(Guid.Parse(customerId), includeTickets);

            if (customer == null)
            {
                return Task.FromResult(new Response<CustomerResponse>
                {
                    Status = ResponseStatus.NOT_FOUND
                });
            }

            if (includeTickets)
            {
                customer.Tickets = _ticketRepository.RetrieveTicketsByCustomerId(customer.Id.ToString());
            }

            return Task.FromResult(new Response<CustomerResponse>
            {
                Data = customer
            });
        }

        public Task<Response<CustomerResponse?>> GetCustomerByName(string name)
        {
            var customer = _customerRepository.RetrieveCustomerByName(name);

            if (customer == null)
            {
                return Task.FromResult(new Response<CustomerResponse?> { Status = ResponseStatus.NOT_FOUND });
            }

            return Task.FromResult(new Response<CustomerResponse?> { Data = customer });
        }

        public async Task<Response<string>> RegisterCustomer(CustomerRequest customerRequest)
        {
            try
            {
                var customerId = await _customerRepository.CreateCustomer(customerRequest.ToCustomerDal());
                if (customerId == null)
                {
                    return await Task.FromResult(new Response<string> { Status = ResponseStatus.COULD_NOT_CREATE_CUSTOMER });
                }
                return await Task.FromResult(new Response<string> { Data = customerId });
            }
            catch (Exception)
            {
                return await Task.FromResult(new Response<string> { Status = ResponseStatus.UNKNOWN_ERROR });
            }
        }
    }
}
