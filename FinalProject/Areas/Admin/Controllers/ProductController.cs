using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Business.Services.Concret;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IFlavourService _flavourService;
        private readonly ISizeService _sizeService;


        public ProductController(IProductService productService, ICategoryService categoryService, IFlavourService flavourService, ISizeService sizeService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _flavourService = flavourService;
            _sizeService = sizeService;
        }


        public IActionResult Index()
        {
            var products= _productService.GetAllProducts(); 
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Category= _categoryService.GetAllCategories();
            ViewBag.Size= _sizeService.GetAllSizes();
            ViewBag.Flavour= _flavourService.GetAllFlavours();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
        {
            ViewBag.Category = _categoryService.GetAllCategories();
            ViewBag.Size = _sizeService.GetAllSizes();
            ViewBag.Flavour = _flavourService.GetAllFlavours();

            if (!ModelState.IsValid)
                return View();

           await  _productService.AddAsyncProduct(productCreateDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Category = _categoryService.GetAllCategories();
            ViewBag.Size = _sizeService.GetAllSizes();
            ViewBag.Flavour = _flavourService.GetAllFlavours();

            var exsist = _productService.GetProduct(x => x.Id == id);

            if (exsist == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id);

            return Ok(exsist);
        }

        public IActionResult Update(int id)
        {
            ProductUpdateDTO productUpdateDTO = new ProductUpdateDTO();

            ViewBag.Category = _categoryService.GetAllCategories();
            ViewBag.Size = _sizeService.GetAllSizes();
            ViewBag.Flavour = _flavourService.GetAllFlavours();

            var exsistProduct = _productService.GetProduct(x => x.Id == id);

            if (exsistProduct == null)
            {
                return NotFound();
            }

            productUpdateDTO.Title = exsistProduct.Title;
            productUpdateDTO.Description = exsistProduct.Description;
            productUpdateDTO.AdditionalInfo = exsistProduct.AdditionalInfo;
            productUpdateDTO.Price = exsistProduct.Price;
            productUpdateDTO.IsAvialable= exsistProduct.IsAvialable;
            productUpdateDTO.CategoryId= exsistProduct.Category.Id;
            productUpdateDTO.FlavourId= exsistProduct.Flavour.Id;
            
            
            return View(productUpdateDTO);
        }

        [HttpPost]
        public IActionResult Update(ProductUpdateDTO productUpdateDTO)
        {
            ViewBag.Category = _categoryService.GetAllCategories();
            ViewBag.Size = _sizeService.GetAllSizes();
            ViewBag.Flavour = _flavourService.GetAllFlavours();

            if (!ModelState.IsValid)
                return View();

            _productService.UpdaterProduct(productUpdateDTO);
            return RedirectToAction("Index");
        }
    }
}
