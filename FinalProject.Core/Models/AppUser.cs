using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Models;

public class AppUser:IdentityUser
{
	public string FullName { get; set; }

	public List<BasketItem> BasketItems { get; set; }

	public List<Order> Order { get; set; }
}
