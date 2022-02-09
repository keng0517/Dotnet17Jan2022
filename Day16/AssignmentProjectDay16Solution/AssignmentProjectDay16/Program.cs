var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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


//Create a MVC application that will take the Product details from the user

//Product
//  Id
//  Name
//  Price
//  SupplierId
//  Quantity
//  Remarks

//Implement the List and Create for the product using Controller and Views

//Explore edit and details options as well