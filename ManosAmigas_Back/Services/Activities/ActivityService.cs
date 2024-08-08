using ManosAmigas_Back.Data;
using ManosAmigas_Back.Models;
using ManosAmigas_Back.Models.Request;
using ManosAmigas_Back.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace ManosAmigas_Back.Services.Activities
{
    public class ActivityService : IActivityService
    {
        public async Task<IEnumerable<ActivityResponse>> GetActivities()
        {
            using (var db = new ManosAmigasDbContext())
            {
                return await db.Activities
                    .Select(activity => new ActivityResponse
                    {
                        id = activity.Id,
                        title = activity.Title,
                        description = activity.Description,
                        category = activity.Category,
                        location = activity.Location,
                        meetingPoint = activity.MeetingPoint,
                        peopleRequired = activity.PeopleRequired,
                        benefits = activity.Benefits,
                        startDate = activity.StartDate,
                        endDate = activity.EndDate,
                        imagePath = activity.ImagePath,
                        hostId = (int)activity.HostId
                    }).ToListAsync();
            }

        }

        public async Task<IEnumerable<ActivityResponse>> GetActivitiesForHost(int hostId)
        {
            using (var db = new ManosAmigasDbContext())
            {
                return await db.Activities
                    .Where(activity => activity.HostId == hostId)
                    .Select(activity => new ActivityResponse
                    {
                        id = activity.Id,
                        title = activity.Title,
                        description = activity.Description,
                        category = activity.Category,
                        location = activity.Location,
                        meetingPoint = activity.MeetingPoint,
                        peopleRequired = activity.PeopleRequired,
                        benefits = activity.Benefits,
                        startDate = activity.StartDate,
                        endDate = activity.EndDate,
                        imagePath = activity.ImagePath,
                        hostId = (int)activity.HostId
                    }).ToListAsync();
            }
        }

        public async Task<Activity> GetActivityById(int id)
        {
            using (var db = new ManosAmigasDbContext())
            {
                var activity = await db.Activities.FindAsync(id);
                if (activity == null) return null;
                return activity;
            }
        }

        public async Task<Activity> CreateActivity(ActivityRequest model)
        {
            string fileName = Guid.NewGuid().ToString() + ' ' + model.image.FileName;
            string fullPath = Path.Combine(@"imgs", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await model.image.CopyToAsync(stream);
            }

            using (var db = new ManosAmigasDbContext())
            {
                var activity = new Activity
                {
                    Title = model.title,
                    Description = model.description,
                    Category = model.category,
                    Location = model.location,
                    MeetingPoint = model.meetingPoint,
                    PeopleRequired = model.peopleRequired,
                    Benefits = model.benefits,
                    StartDate = model.startDate,
                    EndDate = model.endDate,
                    ImagePath = fullPath,
                    HostId = model.hostId
                };

                db.Activities.Add(activity);
                await db.SaveChangesAsync();

                return activity;
            }
        }

        public async Task<Activity> DeleteActivity(int id)
        {
            using (var db = new ManosAmigasDbContext())
            {
                var activity = await db.Activities.FindAsync(id);
                if (activity == null) return null;
                db.Activities.Remove(activity);
                await db.SaveChangesAsync();
                return activity;
            }
        }


    }
}
