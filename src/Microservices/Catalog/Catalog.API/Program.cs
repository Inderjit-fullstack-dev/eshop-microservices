using Catalog.API;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container
builder.Services.InjectApplicationServices(builder.Configuration);

// Disable HTTPS in Development
if (builder.Environment.IsDevelopment())
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(8080);
    });
}

var app = builder.Build();

app.MapCarter();

// Configure http request pipeline.
app.Run();
