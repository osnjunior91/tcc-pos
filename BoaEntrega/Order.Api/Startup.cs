using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BoaEntrega.Lib.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Order.Lib.Infrastructure.InversionOfControl;

namespace Order.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
              .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
              });
            services.AddHttpClient("customerClient", c => c.BaseAddress = new System.Uri(Apis.CUSTOMER_API));
            services.AddHttpClient("warehouseClient", c => c.BaseAddress = new System.Uri(Apis.WAREHOUSE_API));
            services.AddHttpClient("utilsClient", c => c.BaseAddress = new System.Uri(Apis.UTILS_API));
            services.AddHttpClient("productClient", c => c.BaseAddress = new System.Uri(Apis.PRODUCTS_API));
            services.AddInversionOfControl();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Boa Entrega -  Customer Api - v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Bem vindo a api de pedidos boa entrega.");
                });
            });
        }
    }
}
