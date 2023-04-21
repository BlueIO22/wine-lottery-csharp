namespace wine_lottery_csharp.Dto
{
    [Serializable]
    public class LotteryTicket
    {
        public Guid Id { get; set; }   
        public int Number { get; set; }
        public string CustomerId { get; set; } = string.Empty;

        public bool IsFree ()
        {
            return CustomerId == string.Empty;
        }
    }
}
