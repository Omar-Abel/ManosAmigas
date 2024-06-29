using ManosAmigas_Back.Sources.Application.ViewModels.Users;

namespace ManosAmigas_Back.Sources.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel>
    {
    }
}
