using AutoMapper;
using FinalProject.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
	public class ReservationController : Controller
	{
		public IActionResult Reserv()
		{
			return View();
		}

	}
}
