using BaseCafe.BLL.Managers.Abstract;
using BaseCafe.BLL.Managers.Concrete;
using BaseCafe.DAL;
using BaseCafe.DAL.Context;
using BaseCafe.DAL.Entities.Concrete;
using BaseCafe.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDalService();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole<string>>().AddEntityFrameworkStores<MyDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Customer", policy => policy.RequireRole("Customer"));
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));

});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IGenericManager<,>), typeof(GenericManager<,>));
// CORS politikası ekleyelim
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        // Hangi origin'lere izin verileceğini burada belirtirsiniz
        policy.WithOrigins("http://localhost:5167/")
        .AllowAnyOrigin()  // Herhangi bir origin'e izin verir
              .AllowAnyMethod()  // Herhangi bir HTTP metoduna izin verir
              .AllowAnyHeader(); // Herhangi bir başlığa izin verir
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.MapRazorPages();
app.UseWebSockets();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
