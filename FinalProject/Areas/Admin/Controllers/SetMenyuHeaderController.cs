using FinalProject.Business.DTOs.SetMenyuHeaderDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Business.Services.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class SetMenyuHeaderController : Controller
	{
		private readonly ISetMenyuHeaderService _setMenyuHeaderService;

		public SetMenyuHeaderController(ISetMenyuHeaderService setMenyuHeaderService)
		{
			_setMenyuHeaderService = setMenyuHeaderService;
		}

		public IActionResult Index()
		{
			var header= _setMenyuHeaderService.GetAllSetMenyuHeaders();
			return View(header);
		}


		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(SetMenyuHeaderCreateDTO setMenyuHeaderCreateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				await _setMenyuHeaderService.AddSetMenyuHeaderAsync(setMenyuHeaderCreateDTO);
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
			var existSetMenyuHeader = _setMenyuHeaderService.GetHeaderMenyu(x => x.Id == id);

			var updateDto = new SetMenyuHeaderUpdateDTO();

			if (existSetMenyuHeader == null)
				return NotFound();

			updateDto.Description = existSetMenyuHeader.Description;
			updateDto.Title = existSetMenyuHeader.Title;


			return View(updateDto);
		}

		[HttpPost]
		public IActionResult Update(SetMenyuHeaderUpdateDTO setMenyuHeaderUpdateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				_setMenyuHeaderService.UpdateSetMenyuHeader(setMenyuHeaderUpdateDTO);
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
				_setMenyuHeaderService.DeleteSetMenyuHeader(id);
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
