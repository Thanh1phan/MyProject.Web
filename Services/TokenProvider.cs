using MyProject.Web.Models.Dto;
using MyProject.Web.Services.IServices;
using MyProject.Web.Utility;

namespace MyProject.Web.Services
{
    public class TokenProvider : ITokenProvider
    {
        private IHttpContextAccessor _contextAccessor;

        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void ClearToken()
        {
            _contextAccessor.HttpContext?.Response.Cookies.Delete(CConst.AccessToken);
            _contextAccessor.HttpContext?.Response.Cookies.Delete(CConst.RefreshToken);
        }

        public TokenDto? GetToken()
        {
            try
            {
                bool hasAccessToken = _contextAccessor.HttpContext.Request.Cookies.TryGetValue(CConst.AccessToken, out string accessToken);
                bool hasRefreshToken = _contextAccessor.HttpContext.Request.Cookies.TryGetValue(CConst.RefreshToken, out string refreshToken);

                TokenDto tokenDto = new()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };
                return hasAccessToken ? tokenDto : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SetToken(TokenDto tokenDto)
        {
            var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(5) };
            _contextAccessor.HttpContext?.Response.Cookies.Append(CConst.AccessToken, tokenDto.AccessToken, cookieOptions);
            _contextAccessor.HttpContext?.Response.Cookies.Append(CConst.RefreshToken, tokenDto.RefreshToken, cookieOptions);
        }
    }
}
