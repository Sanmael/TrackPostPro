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
            //repositories
            services.AddScoped<IGenericRepository, DapperRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();            
            services.AddScoped<ILoggerRepository, LoggerRepository>();            
            services.AddScoped<IAddressRepository, AddressRepository>();

            //conection
            services.AddScoped<IContext,DapperSession>();
            
            //transaction
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //validations
            services.AddScoped<IPersonValidation, PersonValidation>();

            return services;
        }
    }
}
