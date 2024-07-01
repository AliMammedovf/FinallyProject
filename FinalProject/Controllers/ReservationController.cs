using AutoMapper;
using FinalProject.Business.DTOs.ReservationDTOs;
using FinalProject.Business.DTOs.TableDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Data.DAL;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Stripe.Climate;
using Stripe;
using FinalProject.Business.Services.Concret;
using System.Net.Mail;

namespace FinalProject.Controllers
{
	public class ReservationController : Controller
	{
		private readonly IReservationService _reservationService;
		private readonly IMapper _mapper;
		private readonly ITableService _tableService;
		private readonly IEmailService _emailService;


		public ReservationController(IReservationService reservationService, IMapper mapper, ITableService tableService, IEmailService emailService)
		{
			_reservationService = reservationService;
			_mapper = mapper;
			_tableService = tableService;
			_emailService = emailService;
		}

		public  IActionResult Index()
		{
			var tables =  _tableService.GetAllTables();
			ViewBag.Tables=tables;
			return View();
		}

		

		[HttpPost]
		public async Task<IActionResult> Index(ReservationCreateDTO reservationCreateDTO)
		{
			AppUser user = new AppUser();

            var tables = _tableService.GetAllTables();
            ViewBag.Tables = tables;
            if (!ModelState.IsValid)
				return View();

            List<ReservationGetDTO> reservation = _reservationService.GetAllReservations();

			IEnumerable<ReservationGetDTO> reservationGetDTOs = reservation;
            

            if (reservationCreateDTO.StartDate.HasValue && reservationCreateDTO.EndDate.HasValue) 
            {
				reservationGetDTOs = reservationGetDTOs.Where(reserv => !reserv.Reservations.Any(reservation =>
					(reservation.StartDate <= reservationCreateDTO.EndDate && reservation.EndDate >= reservationCreateDTO.StartDate)
				));

                

            }


			await _reservationService.AddAsyncReservation(reservationCreateDTO);

			

			string emailBody = $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Reservation Confirmation</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            color: #333;
            margin: 0;
            padding: 0;
        }}
        .container {{
            width: 100%;
            max-width: 600px;
            margin: 0 auto;
            background-color: #ffffff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }}
        .header {{
            background-color: #007bff;
            color: #ffffff;
            padding: 10px 0;
            text-align: center;
        }}
        .content {{
            padding: 20px;
        }}
        .content h1 {{
            color: #007bff;
        }}
        .reservation-details {{
            margin: 20px 0;
        }}
        .reservation-details p {{
            margin: 5px 0;
        }}
        .footer {{
            text-align: center;
            padding: 10px;
            color: #888;
            font-size: 12px;
        }}
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""header"">
            <h1>Reservation Confirmation</h1>
        </div>
        <div class=""content"">
            <h1>Hello, {reservationCreateDTO.Email}</h1>
            <p>We are pleased to confirm your reservation. Here are the details:</p>
            <div class=""reservation-details"">
                <p><strong> Phone:</strong> {reservationCreateDTO.Phone}</p>
                <p><strong>StartDate:</strong> {reservationCreateDTO.StartDate}</p>
                <p><strong>EndDate:</strong> {reservationCreateDTO.EndDate}</p>
                <p><strong>Table:</strong>{reservationCreateDTO.TableId}</p>
            </div>
            <p>Thank you for choosing our service. We look forward to serving you!</p>
        </div>
        <div class=""footer"">
            <p>Thank you for your reservation!</p>
        </div>
    </div>
</body>
</html>



			";

			_emailService.SendEmail(reservationCreateDTO.Email, "Reservation made successfully!", emailBody);



			return RedirectToAction("Index","Reservation");
			
		}





	}
}
