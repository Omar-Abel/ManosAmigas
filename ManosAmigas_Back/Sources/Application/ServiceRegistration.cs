using ManosAmigas_Back.Sources.Application.Interfaces.Services;
using ManosAmigas_Back.Sources.Application.Services;

namespace ManosAmigas_Back.Sources.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {

            #region Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IVolunteerActivityService, VolunteerActivityService>();
            services.AddTransient<IRegistrationService, RegistrationService>();
            #endregion

        }
    }
}
