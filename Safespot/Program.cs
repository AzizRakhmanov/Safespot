using Microsoft.EntityFrameworkCore;
using Safespot.Areas.Identity.Models;
using Safespot.Data;
using Safespot.Data.DataAccess;
using Safespot.Data.IRepositories;
using Safespot.Data.Repositories;
using Safespot.Models.Entities;
using Safespot.Service.Extentions;
using Safespot.Service.Mapper;
using Safespot.Service.Services.AdminService.Interfaces;
using Safespot.Service.Services.AdminService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<SafeSpotDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<SafespotContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<ParkingZone>, Repository<ParkingZone>>();

builder.Services.AddDefaultIdentity<UserForLoginDto>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SafespotContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<SafeSpotDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IRepository<Reservation>, Repository<Reservation>>();
builder.Services.ConfigureServices();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<IAdminParkingZoneService, AdminParkingZoneService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
