using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Whitelabel.Service.Impl.Context;
using Microsoft.EntityFrameworkCore;
using Whitelabel.Service.Domain.Interfaces.Repository;
using Whitelabel.Service.Impl.Repository;
using Whitelabel.Service.APP.AutoMapper;
using AutoMapper;
using Whitelabel.Service.CrossCutting.IoC;

namespace whitelabel_service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services)
        {
            object p = services.AddDbContext<WhitelabelContext>(opt =>
               opt.UseInMemoryDatabase("Whitelabel"));

            new DependencyInjection(services).RegisterServices();
            new DependencyInjection(services).RegisterRepositories();

            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<AutoMapperConfig>(), typeof(Startup));
            
            services.AddControllers();           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
