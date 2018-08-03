using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hnqnkj.OA.Model
{
   public class AdminUser : EntityBase
    {

        /// <summary>
        /// 用户名
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string AccountPwd { get; set; }

        //public string UserType { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string  RealName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string MPhone { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int? LoginCount { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLogingTime { get; set; }
        //[InverseProperty("OperatorAdminUser")]
        //public virtual ICollection<Student> OperatorAdminUsers { get; set; }
        //[InverseProperty("ListOperatorAdminUser")]
        //public virtual ICollection<Student> LastOperatorAdminUsers { get; set; }

        public bool Status { get; set; }

       // public bool? IsDel { get; set; }
    }
}
