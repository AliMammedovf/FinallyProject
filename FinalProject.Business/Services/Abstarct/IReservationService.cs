using FinalProject.Business.DTOs.ReservationDTOs;
using FinalProject.Core.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public interface IReservationService
{
	Task<bool> AddAsyncReservation(ReservationCreateDTO reservationCreateDTO,ModelStateDictionary ModelState,dynamic ViewBag);
	
	ReservationGetDTO GetReservation(Func<Reservation, bool>? func = null);
	List<ReservationGetDTO> GetAllReservations(Func<Reservation, bool>? func = null);
}
