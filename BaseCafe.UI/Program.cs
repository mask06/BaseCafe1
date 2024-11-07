using BaseCafe.BLL.Managers.Abstract;
using BaseCafe.BLL.Managers.Concrete;
using BaseCafe.DAL;
using BaseCafe.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDalService();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IGenericManager<,>) , typeof(GenericManager<,>));
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
app.UseWebSockets();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
