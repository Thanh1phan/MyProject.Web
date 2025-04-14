using MyProject.Web.Models.Dto;

namespace MyProject.Web.Services.IServices
{
    public interface IOrderService
    {
        Task<T> CreateOrder<T>(OrderCreateDto order);
    }
}
