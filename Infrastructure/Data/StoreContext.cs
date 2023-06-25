using Core.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Metrics;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public StoreContext(
            DbContextOptions options,
            IConfiguration configuration
        ) : base(options) 
        {
            _configuration = configuration;
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_configuration == null)
            {
                return;
            }

            string connString = _configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);

            modelBuilder.SeedData();
        }
    }
}
