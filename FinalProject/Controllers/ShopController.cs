using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
	public class ShopController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
