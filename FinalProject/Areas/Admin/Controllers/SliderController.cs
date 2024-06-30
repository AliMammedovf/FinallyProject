using FinalProject.Business.DTOs.SliderDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Services.Abstarct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class SliderController : Controller
	{
		private readonly ISliderService _sliderService;

		public SliderController(ISliderService sliderService)
		{
			_sliderService = sliderService;
		}

		public IActionResult Index()
		{
			var slider= _sliderService.GetAllSliders();
			return View(slider);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(SliderCreateDTO sliderCreateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				await _sliderService.AddSliderAsync(sliderCreateDTO);
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
			var existSlider = _sliderService.GetSlider(x => x.Id == id);

			var updateDto = new SliderUpdateDTO();

			if (existSlider == null)
				return NotFound();

			updateDto.Description = existSlider.Description;
			updateDto.Title = existSlider.Title;
			updateDto.RedirectUrl = existSlider.RedirectUrl;
			

			return View(updateDto);
		}

		[HttpPost]
		public IActionResult Update(SliderUpdateDTO sliderUpdateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				_sliderService.UpdateSlider(sliderUpdateDTO);
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
				_sliderService.DeleteSlider(id);
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
