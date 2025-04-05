using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyProject.Web.Models;
using MyProject.Web.Models.Dto;
using MyProject.Web.Services.IServices;
using MyProject.Web.Utility;
using Newtonsoft.Json;

namespace MyProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _ProductService;

        public HomeController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        public async Task<IActionResult> Index()
        {
            List<InfoProductDto> listData = new List<InfoProductDto>();
            var response = await _ProductService.GetListProduct<APIResponse>();

            if (SolutionModule.CheckResponse(response))
            {
                listData = SolutionModule.ConvertJsonToObject<List<InfoProductDto>>(response.Result);
                return View(listData);
            }
            return View(listData);
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
