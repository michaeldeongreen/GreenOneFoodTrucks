using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lamar;
using GreenOneFoodTrucks.Common;
using GreenOneFoodTrucks.Services;
using GreenOneFoodTrucks.Services.Interfaces;

namespace GreenOneFoodTrucks.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureContainer(ServiceRegistry services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddMvc();
            services.AddCors();
            services.AddLogging();

            services.IncludeRegistry<CommonRegistry>();
            services.IncludeRegistry<ServicesRegistry>();
            services.IncludeRegistry<DefaultRegistry>();

            services.Scan(s =>
            {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c => c.AllowAnyOrigin());
            app.UseMvc();
        }
    }
}
