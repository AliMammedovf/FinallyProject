using FinalProject.Business.Exceptions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Concret;

public class BasketItemService:IBasketItemService
{
	private readonly IBasketItemRepository _basketItemRepository;

	public BasketItemService(IBasketItemRepository basketItemRepository)
	{
		_basketItemRepository = basketItemRepository;
	}

	public async Task AddAsyncBasketItemAsync(BasketItem basketItem)
	{
		await _basketItemRepository.AddAsync(basketItem);
		await _basketItemRepository.CommitAsync();
	}

	public void DeleteBasketItem(int id)
	{
		var existBasketItem = _basketItemRepository.Get(x => x.Id == id);

		if (existBasketItem == null)
			throw new EntityNotFoundException("Basket Item tapilmadi!");

		_basketItemRepository.Delete(existBasketItem);
	}

	public IEnumerable<BasketItem> GetAllBasketItems(Func<BasketItem, bool>? func = null)
	{
		return _basketItemRepository.GetAll(func,"Product");
	}

	public BasketItem GetBasketItem(Func<BasketItem, bool>? func = null)
	{
		return _basketItemRepository.Get(func, "Product");
	}

	public void UpdateBasketItem(int id, BasketItem newBasketItem)
	{
		var existBasketItem = _basketItemRepository.Get(x => x.Id == id);

		if (existBasketItem == null)
			throw new EntityNotFoundException("Basket item tapilmadi!");

		
		existBasketItem.ProductId = newBasketItem.ProductId;
		existBasketItem.AppUserId = newBasketItem.AppUserId;
		existBasketItem.Count = newBasketItem.Count;

		_basketItemRepository.Commit();
	}

	
}
