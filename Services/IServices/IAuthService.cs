using MyProject.Web.Models.Dto;

namespace MyProject.Web.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDto objToCreate);
        Task<T> RegisterAsync<T>(RegisterationDto objToCreate);
        Task<T> LogoutAsync<T>(TokenDto objLogout);
    }
}
