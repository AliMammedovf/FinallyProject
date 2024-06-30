using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
	public class AboutController : Controller
	{
		private readonly IAboutSliderService _aboutSliderService;
		private readonly IPizzaMenyuService _pizzaMenyuService;
		private readonly IEmployeeService _employeeService;
		private readonly IAboutInfoService _aboutInfoService;

        public AboutController(IAboutSliderService aboutSliderService, IPizzaMenyuService pizzaMenyuService, IEmployeeService employeeService, IAboutInfoService aboutInfoService)
        {
            _aboutSliderService = aboutSliderService;
            _pizzaMenyuService = pizzaMenyuService;
            _employeeService = employeeService;
            _aboutInfoService = aboutInfoService;
        }


        public IActionResult Index()
		{
			var aboutSlider = _aboutSliderService.GetAboutSlider();
			var menyu = _pizzaMenyuService.GetAllPizzaMenyus();
			var employer = _employeeService.GetAllEmployees();
			var info= _aboutInfoService.GetAllAboutInfos();

			AboutVM aboutVM = new AboutVM()
			{
				AboutSlider = aboutSlider,
				PizzasMenyu = menyu,
				Employees = employer,
				AboutInfo = info
			};

			return View(aboutVM);
		}

		public IActionResult Team()
		{
			var employer = _employeeService.GetAllEmployees();

			AboutVM vm = new AboutVM()
			{
				
				Employees = employer
			};
			return View(vm);
		}
	}
}
