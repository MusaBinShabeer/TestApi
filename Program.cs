using Microsoft.EntityFrameworkCore;
using TestApi.Models.DBModels;
using TestApi.Repositories.UserServicesRepo;
using TestApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    using (var ctx = scope.ServiceProvider.GetRequiredService<TestDBContext>())
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

app.MapControllers();
app.Run();
