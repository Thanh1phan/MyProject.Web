using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MyProject.Web.Models;
using MyProject.Web.Models.Dto;
using MyProject.Web.Services.IServices;
using MyProject.Web.Utility;
using static MyProject.Web.Utility.CConst;

namespace MyProject.Web.Services
{
    public class ProductService : IProductService
    {
        private string _url;
        private IBaseService _baseService;
        public ProductService(IConfiguration configuration, IBaseService baseService)
        {
            _url = configuration.GetValue<string>("ServiceUrls:UrlAPI");
            _baseService = baseService;
        }

        public async Task<T> CreateProduct<T>(ProductCreateDto createDto)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.POST,
                Data = createDto,
                Url = _url + "/api/Product/Create",
                ContentType = ContentType.MultipartFormData
                
            });
        }

        public async Task<T> DeleteProduct<T>(Guid id)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.DELETE,
                Url = _url + "/api/Product/Delete/" + id,
            });
        }

        public async Task<T> GetAllCategories<T>()
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.GET,
                Url = _url + "/api/Product/GetAllCategories",
            });
        }

        public async Task<T> GetListProduct<T>(string keyword = null)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.GET,
                Url = _url + "/api/Product/GetList",
            });
        }

        public async Task<T> GetProduct<T>(Guid id)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.GET,
                Url = _url + "/api/Product/Get/" + id,
            });
        }

        public async Task<T> UpdateProduct<T>(ProductUpdateDto updateDto)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.PUT,
                Data = updateDto,
                Url = _url + "/api/Product/Update",
                ContentType = ContentType.MultipartFormData
            });
        }

        public async Task<T> GetProductToUpdate<T>(Guid id)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.GET,
                Url = _url + "/api/Product/Update/" + id,
            });
        }
    }
}
