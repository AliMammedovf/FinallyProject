using FinalProject.Core.Models;

namespace FinalProject.ViewModels;

public class OrderVM
{
    //public List<CheckOutVM>? CheckOutVMs { get; set; }

    public string FullName { get; set; }


    public string Address { get; set; }

    public string Country { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string PostCode { get; set; }


    public int Total { get; set; }
}
