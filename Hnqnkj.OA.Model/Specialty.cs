using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqnkj.OA.Model
{
    /// <summary>
    /// 专业
    /// </summary>
    public class Specialty:EntityBase
    {

        public string  Name { get; set; }

        public string  Remark { get; set; }

     //   public virtual ICollection<Team> Team { get; set; }
    }
}
