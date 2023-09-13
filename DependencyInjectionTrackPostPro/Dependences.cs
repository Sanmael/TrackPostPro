using Context.GenericRepository;
using Context.Repositories;
using Context.Session;
using Context.UOW;
using DomainTrackPostPro.Interfaces;
using DomainTrackPostPro.Validations;

namespace DependencyInjectionTrackPostPro
{
    public static class Dependences
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection services)
        {
            services.AddScoped<IGenericRepository, DapperRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IPersonValidation, PersonValidation>();            
            services.AddScoped<IPersonRepository, PersonRepository>();            
            services.AddTransient<IContext,DapperSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
