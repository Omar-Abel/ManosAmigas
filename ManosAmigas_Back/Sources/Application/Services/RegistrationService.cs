using ManosAmigas_Back.Sources.Application.Interfaces.Repositories;
using ManosAmigas_Back.Sources.Application.Interfaces.Services;
using ManosAmigas_Back.Sources.Application.ViewModels.Registrations;
using ManosAmigas_Back.Sources.Domain.Entities;

namespace ManosAmigas_Back.Sources.Application.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }


        public async Task Update(SaveRegistrationViewModel vm)
        {
            Registration registra = new();
            registra.Id = vm.Id;
            registra.RegistrationDate = vm.RegistrationDate;
            registra.UserId = vm.UserId;
            registra.ActivityId = vm.ActivityId;

            await _registrationRepository.UpdateAsync(registra);
        }

        public async Task Add(SaveRegistrationViewModel vm)
        {
            Registration registra = new();
            registra.Id = vm.Id;
            registra.RegistrationDate = vm.RegistrationDate;
            registra.UserId = vm.UserId;
            registra.ActivityId = vm.ActivityId;

            await _registrationRepository.AddAsync(registra);
        }

        public async Task Delete(int id)
        {
            var registra = await _registrationRepository.GetByIdAsync(id);
            await _registrationRepository.DeleteAsync(registra);
        }

        public async Task<SaveRegistrationViewModel> GetByIdSaveViewModel(int id)
        {
            var registra = await _registrationRepository.GetByIdAsync(id);

            SaveRegistrationViewModel vm = new();

            vm.Id = registra.Id;
            vm.RegistrationDate = registra.RegistrationDate;
            vm.UserId = registra.UserId;
            vm.ActivityId = registra.ActivityId;

            return vm;
        }

        public async Task<List<RegistrationViewModel>> GetAllViewModel()
        {
            var regitratList = await _registrationRepository.GetAllAsync();

            return regitratList.Select(registra => new RegistrationViewModel
            {
                Id = registra.Id,
                RegistrationDate = registra.RegistrationDate,
                UserId = registra.UserId,
                ActivityId = registra.ActivityId

            }).ToList();
        }
    }
}
