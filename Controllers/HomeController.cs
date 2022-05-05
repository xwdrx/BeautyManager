using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyManager.Controllers
{
    public class HomeController : Controller
    {
        public List<BeautySpecialistModel> beautySpecialists => new List<BeautySpecialistModel>
        {
            new BeautySpecialistModel
            {
                Name ="Anna",
                beautyServicesModels=new List<BeautyServicesModel>
                {
                    new BeautyServicesModel{
                        Name="Usługa 1",
                        Cosmetics= new List<CosmetologyModel>
                        {
                           new CosmetologyModel{
                               Name="Makijaz slubny",
                            },

                           new CosmetologyModel{
                               Name="Makijaz wieczorowy",
                            },
                           new CosmetologyModel{
                               Name="henna brwi",
                            },
                           
                        },
                        Aesthics=new List<AesthicMedicineModel>
                        {
                           new AesthicMedicineModel
                           {
                               Name="Mikrodermabrazja",
                           },
                              new AesthicMedicineModel
                           {
                               Name="Kwas chemiczny",
                           },
                                 new AesthicMedicineModel
                           {
                               Name="Mezoterapia",
                           },
                        }
                    },
                   
                }
            },
            new BeautySpecialistModel
            {
                Name ="Maria",
                beautyServicesModels=new List<BeautyServicesModel>
                {
                    new BeautyServicesModel{
                        Name="Usługa 1",
                        Cosmetics= new List<CosmetologyModel>
                        {
                           new CosmetologyModel{
                               Name="Listing rzes",
                            },

                           new CosmetologyModel{
                               Name="Henna rzes",
                            },
                           new CosmetologyModel{
                               Name="henna brwi",
                            },

                        },
                        Aesthics=new List<AesthicMedicineModel>
                        {
                              new AesthicMedicineModel
                           {
                               Name="Kwas chemiczny",
                           },
                                 new AesthicMedicineModel
                           {
                               Name="Mezoterapia",
                           },
                        }
                    },

                }
            },
             new BeautySpecialistModel
            {
                Name ="Alicja",
                beautyServicesModels=new List<BeautyServicesModel>
                {
                    new BeautyServicesModel{
                        Name="Usługa 1",
                        Aesthics=new List<AesthicMedicineModel>
                        {
                           new AesthicMedicineModel
                           {
                               Name="Mikrodermabrazja",
                           },
                              new AesthicMedicineModel
                           {
                               Name="Kwas chemiczny",
                           },
                                 new AesthicMedicineModel
                           {
                               Name="Mezoterapia",
                           },
                        }
                    },

                }
            },
        };
        public HomeController()
        {
        }

        // GET: HomeController
        public IActionResult Index()
        {
            return View(beautySpecialists); //wyswietlenie danych
        }

        public IActionResult View(int indexOfSpecialist)
        {
            return RedirectToAction("Index", "BeautyServices", beautySpecialists.ElementAt(indexOfSpecialist));
        }
        public IActionResult Delete(int indexOfSpecialist)
        {
            return View(beautySpecialists); //wyswietlenie danych
        }

    }
}
