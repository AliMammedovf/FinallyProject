using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Models;

public class Table:BaseEntity
{
	public string Title {  get; set; }

	public decimal Price { get; set; }

	public int Seats { get; set; }

	public List<Reservation> Reservations { get; set; }
}
