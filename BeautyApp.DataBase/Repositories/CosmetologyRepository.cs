using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyManagerApp.DataBase
{

    public class CosmetologyRepository : BaseRepository<Cosmetology>, IDCosmetologyRepository
    {
        protected override DbSet<Cosmetology> DbSet => managerDbContext.cosmetologies;

        public CosmetologyRepository(BeautyManagerAppDbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Cosmetology> GetCosmetologies()         
        {
            return DbSet.Select(x => x);
        }

        public bool AddNew(Cosmetology cosmetology)
        {
            DbSet.Add(cosmetology);
            return saveChanges();
        }

        public bool Delete(Cosmetology cosmetology)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == cosmetology.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return saveChanges();

            }
            return false;
        }
     
    }
}
