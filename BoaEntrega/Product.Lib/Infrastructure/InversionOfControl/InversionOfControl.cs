using BoaEntrega.Lib.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Product.Lib.Infrastructure.HttpClient.Warehouse;
using Product.Lib.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Lib.Infrastructure.InversionOfControl
{
    public static class InversionOfControl
    {
        public static void AddInversionOfControl(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IWarehouseApi, WarehouseApi>();
        }
    }
}
