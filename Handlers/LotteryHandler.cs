using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dto;
using wine_lottery_csharp.Dto.Request;
using wine_lottery_csharp.Enums;
using wine_lottery_csharp.Handlers.Interfaces;
using wine_lottery_csharp.Repository.Interfaces;

namespace wine_lottery_csharp.Handlers
{
    public class LotteryHandler : ILotteryHandler
    {
        private ILotteryRepository _lotteryRepository;
        private ITicketRepository _ticketRepository;
        private ICustomerRepository _customerRepository;
        private IWineRepository _wineRepository;

        public LotteryHandler(ILotteryRepository lotteryRepository, ITicketRepository ticketRepository, ICustomerRepository customerRepository, IWineRepository wineRepository)
        {
            _lotteryRepository = lotteryRepository;
            _ticketRepository = ticketRepository;
            _customerRepository = customerRepository;
            _wineRepository = wineRepository;
        }

        public Task<Response<LotteryResponse>> GetLotteryByName(string lotteryName)
        {
            var lottery = _lotteryRepository.RetrieveLotteryByName(lotteryName);

            if (lottery == null) return Task.FromResult(new Response<LotteryResponse>
            {
                Status = ResponseStatus.NOT_FOUND
            });

            LotteryResponse lotteryDto = new LotteryResponse
            {
                Name = lottery.Name,
                NumberOfTickets = lottery.NumberOfTickets,
            };

            // retrieve Wine
            lotteryDto.Wines = _wineRepository.RetrieveWinesByLotteryId(lottery.Id);

            // retrieve customers

            // retrieve tickets


            return Task.FromResult(new Response<LotteryResponse> { Data = lotteryDto });
        }

        public async Task<ResponseStatus> ResetLotteryTickets(Guid lotteryId, int numberOfTickets)
        {
            try
            {
                await _ticketRepository.ResetLotteryTickets(lotteryId.ToString(), numberOfTickets);
                return ResponseStatus.OK;
            }
            catch (Exception)
            {
                return ResponseStatus.UNKNOWN_ERROR;
            }
        }

        public async Task<ResponseStatus> RegisterLottery(LotteryRequest lotteryDto)
        {
            try
            {
                var lotteryId = Guid.NewGuid().ToString();

                var lottery = lotteryDto.ToLottery();
                lottery.Id = lotteryId;
                await _lotteryRepository.CreateLottery(lottery);
                await CreateWine(lotteryDto, lotteryId);
                await _ticketRepository.CreateTicketsByNumberOfTickets(lottery.NumberOfTickets, lottery.Id);
            }
            catch (Exception)
            {
                return ResponseStatus.UNKNOWN_ERROR;
            }
            return ResponseStatus.OK;
        }

        private async Task CreateWine(LotteryRequest lotteryDto, string lotteryId)
        {
            foreach (WineRequest wine in lotteryDto.Wines)
            {
                await _wineRepository.CreateWine(wine.ToWineDal(lotteryId));
            }
        }

        public async Task<Response<List<LotteryTicket>>> MarkLotteryTickets(string customerId, int numberOfTickets, string lotteryId)
        {
            var lotteryTickets = _ticketRepository.MarkLotteryTickets(customerId, numberOfTickets, lotteryId);

            if (lotteryTickets.Count != numberOfTickets)
            {
                return await Task.FromResult(new Response<List<LotteryTicket>>() { Status = ResponseStatus.NUMBER_OF_TICKETS_MISMATCH });
            }

            return await Task.FromResult(new Response<List<LotteryTicket>>() { Data = lotteryTickets });
        }

        public Task<bool> CheckIfLotteryHasAvailableTickets(int numberOfTickets, Guid lotteryId)
        {
            var tickets = _ticketRepository.FindUnMarkedTicketsByLotteryId(lotteryId.ToString());
            if (tickets == null)
            {
                return Task.FromResult(false);
            }

            if (tickets.Count < numberOfTickets)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<Response<Lottery?>> GetLotteryById(Guid lotteryId)
        {
            var lottery = _lotteryRepository.RetrieveLotteryById(lotteryId.ToString());

            if (lottery == null)
            {
                return Task.FromResult(new Response<Lottery?> { Status = ResponseStatus.NOT_FOUND });
            }

            return Task.FromResult(new Response<Lottery?> { Data = lottery });
        }
    }
}
