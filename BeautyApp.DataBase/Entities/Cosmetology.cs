using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyManagerApp.DataBase
{
    public class Cosmetology : BaseEntity
    {
    
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }


        [ForeignKey("BeautyServices")]
        public int BeautyServiceId { get; set; }
        public virtual BeautyServices BeautyServices { get; set; }
       
    }
}
