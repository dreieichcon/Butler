using Conservices.Butler.Controllers.Api;
using Conservices.Butler.Interfaces.Repositories;
using Conservices.Butler.Interfaces.Services;
using Conservices.Butler.Repositories.Endpoints;
using Conservices.Butler.Services.Endpoints;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IGameRepository, GameRepository>();
builder.Services.AddSingleton<IRawGameService, KeyedRawGameService>();

builder.Services.AddSingleton<IProgramRepository, ProgramRepository>();
builder.Services.AddSingleton<IRawProgramService, KeyedRawProgramService>();

var assembly = typeof(GameController).Assembly;

builder.Services.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseHttpsRedirection();
}

app.MapControllers();

await app.RunAsync();