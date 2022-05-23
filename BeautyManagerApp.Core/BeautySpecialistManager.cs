using BeautyManagerApp.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyManagerApp.Core
{


    public class BeautySpecialistManager : IBeautySpecialistmanager
    {
        private readonly IDBeautySpecialistRepository dbeautySpecialiastRepository;
        private readonly IDBeautyServicesRepository dBeautyServicesRepository;
        private readonly IDCosmetologyRepository dCosmetologyRepository;
        private readonly DTOmapper beautySpecialistMapper;

        public BeautySpecialistManager(IDBeautySpecialistRepository beautySpecialiastRepository, IDBeautyServicesRepository BeautyServicesRepository,
                                        IDCosmetologyRepository CosmetologyRepository, DTOmapper dTOmapper)
        {
            dbeautySpecialiastRepository = beautySpecialiastRepository;
            dBeautyServicesRepository = BeautyServicesRepository;
            dCosmetologyRepository = CosmetologyRepository;
            beautySpecialistMapper = dTOmapper;



        }
        public List<BeautySpecialistDTO> GetBeautySpecialists(string filterString)
        {
            var bspecialistsEntities = dbeautySpecialiastRepository.GetBeautySpecialists().ToList();
            if (!string.IsNullOrEmpty(filterString))
            {
                bspecialistsEntities = bspecialistsEntities
                    .Where(x => x.FirstName.Contains(filterString) || x.LastName.Contains(filterString)).ToList();
            }
            return beautySpecialistMapper.Map(bspecialistsEntities);
        }

        public List<BeautyServicesDTO> GetBServicesForSpecialist(int specialistID, string filterString)
        {
            var bServicesEntities = dBeautyServicesRepository.GetServises().Where(X => X.BeautySpecialistId == specialistID).ToList(); ;        
            if (!string.IsNullOrEmpty(filterString))
            {
                bServicesEntities = bServicesEntities
                    .Where(x => x.Name.Contains(filterString)).ToList(); ;
            }
            return beautySpecialistMapper.Map(bServicesEntities);
        }

        public List<CosmetologyDTO> GetCosmetologyForServices(int serviceId, string filterString)
        {
            var cosmetologyEntities = dCosmetologyRepository.GetCosmetologies().Where(X => X.BeautyServiceId == serviceId).ToList(); ;        
            if (!string.IsNullOrEmpty(filterString))
            {
                cosmetologyEntities = cosmetologyEntities
                    .Where(x => x.Name.Contains(filterString)).ToList(); 
            }
            return beautySpecialistMapper.Map(cosmetologyEntities);
        }



        //ADDING NEW SERVICES

        public void AddNewCosmetology(CosmetologyDTO cosmetology, int serviceId)
        {
            var entity = beautySpecialistMapper.Map(cosmetology);
            entity.BeautyServiceId = serviceId;
            dCosmetologyRepository.AddNew(entity);
        }


        public void AddNewService(BeautyServicesDTO beautyServices, int SpecialistId)
        {
            var entity = beautySpecialistMapper.Map(beautyServices);
            entity.BeautySpecialistId = SpecialistId;
            dBeautyServicesRepository.AddNew(entity);
        }

        public void AddNewSpecialist(BeautySpecialistDTO beautySpecialist)
        {
            var entity = beautySpecialistMapper.Map(beautySpecialist);
            dbeautySpecialiastRepository.AddNew(entity);
        }

        //delete 

        public bool DeleteCosmetology(CosmetologyDTO cosmetology)
        {
            var entity = beautySpecialistMapper.Map(cosmetology);
            return dCosmetologyRepository.Delete(entity);
        }


        public bool DeleteService(BeautyServicesDTO beautyServices)
        {
            var entity = beautySpecialistMapper.Map(beautyServices);
            return dBeautyServicesRepository.Delete(entity);
        }

        public bool DeleteSpecialist(BeautySpecialistDTO beautySpecialist)
        {
            var entity = beautySpecialistMapper.Map(beautySpecialist);
            return dbeautySpecialiastRepository.Delete(entity);
        }
    }

}
