using Context.GenericRepository;
using Context.Repositories;
using DomainTrackPostPro.Interfaces;
using DomainTrackPostPro.Validations;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
