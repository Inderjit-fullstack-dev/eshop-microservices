using Catalog.API;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container
builder.Services.InjectApplicationServices();

var app = builder.Build();

app.MapCarter();

// Configure http request pipeline.

app.Run();
