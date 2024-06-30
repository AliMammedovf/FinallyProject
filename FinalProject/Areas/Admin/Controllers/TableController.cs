using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.DTOs.TableDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Business.Services.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class TableController : Controller
	{
		private readonly ITableService _tableService;

		public TableController(ITableService tableService)
		{
			_tableService = tableService;
		}

		public IActionResult Index()
		{
			var table= _tableService.GetAllTables();
			return View(table);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(TableCreateDTO tableCreateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{

				await _tableService.AddAsyncTable(tableCreateDTO);
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
			var exsist = _tableService.GetTable(x => x.Id == id);

			if (exsist == null)
			{
				return NotFound();
			}
			_tableService.DeleteTable(id);

			return Ok(exsist);


		}



		public IActionResult Update(int id)
		{
			var oldTable = _tableService.GetTable(x => x.Id == id);

			if (oldTable == null)
			{
				return NotFound();
			}

			return View(oldTable);
		}

		[HttpPost]
		public IActionResult Update(TableUpdateDTO tableUpdateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				_tableService.UpdateTable(tableUpdateDTO);
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
