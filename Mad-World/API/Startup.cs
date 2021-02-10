using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Coins;
using BusinessLayer.Coins.Interfaces;
using CoinChecker.Base.Enums;
using CoinChecker.Base.Interfaces;
using CoinChecker.Bittrex;
using CoinChecker.Bittrex.Info;
using CoinChecker.Cex;
using CoinChecker.Cex.Info;
using Common;
using Common.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            AddToScope(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddToScope(IServiceCollection services)
        {
            services.AddScoped<IService, Service>();
            services.AddScoped<IExchangeManager, ExchangeManager>();

            services.AddScoped<IExchangeAPI, BittrexExchange>();
            services.AddScoped<IExchangeAPI, CexExchange>();

            services.AddScoped<BittrexCoinManager>();
            services.AddScoped<CexCoinManager>();

            services.AddScoped<BittrexUrls>();
            services.AddScoped<CexUrls>();

            services.AddTransient<Func<ExchangeType, ICoinManager>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case ExchangeType.Bittrex:
                        return serviceProvider.GetService<BittrexCoinManager>();
                    case ExchangeType.Cex:
                        return serviceProvider.GetService<CexCoinManager>();
                    default:
                        return null;
                }
            });

            services.AddTransient<Func<ExchangeType, IUrlsHandler>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case ExchangeType.Bittrex:
                        return serviceProvider.GetService<BittrexUrls>();
                    case ExchangeType.Cex:
                        return serviceProvider.GetService<CexUrls>();
                    default:
                        return null;
                }
            });
        }
    }
}
