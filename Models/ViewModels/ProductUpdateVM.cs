using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject.Web.Models.Dto;

namespace MyProject.Web.Models.ViewModels
{
    public class ProductUpdateVM
    {
        public ProductUpdateVM()
        {
            Product = new();
        }

        public ProductUpdateDto Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
