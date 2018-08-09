using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqnkj.OA.Model
{
    /// <summary>
    /// 报名表
    /// </summary>
    public class SignUp:EntityBase
    {
        /// <summary>
        /// 学生Id
        /// </summary>
        public int StudentId { get; set; }
       
        /// <summary>
        /// 班级
        /// </summary>
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        /// <summary>
        /// 报名日期
        /// </summary>
        public DateTime SignDateTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public int AdminUserId { get; set; }
        public virtual AdminUser AdminUser { get; set; }

    }
}
