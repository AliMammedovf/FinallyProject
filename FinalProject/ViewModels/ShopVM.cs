using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.DTOs.ProductDTOs;

namespace FinalProject.ViewModels;

public class ShopVM
{
	public IEnumerable<ProductGetDTO> Products { get; set; }

	public IEnumerable<CategoryGetDTO> Categories { get; set; }
}
