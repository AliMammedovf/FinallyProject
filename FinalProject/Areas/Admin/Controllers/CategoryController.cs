using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Data.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
       

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
           
        }

        public IActionResult Index()
        {
            var category = _categoryService.GetAllCategories();
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTO categoryCreateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            await _categoryService.AddAsyncCategory(categoryCreateDTO);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var exsist= _categoryService.GetCategory(x=>x.Id==id);

            if (exsist == null)
            {
                return NotFound();
            }

            _categoryService.DeleteCategory(id);

            return Ok(exsist);
            

            

           
        }

        //[HttpPost]
        //public IActionResult DeletePost(int id)
        //{
        //    if (!ModelState.IsValid)
        //        return View();

        //    _categoryService.DeleteCategory(id);

        //    return Ok();
        //}

        public IActionResult Update(int id)
        {
            var oldCategory= _categoryService.GetCategory(x=> x.Id==id);    

            if(oldCategory == null)
            {
                return NotFound();
            }

            return View(oldCategory);
        }

        [HttpPost]
        public IActionResult Update(CategoryUpdateDTO categoryUpdateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            _categoryService.UpdateCategory(categoryUpdateDTO);
            return RedirectToAction("Index");
        }
    }
}
