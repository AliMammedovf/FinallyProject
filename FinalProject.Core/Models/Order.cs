using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Models;

public class Order : BaseEntity
{
    public string FullName { get; set; }

    public string Address { get; set; }

    public string Country { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string PostCode { get; set; }

    public decimal? TotalPrice { get; set; }

    public string AppUserId { get; set; }

    public AppUser AppUser { get; set; }

    public List<OrderItem> OrdeerItems { get; set; }
}
