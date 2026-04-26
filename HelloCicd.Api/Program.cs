using HelloCicd.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IHelloService, HelloService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

// Required for WebApplicationFactory in integration tests
public partial class Program { }