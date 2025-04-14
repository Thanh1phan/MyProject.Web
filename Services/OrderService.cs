using Microsoft.AspNetCore.Http.HttpResults;
using MyProject.Web.Models;
using MyProject.Web.Models.Dto;
using MyProject.Web.Services.IServices;
using static MyProject.Web.Utility.CConst;

namespace MyProject.Web.Services
{
    public class OrderService : IOrderService
    {
        private string _url;
        private IBaseService _baseService;
        public OrderService(IConfiguration configuration, IBaseService baseService)
        {
            _url = configuration.GetValue<string>("ServiceUrls:UrlAPI");
            _baseService = baseService;
        }
        public async Task<T> CreateOrder<T>(OrderCreateDto order)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.POST,
                Data = order,
                Url = _url + "/api/Order/Create"
            });
        }
    }
}
