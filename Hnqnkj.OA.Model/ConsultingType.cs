using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqnkj.OA.Model
{
    /// <summary>
    /// 咨询类型model
    /// </summary>
    public class ConsultingType:EntityBase
    {
        /// <summary>
        /// 咨询类型
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 默认排序
        /// </summary>
        public int DefaultSort { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }
    }
}
