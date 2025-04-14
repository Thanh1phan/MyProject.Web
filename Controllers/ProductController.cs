using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject.Web.Models;
using MyProject.Web.Models.Dto;
using MyProject.Web.Models.ViewModels;
using MyProject.Web.Services.IServices;
using MyProject.Web.Utility;

namespace MyProject.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            List<InfoProductDto> listData = new List<InfoProductDto>();
            var response = await _productService.GetListProduct<APIResponse>();
            if (SolutionModule.CheckResponse(response))
            {
                listData = SolutionModule.ConvertJsonToObject<List<InfoProductDto>>(response.Result);
            }
            return View(listData);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct<APIResponse>(model.Product);
                if (SolutionModule.CheckResponse(response))
                {
                    TempData["success"] = "Product created successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Error encountered.";
                }
            }

            var categories = await _productService.GetAllCategories<APIResponse>();
            if (SolutionModule.CheckResponse(categories))
            {
                model.CategoryList = SolutionModule.ConvertJsonToObject<IEnumerable<CategoryDto>>(categories.Result)
                       .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            }
            
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await _productService.UpdateProduct<APIResponse>(model.Product);
            if (SolutionModule.CheckResponse(response))
            {
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _productService.DeleteProduct<APIResponse>(id);
            if (SolutionModule.CheckResponse(response))
            {
                TempData["success"] = "Product deleted successfully";
            }
            else
            {
                TempData["error"] = "Error encountered.";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(Guid id)
        {
            var response = await _productService.GetProductToUpdate<APIResponse>(id);
            if (SolutionModule.CheckResponse(response))
            {
                var data = SolutionModule.ConvertJsonToObject<DetailProductDto>(response.Result);
                var productUpdateVM = new ProductUpdateVM()
                {
                    Product = new ProductUpdateDto()
                    {
                        Id = data.Id,
                        B3Id = data.B3Id,
                        Name = data.Name,
                        ZIBAIKA = data.ZIBAIKA,
                        ZOBAIKA = data.ZOBAIKA,
                        ListUrlImage = data.ListUrlImage
                        
                    },
                    CategoryList = data.Categories.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name })
                };
                return View(productUpdateVM);
            }
            TempData["error"] = "Error encountered.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create()
        {
            var model = new ProductCreateVM();
            var response = await _productService.GetAllCategories<APIResponse>();
            if (SolutionModule.CheckResponse(response))
            {
                model.CategoryList = SolutionModule.ConvertJsonToObject<IEnumerable<CategoryDto>>(response.Result)
                       .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
                return View(model);
            }
            TempData["error"] = "Error encountered.";
            return RedirectToAction("Index");
        }
    }
}
