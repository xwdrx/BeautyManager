using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyManager.Controllers
{
    public class AesthicMedicineController : Controller
    {
        public AesthicMedicineController()
        {

        }


        public IActionResult Index(BeautyServicesModel beautyServicesModel)
        {
            return View(beautyServicesModel);
        }
        public IActionResult Delete(int indexOfAethic)
        {
            return View();
        }
    }
}
