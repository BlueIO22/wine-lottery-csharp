using Microsoft.EntityFrameworkCore;
using wine_lottery_csharp.Context.Dal;

namespace wine_lottery_csharp.Dal.Context
{
    public class LotteryDbContext : DbContext
    {
        public LotteryDbContext(DbContextOptions<LotteryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Lottery> Lottery { get; set; }
        public DbSet<Wine> Wine { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
    }
}
