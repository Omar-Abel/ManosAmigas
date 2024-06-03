using ManosAmigas_Back.Sources.Application.Interfaces.Repositories;
using ManosAmigas_Back.Sources.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManosAmigas_Back.Sources.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IRegistrationRepository, RegistrationRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IVolunteerActivityRepository, VolunteerActivityRepository>();
            #endregion
        }
    }
}
