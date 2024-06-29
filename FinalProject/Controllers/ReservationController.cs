using AutoMapper;
using FinalProject.Business.DTOs.TableDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
	public class ReservationController : Controller
	{
		private readonly IReservationService _reservationService;
		private readonly IMapper _mapper;
		private readonly ITableService _tableService;

        public ReservationController(IReservationService reservationService, IMapper mapper, ITableService tableService)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            _tableService = tableService;
        }

        public IActionResult Index()
		{
			return View();
		}

		public IActionResult Reserv(string? search, int? price, int? seats, DateTime? arrive, DateTime? departure)
		{

			var table = _tableService.GetAllTables().AsQueryable();

			if(!string.IsNullOrEmpty(search) )
			{
				table= table.Where(x=>x.Title.ToLower().Contains(search.ToLower()));
			}

			if (price.HasValue)
			{
				table = table.Where(x => x.Price == price);
			}

			if (seats.HasValue)
			{
				table= table.Where(x=>x.Seats == seats);
			}

			if(arrive.HasValue && departure.HasValue)
			{
				table = table.Where(table => table.Reservations.Any(reservation =>
				    (reservation.StartDate <= departure && reservation.EndDate >= departure)
			    ));
			}


			List<TableGetDTO> tableGetDTOs= _mapper.Map<List<TableGetDTO>>(table);

			ResservationVM tableVM = new ResservationVM()
			{
				Tables = tableGetDTOs,
			};

			return View(tableVM);
			
		}





	}
}
