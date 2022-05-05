using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyManager.Controllers
{
    public class CosmetologyController : Controller
    {
        public CosmetologyController()
        {
           
        }

        public IActionResult Index(BeautyServicesModel beautyServicesModel)
        {
            return View(beautyServicesModel);
        }
        public IActionResult Delete(int indexOfCosmetology)
        {
            return View();
        }

    }
}
