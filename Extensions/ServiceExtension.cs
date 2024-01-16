using Microsoft.EntityFrameworkCore;
using TestApi.Models.DBModels;
using TestApi.Repositories.UserServicesRepo;

namespace TestApi.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TestDBContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            // Adding Cors
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowedOrigins",
                                  policy =>
                                  {
                                      policy
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .AllowAnyOrigin();
                                  });
            });
            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddTransient<OtherServices>();
            services.AddTransient<IUserService, UserService>();
        }

    }
}
