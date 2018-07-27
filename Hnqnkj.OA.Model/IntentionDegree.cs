using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqnkj.OA.Model
{
    /// <summary>
    /// 意向程度
    /// </summary>
    public class IntentionDegree:EntityBase
    {
        /// <summary>
        /// 程度级别
        /// </summary>
        public string Leavl { get; set; }

        public int DefaultSort { get; set; }

        public bool Status { get; set; }
    }
}
