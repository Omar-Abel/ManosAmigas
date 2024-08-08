using ManosAmigas_Back.Models;
using ManosAmigas_Back.Models.Request;
using ManosAmigas_Back.Models.Response;

namespace ManosAmigas_Back.Services.Activities
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityResponse>> GetActivities();
        Task<IEnumerable<ActivityResponse>> GetActivitiesForHost(int hostId);
        Task<Activity> GetActivityById(int id);
        Task<Activity> CreateActivity(ActivityRequest model);
        Task<Activity> DeleteActivity(int id);


    }
}
