using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Core.Models;

namespace FinalProject.ViewModels;

public class CheckOutVM
{
	public Product Product { get; set; }

	public int Count { get; set; }
}
