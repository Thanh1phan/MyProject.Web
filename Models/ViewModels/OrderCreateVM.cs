using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MyProject.Web.Models.Dto;

namespace MyProject.Web.Models.ViewModels
{
    public class OrderCreateVM
    {
        [ValidateNever]
        public InfoProductDto Product { get; set; }
        
        public OrderCreateDto Order { get; set; }
    }
}
