using Context.GenericRepository;
using Context.Repositories;
using Context.Session;
using Context.UOW;
using DomainTrackPostPro.Interfaces;
using DomainTrackPostPro.Validations;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.Service;

namespace DependencyInjectionTrackPostPro
{
    public static class Dependences
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection services)
        {
            //repositories
            services = AddRepositorys(services);

            //services
            services = AddServices(services);

            //conection
            services.AddScoped<IContext,DapperSession>();
            
            //transaction
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //validations
            services.AddScoped<IPersonValidation, PersonValidation>();

            return services;
        }
        private static IServiceCollection AddRepositorys(IServiceCollection services)
        {
            services.AddScoped<IGenericRepository, DapperRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoggerRepository, LoggerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            return services;
        }

        private static IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ILoggerService, DiscordLoggerService>();
            services.AddScoped<IAddresService, AddressService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICachingService, CachingService>();

            return services;
        }
    }
}
