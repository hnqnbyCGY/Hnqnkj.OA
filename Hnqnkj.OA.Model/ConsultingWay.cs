using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqnkj.OA.Model
{
    /// <summary>
    /// 咨询方式 沟通方式
    /// </summary>
    public class ConsultingWay:EntityBase
    {
        public string WayName { get; set; }
        public int DefaultSort { get; set; }
        public bool Status { get; set; }
    }
}
