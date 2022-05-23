using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyManagerApp.Core
{
    public interface IBeautySpecialistmanager
    {
        void AddNewCosmetology(CosmetologyDTO cosmetology, int serviceId);
        void AddNewService(BeautyServicesDTO beautyServices, int SpecialistId);
        void AddNewSpecialist(BeautySpecialistDTO beautySpecialist);
        bool DeleteCosmetology(CosmetologyDTO cosmetology);
        bool DeleteService(BeautyServicesDTO beautyServices);
        bool DeleteSpecialist(BeautySpecialistDTO beautySpecialist);
        List<BeautySpecialistDTO> GetBeautySpecialists(string filterString);
        List<BeautyServicesDTO> GetBServicesForSpecialist(int bSpecialistId, string filterString);
        List<CosmetologyDTO> GetCosmetologyForServices(int serviceId, string filterString);
    }
}
