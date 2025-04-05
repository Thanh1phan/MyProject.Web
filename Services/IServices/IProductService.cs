using MyProject.Web.Models.Dto;
using System.Threading.Tasks;

namespace MyProject.Web.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetProduct<T>(Guid id);
        Task<T> GetListProduct<T>(string keyword = null);
        Task<T> DeleteProduct<T>(Guid id);
        Task<T> CreateProduct<T>(ProductCreateDto createDto);
        Task<T> UpdateProduct<T>(ProductUpdateDto updateDto);
        Task<T> GetProductToUpdate<T>(Guid id);
        Task<T> GetAllCategories<T>();
    }
}
