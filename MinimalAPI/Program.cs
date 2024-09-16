using Microsoft.AspNetCore.Hosting.Builder;
using MinimalAPI;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/", () => HelloMethods.HelloWorld());

app.MapGet("/hello/{name}/narozeni/{dob}", (string name) => HelloMethods.HelloWorld(name));

app.Run();



