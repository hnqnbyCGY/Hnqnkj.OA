using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqnkj.OA.Model
{
    /// <summary>
    /// 班级
    /// </summary>
    public class Team:EntityBase
    {
        public string TName { get; set; }

        public int Specialty_Id { get; set; }
        public virtual Specialty Specialty { get; set; }
    }
}
