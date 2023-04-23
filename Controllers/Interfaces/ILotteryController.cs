using Microsoft.AspNetCore.Mvc;
using wine_lottery_csharp.Dto.Request;

namespace wine_lottery_csharp.Controllers.Interfaces
{
    public interface ILotteryController
    {
        public Task<ActionResult> PurchaseTicket([FromBody] PurchaseTicketRequest request);

        public Task<ActionResult> RegisterLottery([FromBody] LotteryRequest request);


    }
}
