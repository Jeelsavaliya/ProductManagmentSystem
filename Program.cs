using Microsoft.AspNetCore.Builder;
using ProductManagmentSystem.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

//Login
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

/*builder.Services.AddIdentity<UserModel, IdentityUser>()
    .AddDefaultTokenProviders();
*/


var app = builder.Build();
 


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//Login
app.UseSession();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserLogin}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();



//Custom Middleware
/*app.UseMiddleware(typeof(Middleware)); 

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello World!");
});*/
