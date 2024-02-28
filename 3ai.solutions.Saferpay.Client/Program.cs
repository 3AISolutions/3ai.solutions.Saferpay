using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using _3ai.solutions.Saferpay.Client.Data;
using _3ai.solutions.Saferpay;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<SaferpayService>(new SaferpayService(new SaferpayConfig
{
    BaseUrl = builder.Configuration["Saferpay:BaseUrl"],
    Username = builder.Configuration["Saferpay:Username"],
    Password = builder.Configuration["Saferpay:Password"]
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
