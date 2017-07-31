using CoreBase.Domain.Interfaces.Repositories;
using CoreBase.Domain.Interfaces.Services;
using CoreBase.Domain.Services;
using CoreBase.Infra.Data.Context;
using CoreBase.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CoreBase.Infra.Cross.IoC
{
    public static class DIContainer
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<CoreContext>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IPaymentMethodService, PaymentMethodService>();
        }
    }
}
