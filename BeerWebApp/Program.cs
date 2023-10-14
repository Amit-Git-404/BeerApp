using BeerApp.Contracts.IServices;
using BeerApp.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddTransient<IBeerFetchService, BeerFetchService>();

//builder.Services.AddCors(options => options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin() .AllowAnyMethod() .AllowAnyHeader()));

builder.Services.AddCors(options => options.AddPolicy("AllowSpecificOrigin", builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));




var app = builder.Build();

//app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseCors("AllowSpecificOrigin");
app.UseEndpoints(endpoints =>
{
    endpoints.MapFallbackToFile("index.html");
});

app.Run();

//record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
