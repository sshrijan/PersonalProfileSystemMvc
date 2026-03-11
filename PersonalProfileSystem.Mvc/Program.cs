using Microsoft.EntityFrameworkCore;
using PersonalProfileSystem.Mvc.Data;
using PersonalProfileSystem.Mvc.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PersonalProfileSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<RegisterService>();
builder.Services.AddScoped<IProfileService, ProfileService>();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
