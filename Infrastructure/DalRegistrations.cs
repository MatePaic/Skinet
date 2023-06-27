using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DalRegistrations
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services)
        {
            services.AddDbContext<StoreContext>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
