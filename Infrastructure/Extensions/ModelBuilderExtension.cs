using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData
            (
                new Product()
                {
                    Id = 1,
                    Name = "Product One"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Product Two"
                },
                new Product()
                {
                    Id = 3,
                    Name = "Product Three"
                }
            );
        }
    }
}
