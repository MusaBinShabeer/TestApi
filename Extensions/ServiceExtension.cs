using UserManagementApi.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Repositories.JWTUtilsRepo;
using UserManagementApi.Repositories.ApiKeyServiceRepo;
using UserManagementApi.Extensions.MiddleWare;
using UserManagementApi.Repositories.UserServicesRepo;
using UserManagementApi.Repositories.AuthServicesRepo;

namespace UserManagementApi.Extensions
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
            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddTransient<IJWTUtils, JWTUtils>();
            services.AddTransient<IApiKeyService, ApiKeyService>();
            services.AddTransient<IApiKeyService, ApiKeyService>();
            services.AddSingleton<UserAuthorizeAttribute>();
            services.AddSingleton<ApiKeyAttribute>();
            services.AddTransient<OtherServices>();
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<IAuthServices, AuthServices>();
        }

    }
}
