using Aplication.Commands.PersonCommands.CreatePerson;
using Context.GenericRepository;
using Context.Repositories;
using Context.Session;
using Context.UOW;
using DependencyInjectionTrackPostPro;
using DomainTrackPostPro.Interfaces;
using DomainTrackPostPro.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
