
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyManagerApp.Core
{
    public class BeautyServicesDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public BeautySpecialistDTO BeautySpecialist { get; set; }
        public IEnumerable<CosmetologyDTO> cosmetologyDTOs { get; set; }
    }
}
