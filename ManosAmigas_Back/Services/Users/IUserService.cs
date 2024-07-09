using ManosAmigas_Back.Models.Request;
using ManosAmigas_Back.Models.Response;

namespace ManosAmigas_Back.Services.Users
{
    public interface IUserService
    {
        Task<UserResponse> AuthUser(UserAuthRequest model);

    }
}
