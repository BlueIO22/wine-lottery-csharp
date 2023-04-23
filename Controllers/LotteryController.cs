using Microsoft.AspNetCore.Mvc;
using wine_lottery_csharp.Controllers.Interfaces;
using wine_lottery_csharp.Dto.Request;
using wine_lottery_csharp.Handlers.Interfaces;
using wine_lottery_csharp.Services.Dto;
using wine_lottery_csharp.Services.Types;

namespace wine_lottery_csharp.Controllers
{
    [ApiController]
    [Route("api/lottery")]
    public class LotteryController : ControllerBase, ILotteryController
    {
        private readonly IPaymentHandler _paymentHandler;
        private readonly ICustomerHandler _customerHandler;
        private readonly ILotteryHandler _lotteryHandler;

        public LotteryController(IPaymentHandler paymentHandler, ICustomerHandler customerHandler, ILotteryHandler lotteryHandler)
        {
            _paymentHandler = paymentHandler;
            _customerHandler = customerHandler;
            _lotteryHandler = lotteryHandler;
        }

        [HttpPost("register-account")]
        public async Task<IActionResult> RegisterAccount([FromBody] CustomerRequest customerRequest)
        {
            if (customerRequest == null) return BadRequest();

            return Ok(new
            {
                name = "hello"
            });
        }

        [HttpPost("purchase-ticket")]
        public async Task<ActionResult> PurchaseTicket([FromBody] PaymentRequest paymentRequest)
        {
            if (paymentRequest == null) return BadRequest();



            return Ok(new
            {
                name = "hello world"
            });
        }

        [HttpPost]
        public async Task<ActionResult> InsertCustomer([FromBody] CustomerRequest customerRequest)
        {
            await _customerHandler.RegisterCustomer(customerRequest);

            return Ok();
        }

        [HttpGet("get-customer")]
        public async Task<ActionResult> GetCustomer(string customerId)
        {
            var result = await _customerHandler.GetCustomer(customerId, false);

            return Ok(new
            {
                customer = result.Data
            });
        }

        [HttpPost("register-lottery")]
        public async Task<ActionResult> CreateLottery([FromBody] LotteryRequest lottery)
        {
            var result = await _lotteryHandler.RegisterLottery(lottery);

            return Ok(result);
        }
    }



}