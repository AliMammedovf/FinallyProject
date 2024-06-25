using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
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
            //IEnumerable<ProductGetDTO> products = new List<ProductGetDTO>();
            //if (categoryId != null)
            //    products = _productService.GetAllProducts(x=>x.CategoryId == categoryId);
            //else
            var products = _productService.GetAllProducts();

            HomeVM vm = new HomeVM()
            {
                Categories = category,
                Products = products
            };

            return View(vm);
        }

        public IActionResult CategoryFilter(int? categoryId)
        {
			var category = _categoryService.GetAllCategories();
			IEnumerable<ProductGetDTO> products = new List<ProductGetDTO>();
            if (categoryId != null)
                products = _productService.GetAllProducts(x => x.Category.Id==categoryId);
            else
                products = _productService.GetAllProducts();

			HomeVM vm = new HomeVM()
			{
				Categories = category,
				Products = products
			};
            			return View(vm);
		}

		
	}
}
