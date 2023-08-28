using UserManagementApi.Extensions;
using UserManagementApi.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Extensions.MiddleWare;
using UserManagementApi.Repositories.UserTypeServicesRepo;
using UserManagementApi.Repositories.UserServicesRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureServices(builder.Configuration);
builder.Services.AddScoped<IUserTypeService, UserTypeService>();
builder.Services.AddScoped<IUserService, UserService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.ConfigureJWT(builder.Configuration);
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    using (var ctx = scope.ServiceProvider.GetRequiredService<DBManagementContext>())
    {
        if (ctx.Database.GetPendingMigrations().Any())
        {
            await ctx.Database.MigrateAsync();
        }
        await ctx.Database.EnsureCreatedAsync();
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<JWTMiddleWare>();
app.MapControllers();
app.Run();
