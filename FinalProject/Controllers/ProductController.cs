using FinalProject.Business.Services.Abstarct;
using FinalProject.Business.Services.Concret;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using FinalProject.Data.DAL;
using FinalProject.Data.RepositoryConcret;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Stripe;
using System.Runtime.Intrinsics.X86;

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

		public async Task<IActionResult> AddToBasket(int productId,int sizeId,int flavourId, string? returnUrl, int count=1)
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

				userBasketItem = await _appDbContext.BasketItems.FirstOrDefaultAsync(x => x.ProductId == productId && x.AppUserId == user.Id && x.SizeId==sizeId && x.FlavourId==flavourId);

				if (userBasketItem != null)
				{
					userBasketItem.Count+=count;
				}
				else
				{
					userBasketItem = new BasketItem
					{
						ProductId = productId,
						Count = count,
						AppUserId = user.Id,
						SizeId = sizeId,
						FlavourId = flavourId,

					};

					_appDbContext.BasketItems.Add(userBasketItem);
				}

				await _appDbContext.SaveChangesAsync();
			}
			else
			{
				return RedirectToAction("Login", "User");
			}

			if (returnUrl is not null)
				return Redirect(returnUrl);
			return RedirectToAction("Detail", "Home", new {id=productId});

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
			else
			{
				return RedirectToAction("Login","User");
			}

			OrderVM orderVM = new OrderVM()
			{
			
				FullName=user.FullName
			};
            ViewBag.CheckOutViewModel = checkOutItemList;
            return View(orderVM);
		}

		[HttpPost]
		public async Task<IActionResult> CheckOut(OrderVM orderVM)
		{

            List<CheckOutVM> checkOutItemList = new List<CheckOutVM>();
            List<BasketItemVM> basketItemList = new List<BasketItemVM>();
            List<BasketItem> userBasketItems = new List<BasketItem>();
            OrderItem orderItem = null;
			CheckOutVM checkOut = null;



            AppUser user = null;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            }

            Order order = new Order()
            {
                FullName = orderVM.FullName,
                Address = orderVM.Address,
                Country = orderVM.Country,
                Phone = orderVM.Phone,
                PostCode = orderVM.PostCode,
                Email = orderVM.Email,
				OrdeerItems = new List<OrderItem>(),
                AppUserId = user.Id

            };

			List<CheckOutVM> checkoutVmList = new List<CheckOutVM>();

            if (user != null)
			{
                userBasketItems = _basketItemService.GetAllBasketItems(x => x.AppUserId == user.Id);

				foreach (var item in userBasketItems)
				{
                    Core.Models.Product product =  _appDbContext.Products.FirstOrDefault(x => x.Id == item.ProductId);
                    CheckOutVM checkOutVM = new ()
					{
						Product = product,
						Count = item.Count
					};
					checkoutVmList.Add(checkOutVM);
					orderItem = new OrderItem()
					{
						Product = product,
						ProductName = product.Title,
						Price = product.Price,
						Count = item.Count,
						Order = order
					};

					order.TotalPrice += orderItem.Price * orderItem.Count;
					

					order.OrdeerItems.Add(orderItem);
				}
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

			var optionCust = new CustomerCreateOptions
			{
				Email = "tu7dw5n4h@code.edu.az",
				Name = user.Email + " " + user.FullName,
				Phone = "+994 50 66"
			};
			var serviceCust = new CustomerService();
			Customer customer = serviceCust.Create(optionCust);
			//orderVM.Total = orderVM.Total * 100;
			//var optionsCharge = new ChargeCreateOptions
			//{
			//	Amount = (long)orderVM.Total,
			//	Currency = "USD",
			//	Description = "Product Selling amount",
			//	//Source = "pk_test_51PYOQsFiyqPg2bBwmm5AFN6aHiPzDrKk25qwKT3J91AD0kyLNuJKmggc7YvBErKSwABEaoGXZ8fOgoofRV6qe1Z300429HKATQ",
			//	ReceiptEmail = "tu7dw5n4h@code.edu.az"
			//};
			//var serviceCharge = new ChargeService();



			//Charge charge = serviceCharge.Create(optionsCharge);

			//if (charge.Status != "succeeded")
			//{

			//	ModelState.AddModelError("Address", "Odenishde problem var");
			//	return View();
			//}

			ViewBag.CheckOutViewModel = checkoutVmList;

			if (!ModelState.IsValid)
				return View();
           
            await _appDbContext.Orders.AddAsync(order);
		    await _appDbContext.SaveChangesAsync();

			return RedirectToAction("Index","Home");
		}

		[HttpGet]
		public IActionResult DeleteBasket(int productId)
		{
			// Your logic to remove the product from the basket
			// For example:
			var product = _appDbContext.BasketItems.FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				_appDbContext.BasketItems.Remove(product);
				_appDbContext.SaveChanges();
				return RedirectToAction("Index", "Shop");
			}
			else
			{
				return RedirectToAction("Error", "Home");
			}
			
		}





	}
}
