using AutoMapper;
using BeautyManagerApp.Core;

namespace BeautyManagerApp
{
    public class ViewModelMapper
    {
        private IMapper mVMMapper;

        /// <summary>
        /// ViewModelMapper: used to mapped data from DTOmodel to ViewModel;
        /// each model has its own converters
        /// </summary>
        public ViewModelMapper()
        {
            mVMMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<BeautySpecialistDTO, BeautySpecialistViewModel>()
                    .ReverseMap();
                config.CreateMap<BeautyServicesDTO, BeautyServicesViewModel>()
                    .ReverseMap();
                config.CreateMap<CosmetologyDTO, CosmetologyViewModel>()
                    .ReverseMap();
              
            }).CreateMapper();
        }
        #region BeautySpecialist Maps
        public BeautySpecialistViewModel Map(BeautySpecialistDTO beautySpecialist)
            => mVMMapper.Map<BeautySpecialistViewModel>(beautySpecialist);
        public List<BeautySpecialistViewModel> Map(List<BeautySpecialistDTO> beautySpecialist)
          => mVMMapper.Map<List<BeautySpecialistViewModel>>(beautySpecialist);
        public BeautySpecialistDTO Map(BeautySpecialistViewModel beautySpecialist)
            => mVMMapper.Map<BeautySpecialistDTO>(beautySpecialist);
        public List<BeautySpecialistDTO> Map(List<BeautySpecialistViewModel> beautySpecialist)
          => mVMMapper.Map<List<BeautySpecialistDTO>>(beautySpecialist);

        #endregion

        #region BeautySeervices Maps

        public BeautyServicesViewModel Map(BeautyServicesDTO beautyServices)
            => mVMMapper.Map<BeautyServicesViewModel>(beautyServices);
        public List<BeautyServicesViewModel> Map(List<BeautyServicesDTO> beautyServices)
          => mVMMapper.Map<List<BeautyServicesViewModel>>(beautyServices);
        public BeautyServicesDTO Map(BeautyServicesViewModel beautyServices)
            => mVMMapper.Map<BeautyServicesDTO>(beautyServices);
        public List<BeautyServicesDTO> Map(List<BeautyServicesViewModel> beautyServices)
          => mVMMapper.Map<List<BeautyServicesDTO>>(beautyServices);
        #endregion

        #region Cosmetology Maps

        public CosmetologyViewModel Map(CosmetologyDTO cosmetology)
           => mVMMapper.Map<CosmetologyViewModel>(cosmetology);
        public List<CosmetologyViewModel> Map(List<CosmetologyDTO> cosmetologies)
          => mVMMapper.Map<List<CosmetologyViewModel>>(cosmetologies);
        public CosmetologyDTO Map(CosmetologyViewModel cosmetology)
            => mVMMapper.Map<CosmetologyDTO>(cosmetology);
        public List<CosmetologyDTO> Map(List<CosmetologyViewModel> cosmetologies)
          => mVMMapper.Map<List<CosmetologyDTO>>(cosmetologies);

        #endregion

    }
}
