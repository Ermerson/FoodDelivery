using FluentMediator;
using FoodDelivery.API.Extensions.Middleware;
using FoodDelivery.Application.Handlers;
using FoodDelivery.Application.Mappers;
using FoodDelivery.Application.Services;
using FoodDelivery.Domain.Restaurant;
using FoodDelivery.Domain.Restaurant.Commands;
using FoodDelivery.Domain.Restaurant.Events;
using FoodDelivery.Infrastructure.Factories;
using FoodDelivery.Infrastructure.Repositories;
using FoodDelivery.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace FoodDelivery.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddSingleton<RestaurantViewModelMapper>();
            services.AddTransient<IRestaurantFactory, EntityFactory>();

            services.AddScoped<RestaurantCommandHandler>();
            services.AddScoped<RestaurantEventHandler>();

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddFluentMediator(builder =>
            {
                builder.On<CreateNewRestaurantCommand>().PipelineAsync().Return<Restaurant, RestaurantCommandHandler>((handle, request) => handle.HandleNewRestaurant(request));
                builder.On<RestaurantCreatedEvent>().PipelineAsync().Call<RestaurantEventHandler>((handler, request) => handler.HandleRestaurantCreatedEvent(request));
                builder.On<DeleteRestaurantCommand>().PipelineAsync().Call<RestaurantCommandHandler>((handler, request) => handler.HandleDeleteRestaurant(request));
                builder.On<RestaurantDeletedEvent>().PipelineAsync().Call<RestaurantEventHandler>((handler, request) => handler.HandleRestaurantDeletedEvent(request));
            });

            Log.Logger = new LoggerConfiguration().CreateLogger();

            services.AddOpenTracing();
            services.AddOptions();
            services.AddMvc();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionMiddleware>();            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestaurantDelivery API V1");
            });
        }
    }
}
