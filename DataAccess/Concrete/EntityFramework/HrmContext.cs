using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class HrmContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BVB2G1H;Database=HRM2;Trusted_Connection=true");
        }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<User> AspNetUsers { get; set; }
    }
}
