using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Models
{
	public class BasketItem:BaseEntity
	{
		public string AppUserId { get; set; }
		public int ProductId { get; set; }
		
		public int Count { get; set; }
		public Product Product { get; set; }
		public AppUser AppUser { get; set; }

		
	}
}
