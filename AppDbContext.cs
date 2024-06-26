using Microsoft.EntityFrameworkCore;

namespace ItemConsoleApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the SQL Server connection string
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ItemDb;Trusted_Connection=True;");
        }
    }
}
