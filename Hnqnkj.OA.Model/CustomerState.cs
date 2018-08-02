using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqnkj.OA.Model
{
    /// <summary>
    /// 客户状态
    /// </summary>
    public class CustomerState:EntityBase
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string  StatusStr { get; set; }
        /// <summary>
        /// 默认排序
        /// </summary>
        public int DefaultSort { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Status { get; set; }
    }
}
