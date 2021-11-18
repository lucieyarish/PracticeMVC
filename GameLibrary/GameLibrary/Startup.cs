using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibrary.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GameLibrary
{
    public class Startup
    {
        private IConfiguration AppConfig { get; }
        public Startup(IConfiguration config)
        {
            AppConfig = config;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddTransient<NameService>(); //Table1
            //services.AddTransient<Name2Service>(); //Table2
            ConfigureDb(services);
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        private void ConfigureDb(IServiceCollection services)
        {
            var connectionString = AppConfig.GetConnectionString("DefaultConnection");
            var serverVersion = new MySqlServerVersion(new Version(8,0));
            //AddDbContext is similar to AddTransient<DependencyInjection>
            services.AddDbContext<ApplicationDbContext>(
                options => options
                    .UseMySql(connectionString, serverVersion)
                    // The following three options help with debugging and are optional
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors());
        }
    }
}