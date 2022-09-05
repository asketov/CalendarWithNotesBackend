using System.Threading.Tasks;
using Core;
using InterfacesServices.ApiModels;

namespace InterfacesServices
{
    public interface IUserService
    {
        Task<LoginResponse> Authenticate(LoginRequest model);
        Task<LoginResponse> Register(RegisterUser userModel);
        Task<User> GetById(int id);
    }
}
