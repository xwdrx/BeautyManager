namespace BeautyManagerApp
{
   
    public class BeautyServicesViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }

        public BeautySpecialistViewModel BeautySpecialist { get; set; }
        public IEnumerable<CosmetologyViewModel> cosmetology { get; set; }

    }
}
