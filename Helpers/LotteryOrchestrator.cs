using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Dto.Request;
using wine_lottery_csharp.Enums;
using wine_lottery_csharp.Handlers;
using wine_lottery_csharp.Handlers.Interfaces;

namespace wine_lottery_csharp.Helpers
{
    public class LotteryOrchestrator : ILotteryOrchestrator
    {
        private readonly ILotteryHandler _lotteryHandler;
        private readonly ICustomerHandler _customerHandler;
        private readonly IWineHandler _wineHandler;
        private readonly ITicketHandler _ticketHandler;

        public LotteryOrchestrator(ILotteryHandler lotteryHandler, ICustomerHandler customerHandler, IWineHandler wineHandler, ITicketHandler ticketHandler)
        {
            _lotteryHandler = lotteryHandler;
            _customerHandler = customerHandler;
            _wineHandler = wineHandler;
            _ticketHandler = ticketHandler;

        }
        public async Task<Response<List<LotteryResult>>> RunLottery(Guid lotteryId)
        {
            List<LotteryResult> lotteryResults = new List<LotteryResult>();

            var wines = await GetWinesByLotteryId(lotteryId);

            var sortedWines = wines.OrderBy(x => x.Price);

            var lottery = await GetLotteryById(lotteryId);

            if (lottery.GetLotteryStatus() == LotteryStatus.FINISHED)
            {
                return new Response<List<LotteryResult>> { Status = ResponseStatus.LOTTERY_IS_FINISHED };
            }

            foreach (WineResponse wine in wines)
            {
                var lotteryResult = await RunLotteryIteration(lottery, wine);

                await RemoveTicket(lotteryResult.Data.WinnerTicket);

                lotteryResults.Add(lotteryResult.Data);
            }

            await MarkLotteryAsFinished(lotteryId);

            return new Response<List<LotteryResult>> { Data = lotteryResults };
        }

        private Task MarkLotteryAsFinished(Guid lotteryId)
        {
            return _lotteryHandler.MarkLotteryAsFinished(lotteryId);
        }

        private Task RemoveTicket(LotteryTicket winnerTicket)
        {
            _ticketHandler.RemoveLotteryTicket(winnerTicket.Id);

            return Task.CompletedTask;
        }

        private Task RemoveWine(WineResponse wine)
        {
            _wineHandler.RemoveWine(wine);

            return Task.CompletedTask;
        }

        private async Task<Response<LotteryResult>> RunLotteryIteration(Lottery lottery, WineResponse wine)
        {
            LotteryResult result = new LotteryResult();

            var lotteryId = Guid.Parse(lottery.Id);

            var tickets = await GetTicketsByLotteryId(lotteryId);

            var winnerTicket = GetWinnerTicket(tickets, lottery.NumberOfTickets);

            var winnerCustomer = await GetWinnerCustomer(winnerTicket);

            while (winnerCustomer.Name == Constants.UNKNOWN_WINNER)
            {
                winnerTicket = GetWinnerTicket(tickets, lottery.NumberOfTickets);
            }

            result.WinnerTicket = winnerTicket;

            if (winnerCustomer.Name == Constants.UNKNOWN_WINNER)
            {
                return await Task.FromResult(new Response<LotteryResult>
                {
                    Status = ResponseStatus.TICKET_IS_WITHOUT_WINNER
                });
            }

            var lotteryResult = new LotteryResult
            {
                LotteryId = lotteryId,
                LotteryName = lottery.Name,
                Wine = wine,
                WinnerProfile = winnerCustomer,
                WinnerTicket = winnerTicket,
            };

            return new Response<LotteryResult>
            {
                Data = lotteryResult
            };
        }

        private async Task<CustomerResponse> GetWinnerCustomer(LotteryTicket winnerTicket)
        {
            if (winnerTicket.CustomerId == Guid.Empty)
            {
                return await Task.FromResult(new CustomerResponse
                {
                    Name = Constants.UNKNOWN_WINNER
                });
            }

            var customerResponse = await _customerHandler.GetCustomer(winnerTicket.CustomerId.ToString(), false);

            if (customerResponse == null || customerResponse.Status == ResponseStatus.NOT_FOUND)
            {
                throw new Exception($"Winner customer not found {winnerTicket.CustomerId}");
            }

            return await Task.FromResult(customerResponse.Data);
        }

        private LotteryTicket GetWinnerTicket(List<LotteryTicket> tickets, int numberOfTickets)
        {
            var numbers = tickets.Select(ticket => ticket.Number);

            Random random = new Random();

            int selectedNumber = random.Next(numberOfTickets);

            var ticket = tickets.FirstOrDefault(ticket => ticket.Number == selectedNumber);

            while (ticket == null)
            {
                selectedNumber = random.Next(numberOfTickets);
                ticket = tickets.FirstOrDefault(ticket => ticket.Number == selectedNumber);
            }

            return ticket;
        }

        private async Task<List<LotteryTicket>> GetTicketsByLotteryId(Guid lotteryId)
        {
            var tickets = await _ticketHandler.GetLotteryTicketsByLotteryId(lotteryId);

            if (tickets.Status == ResponseStatus.NOT_FOUND)
            {
                throw new Exception("No tickets found");
            }

            return tickets.Data;
        }

        private async Task<Lottery> GetLotteryById(Guid lotteryId)
        {
            var lottery = await _lotteryHandler.GetLotteryById(lotteryId);

            if (lottery == null || lottery.Data == null)
            {
                throw new Exception("No lottery found");
            }

            return lottery.Data;
        }

        private async Task<List<WineResponse>> GetWinesByLotteryId(Guid lotteryId)
        {
            var wineResult = await _wineHandler.GetAllWinesByLotteryId(lotteryId);

            if (wineResult.Status == ResponseStatus.NOT_FOUND)
            {
                throw new Exception("Found no wines, cannot run lottery without wines!");
            }

            return wineResult.Data;
        }
    }
}
