using AutoMapper;
using FinalProject.Business.DTOs.ReservationDTOs;
using FinalProject.Business.DTOs.TableDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Data.DAL;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
	public class ReservationController : Controller
	{
		private readonly IReservationService _reservationService;
		private readonly IMapper _mapper;
		private readonly ITableService _tableService;
		private readonly AppDbContext _appDbContext;

		public ReservationController(IReservationService reservationService, IMapper mapper, ITableService tableService, AppDbContext appDbContext)
		{
			_reservationService = reservationService;
			_mapper = mapper;
			_tableService = tableService;
			_appDbContext = appDbContext;
		}

		public  IActionResult Index()
		{
			var tables =  _tableService.GetAllTables();
			ViewBag.Tables=tables;
			return View();
		}

		
		public IActionResult Reserv(ReservationCreateDTO reservation)/*, string? search, int? minPrice, int? maxPrice, int? personCount, DateTime? arrive, DateTime? departure)*/
		{
			
			_reservationService.AddAsyncReservation(reservation, ModelState, ViewBag);



			return RedirectToAction("Index","Reservation");
			
		}





	}
}
