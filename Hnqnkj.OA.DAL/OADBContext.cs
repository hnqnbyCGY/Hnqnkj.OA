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
    }
}
