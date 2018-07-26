using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqnkj.OA.Model
{
    /// <summary>
    /// 客户来源
    /// </summary>
    public class CustomerSource:EntityBase
    {
        public string   Sourece { get; set; }

        public int DefaultSort { get; set; }

        public bool Status { get; set; }
    }
}
