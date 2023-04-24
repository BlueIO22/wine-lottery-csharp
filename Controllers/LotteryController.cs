using Microsoft.AspNetCore.Mvc;
using wine_lottery_csharp.Controllers.Interfaces;
using wine_lottery_csharp.Dto.Request;
using wine_lottery_csharp.Handlers.Interfaces;
using wine_lottery_csharp.Helpers;

namespace wine_lottery_csharp.Controllers
{
    [ApiController]
    [Route("api/lottery")]
    public class LotteryController : ControllerBase, ILotteryController
    {
        private readonly IPaymentHandler _paymentHandler;
        private readonly ICustomerHandler _customerHandler;
        private readonly ILotteryHandler _lotteryHandler;
        private readonly ILotteryOrchestrator _lotteryOrchestrator;

        public LotteryController(IPaymentHandler paymentHandler, ICustomerHandler customerHandler, ILotteryHandler lotteryHandler, ILotteryOrchestrator lotteryOrchestrator)
        {
            _paymentHandler = paymentHandler;
            _customerHandler = customerHandler;
            _lotteryHandler = lotteryHandler;
            _lotteryOrchestrator = lotteryOrchestrator;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterLottery([FromBody] LotteryRequest request)
        {
            var result = await _lotteryHandler.RegisterLottery(request);

            return Ok(result);
        }

        [HttpPut("purchase-tickets")]
        public async Task<ActionResult> PurchaseTickets([FromBody] PurchaseTicketRequest request)
        {
            var result = await _paymentHandler.PurchaseLotteryTickets(request);

            return Ok(result);
        }

        [HttpGet("retrieve-customer")]
        public async Task<ActionResult> GetCustomerById(string customerId, bool includeTickets)
        {
            var result = await _customerHandler.GetCustomer(customerId, includeTickets);

            return Ok(result);
        }

        [HttpPut("run-lottery")]
        public async Task<ActionResult> RunLottery([FromBody] RunLotteryRequest request)
        {
            var result = await _lotteryOrchestrator.RunLottery(Guid.Parse(request.LotteryId));

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetLotteryById(string lotteryId)
        {
            var result = await _lotteryHandler.GetLotteryById(Guid.Parse(lotteryId));

            return Ok(result);
        }

        [HttpPost("reset-tickets")]
        public async Task<ActionResult> ResetLotteryTickets([FromBody] ResetLotteryTicketsRequest request)
        {
            var result = await _lotteryHandler.ResetLotteryTickets(Guid.Parse(request.LotteryId), request.NumberOfTickets);

            return Ok(result);
        }
        
        [HttpGet("get-feedback")]
        public string GetFeedback(string lmao) 
        {
            return "hello" + lmao; 
        }
    }



}
