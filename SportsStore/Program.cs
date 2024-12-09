using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts => {
    opts.UseSqlServer(
    builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
app.UseSession();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute("pagination",
//    "Products/Page{productPage}",
//    new { Controller = "Product", action = "Index" });

app.MapControllerRoute("catpage",
    "Products/{category}/Page{productPage:int}",
    new { Controller = "Product", action = "Index" });

app.MapControllerRoute("page",
    "Products/Page{productPage:int}",
    new { Controller = "Product", action = "Index", productPage = 1 });

app.MapControllerRoute("category",
    "Products/{category}",
    new { Controller = "Product", action = "Index", productPage = 1 });

app.MapControllerRoute("pagination",
    "Products/Page{productPage}",
    new { Controller = "Product", action = "Index", productPage = 1 });

app.MapDefaultControllerRoute();

app.MapRazorPages(); // végpontok vagy endpoint-ok 

SeedData.EnsurePopulated(app);

app.Run();
