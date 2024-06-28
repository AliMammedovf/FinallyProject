using FinalProject.Business.DTOs.ReservationDTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public interface IReservationService
{
	Task AddAsyncReservation(ReservationCreateDTO reservationCreateDTO);
	
	ReservationGetDTO GeTReservation(Func<Reservation, bool>? func = null);
	List<ReservationGetDTO> GetAllReservations(Func<Reservation, bool>? func = null);
}
