using MyProject.Web.Models.Dto;

namespace MyProject.Web.Services.IServices
{
    public interface ITokenProvider
    {
        void SetToken(TokenDto tokenDto);
        TokenDto? GetToken();
        void ClearToken();
    }
}
