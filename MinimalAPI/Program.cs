using Microsoft.AspNetCore.Hosting.Builder;
using MinimalAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<GreetingService>();

// Add services to the container.

var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/", () => HelloMethods.HelloWorld());

app.MapGet("/hello/{name}", (string name, GreetingService gs, HttpContext http) => gs.Hello() + " ");


app.Run();



