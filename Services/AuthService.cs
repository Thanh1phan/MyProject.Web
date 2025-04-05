using MyProject.Web.Models;
using MyProject.Web.Models.Dto;
using MyProject.Web.Services.IServices;
using MyProject.Web.Utility;

namespace MyProject.Web.Services
{
    public class AuthService : IAuthService
    {
        private string _url;
        private IBaseService _baseService;
        public AuthService(IHttpClientFactory httpClient, IConfiguration configuration, IBaseService baseService)
        {
            _url = configuration.GetValue<string>("ServiceUrls:UrlAPI");
            _baseService = baseService;
        }

        public Task<T> LoginAsync<T>(LoginRequestDto obj)
        {
            return _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = CConst.ApiType.POST,
                Data = obj,
                Url = _url + "/api/User/login"
            }, false);
        }

        public Task<T> RegisterAsync<T>(RegisterationDto obj)
        {
            return _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = CConst.ApiType.POST,
                Data = obj,
                Url = _url + "/api/User/Register"
            }, false);
        }

        public async Task<T> LogoutAsync<T>(TokenDto objLogout)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = CConst.ApiType.POST,
                Data = objLogout,
                Url = _url + "/api/User/revoke"
            });
        }

    }
}
