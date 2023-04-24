using Microsoft.AspNetCore.Mvc;
using wine_lottery_csharp.Dto.Request;
using wine_lottery_csharp.Handlers.Interfaces;
using wine_lottery_csharp.Repository.Helpers;

namespace wine_lottery_csharp.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase, IPaymentController
    {
        private readonly IPaymentHandler _paymentHandler;
        private readonly ILotteryHelper _lotteryHelper;

        public PaymentController(IPaymentHandler paymentHandler, ILotteryHelper lotteryHelper)
        {
            _paymentHandler = paymentHandler;
            _lotteryHelper = lotteryHelper;
        }

        [HttpPut("purchase-tickets")]
        public async Task<ActionResult> PurchaseTickets([FromBody] PurchaseTicketRequest request)
        {
            var result = await _paymentHandler.PurchaseLotteryTickets(request);

            return Ok(new
            {
                Data = result.Data,
                Status = _lotteryHelper.GetStatusString(result.Status)
            });
        }
    }
}
