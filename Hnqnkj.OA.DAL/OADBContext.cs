using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hnqnkj.OA.Model;

namespace Hnqnkj.OA.DAL
{
    public class OADBContext:DbContext
    {
        public OADBContext():base("OADB")
        {

        }
        public DbSet<AdminUser> AdminUsers { get; set; }

        public DbSet<Shcool> Shcools { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Specialty> Specialtys { get; set; }

        public DbSet<ConsultingType> ConsultingTypes { get; set; }

        public DbSet<ConsultingWay> ConsultingWays { get; set; }

        public DbSet<ConsultMajor> ConsultMajor { get; set; }

        public DbSet<CustomerSource> CustomerSource { get; set; }

        public DbSet<CustomerState> CustomerState { get; set; }
    }
}
