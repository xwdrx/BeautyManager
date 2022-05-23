namespace BeautyManagerApp
{
    public class CosmetologyViewModel
    {

        public int Id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public BeautyServicesViewModel BeautyServices { get; set; }


    }
}
