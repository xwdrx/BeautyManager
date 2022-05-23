using BeautyManagerApp.Core;
using BeautyManagerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace BeautyManagerApp.Controllers
{
    /// <summary>
    /// Cosmetology controller(using data from the database
    /// and associating them with the appropriate values from model view)
    /// </summary>
    public class CosmetologyController : Controller
    {
        private readonly IBeautySpecialistmanager _beautySpeciliastManager;
        private readonly ViewModelMapper _viewModelMapper;
        private int SpecialistID { get; set; }
        private int ServiceID { get; set; }

        public CosmetologyController(IBeautySpecialistmanager beautySpecialistmanager, ViewModelMapper viewModelMapper)
        {
            _beautySpeciliastManager = beautySpecialistmanager;
            _viewModelMapper = viewModelMapper;
        }

        public IActionResult Index(int specialistID, int serviceID, string filterName)
        {
           TempData["SpecialistID"] = specialistID;
            TempData["ServiceID"] = serviceID;

            var ServicesDto = _beautySpeciliastManager.GetBServicesForSpecialist(specialistID, null)
                                                      .FirstOrDefault(x => x.Id == serviceID);
            var cosmetologyDto = _beautySpeciliastManager.GetCosmetologyForServices(serviceID, filterName); 
            var servicesViewModel = _viewModelMapper.Map(ServicesDto);
            servicesViewModel.cosmetology = _viewModelMapper.Map(cosmetologyDto); 
            return View(servicesViewModel);
        }

        public IActionResult Add() { return View(); }
        [HttpPost]
        public IActionResult Add(CosmetologyViewModel cosmetology)
        {
           
            var dto = _viewModelMapper.Map(cosmetology);
            _beautySpeciliastManager.AddNewCosmetology(dto, int.Parse(TempData["SpecialistID"].ToString()));
            return RedirectToAction("Index", new { specialistID = int.Parse(TempData["SpecialistID"].ToString()), serviceID = int.Parse(TempData["ServiceID"].ToString()) });
        }
        public IActionResult Delete(int cosmetologyID)
        {
            _beautySpeciliastManager.DeleteCosmetology(new CosmetologyDTO { Id = cosmetologyID });
            return RedirectToAction("Index", new { specialistID = int.Parse(TempData["SpecialistID"].ToString()), serviceID = int.Parse(TempData["ServiceID"].ToString()) });
        }
    }
}