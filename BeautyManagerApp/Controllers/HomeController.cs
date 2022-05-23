using BeautyManagerApp.Core;
using BeautyManagerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BeautyManagerApp.Controllers
{
    /// <summary>
    /// Beauty Speciliast controller(using data from the database
    /// and associating them with the appropriate values from model view)
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IBeautySpecialistmanager _beautySpeciliastManager;
        private readonly ViewModelMapper _viewModelMapper;

        public HomeController(IBeautySpecialistmanager beautySpecialistmanager, ViewModelMapper viewModelMapper)
        {
            _beautySpeciliastManager = beautySpecialistmanager;
            _viewModelMapper = viewModelMapper;
        }

        public IActionResult Index(string filterName)
        {
            var specialistDto = _beautySpeciliastManager.GetBeautySpecialists(filterName);
            var specialistVM = _viewModelMapper.Map(specialistDto);
            return View(specialistVM);
        }

        public IActionResult View(int specialistID)
        {
            return RedirectToAction("Index", "BeautyServices", new { specialistID = specialistID });

        }
        public IActionResult Add() { return View(); }
        [HttpPost]
        public IActionResult Add(BeautySpecialistViewModel beautySpecialistModel)
        {
            var dto = _viewModelMapper.Map(beautySpecialistModel);
            _beautySpeciliastManager.AddNewSpecialist(dto);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int specialistID)
        {
            _beautySpeciliastManager.DeleteSpecialist(new BeautySpecialistDTO { Id = specialistID });
            var specialistDto = _beautySpeciliastManager.GetBeautySpecialists(null);
            var specialistVM = _viewModelMapper.Map(specialistDto);

            return View("Index", specialistVM);

        }


    }
}