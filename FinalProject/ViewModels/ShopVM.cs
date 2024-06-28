using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Business.Extensions;
using FinalProject.Core.Models;

namespace FinalProject.ViewModels;

public class ShopVM
{
	public IEnumerable<ProductGetDTO> Products { get; set; }

	public IEnumerable<CategoryGetDTO> Categories { get; set; }

	public PaginatedList<Product> PaginatedProduct= new PaginatedList<Product>();
}
