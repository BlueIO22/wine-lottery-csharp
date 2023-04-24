using System.ComponentModel;

namespace wine_lottery_csharp.Enums
{
    public enum LotteryStatus
    {
        [Description("Lottery not started")]
        NOT_STARTED = 0,
        [Description("Lottery is finished")]
        FINISHED = 1
    }
}
