using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class KomboMenyuController : Controller
	{

		private readonly IKomboMenyuService _komboMenyuService;

		public KomboMenyuController(IKomboMenyuService komboMenyuService)
		{
			_komboMenyuService = komboMenyuService;
		}

		public IActionResult Index()
		{
			var menyu= _komboMenyuService.GetAllMenyus();
			return View(menyu);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(KomboMenyu menyu)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
			  await	_komboMenyuService.AddAsyncKomboMenyu(menyu);
			}
			catch (EntityNotFoundException ex)
			{
				ModelState.AddModelError("Title", ex.Message);
				return View();
			}
			catch (DuplicateEntityException ex)
			{
				ModelState.AddModelError("Title", ex.Message);
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
			var exsist = _komboMenyuService.GetMenyu(x => x.Id == id);

			if (exsist == null)
			{
				return NotFound();
			}

			_komboMenyuService.DeleteKomboMenyu(id);

			return Ok(exsist);


		}



		public IActionResult Update(int id)
		{
			var oldMenyu = _komboMenyuService.GetMenyu(x => x.Id == id);

			if (oldMenyu == null)
			{
				return NotFound();
			}

			return View(oldMenyu);
		}

		[HttpPost]
		public IActionResult Update(KomboMenyu menyu)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				_komboMenyuService.UpdateKomboMenyu(menyu);
			}
			catch (EntityNotFoundException ex)
			{
				ModelState.AddModelError("Title", ex.Message);
				return View();
			}
			catch (DuplicateEntityException ex)
			{
				ModelState.AddModelError("Title", ex.Message);
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
