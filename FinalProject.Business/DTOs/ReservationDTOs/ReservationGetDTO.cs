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
	public int ProductId { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public bool IsDeleted { get; set; }
	public Reservation Reservation { get; set; }
}
