using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.TableDTOs;

public class TableGetDTO
{
	public int Id { get; set; }
	public string Title { get; set; }

	public decimal Price { get; set; }

	public int Seats { get; set; }

	public bool IsAvialable { get; set; }

	public int TableId { get; set; }

	public List<Reservation>? Reservations { get; set; }
}
