using Assignment.Class;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
