namespace BeautyManagerApp
{
    public class BeautySpecialistViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public IEnumerable<BeautyServicesViewModel> BeautyServices { get; set; }

    }
}
