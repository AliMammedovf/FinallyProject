using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct
{
	public interface ICheckOutService
	{
		public List<CheckOut> GetAllCheckOutVM(Func<CheckOut,bool>? func=null);
	}

	public class CheckOut
	{
		public Product Product { get; set; }

		public int Count { get; set; }
	}
}
