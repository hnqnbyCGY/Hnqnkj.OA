using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqnkj.OA.Model
{
    /// <summary>
    /// 学费表
    /// </summary>
    public class Tuition:EntityBase
    {
        /// <summary>
        /// 班级
        /// </summary>
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double Money { get; set; }
        /// <summary>
        /// 备注，如 一期学费，二期学费，一年级学费，二年级学费
        /// </summary>
        public string Remarks { get; set; }
    }
}
