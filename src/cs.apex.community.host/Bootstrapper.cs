using Autofac.Extensions.DependencyInjection;
using cs.apex.community.Api.Controllers;
using cs.apex.community.efcore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore;


namespace cs.apex.community.host
{
    public class Bootstrapper
    {
        public static void Main(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args).UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Bootstrapper>();
            });
            hostBuilder.Build().Run();
        }


        public Bootstrapper(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger();
            });

        }
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            
            services.AddControllers()
                .AddControllersAsServices()
                .AddNewtonsoftJson(options => options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc);
            services.AddSwaggerGen();


            services.AddEntityFrameworkNpgsql().AddDbContext<ApexCommunityContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Postgres"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

    }
}
