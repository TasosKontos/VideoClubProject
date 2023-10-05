using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VideoClub.Common.Services;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("Server=(localdb)\\mssqllocaldb;Database=VideoClubDB;Trusted_Connection=True;");
var connectionString = "Server=(localdb)\\mssqllocaldb;Database=VideoClubDB;Trusted_Connection=True;";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddIdentityCore < ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddRazorPages();
builder.Services.AddIdentityCore<ApplicationUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var scope = app.Services.CreateScope();
var unitOfWork = scope.ServiceProvider.GetService<UnitOfWork>();
var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

await DbInitializer.Initialize(context, userManager, unitOfWork);

app.Run();
