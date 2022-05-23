using AutoMapper;
using BeautyManagerApp.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyManagerApp.Core
{
    public class DTOmapper
    {
        private IMapper mMapper;

        public DTOmapper()
        {
            mMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<BeautySpecialist, BeautySpecialistDTO>()
                    .ReverseMap();
                config.CreateMap<BeautyServices, BeautyServicesDTO>()
                    .ReverseMap();
                config.CreateMap<Cosmetology, CosmetologyDTO>()
                    .ReverseMap();
               
            }).CreateMapper();
        }
        #region BeautySpecialist Maps
        public BeautySpecialistDTO Map(BeautySpecialist beautySpecialist)
            => mMapper.Map<BeautySpecialistDTO>(beautySpecialist);
        public List<BeautySpecialistDTO> Map(List<BeautySpecialist> beautySpecialist)
          => mMapper.Map<List<BeautySpecialistDTO>>(beautySpecialist);
        public BeautySpecialist Map(BeautySpecialistDTO beautySpecialist)
            => mMapper.Map<BeautySpecialist>(beautySpecialist);
        public List<BeautySpecialist> Map(List<BeautySpecialistDTO> beautySpecialist)
          => mMapper.Map<List<BeautySpecialist>>(beautySpecialist);

        #endregion

        #region BeautySeervices Maps

        public BeautyServicesDTO Map(BeautyServices beautyServices)
            => mMapper.Map<BeautyServicesDTO>(beautyServices);
        public List<BeautyServicesDTO> Map(List<BeautyServices> beautyServices)
          => mMapper.Map<List<BeautyServicesDTO>>(beautyServices);
        public BeautyServices Map(BeautyServicesDTO beautyServices)
            => mMapper.Map<BeautyServices>(beautyServices);
        public List<BeautyServices> Map(List<BeautyServicesDTO> beautyServices)
          => mMapper.Map<List<BeautyServices>>(beautyServices);
        #endregion

        #region Cosmetology Maps

        public CosmetologyDTO Map(Cosmetology cosmetology)
            => mMapper.Map<CosmetologyDTO>(cosmetology);
        public List<CosmetologyDTO> Map(List<Cosmetology> cosmetology)
          => mMapper.Map<List<CosmetologyDTO>>(cosmetology);
        public Cosmetology Map(CosmetologyDTO cosmetology)
            => mMapper.Map<Cosmetology>(cosmetology);
        public List<Cosmetology> Map(List<CosmetologyDTO> cosmetology)
          => mMapper.Map<List<Cosmetology>>(cosmetology);

        #endregion
       
    }
}
