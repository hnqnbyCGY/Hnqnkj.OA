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
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasRequired(m => m.OperatorAdminUser).WithMany(n => n.OperatorAdminUsers).WillCascadeOnDelete(false);
            modelBuilder.Entity<Student>().HasRequired(m => m.ListOperatorAdminUser).WithMany(n => n.LastOperatorAdminUsers).WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
