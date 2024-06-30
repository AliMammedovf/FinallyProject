using FinalProject.Business.DTOs.AboutInfoDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Services.Abstarct;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
	public class AboutInfoController : Controller
	{

		private readonly IAboutInfoService _aboutInfoService;

		public AboutInfoController(IAboutInfoService aboutInfoService)
		{
			_aboutInfoService = aboutInfoService;
		}

		public IActionResult Index()
		{
			var info= _aboutInfoService.GetAllAboutInfos();
			return View(info);
		}


		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(AboutInfoCreateDTO aboutInfoCreateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				await _aboutInfoService.AddAboutInfoAsync(aboutInfoCreateDTO);
			}
			catch (EntityNotFoundException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				ModelState.AddModelError("FonImage", ex.Message);
				return View();
			}
			catch (ImageContentTypeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				ModelState.AddModelError("FonImage", ex.Message);
				return View();
			}
			catch (ImageSizeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				ModelState.AddModelError("FonImage", ex.Message);
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
				_aboutInfoService.DeleteAboutInfo(id);
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
			var existInfo = _aboutInfoService.GetAboutInfo(x => x.Id == id);

			var updateDto = new AboutInfoUpdateDTO();

			if (existInfo == null)
				return NotFound();

			updateDto.Description = existInfo.Description;
			updateDto.Title = existInfo.Title;
			


			return View(updateDto);
		}

		[HttpPost]
		public IActionResult Update(AboutInfoUpdateDTO aboutInfoUpdateDTO)
		{

			if (!ModelState.IsValid)
				return View();

			try
			{
				_aboutInfoService.UpdateAboutInfo(aboutInfoUpdateDTO);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound();
			}
			catch (ImageContentTypeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				ModelState.AddModelError("FonImage", ex.Message);
				return View();
			}
			catch (ImageSizeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				ModelState.AddModelError("FonImage", ex.Message);
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
