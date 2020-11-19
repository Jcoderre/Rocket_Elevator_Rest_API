using System;
using RocketElevatorsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace RocketElevatorsAPI
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

            services.AddDbContext<RocketElevatorsContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(
                        Configuration.GetConnectionString("DefaultConnection"),
                        mySqlOptions => mySqlOptions
                            .ServerVersion(new Version(5, 7, 31), ServerType.MySql)
                            .CharSetBehavior(CharSetBehavior.NeverAppend))

                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello! Why don't you try out a few of our GET or PUT requests? An example: /api/elevator/all");
                });
                endpoints.MapControllers();
            });
        }
    }
}
