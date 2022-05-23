using BeautyManagerApp.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyManagerApp.DataBase
{
    public class BeautySpecialistRepository : BaseRepository<BeautySpecialist>, IDBeautySpecialistRepository
    {
        protected override DbSet<BeautySpecialist> DbSet => managerDbContext.beautySpecialists;

        public BeautySpecialistRepository(BeautyManagerAppDbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<BeautySpecialist> GetBeautySpecialists()
        {
          
            return DbSet.Select(x => x);

        }
      
    }
}
