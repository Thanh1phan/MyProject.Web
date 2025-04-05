using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject.Web.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Web.Models.ViewModels
{
    public class ProductCreateVM
    {
        public ProductCreateVM()
        {
            Product = new();
        }
        [Required]
        public ProductCreateDto Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
