﻿using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Dto.Request;

namespace wine_lottery_csharp.Handlers.Interfaces
{
    public interface IPaymentHandler
    {
        Task<List<LotteryTicket>> PurchaseLotteryTickets(PurchaseTicketRequest payment);
    }
}
