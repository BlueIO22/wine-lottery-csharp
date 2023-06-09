﻿using wine_lottery_csharp.Dto.Request;

namespace wine_lottery_csharp.Context.Dal
{
    public class Wine
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string LotteryId { get; set; } = string.Empty;

        public WineResponse ToWineResponse()
        {
            return new WineResponse
            {
                Id = Guid.Parse(Id),
                Name = Name,
                Price = (double)Price,
                LotteryId = Guid.Parse(LotteryId)
            };
        }
    }
}
