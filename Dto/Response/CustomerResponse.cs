﻿namespace wine_lottery_csharp.Dto
{
    [Serializable]
    public class CustomerResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Address Address { get; set; } = new Address();
        public List<LotteryTicket> Tickets { get; set; } = new List<LotteryTicket>();

    }

    [Serializable]
    public class Address
    {
        public string StreetName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int PostalCode { get; set; }
        public string Country { get; set; } = string.Empty;
    }
}
