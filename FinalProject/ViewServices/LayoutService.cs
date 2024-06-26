
using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Data.DAL;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.ViewServices;

public class LayoutService
{
	private readonly IBasketItemService _basketItemService;
	private readonly AppDbContext _context;
	private readonly UserManager<AppUser> _userManager;
	private readonly IHttpContextAccessor _contextAccessor;

	public LayoutService(IBasketItemService basketItemService, AppDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor)
	{
		_basketItemService = basketItemService;
		_context = context;
		_userManager = userManager;
		_contextAccessor = contextAccessor;
	}

	public IEnumerable<BasketItem> GetBasketItems()
	{
		return _basketItemService.GetAllBasketItems();
	}

	public List<CheckOutVM> checks= new List<CheckOutVM>();

	public async Task<AppUser> GetUserData()
	{
		if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
		{
			return await _userManager.FindByNameAsync(_contextAccessor.HttpContext.User.Identity.Name);
		}
		return null;
	}
}
