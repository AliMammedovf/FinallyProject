﻿using FinalProject.Business.DTOs.SizeDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Business.Services.Concret;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizeController : Controller
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        public IActionResult Index()
        {
            var sizes= _sizeService.GetAllSizes();
            return View(sizes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> Create(SizeCreateDTO sizeCreateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            await _sizeService.AddAsyncSize(sizeCreateDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var exsist = _sizeService.GetSize(x => x.Id == id);

            if (exsist == null)
            {
                return NotFound();
            }

            _sizeService.DeleteSize(id);

            return Ok(exsist);
        }

        public IActionResult Update(int id)
        {
            var oldSize = _sizeService.GetSize(x => x.Id == id);

            if (oldSize == null)
            {
                return NotFound();
            }

            return View(oldSize);
        }

        [HttpPost]
        public IActionResult Update(SizeUpdateDTO sizeUpdateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            _sizeService.UpdateSize(sizeUpdateDTO);
            return RedirectToAction("Index");
        }


    }
}