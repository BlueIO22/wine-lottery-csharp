using Microsoft.AspNetCore.Mvc;
using wine_lottery_csharp.Controllers.Interfaces;
using wine_lottery_csharp.Dto.Request;
using wine_lottery_csharp.Handlers.Interfaces;
using wine_lottery_csharp.Helpers;
using wine_lottery_csharp.Repository.Helpers;

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
        private readonly ILotteryHelper _lotteryHelper;

        public LotteryController(IPaymentHandler paymentHandler, ICustomerHandler customerHandler, ILotteryHandler lotteryHandler, ILotteryOrchestrator lotteryOrchestrator, ILotteryHelper lotteryHelper)
        {
            _paymentHandler = paymentHandler;
            _customerHandler = customerHandler;
            _lotteryHandler = lotteryHandler;
            _lotteryOrchestrator = lotteryOrchestrator;
            _lotteryHelper = lotteryHelper;
        }

        [HttpPost("create-lottery")]
        public async Task<ActionResult> RegisterLottery([FromBody] LotteryRequest request)
        {
            var result = await _lotteryHandler.RegisterLottery(request);

            return Ok(_lotteryHelper.GetStatusString(result));
        }

        [HttpPut("run-lottery")]
        public async Task<ActionResult> RunLottery([FromBody] RunLotteryRequest request)
        {
            var result = await _lotteryOrchestrator.RunLottery(Guid.Parse(request.LotteryId));

            return Ok(new
            {
                Data = result.Data,
                Status = _lotteryHelper.GetStatusString(result.Status)
            });
        }

        [HttpGet("get-lottery")]
        public async Task<ActionResult> GetLotteryById(string lotteryId)
        {
            var result = await _lotteryHandler.GetLotteryById(Guid.Parse(lotteryId));

            return Ok(new
            {
                Data = result.Data,
                Status = _lotteryHelper.GetStatusString(result.Status)
            });
        }

        [HttpPost("reset-tickets")]
        public async Task<ActionResult> ResetLotteryTickets([FromBody] ResetLotteryTicketsRequest request)
        {
            var result = await _lotteryHandler.ResetLotteryTickets(Guid.Parse(request.LotteryId), request.NumberOfTickets);

            return Ok(_lotteryHelper.GetStatusString(result));
        }

        [HttpGet("get-lottery-by-name")]
        public async Task<ActionResult> GetLotteryByName(string name)
        {
            var result = await _lotteryHandler.GetLotteryByName(name);

            return Ok(new
            {
                Data = result.Data,
                Status = _lotteryHelper.GetStatusString(result.Status)
            });
        }
    }



}
