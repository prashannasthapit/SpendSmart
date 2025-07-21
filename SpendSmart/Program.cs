using Microsoft.EntityFrameworkCore;
using SpendSmart.Data;
using SpendSmart.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddDbContext<ProductDbContext>(options => options.UseInMemoryDatabase("SpendSmartDb"));
        
var connString = builder.Configuration.GetConnectionString("SpendSmart");

// scoped, not thread safe, transactions
builder.Services.AddSqlite<ProductDbContext>(connString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.MigrateDbAsync();

app.Run();