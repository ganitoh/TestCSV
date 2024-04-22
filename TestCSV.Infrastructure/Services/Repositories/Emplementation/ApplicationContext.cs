using Microsoft.EntityFrameworkCore;
using TestCSV.Domain.Models;
using TestCSV.Infrastructure.EntityConfiguration;

namespace TestCSV.Infrastructure.Services.Repositories.Emplementation
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PriceItem> PriceItem { get; set; }

        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PriceItemConfiguration());
        }
    }
}
