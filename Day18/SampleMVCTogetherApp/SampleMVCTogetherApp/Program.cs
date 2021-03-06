using Microsoft.EntityFrameworkCore;
using SampleMVCTogetherApp.Models;
using SampleMVCTogetherApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//provide coonection string for db connecting
string strCon = builder.Configuration.GetConnectionString("myCon");
builder.Services.AddDbContext<ShopContext>(opts =>
{
    opts.UseSqlServer(strCon);
});

builder.Services.AddScoped<IRepo<int, Customer>, CustomerRepo>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();
