using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyManagerApp.DataBase
{
    public class BeautyManagerAppDbContext : DbContext
    {
        public DbSet<BeautySpecialist> beautySpecialists { get; set; }
        public DbSet<BeautyServices> beautyServices { get; set; }
        public DbSet<Cosmetology> cosmetologies { get; set; }

        public BeautyManagerAppDbContext(DbContextOptions options) : base(options)
        {}
    }
}
