using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using FinalProject.Data.DAL;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FinalProject.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly UserManager<AppUser> _userManager;
		private readonly IBasketItemService _basketItemService;
		private readonly AppDbContext _appDbContext;

		public ProductController(IProductService productService, UserManager<AppUser> userManager, IBasketItemService basketItemService, AppDbContext appDbContext)
		{
			_productService = productService;
			_userManager = userManager;
			_basketItemService = basketItemService;
			_appDbContext = appDbContext;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult SetSession(string name)
		{
			HttpContext.Session.SetString("UserName",name);

			return Content("Add to session");
		}

		public IActionResult GetSession()
		{
			string username = HttpContext.Session.GetString("UserName");

			return Content(username);
		}

		public IActionResult RemoveSession()
		{
			HttpContext.Session.Remove("UserName");

			return RedirectToAction("GetSession");
		}

		public IActionResult SetCookie(int id)
		{
			List<int> ids = new List<int>();

			string idsStr = HttpContext.Request.Cookies["UserId"];

			if(idsStr != null)
			{
				ids= JsonConvert.DeserializeObject<List<int>>(idsStr);
			}

			ids.Add(id);

			idsStr= JsonConvert.SerializeObject(ids);

			HttpContext.Response.Cookies.Append("UserId",idsStr);

			return Content("Added to cookie");
		}

		public IActionResult GetCookie()
		{
			List<int> ids = new List<int>();

			string idsStr= HttpContext.Request.Cookies["UserId"];

			if(idsStr != null)
			{
				ids= JsonConvert.DeserializeObject<List<int>>(idsStr);	
			}

			return Json(ids);
		}

		public async Task<IActionResult> AddToBasket(int productId)
		{

			List<BasketItemVM> basketItemList= new List<BasketItemVM>();
			BasketItemVM basketItem = null;
			BasketItem userBasketItem = null;
			AppUser user = null;

			if (HttpContext.User.Identity.IsAuthenticated)
			{
				user= await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
			}

			if (user != null)
			{
				//string basketItemListStr = HttpContext.Request.Cookies["BasketItems"];

				//if (basketItemListStr != null)
				//{
				//	basketItemList = JsonConvert.DeserializeObject<List<BasketItemVM>>(basketItemListStr);

				//	basketItem = basketItemList.FirstOrDefault(x => x.ProductId == productId);

				//	if (basketItem != null)
				//	{
				//		basketItem.Count++;
				//	}
				//	else
				//	{
				//		basketItem = new BasketItemVM()
				//		{
				//			ProductId = productId,
				//			Count = 1
				//		};

				//		basketItemList.Add(basketItem);
				//	}


				//}
				//else
				//{
				//	basketItem = new BasketItemVM()
				//	{
				//		ProductId = productId,
				//		Count = 1
				//	};

				//	basketItemList.Add(basketItem);
				//}



				//basketItemListStr = JsonConvert.SerializeObject(basketItemList);

				//HttpContext.Response.Cookies.Append("BasketItems", basketItemListStr);

				userBasketItem = await _appDbContext.BasketItems.FirstOrDefaultAsync(x => x.ProductId == productId && x.AppUserId == user.Id);

				if (userBasketItem != null)
				{
					userBasketItem.Count++;
				}
				else
				{
					userBasketItem = new BasketItem
					{
						ProductId = productId,
						Count = 1,
						AppUserId = user.Id,

					};

					_appDbContext.BasketItems.Add(userBasketItem);
				}

				await _appDbContext.SaveChangesAsync();
			}
			else
			{
				return View();
			}
			

			return Ok();

		}

		public IActionResult GetBasketItems()
		{
			List<BasketItemVM> basketItemList = new List<BasketItemVM>();

			string basketItemListStr = HttpContext.Request.Cookies["BasketItems"];

			if (basketItemListStr != null)
			{
				basketItemList = JsonConvert.DeserializeObject<List<BasketItemVM>>(basketItemListStr);
			}

			return Json(basketItemList);
		}

		public async Task<IActionResult> CheckOut()
		{
			List<CheckOutVM> checkOutItemList = new List<CheckOutVM>();
			List<BasketItemVM> basketItemList = new List<BasketItemVM>();
			List<BasketItem> userBasketItems = new List<BasketItem>();
			CheckOutVM checkoutItem = null;
			AppUser user = null;

			if (HttpContext.User.Identity.IsAuthenticated)
			{
				user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
			}

			if(user != null)
			{
				//string basketItemListStr = HttpContext.Request.Cookies["BasketItems"];

				//if (basketItemListStr != null)
				//{
				//	basketItemList = JsonConvert.DeserializeObject<List<BasketItemVM>>(basketItemListStr);

				//	foreach (var item in basketItemList)
				//	{
				//		checkoutItem = new CheckOutVM
				//		{
				//			Product = _productService.GetProduct(x => x.Id == item.ProductId),
				//			Count = item.Count,

				//		};

				//		checkOutItemList.Add(checkoutItem);
				//	}
				//}

				userBasketItems= _basketItemService.GetAllBasketItems(x=>x.AppUserId==user.Id);

				foreach (var item in userBasketItems)
				{
					checkoutItem = new CheckOutVM()
					{
						Product = item.Product,
						Count = item.Count,
					};

					checkOutItemList.Add(checkoutItem);
				}
			}

			return View(checkOutItemList);
		}

	}
}
