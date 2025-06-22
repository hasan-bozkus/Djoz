using Djoz.Application;
using Djoz.Domain.Entities;
using Djoz.Infrastructure;
using Djoz.Infrastructure.ExternalServices.AuthenticationServices;
using Djoz.Persistance;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistanceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//    {
//        var key = Encoding.ASCII.GetBytes("JwtMusicProject+*010203JWTMUSIC01+*..020304JwtMusicProject"); // Secret key'in aynýsý
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = false,
//            ValidateAudience = false,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(key)
//        };
//    });

//builder.Services.AddAuthorization();


builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Djoz.WebApi", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Djoz.WebApi v1");
    });
}

// ?? Roller seed ediliyor
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
    await SeedRoles.InitializeAsync(roleManager);

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    await SeedUsers.CreateAdminUserAsync(userManager);
    await SeedUsers.CreateMemberUserAsync(userManager);
}
app.UseCors("CorsPolicy");
app.UseRequestLocalization();

app.UseHttpsRedirection();
//app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
