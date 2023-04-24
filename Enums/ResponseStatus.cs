using System.ComponentModel;

namespace wine_lottery_csharp.Enums
{
    public enum ResponseStatus
    {
        [Description("Success")]
        OK,
        [Description("Not found")]
        NOT_FOUND,
        [Description("Unknown error")]
        UNKNOWN_ERROR,
        [Description("There was a mismatch between number of tickets bought and number of tickets received")]
        NUMBER_OF_TICKETS_MISMATCH,
        [Description("Could not create customer")]
        COULD_NOT_CREATE_CUSTOMER,
        [Description("Ticket selected is without winner")]
        TICKET_IS_WITHOUT_WINNER,
        [Description("There is sadly not enough tickets left to do your purchase")]
        NOT_ENOUGH_TICKETS,
        [Description("Payment was not successful")]
        PAYMENT_NOT_SUCCESSFUL,
        [Description("Lottery is finished, and cannot be run again")]
        LOTTERY_IS_FINISHED
    }
}
