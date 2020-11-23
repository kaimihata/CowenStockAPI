using Microsoft.EntityFrameworkCore;

namespace CowenAPI.Models
{
    public class CowenAPIContext : DbContext
    {
        public CowenAPIContext(DbContextOptions<CowenAPIContext> options)
            : base(options)
        {
        }

        public DbSet<StockTicker> StockTicker { get; set; }
    }
}