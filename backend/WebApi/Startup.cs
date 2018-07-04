using AutoMapper;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using Core.Services;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
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
            services.AddCors();

            services.AddDbContext<SupportWheelOfFateDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

            services.AddMvc();
            services.AddAutoMapper();

            services.AddTransient<IEngineerRepository, EngineerRepository>();
            services.AddTransient<IRotaEntriesRepository, RotaEntriesRepository>();
            services.AddTransient<IRandomService, RandomService>();
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IEngineersService, EngineersService>();
            services.AddTransient<IRotaBuilder, RotaBuilder>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SupportWheelOfFateDbContext>();
                dbContext.Database.Migrate();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());

            app.UseMvc();
        }
    }
}
