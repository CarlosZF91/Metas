using Microsoft.AspNetCore.ResponseCompression;
using BlazorMetas.Shared;
using Microsoft.EntityFrameworkCore;
using BlazorMetas.Shared.IDA;
using BlazorMetas.Shared.DA;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("GestionDeMetas")));
builder.Services.AddScoped<IMetasDAL, MetasDA>();
builder.Services.AddScoped<IActividadesDAL, ActividadesDA>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
