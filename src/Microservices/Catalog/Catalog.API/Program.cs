using Catalog.API;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container
builder.Services.InjectApplicationServices(builder.Configuration);

var app = builder.Build();

app.MapCarter();

// Configure http request pipeline.

app.Run();
