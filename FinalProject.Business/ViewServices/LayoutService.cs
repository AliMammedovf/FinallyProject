using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.ViewServices;

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
