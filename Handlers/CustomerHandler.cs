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

        public Task<Response<CustomerProfile>> GetCustomer(string customerId, bool includeTickets)
        {
            CustomerProfile? customer = _customerRepository.RetrieveCustomer(Guid.Parse(customerId), includeTickets);

            if (customer == null)
            {
                return Task.FromResult(new Response<CustomerProfile>
                {
                    Status = ResponseStatus.NOT_FOUND
                });
            }

            if (includeTickets)
            {
                customer.Tickets = _ticketRepository.RetrieveTicketsByCustomerId(customer.Id);
            }

            return Task.FromResult(new Response<CustomerProfile>
            {
                Data = customer
            });
        }

        public ResponseStatus RegisterCustomer(CustomerRequest customerRequest)
        {
            try
            {
                _customerRepository.CreateCustomer(customerRequest.ToCustomerDal());
                return ResponseStatus.OK;
            }
            catch (Exception ex)
            {
                return ResponseStatus.UNKNOWN_ERROR;
            }
        }
    }
}
