using Microsoft.AspNetCore.Mvc;

namespace wine_lottery_csharp.Controllers.Interfaces
{
    public interface ICustomerController
    {
        public Task<ActionResult> GetCustomerById(string customerId, bool includeTickets);
    }
}
