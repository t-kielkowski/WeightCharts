using MediatR;
using WeightCharts;
using WeightCharts.Application.ApiAccess;
using WeightCharts.Application.Feature.Beehive;
using WeightCharts.Application.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<ApiConfiguration>(builder.Configuration.GetSection("ApiConfiguration"));
builder.Services.AddTransient<IApiClient, ApiClient>();
builder.Services.AddTransient<IBeehiveNameList, BeehiveNameList>();
builder.Services.AddMediatR(typeof(GetSensorTempDataQuery));

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
