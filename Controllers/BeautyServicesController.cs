using Microsoft.AspNetCore.Mvc;

namespace BeautyManager.Controllers
{
    public class BeautyServicesController : Controller
    {
        private BeautySpecialistModel BeautySpecialistModel { get; set; }
        public BeautyServicesController() { }
        public IActionResult Index(BeautySpecialistModel beautySpecialistModel)
        {
            BeautySpecialistModel = beautySpecialistModel;
            return View(beautySpecialistModel);
        }
        public IActionResult View(int indexOfService)     //trzeba dodac oba viewy do astethic
        {
            return RedirectToAction( "Index", "AesthicMedicine", BeautySpecialistModel.beautyServicesModels.ElementAt(indexOfService));
        }
        //  public IActionResult ViewC(BeautyServicesModel beautyServicesModel)       /trzeba dodac oba viewy do cosmetology
        //  {
        //     return RedirectToAction("Index", "Cosmetology", beautyServicesModel);
        //  }
        public IActionResult Delete(int indexOfService)
        {
            return View(); //wyswietlenie danych
        }
    }
}
