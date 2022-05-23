using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyManagerApp.DataBase
{
    public class BeautyServices :BaseEntity
    {
       

        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("BeautySpecialist")]
        public int BeautySpecialistId { get; set; }
        public virtual BeautySpecialist BeautySpecialist { get; set; }
       
        [NotMapped]
        public List<Cosmetology> Cosmetologies { get; set; }
    }
}
