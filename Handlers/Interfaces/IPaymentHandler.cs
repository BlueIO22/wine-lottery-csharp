using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Services.Types;

namespace wine_lottery_csharp.Handlers.Interfaces
{
    public interface IPaymentHandler
    {
        Task<LotteryTicket> PurchaseLotteryTicket(PaymentRequest payment);
    }
}
