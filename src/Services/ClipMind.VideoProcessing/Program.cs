using System.Reflection;
using BuildingBlocks.Common.Endpoints;
using ClipMind.VideoProcessing.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDefaultServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.RegisterEndpoints(Assembly.GetExecutingAssembly());

app.UseHttpsRedirection();

app.Run();