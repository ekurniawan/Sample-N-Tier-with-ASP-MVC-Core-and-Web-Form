using MyWebFormApp.BLL;
using MyWebFormApp.BLL.Interfaces;
using SampleMVC.Services;

var builder = WebApplication.CreateBuilder(args);
//menambahkan modul mvc
builder.Services.AddControllersWithViews();

//register session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//register DI
builder.Services.AddScoped<ICategoryBLL, CategoryBLL>();
builder.Services.AddScoped<IArticleBLL, ArticleBLL>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<IRoleBLL, RoleBLL>();
builder.Services.AddHttpClient<ICategoryServices, CategoryServices>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();