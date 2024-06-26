using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public interface IBasketItemService
{
	Task AddAsyncBasketItemAsync(BasketItem basketItem);
	void DeleteBasketItem(int id);
	void UpdateBasketItem(int id, BasketItem newBasketItem);
	BasketItem GetBasketItem(Func<BasketItem, bool>? func = null);
	List<BasketItem> GetAllBasketItems(Func<BasketItem, bool>? func = null);
}
