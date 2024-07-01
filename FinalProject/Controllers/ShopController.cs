using AutoMapper;
using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Business.Extensions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Data.DAL;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        private readonly AppDbContext _appDbContext;


		public ShopController(ICategoryService categoryService, IProductService productService, AppDbContext appDbContext, IMapper mapper)
		{
			_categoryService = categoryService;
			_productService = productService;
			_appDbContext = appDbContext;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index(int page=1)
        {
            var category= _categoryService.GetAllCategories();

			var datas = _productService.GetAllProducts();

			List<Product> productGetDtos = _mapper.Map<List<Product>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)productGetDtos.Count / 2))
            {
                return RedirectToAction("Error","Home");
            }

            var paginatedDatas = PaginatedList<Product>.Create(productGetDtos, 6, page);
            ShopVM vm = new ShopVM()
            {
                Categories = category,
                PaginatedProduct = paginatedDatas
            };

            return View(vm);
        }

        public IActionResult CategoryFilter(int? categoryId)
        {
            var category = _categoryService.GetAllCategories();
            List<ProductGetDTO> products = new List<ProductGetDTO>();
            
            if (categoryId != null)
            {
				products = _productService.GetAllProducts(x => x.Category.Id == categoryId);

				

			}
            else
            {
				products = _productService.GetAllProducts();
			}
                

            ShopVM vm = new ShopVM()
            {
                Categories = category,
                Products = products
            };
            return View(vm);
        }




    }
}
