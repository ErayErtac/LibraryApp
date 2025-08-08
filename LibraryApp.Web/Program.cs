using LibraryApp.DataAccess.Context;
using LibraryApp.DataAccess.Repositories;
using LibraryApp.Interfaces.Services;
using LibraryApp.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KutuphaneDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KutuphaneConn")));

// Generic Repository kayýtlarý
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Specific Repository kayýtlarý
builder.Services.AddScoped<IKitapRepository, KitapRepository>();
builder.Services.AddScoped<IUyeRepository, UyeRepository>();
builder.Services.AddScoped<IOduncRepository, OduncRepository>();

// Service kayýtlarý
builder.Services.AddScoped<IKitapService, KitapService>();
builder.Services.AddScoped<IUyeService, UyeService>();
builder.Services.AddScoped<IOduncService, OduncService>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();