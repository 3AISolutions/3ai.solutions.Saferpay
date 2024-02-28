using _3ai.solutions.Saferpay;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<SaferpayService>(sp =>
{
    var saferpayConfig = new SaferpayConfig
    {
        BaseUrl = builder.Configuration["Saferpay:BaseUrl"],
        Username = builder.Configuration["Saferpay:Username"],
        Password = builder.Configuration["Saferpay:Password"]
    };
    return new SaferpayService(saferpayConfig);
}); 

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
