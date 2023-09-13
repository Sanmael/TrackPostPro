using Aplication.Commands.PersonCommands.CreatePerson;
using DependencyInjectionTrackPostPro;
using FluentValidation.AspNetCore;
using TrackPostPro.Application.Filters;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(UserFilterAttribute));
});
builder.Services.AddControllers().AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblies(typeof(CreatePersonCommand).Assembly);
});

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<UserFilterService>();

Dependences.AddInfrastructure(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
