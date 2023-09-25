using DependencyInjectionTrackPostPro;
using FluentValidation.AspNetCore;
using TrackPostPro.Application.Filters;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.Interfaces.Validation;
using TrackPostPro.Application.Service;
using TrackPostPro.Application.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add(typeof(UserFilterAttribute));
//});
builder.Services.AddControllers().AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(LogExceptionFilter)); // Adicione o filtro aqui
});

builder.Services.AddScoped<LogExceptionFilter>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<LoggerService >();
builder.Services.AddScoped<IAddresService, AddressService>();
builder.Services.AddScoped<ICachingService, CachingService>();
builder.Services.AddScoped<IModelValidation, ModelValidation>();

//builder.Services.AddScoped<UserFilterService>();


builder.Services.AddStackExchangeRedisCache(o =>
{
    o.InstanceName = "instance";
    o.Configuration = "localhost:6379";
});

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
