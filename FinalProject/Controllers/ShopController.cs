using FinalProject.Business.Services.Abstarct;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICategoryService _categoryService;

		public ShopController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IActionResult Index()
        {
            var category= _categoryService.GetAllCategories();

            HomeVM vm = new HomeVM()
            {
                Categories = category,
            };

            return View(vm);
        }
    }
}
