using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure.Data
{
    public static class StoreContextSeed
    {
        public static async Task SaveDataAsync<T>(string path, StoreContext context) where T: BaseEntity
        {
            var jsonData = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<List<T>>(jsonData);

            foreach (var item in data)
                context.Set<T>().Add(item);

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }

        public static async Task SeedAsync(StoreContext context, ILogger logger)
        {
            try
            {
                if (!await context.ProductBrands.AnyAsync())
                {
                    await SaveDataAsync<ProductBrand>("../Infrastructure/Data/SeedData/brands.json", context);
                }

                if (!await context.ProductTypes.AnyAsync())
                {
                    await SaveDataAsync<ProductType>("../Infrastructure/Data/SeedData/types.json", context);
                }

                if (!await context.Products.AnyAsync())
                {
                    await SaveDataAsync<Product>("../Infrastructure/Data/SeedData/products.json", context);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}
