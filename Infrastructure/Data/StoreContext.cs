using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

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
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

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
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
