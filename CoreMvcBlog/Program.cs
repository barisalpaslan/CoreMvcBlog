using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
// Add services to the container.
builder.Services.AddControllersWithViews();


//Proje seviyesinde Authorize iþlemi
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                 .Build();

    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();

//login sayfasýndayken baþka sayfalara gitmek istendiðinde gitmeyi engelleme iþlemi
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme
    ).AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    });

builder.Services.AddSession(); //kesin lazým, kaldýrýnca hata veriyor

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//durum kodlarýný kullanmak için
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

//Proje seviyesinde Authorize iþlemi -> login olursa
app.UseSession();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
