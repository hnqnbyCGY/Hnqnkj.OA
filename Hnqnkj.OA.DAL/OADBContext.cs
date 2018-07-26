using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hnqnkj.OA.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

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
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasRequired(m => m.OperatorAdminUser).WithMany(n => n.OperatorAdminUsers).WillCascadeOnDelete(false);
            modelBuilder.Entity<Student>().HasRequired(m => m.ListOperatorAdminUser).WithMany(n => n.LastOperatorAdminUsers).WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
