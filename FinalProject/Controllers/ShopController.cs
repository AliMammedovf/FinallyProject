using FinalProject.Business.Services.Abstarct;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

		public ShopController(ICategoryService categoryService, IProductService productService)
		{
			_categoryService = categoryService;
			_productService = productService;
		}

		public IActionResult Index()
        {
            var category= _categoryService.GetAllCategories();
            
            var products= _productService.GetAllProducts();

            HomeVM vm = new HomeVM()
            {
                Categories = category,
                Products = products
            };

            return View(vm);
        }

		
	}
}
