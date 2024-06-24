using FinalProject.Business.Services.Abstarct;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
	public class ContactController : Controller
	{


        public IActionResult Index()
		{

          
			return View();
		}
	}
}
