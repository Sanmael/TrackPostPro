using Context.GenericRepository;
using Context.Repositories;
using Entities.Interfaces;
using Entities.Validations;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
