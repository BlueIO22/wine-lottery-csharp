using Microsoft.AspNetCore.Mvc;
using wine_lottery_csharp.Controllers.Interfaces;
using wine_lottery_csharp.Handlers.Interfaces;
using wine_lottery_csharp.Repository.Helpers;

namespace wine_lottery_csharp.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase, ICustomerController
    {
        private readonly ICustomerHandler _customerHandler;
        private readonly ILotteryHelper _lotteryHelper;

        public CustomerController(ICustomerHandler customerHandler, ILotteryHelper lotteryHelper)
        {
            _customerHandler = customerHandler;
            _lotteryHelper = lotteryHelper;
        }

        [HttpGet("retrieve-customer")]
        public async Task<ActionResult> GetCustomerById(string customerId, bool includeTickets)
        {
            var result = await _customerHandler.GetCustomer(customerId, includeTickets);

            return Ok(new
            {
                Data = result.Data,
                Status = _lotteryHelper.GetStatusString(result.Status)
            });
        }
    }



}
