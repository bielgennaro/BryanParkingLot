using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BryanParkingLot.Data;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bryan Parking Lot", Description = "Estacionamento do braia", Version = "v1" });
});


builder.Services.AddDbContext<BryanParkingLotContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ConnectionDb") ??
                      throw new InvalidOperationException("Connection string 'ConnectionDb' not found.")));

new ServiceCollection()
    .AddLogging()
    .AddMvc()
    .AddNewtonsoftJson()
    .Services.BuildServiceProvider();

builder.Services.AddCors();

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();