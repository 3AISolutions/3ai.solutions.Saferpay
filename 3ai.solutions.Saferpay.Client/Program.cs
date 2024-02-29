using _3ai.solutions.Saferpay.Client.Data;
using _3ai.solutions.Saferpay;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.Configure<SaferpayConfig>(builder.Configuration.GetSection("Saferpay"));

builder.Services.AddSingleton(sp =>
{
    var options = sp.GetRequiredService<IOptions<SaferpayConfig>>();
    return new SaferpayService(options.Value);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapGet("/PaymentRedirectEndpoint", () =>
{
    return Results.Content("<script>window.parent.location.href = '/Counter';</script>", "text/html");
});

app.Run();
