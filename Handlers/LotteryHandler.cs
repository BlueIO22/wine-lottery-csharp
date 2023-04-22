using wine_lottery_csharp.Context.Dal;
using wine_lottery_csharp.Dto;
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

        public Task<Response<LotteryDto>> GetLotteryByName(string lotteryName)
        {
            var lottery = _lotteryRepository.RetrieveLotteryByName(lotteryName);

            if (lottery == null) return Task.FromResult(new Response<LotteryDto>
            {
                Status = ResponseStatus.NOT_FOUND
            });

            LotteryDto lotteryDto = new LotteryDto
            {
                Name = lottery.Name,
                NumberOfTickets = lottery.NumberOfTickets,
            };

            // retrieve Wine
            lotteryDto.Wine = _wineRepository.RetrieveWineByWineId(lottery.Id) ?? new Wine();

            // retrieve customers

            // retrieve tickets


            return Task.FromResult(new Response<LotteryDto> { Data = lotteryDto });
        }

        public ResponseStatus RegisterLottery(LotteryDto lottery)
        {
            try
            {
                lottery.Wine.Id = Guid.NewGuid();
                _wineRepository.CreateWine(lottery.Wine);
                _ticketRepository.CreateTicketsByNumber(lottery.NumberOfTickets);
                _lotteryRepository.CreateLottery(lottery.ToLottery());
            }
            catch (Exception)
            {
                return ResponseStatus.UNKNOWN_ERROR;
            }
            return ResponseStatus.OK;
        }

        public Task<Response<LotteryResultDto>> RunLottery(string lotteryName)
        {
            throw new NotImplementedException();
        }
    }
}
