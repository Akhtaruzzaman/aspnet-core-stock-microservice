using EventBus.Common.Common;
using Inventory.Microservice.Model.DBContext;
using Inventory.Microservice.Repository;
using Inventory.Microservice.Repository.Interface;
using Inventory.Microservice.Service;
using Inventory.Microservice.Service.Interface;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Sidecar.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Microservice
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


            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddCors();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(o =>
            //{
            //    o.Authority = "https://localhost:44352";
            //    o.Audience = "myresourceapi";
            //    o.RequireHttpsMetadata = false;
            //});

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("PublicSecure", policy => policy.RequireClaim("client_id", "secret_client_id"));
            //});


            services.AddControllers();


            services.AddMassTransit(config =>
            {
                config.AddConsumer<InventoryConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);
                    cfg.ReceiveEndpoint(EventBusConstants.InventoryQueue, c =>
                    {
                        c.ConfigureConsumer<InventoryConsumer>(ctx);
                    });
                });
            });
            services.AddMassTransitHostedService();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Inventory.Microservice", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory.Microservice v1"));
            }
            app.UseCors(options => options.WithOrigins("https://localhost:44382").AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
