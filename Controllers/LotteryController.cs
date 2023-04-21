using Microsoft.AspNetCore.Mvc;
using Stripe;
using wine_lottery_csharp.Handlers.Interfaces;
using wine_lottery_csharp.services.interfaces;
using wine_lottery_csharp.Services.Dto;
using wine_lottery_csharp.Services.Types;

namespace wine_lottery_csharp.Controllers
{
    [ApiController]
    [Route("api/lottery")]
    public class LotteryController : ControllerBase
    {
        private readonly IPaymentHandler _paymentHandler;

        public LotteryController(IPaymentHandler paymentHandler)
        {
            _paymentHandler = paymentHandler;
        }

        [HttpPost("register-account")]
        public async Task<IActionResult> RegisterAccount([FromBody]CustomerRequest customerRequest)
        {
            if (customerRequest == null) return BadRequest();

            return Ok(new
            {
                name = "hello"
            });
        }

        [HttpPost("purchase-ticket")]
        public async Task<ActionResult> PurchaseTicket([FromBody]PaymentRequest paymentRequest)
        {
            if (paymentRequest == null) return BadRequest();

            

            return Ok(new
            {
               name =  "hello world"
            });
        }
    }

    

}