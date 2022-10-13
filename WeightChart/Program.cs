using WeightChart.Infrastructure;
using WeightChart.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<SensorReadingsContext>();
builder.Services.AddTransient<IBH1750Repository, BH1750Repository>();
builder.Services.AddTransient<IBMP280Repository, BMP280Repository>();
builder.Services.AddTransient<IHDC1080Repository, HDC1080Repository>();
builder.Services.AddTransient<ISHT31Repository, SHT31Repository>();
builder.Services.AddTransient<ISHT31TestRepository, SHT31TestRepository>();
builder.Services.AddTransient<ISoilMoistureRepository, SoilMoistureRepository>();
builder.Services.AddTransient<IAllSensorData, AllSensorData>();
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
