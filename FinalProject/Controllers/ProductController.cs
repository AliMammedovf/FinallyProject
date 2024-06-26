using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.RepositoryAbstract;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FinalProject.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
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

		public IActionResult AddToBasket(int productId)
		{

			List<BasketItemVM> basketItemList= new List<BasketItemVM>();
			BasketItemVM basketItem = null;

			string basketItemListStr= HttpContext.Request.Cookies["BasketItems"];

			if(basketItemListStr != null)
			{
				basketItemList = JsonConvert.DeserializeObject<List<BasketItemVM>>(basketItemListStr);

				basketItem= basketItemList.FirstOrDefault(x=>x.ProductId==productId);

				if(basketItem != null)
				{
					basketItem.Count++;
				}
				else
				{
					basketItem = new BasketItemVM()
					{
						ProductId = productId,
						Count = 1
					};

					basketItemList.Add(basketItem);
				}

				 
			}
			else
			{
				 basketItem = new BasketItemVM()
				{
					ProductId = productId,
					Count = 1
				};

				basketItemList.Add(basketItem);
			}

			

			 basketItemListStr=  JsonConvert.SerializeObject(basketItemList);

			HttpContext.Response.Cookies.Append("BasketItems",basketItemListStr);

			return Ok();

		}

		public IActionResult GetBasketItems()
		{
			List<BasketItemVM> basketItemList = new List<BasketItemVM>();

			string basketItemListStr = HttpContext.Request.Cookies["BasketItems"];

			if(basketItemListStr != null)
			{
				basketItemList= JsonConvert.DeserializeObject<List<BasketItemVM>>(basketItemListStr);
			}

			return Json(basketItemList);
		}

		public  IActionResult CheckOut()
		{
			List<CheckOutVM> checkOutItemList = new List<CheckOutVM>();
			List<BasketItemVM> basketItemList= new List<BasketItemVM>();

			CheckOutVM checkoutItem = null;

			string basketItemListStr = HttpContext.Request.Cookies["BasketItems"];

			if(basketItemListStr != null)
			{
				basketItemList = JsonConvert.DeserializeObject<List<BasketItemVM>>(basketItemListStr);

				foreach(var item in basketItemList)
				{
					checkoutItem = new CheckOutVM
					{
						Product = _productService.GetProduct(x => x.Id == item.ProductId),
						Count = item.Count,

					};

					checkOutItemList.Add(checkoutItem);
				}
			}

			 return View(checkOutItemList);
		}

	}
}
