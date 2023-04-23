using Microsoft.AspNetCore.Mvc;
using wine_lottery_csharp.Dto.Request;

namespace wine_lottery_csharp.Controllers.Interfaces
{
    public interface ILotteryController
    {
        public Task<ActionResult> PurchaseTickets([FromBody] PurchaseTicketRequest request);

        public Task<ActionResult> GetCustomerById(string customerId, bool includeTickets);

        public Task<ActionResult> RegisterLottery([FromBody] LotteryRequest request);

        public Task<ActionResult> RunLottery([FromBody] RunLotteryRequest request);

        public Task<ActionResult> GetLotteryById(string lotteryId);

        public Task<ActionResult> ResetLotteryTickets([FromBody] ResetLotteryTicketsRequest request);

    }
}
