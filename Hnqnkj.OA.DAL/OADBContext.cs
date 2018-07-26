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
        /// <summary>
        /// 学校，校区
        /// </summary>
        public DbSet<Shcool> Shcools { get; set; }
        /// <summary>
        /// 学生，客户
        /// </summary>
        public DbSet<Student> Students { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        public DbSet<Specialty> Specialtys { get; set; }
        /// <summary>
        /// 沟通类型
        /// </summary>
        public DbSet<ConsultingType> ConsultingTypes { get; set; }
        /// <summary>
        /// 咨询沟通方式
        /// </summary>
        public DbSet<ConsultingWay> ConsultingWays { get; set; }
        /// <summary>
        /// 咨询专业
        /// </summary>
        public DbSet<ConsultMajor> ConsultMajor { get; set; }
        /// <summary>
        /// 客户来源
        /// </summary>
        public DbSet<CustomerSource> CustomerSource { get; set; }
        /// <summary>
        /// 客户状态
        /// </summary>
        public DbSet<CustomerState> CustomerState { get; set; }
        /// <summary>
        /// 班级
        /// </summary>
        public DbSet<Team> Teams { get; set; }
        /// <summary>
        /// 意向程度
        /// </summary>
        public DbSet<IntentionDegree> IntentionDegrees { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasRequired(m => m.OperatorAdminUser).WithMany(n => n.OperatorAdminUsers).WillCascadeOnDelete(false);
            modelBuilder.Entity<Student>().HasRequired(m => m.ListOperatorAdminUser).WithMany(n => n.LastOperatorAdminUsers).WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
