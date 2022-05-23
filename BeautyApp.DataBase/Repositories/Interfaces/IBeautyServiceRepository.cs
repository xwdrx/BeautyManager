using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyManagerApp.DataBase
{
    public interface IDBeautyServicesRepository : IRepository<BeautyServices>
    {
        IEnumerable<BeautyServices> GetServises();


    }
}
