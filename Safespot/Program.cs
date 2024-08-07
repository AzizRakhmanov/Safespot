using Microsoft.EntityFrameworkCore;
using Safespot.Data;
using Safespot.Data.DataAccess;
using Safespot.Data.IRepositories;
using Safespot.Data.Repositories;
using Safespot.Models.Entities;
using Safespot.Service.DTO.UserDto;
using Safespot.Service.Extentions;
using Safespot.Service.Mapper;
using Safespot.Service.Services.AdminService.Interfaces;
using Safespot.Service.Services.AdminService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SafeSpotDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<SafespotContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<ParkingZone>, Repository<ParkingZone>>();
builder.Services.AddScoped<IRepository<Slot>, Repository<Slot>>();
builder.Services.AddScoped<IRepository<Reservation>, Repository<Reservation>>();
builder.Services.AddScoped<IAdminSlotService, AdminSlotService>();


builder.Services.AddDefaultIdentity<UserForLoginDto>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SafespotContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();

//var build = Host.CreateDefaultBuilder()
//    .ConfigureServices((cxt, services) =>
//    {
//        services.AddQuartz();
//        services.AddQuartzHostedService(opt =>
//        {
//            opt.WaitForJobsToComplete = true;
//        });
//    }).Build();



//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<SafeSpotDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IRepository<Reservation>, Repository<Reservation>>();
builder.Services.ConfigureServices();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddTransient<IAdminParkingZoneService, AdminParkingZoneService>();
builder.Services.AddScoped<IAdminParkingZoneService, AdminParkingZoneService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // app.UseExceptionHandler("/Home/Error");

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
