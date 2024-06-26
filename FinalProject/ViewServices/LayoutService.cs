
using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.ViewModels;

namespace FinalProject.ViewServices;

public class LayoutService
{
	private readonly IBasketItemService _basketItemService;

	public LayoutService(IBasketItemService basketItemService)
	{
		_basketItemService = basketItemService;
	}

	public IEnumerable<BasketItem> GetBasketItems()
	{
		return _basketItemService.GetAllBasketItems();
	}
}
