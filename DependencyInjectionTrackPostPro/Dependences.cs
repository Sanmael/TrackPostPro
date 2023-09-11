using Context.GenericRepository;
using Context.Repositories;
using Context.Session;
using Context.UOW;
using Entities.Interfaces;
using Entities.Validations;
using Microsoft.AspNetCore.Identity;

namespace DependencyInjectionTrackPostPro
{
    public static class Dependences
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection services)
        {
            services.AddScoped<IGenericRepository, DapperRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IPersonValidation, PersonValidation>();
            services.AddTransient<IContext,DapperSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
