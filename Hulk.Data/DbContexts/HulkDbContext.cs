using Hulk.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hulk.Data.DbContexts
{
    public class HulkDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Pair> Pairs { get; set; }
        public DbSet<TradeLog> TradeLogs { get; set; }
    }
}
