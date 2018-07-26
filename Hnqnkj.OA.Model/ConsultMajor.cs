using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqnkj.OA.Model
{
    /// <summary>
    /// 咨询专业
    /// </summary>
    public  class ConsultMajor
    {
        /// <summary>
        /// 学生Id
        /// </summary>
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        /// <summary>
        /// 专业Id
        /// </summary>
        public int SpecialtyId { get; set; }
        public  virtual Specialty Specialty { get; set; }
    }
}
