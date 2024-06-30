using FinalProject.Business.DTOs.EmployeeDTOs;
using FinalProject.Business.DTOs.SliderDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Services.Abstarct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class EmployeeController : Controller
	{

		private readonly IEmployeeService _employeeService;

		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		public IActionResult Index()
		{
			var employer= _employeeService.GetAllEmployees();
			return View(employer);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(EmployeeCreateDTO employeeCreateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				await _employeeService.AddAsyncEmployee(employeeCreateDTO);
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
			var exsistEmployer = _employeeService.GetEmployee(x => x.Id == id);

			var updateDto = new EmployeeUpdateDTO();

			if (exsistEmployer == null)
				return NotFound();

			updateDto.FullName = exsistEmployer.FullName;
			updateDto.Profession = exsistEmployer.Profession;
			


			return View(updateDto);
		}

		[HttpPost]
		public IActionResult Update(EmployeeUpdateDTO employeeUpdateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				_employeeService.UpdateEmployee(employeeUpdateDTO);
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
				_employeeService.DeleteEmployee(id);
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
