
using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISizeService _sizeService;
        private readonly IFlavourService _favourService;

        public HomeController(IProductService productService, ISizeService sizeService, IFlavourService favourService)
        {
            _productService = productService;
            _sizeService = sizeService;
            _favourService = favourService;
        }

        public IActionResult Index()
        {
            var products= _productService.GetAllProducts();
            HomeVM vm = new HomeVM()
            {
                Products =products,
            };
            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            ViewBag.Sizes= _sizeService.GetAllSizes();
            ViewBag.Flavours= _favourService.GetAllFlavours();
            var product= _productService.GetProduct(x=>x.Id==id);
            var products = _productService.GetAllProducts();


            if (product==null) return View("Error");

            HomeVM vm = new HomeVM()
            {
                Product = product,
                Products = products,
            };

            return View(vm);
        }

       
    }
}
