using MeteringManagementApi.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace MeteringManagementApi.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBManagementContext>(options =>
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
        }

    }
}
