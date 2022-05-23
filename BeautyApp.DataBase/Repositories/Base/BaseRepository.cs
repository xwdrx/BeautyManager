
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyManagerApp.DataBase
{
    public abstract class BaseRepository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        protected BeautyManagerAppDbContext managerDbContext;
        protected abstract DbSet<Entity> DbSet { get; }

        public BaseRepository(BeautyManagerAppDbContext dbContext)
        {
            managerDbContext = dbContext;
        }
        public List<Entity> GetAll()
        {
            var list = new List<Entity>();
            var entities = DbSet;
            foreach (var entity in entities)
                list.Add(entity);
            return list;
        }
        public bool saveChanges()
        {
            return managerDbContext.SaveChanges() > 0;
        }
        public bool Delete(Entity entity)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return saveChanges();
            }
            return false;
        }


        public bool AddNew(Entity entity)
        {
            DbSet.Add(entity);
            return saveChanges();
        }
       

    }
}
