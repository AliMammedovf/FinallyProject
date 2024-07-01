using FinalProject.Business.DTOs.ReservationDTOs;
using FinalProject.Business.DTOs.TableDTOs;
using FinalProject.Core.Models;

namespace FinalProject.ViewModels
{
	public class ResservationVM
	{
		public List<TableGetDTO> Tables {  get; set; }

		public List<ReservationGetDTO> Reservations { get; set; }

		public TableGetDTO Table { get; set; }

		public Reservation Reservation { get; set; }
        public ReservationCreateDTO res { get; set; }
    }
}
