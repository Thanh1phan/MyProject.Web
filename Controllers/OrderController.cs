using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Web.Models;
using MyProject.Web.Models.Dto;
using MyProject.Web.Models.ViewModels;
using MyProject.Web.Services.IServices;
using MyProject.Web.Utility;
using Org.BouncyCastle.Security;

namespace MyProject.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IProductService _productService;
        private APIResponse _response;
        public OrderController(IOrderService orderService, IProductService productService)
        { 
            _orderService = orderService;
            _productService = productService;
            _response = new APIResponse();
        }
        public async Task<IActionResult> Create(Guid id)
        {
            var viewModel = new OrderCreateVM();
            _response = await _productService.GetProduct<APIResponse>(id);

            if (!SolutionModule.CheckResponse(_response))
            {
                TempData["error"] = _response.ErrorMessages.FirstOrDefault();
                return RedirectToAction("Index", "Home");
            }
            var product = SolutionModule.ConvertJsonToObject<InfoProductDto>(_response.Result);
            viewModel.Product = product;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                _response = await _productService.GetProduct<APIResponse>(model.Order.M01CId);
                var product = SolutionModule.ConvertJsonToObject<InfoProductDto>(_response.Result);
                model.Product = product;
                return View(model);
            }

            _response = await _orderService.CreateOrder<APIResponse>(model.Order);
            if (!_response.IsSuccess)
            {
                _response = await _productService.GetProduct<APIResponse>(model.Order.M01CId);
                var product = SolutionModule.ConvertJsonToObject<InfoProductDto>(_response.Result);
                model.Product = product;
                TempData["error"] = "Error encountered.";
                return View(model);
            }
            TempData["success"] = "Order created successfully";
            return RedirectToAction("Index", "Home");
        }
    }
}
