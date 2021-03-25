using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Purchase.Microservice.Model.DBContext;
using Purchase.Microservice.Repository;
using Purchase.Microservice.Repository.Interface;
using Purchase.Microservice.Service;
using Purchase.Microservice.Service.Interface;
using Sidecar.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purchase.Microservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SYS_DATA.DB_Connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Database_Context>(options =>
              options.UseSqlServer(SYS_DATA.DB_Connection));

            services.AddTransient<ISupplierService, SupplierService>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            services.AddControllers();



            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);
                });
            });
            services.AddMassTransitHostedService();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Purchase.Microservice", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Purchase.Microservice v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
