using Microsoft.AspNetCore.Mvc;
using wine_lottery_csharp.Dto.Request;

namespace wine_lottery_csharp.Controllers
{
    public interface IPaymentController
    {
        public Task<ActionResult> PurchaseTickets([FromBody] PurchaseTicketRequest request);
    }
}