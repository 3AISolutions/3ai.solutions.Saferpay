using _3ai.solutions.Saferpay;

var builder = WebApplication.CreateBuilder(args);

var saferpayConfig = builder.Configuration.GetSection("Saferpay").Get<SaferpayConfig>();
if (saferpayConfig is not null && saferpayConfig.IsEnabled)
    builder.Services.AddHttpClient<SaferpayServiceClient>(client =>
    {
        client.BaseAddress = new Uri(saferpayConfig.BaseUrl);
        client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{saferpayConfig.Username}:{saferpayConfig.Password}")));
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");
app.MapPost("/api/saferpay", async (SaferpayServiceClient client) =>
{
    var response = "";//await client.tr
    return response;
});

app.Run();
