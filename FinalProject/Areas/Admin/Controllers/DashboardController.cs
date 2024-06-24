using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class DashboardController : Controller
    {
        

        public IActionResult Index()
        {
           
            return View();
        }
    }
}
