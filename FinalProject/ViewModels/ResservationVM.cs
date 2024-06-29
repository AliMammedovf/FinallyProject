using FinalProject.Business.DTOs.ReservationDTOs;
using FinalProject.Business.DTOs.TableDTOs;

namespace FinalProject.ViewModels
{
	public class ResservationVM
	{
		public List<TableGetDTO> Tables = new List<TableGetDTO>();

		public List<ReservationGetDTO> Reservations = new List<ReservationGetDTO>();

		public TableGetDTO Table = new TableGetDTO();
	}
}
