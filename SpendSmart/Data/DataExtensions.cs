using Microsoft.EntityFrameworkCore;
using SpendSmart.Models;

namespace SpendSmart.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<ProductDbContext>();
        await dbContext!.Database.MigrateAsync();
    }
}