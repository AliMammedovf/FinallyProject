using FinalProject.Business.DTOs.AboutSliderDTOs;
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
    public class AboutSliderController : Controller
	{
		private readonly IAboutSliderService _aboutSliderService;

		public AboutSliderController(IAboutSliderService aboutSliderService)
		{
			_aboutSliderService = aboutSliderService;
		}

		public IActionResult Index()
		{
			var sliders= _aboutSliderService.GetAllAboutSliders();
			return View(sliders);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(AboutSliderCreateDTO aboutSliderCreateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				await _aboutSliderService.AddAboutSliderAsync(aboutSliderCreateDTO);
			}
			catch (EntityNotFoundException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				ModelState.AddModelError("IconImage", ex.Message);
				return View();
			}
			catch (ImageContentTypeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				ModelState.AddModelError("IconImage", ex.Message);
				return View();
			}
			catch (ImageSizeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				ModelState.AddModelError("IconImage", ex.Message);
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
				_aboutSliderService.DeleteAboutSlider(id);
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


		public IActionResult Update(int id)
		{
			var existSlider = _aboutSliderService.GetAboutSlider(x => x.Id == id);

			var updateDto = new AboutSliderUpdateDTO();

			if (existSlider == null)
				return NotFound();

			updateDto.Description = existSlider.Description;
			updateDto.Title = existSlider.Title;
			updateDto.RedirectUrl = existSlider.RedirectUrl;
			updateDto.Text = existSlider.Text;


			return View(updateDto);
		}

		[HttpPost]
		public IActionResult Update(AboutSliderUpdateDTO aboutSliderUpdateDTO)
		{

			if (!ModelState.IsValid)
				return View();

			try
			{
				_aboutSliderService.UpdateAboutSlider(aboutSliderUpdateDTO);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound();
			}
			catch (ImageContentTypeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				ModelState.AddModelError("IconImage", ex.Message);
				return View();
			}
			catch (ImageSizeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				ModelState.AddModelError("IcoImage", ex.Message);
				return View();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return RedirectToAction("Index");
		}
	}
}
