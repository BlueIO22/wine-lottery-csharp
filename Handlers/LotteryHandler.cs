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

        public async Task<ResponseStatus> RegisterLottery(LotteryRequest lotteryDto)
        {
            try
            {
                var lotteryId = Guid.NewGuid().ToString();

                var lottery = lotteryDto.ToLottery();
                lottery.Id = lotteryId;
                await CreateWine(lotteryDto, lotteryId);
                await _lotteryRepository.CreateLottery(lottery);
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

        public Task<Response<LotteryResult>> RunLottery(string lotteryName)
        {
            throw new NotImplementedException();
        }
    }
}
