using ManosAmigas_Back.Sources.Application.Interfaces.Repositories;
using ManosAmigas_Back.Sources.Application.Interfaces.Services;
using ManosAmigas_Back.Sources.Application.ViewModels.VolunteerActivities;
using ManosAmigas_Back.Sources.Domain.Entities;

namespace ManosAmigas_Back.Sources.Application.Services
{
    public class VolunteerActivityService : IVolunteerActivityService
    {
        private readonly IVolunteerActivityRepository _repository;
        public VolunteerActivityService(IVolunteerActivityRepository volunteerActivityRepository)
        {
            _repository = volunteerActivityRepository;
        }


        public async Task Update(SaveVolunteerActivityViewModel vm)
        {
            VolunteerActivity activity = new();
            activity.Id = vm.Id;
            activity.Title = vm.Title;
            activity.Description = vm.Description;
            activity.StartDate = vm.StartDate;
            activity.EndDate = vm.EndDate;
            activity.Locations = vm.Locations;
            activity.Tasks = vm.Tasks;
            activity.Benefits = vm.Benefits;
            activity.OrganizerId = vm.OrganizerId;

            await _repository.UpdateAsync(activity);
        }

        public async Task Add(SaveVolunteerActivityViewModel vm)
        {
            VolunteerActivity activity = new();
            activity.Id = vm.Id;
            activity.Title = vm.Title;
            activity.Description = vm.Description;
            activity.StartDate = vm.StartDate;
            activity.EndDate = vm.EndDate;
            activity.Locations = vm.Locations;
            activity.Tasks = vm.Tasks;
            activity.Benefits = vm.Benefits;
            activity.OrganizerId = vm.OrganizerId;

            await _repository.AddAsync(activity);
        }

        public async Task Delete(int id)
        {
            var activity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(activity);
        }

        public async Task<SaveVolunteerActivityViewModel> GetByIdSaveViewModel(int id)
        {
            var activity = await _repository.GetByIdAsync(id);

            SaveVolunteerActivityViewModel vm = new();

            vm.Id = activity.Id;
            vm.Title = activity.Title;
            vm.Description = activity.Description;
            vm.StartDate = activity.StartDate;
            vm.EndDate = activity.EndDate;
            vm.Locations = activity.Locations;
            vm.Tasks = activity.Tasks;
            vm.Benefits = activity.Benefits;
            vm.OrganizerId = activity.OrganizerId;

            return vm;
        }

        public async Task<List<VolunteerActivityViewModel>> GetAllViewModel()
        {
            var regitratList = await _repository.GetAllAsync();

            return regitratList.Select(activity => new VolunteerActivityViewModel
            {
                Id = activity.Id,
                Title = activity.Title,
                Description = activity.Description,
                StartDate = activity.StartDate,
                EndDate = activity.EndDate,
                Locations = activity.Locations,
                Tasks = activity.Tasks,
                Benefits = activity.Benefits,
                OrganizerId = activity.OrganizerId,

            }).ToList();
        }
    }
}
