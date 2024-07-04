using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.ReservationDTOs;

public class ReservationGetDTO
{
	public int Id { get; set; }
	public string Email { get; set; } = null!;
	public string Phone { get; set; } = null!;
	public int TableId { get; set; }

	public string Comments { get; set; }

	public DateTime? StartDate { get; set; }
	public DateTime? EndDate { get; set; }

	public List<Reservation> Reservations { get; set; }

	
}
