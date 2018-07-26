using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hnqnkj.OA.Model;


namespace Hnqnkj.OA.DAL
{
    public class WorkUnit
    {
        private OADBContext db;
        public OADBContext DB { get { return this.db; } }
        public WorkUnit()
        {
            this.db = new OADBContext();
        }
    }
}