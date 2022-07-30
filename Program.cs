using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.EntityFrameworkCore;
using CC2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
    // Handling SameSite cookie according to https://docs.microsoft.com/en-us/aspnet/core/security/samesite?view=aspnetcore-3.1
    options.HandleSameSiteCookieCompatibility();
});

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDatabase"));
});

// Configuration to sign-in users with Azure AD B2C
builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "AzureAdB2C");

builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

builder.Services.AddRazorPages();

//Configuring appsettings section AzureAdB2C, into IOptions
builder.Services.AddOptions();
builder.Services.Configure<OpenIdConnectOptions>(builder.Configuration.GetSection("AzureAdB2C"));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Add the Microsoft Identity Web cookie policy
app.UseCookiePolicy();
app.UseRouting();
// Add the ASP.NET Core authentication service
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Add endpoints for Razor pages
    endpoints.MapRazorPages();
});


app.Run();
