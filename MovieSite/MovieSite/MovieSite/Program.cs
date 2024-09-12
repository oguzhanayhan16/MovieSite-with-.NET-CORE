using BusinessLayer.Concrate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<AzureBlobService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // Session is necessary for GDPR compliance.
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // Path to the login page
        options.LogoutPath = "/Login/Logout"; // Path to the logout action
        options.AccessDeniedPath = "/Login/AccessDenied";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireRole("Admin") // Admin rolüne sahip olmayanlarý reddet
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
var app = builder.Build();
app.UseStatusCodePagesWithRedirects("/Login/AccessDenied");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1","?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );

app.UseEndpoints(endpoints =>
{
    // Varsayýlan rota
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Movie}/{action=Index}/{id?}");

    // Admin alanlarý için yetkilendirme
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "Admin/{controller=Client}/{action=Index}/{id?}")
        .RequireAuthorization("AdminOnly");  // Yalnýzca "Admin" rolü yetkisine sahip kullanýcýlar eriþebilir.
});

app.Run();
