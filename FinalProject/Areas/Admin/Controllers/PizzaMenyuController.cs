using FinalProject.Business.DTOs.PizzaMenyuDTOs;
using FinalProject.Business.DTOs.SliderDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Business.Services.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class PizzaMenyuController : Controller
    {
        private readonly IPizzaMenyuService _manyuService;

        public PizzaMenyuController(IPizzaMenyuService manyuService)
        {
            _manyuService = manyuService;
        }

        public IActionResult Index()
        {
            var menyu= _manyuService.GetAllPizzaMenyus();
            return View(menyu);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PizzaMenyuCreateDTO createDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _manyuService.AddPizzaMenyuAsync(createDTO);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (ImageContentTypeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (ImageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var existMenyu = _manyuService.GetPizzaMenyu(x => x.Id == id);

            var updateDto = new PizzaMenyuUpdateDTO();

            if (existMenyu == null)
                return NotFound();

            updateDto.Description = existMenyu.Description;
            updateDto.Title = existMenyu.Title;
            updateDto.Price = existMenyu.Price;


            return View(updateDto);
        }

        [HttpPost]
        public IActionResult Update(PizzaMenyuUpdateDTO menyuUpdateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _manyuService.UpdatePizzaMenyu(menyuUpdateDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (ImageContentTypeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (ImageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                _manyuService.DeletePizzaMenyu(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok();

        }


    }
}
