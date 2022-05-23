using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyManagerApp.DataBase
{

    public class BeautyServicesRepository : BaseRepository<BeautyServices>, IDBeautyServicesRepository
    {
        protected override DbSet<BeautyServices> DbSet => managerDbContext.beautyServices;

        public BeautyServicesRepository(BeautyManagerAppDbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<BeautyServices> GetServises()        
        {
            
            return DbSet.Select(x => x);
        }

        public bool AddNew(BeautyServices beautyServices)
        {
            DbSet.Add(beautyServices);
            return saveChanges();
        }

        public bool Delete(BeautyServices beautyServices)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == beautyServices.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return saveChanges();

            }
            return false;
        }
       
    }
}
