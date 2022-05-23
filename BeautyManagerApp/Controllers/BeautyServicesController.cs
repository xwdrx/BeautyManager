using BeautyManagerApp.Core;
using BeautyManagerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace BeautyManagerApp.Controllers
{
    /// <summary>
    /// Beauty services controller(using data from the database
    /// and associating them with the appropriate values from model view)
    /// </summary>
    public class BeautyServicesController : Controller
    {
        private readonly IBeautySpecialistmanager _beautySpeciliastManager;
        private readonly ViewModelMapper _viewModelMapper;
        private int SpecialistID { get; set; }
 
        public BeautyServicesController(IBeautySpecialistmanager beautySpecialistmanager, ViewModelMapper viewModelMapper)
        {
            _beautySpeciliastManager = beautySpecialistmanager;
            _viewModelMapper = viewModelMapper;
        }

        public IActionResult Index(int specialistID, string filterName)
        {
            TempData["SpecialistID"] = specialistID;
            var specialistDto = _beautySpeciliastManager.GetBeautySpecialists( null)
                                                      .FirstOrDefault(x => x.Id == specialistID);
            var serviceDto = _beautySpeciliastManager.GetBServicesForSpecialist(specialistID, filterName); 
            var servicesViewModel = _viewModelMapper.Map(specialistDto);
            servicesViewModel.BeautyServices = _viewModelMapper.Map(serviceDto);
            return View(servicesViewModel);
        }

        public IActionResult View(int serviceID)
        {
            return RedirectToAction("Index", "Cosmetology", new { specialistID = SpecialistID, serviceID = serviceID });

        }

        public IActionResult Add() { return View(); }
        [HttpPost]
        public IActionResult Add(BeautyServicesViewModel beautyService)
        {
            var dto = _viewModelMapper.Map(beautyService);
            _beautySpeciliastManager.AddNewService(dto, int.Parse(TempData["SpecialistID"].ToString()));
            return RedirectToAction("Index", new { specialistID = int.Parse(TempData["SpecialistID"].ToString()) });
        }
        public IActionResult Delete(int serviceID)
        {

            _beautySpeciliastManager.DeleteService(new BeautyServicesDTO { Id = serviceID });
            return RedirectToAction("Index", new { specialistID = int.Parse(TempData["SpecialistID"].ToString()) });

        }
    }
}