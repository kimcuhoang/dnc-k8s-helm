using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PeopleWebApi.Db;
using PeopleWebApi.HostedServices;

namespace PeopleWebApi
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
            services.AddDbContext<PeopleDbContext>((provider, opts) =>
            {
                var logger = provider.GetRequiredService<ILogger<Startup>>();
                var connectionString = this.Configuration.GetConnectionString("Default");
                logger.LogInformation($"[{nameof(Startup)}] - ConnectionString: {connectionString}");
                opts.UseSqlServer(this.Configuration.GetConnectionString("Default"));
            });
            services.AddHostedService<DbMigratorHostedService>();
        }

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
        }
    }
}
