using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Data.DAL;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.ViewService
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IBasketItemService _basketItemService;

        public LayoutService(AppDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor, IBasketItemService basketItemService = null)
        {

            _context = context;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _basketItemService = basketItemService;
        }

        public async Task<AppUser> GetUserData()
        {
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return await _userManager.FindByNameAsync(_contextAccessor.HttpContext.User.Identity.Name);
            }
            return null;
        }

        public List<BasketItem> GetBasketItems()
        {
            return _basketItemService.GetAllBasketItems();
        }
    }
}
