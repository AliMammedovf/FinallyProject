using FinalProject.Business.DTOs.FlavourDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Business.Services.Concret;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FlavourController : Controller
    {
        private readonly IFlavourService _flavourService;

        public FlavourController(IFlavourService flavourService)
        {
            _flavourService = flavourService;
        }

        public IActionResult Index()
        {
            var flavours= _flavourService.GetAllFlavours();
            return View(flavours);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FlavourCreateDTO flavourCreateDTO)
        {
            if (!ModelState.IsValid)
                return View();

           await  _flavourService.AddAsyncFlavour(flavourCreateDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var exsist = _flavourService.GetFlavour(x => x.Id == id);

            if (exsist == null)
            {
                return NotFound();
            }

            _flavourService.DeleteFlavour(id);

            return Ok(exsist);
        }

        public IActionResult Update(int id)
        {
            var oldFlavour = _flavourService.GetFlavour(x => x.Id == id);

            if (oldFlavour == null)
            {
                return NotFound();
            }

            return View(oldFlavour);
        }

        [HttpPost]
        public IActionResult Update(FlavourUpdateDTO flavourUpdateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            _flavourService.UpdateFlavour(flavourUpdateDTO);
            return RedirectToAction("Index");
        }
    }
}
