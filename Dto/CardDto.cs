namespace wine_lottery_csharp.Dto
{
    public class CardDto
    {
        public string CardNumber { get; set; } = string.Empty;
        public string Cvc { get; set; } = string.Empty;
        public string ExpireYear { get; set; } = string.Empty;
        public string ExpireMonth { get; set; } = string.Empty;
    }
}
