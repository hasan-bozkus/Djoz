using Djoz.Application;
using Djoz.Domain.Entities;
using Djoz.Infrastructure;
using Djoz.Infrastructure.ExternalServices.AuthenticationServices;
using Djoz.Persistance;
using Djoz.WebUI.Services.BannerServices;
using Djoz.WebUI.Services.Concrete;
using Djoz.WebUI.Services.ContactServices;
using Djoz.WebUI.Services.CountDownServices;
using Djoz.WebUI.Services.DjInfoServices;
using Djoz.WebUI.Services.EventServices;
using Djoz.WebUI.Services.Interfaces;
using Djoz.WebUI.Services.LoginServices;
using Djoz.WebUI.Services.PackageServices;
using Djoz.WebUI.Services.SongServices;
using Djoz.WebUI.Services.UserServices;
using Djoz.WebUI.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var key = Encoding.ASCII.GetBytes("JwtMusicProject+*010203JWTMUSIC01+*..020304JwtMusicProject"); // Secret key'in aynýsý
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Login/Index";
});

builder.Services.AddPersistanceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// ?? Roller seed ediliyor
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
    await SeedRoles.InitializeAsync(roleManager);

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    await SeedUsers.CreateAdminUserAsync(userManager);
    await SeedUsers.CreateMemberUserAsync(userManager);
}
app.UseRequestLocalization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Error Page - 403
app.UseStatusCodePagesWithReExecute("/Admin/Errors/AccessDenied", "?code={0}");

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UILayout}/{action=_UILayout}/{id?}")
    .WithStaticAssets();


app.Run();
