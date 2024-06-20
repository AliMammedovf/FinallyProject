
using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

		public HomeController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
        {
            var products= _productService.GetAllProducts();
            HomeVM vm = new HomeVM()
            {
                Products =products
            };
            return View(vm);
        }

       
    }
}
