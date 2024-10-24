using EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Services;
using Microsoft.OpenApi.Models;

namespace EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi
{
    /// <summary>
    /// Настройка приложения.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Конфигурация сервисов.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DeliveryServiceDbContext>();
            services.AddScoped<OrderService>();
            services.AddSingleton<ILogger<OrderService>, Logger>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DeliveryService // Test API",
                    Description = "Данное API создал Идиятуллин Булат",
                    Version = "v1"
                });
            });
        }

        /// <summary>
        /// Конфигурация запросов и их обработки.
        /// </summary>
        /// <param name="app">Конфигурация приложения.</param>
        /// <param name="env">Среда работы приложения.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeliveryService API v1");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DeliveryServiceDbContext>();
                dbContext.EnsureDbCreated();
            }
        }
    }
}