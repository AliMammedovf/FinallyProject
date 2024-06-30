
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
        private readonly ISliderService _sliderService;
        private readonly IAboutSliderService _aboutSliderService;
        private readonly IPizzaMenyuService _pizzaMenyuService;
        private readonly IEmployeeService _employeeService;
        private readonly ISetMenyuHeaderService _setMenyuHeaderService;
        private readonly IKomboMenyuService _komboMenyuService;

        public HomeController(IProductService productService, ISizeService sizeService, IFlavourService favourService, ISliderService sliderService, IAboutSliderService aboutSliderService, IPizzaMenyuService pizzaMenyuService, IEmployeeService employeeService, ISetMenyuHeaderService setMenyuHeaderService, IKomboMenyuService komboMenyuService)
        {
            _productService = productService;
            _sizeService = sizeService;
            _favourService = favourService;
            _sliderService = sliderService;
            _aboutSliderService = aboutSliderService;
            _pizzaMenyuService = pizzaMenyuService;
            _employeeService = employeeService;
            _setMenyuHeaderService = setMenyuHeaderService;
            _komboMenyuService = komboMenyuService;
        }

        public IActionResult Index()
        {
            var products= _productService.GetAllProducts();
            var sliders= _sliderService.GetAllSliders();
            var aboutSlider = _aboutSliderService.GetAboutSlider();
            var menyu= _pizzaMenyuService.GetAllPizzaMenyus();
            var employer= _employeeService.GetAllEmployees();
            var menyuheader= _setMenyuHeaderService.GetAllSetMenyuHeaders();
            var komboMenyu = _komboMenyuService.GetAllMenyus();

            HomeVM vm = new HomeVM()
            {
                Products =products,
                Sliders = sliders,
                AboutSlider = aboutSlider,
                PizzasMenyu = menyu,
                Employees=employer,
                SetMenyuHeader = menyuheader,
                KomboMenyu= komboMenyu,
            };
            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            ViewBag.Sizes = _sizeService.GetAllSizes();
            ViewBag.Flavours = _favourService.GetAllFlavours();
            var product = _productService.GetProduct(x => x.Id == id);
            var products = _productService.GetAllProducts();


            if (product == null) return RedirectToAction("Error");

            HomeVM vm = new HomeVM()
            {
                Product = product,
                Products = products,
            };

            return View(vm);
        }

        public IActionResult Error()
        {

           return View(); 
        }



	}
}
