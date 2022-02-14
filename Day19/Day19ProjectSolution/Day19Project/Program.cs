using Microsoft.EntityFrameworkCore;
using Day19Project.Models;
using Day19Project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//provide coonection string for db connecting
string strCon = builder.Configuration.GetConnectionString("myCon");

builder.Services.AddDbContext<ShopContext>(opts =>
{
    opts.UseSqlServer(strCon);
});

builder.Services.AddScoped<IRepo<int, Product>, ProductRepo>();

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
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();




//Create an application that will allow user to add a products to the given product list

//Product(Id, Name, Category, Price, Quantity, Pic, description)

//while adding the product the product the category should be Food, Toy, Clothing

//Price and quantity  cannot be negative

//Maximum of 20 units  only can be stored for every product

//The data to reflect in database

//While listing the products list in card layout with a buy button ->Index
//Add a quantity to buy in the layout
//When teh user clicks the buy button show total price and show big picture of teh product with the compelet description -> Details
