using FinalProject.Core.Models;
using FinalProject.Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public OrderController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var datas =  _appDbContext.Orders.ToList();
            return View(datas);
        }

        public IActionResult Detail(int id)
        {
            Order order =  _appDbContext.Orders.Include(x => x.OrdeerItems).FirstOrDefault(x => x.Id == id);

            if (order is null)
                return NotFound();

            return View(order);
        }


        public async Task<IActionResult> Accept(int id)
        {
            Order order = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order is null)
                return NotFound();

            order.OrderStatus = Core.EnumForCore.OrderStatus.Accepted;

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Order");
        }

        public async Task<IActionResult> Reject(int id)
        {
            Order order = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order is null)
                return NotFound();

            order.OrderStatus = Core.EnumForCore.OrderStatus.Rejected;

            await _appDbContext.SaveChangesAsync();


            return RedirectToAction("Index", "Order");
        }
    }
}
