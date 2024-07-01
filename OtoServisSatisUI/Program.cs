using AspNetCoreHero.ToastNotification;
using OtoServisSatis.Data;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.





builder.Services.AddNotyf(Configuration =>
{
    Configuration.Position = NotyfPosition.BottomRight;
    Configuration.IsDismissable = true;
    Configuration.DurationInSeconds = 5;

});
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login";
    x.AccessDeniedPath = "/AccessDenid";
    x.LogoutPath = "/Admin/Logout";
    x.Cookie.Name = "Admin";
    x.Cookie.MaxAge =TimeSpan.FromDays(2);
    x.Cookie.IsEssential = true;
});

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("Y�neticiPolicy", policy => policy.RequireClaim("Rol", "Y�netici"));
    x.AddPolicy("PersonelPolicy", policy => policy.RequireClaim("Rol", "Personel"));
});

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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
          name: "admin",
          pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
        );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
