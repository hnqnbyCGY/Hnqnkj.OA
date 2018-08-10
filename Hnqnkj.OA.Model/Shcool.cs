using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqnkj.OA.Model
{
    public class School:EntityBase
    {

        public string Name { get; set; }
        /// <summary>
        /// 校长或负责人
        /// </summary>
        public string Principal { get; set; }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string MPhone { get; set; }
        /// <summary>
        /// 固定电话
        /// </summary>
        public string TPhone { get; set; }
        /// <summary>
        /// 学校地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 学校状态
        /// </summary>
        public bool Status { get; set; }

    }
}
