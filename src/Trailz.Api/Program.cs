using Trailz.Api;
using Trailz.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var config = builder.Configuration;
var env = builder.Environment;

builder.Services
    .AddCustomConfiguration(config)
    .AddDependencyInjection()
    .AddDatabase();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
}

app.UseHttpsRedirection();
