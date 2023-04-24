namespace wine_lottery_csharp.Dto.Request
{
    public class ResetLotteryTicketsRequest
    {
        public string LotteryId { get; set; } = string.Empty;

        public int NumberOfTickets { get; set; }
    }
}
