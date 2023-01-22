using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Interfaces.Repositories;
using Store.Domain.Interfaces.Services;
using Store.Infra.Data.Repository;
using Store.Service.Services;

namespace Store.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();

            // Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        }
    }
}