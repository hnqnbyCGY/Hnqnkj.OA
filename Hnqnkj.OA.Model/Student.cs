using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hnqnkj.OA.Model
{
    public class Student:EntityBase
    {
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 出生日期，生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }
        /// <summary>
        /// 家长电话
        /// </summary>
        public string ParentsPhone { get; set; }
        /// <summary>
        /// 其他电话
        /// </summary>
        public string OtherPhone { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        public string WechatNumber { get; set; }
        /// <summary>
        /// 公立学生
        /// </summary>
        public string CouncilSchool { get; set; }
        /// <summary>
        /// 班级年级
        /// </summary>
        public string ClassGrade { get; set; }
        /// <summary>
        /// 居住区域
        /// </summary>
        public string ResidentialZone { get; set; }
        /// <summary>
        /// 客户状态Id
        /// </summary>
        public int CutomerStateId { get; set; }
        public virtual CustomerState CustomerState { get; set; }
        /// <summary>
        /// 客户来源
        /// </summary>
        public int CustomerSourceId { get; set; }
        public virtual CustomerSource CustomerSource { get; set; }
        /// <summary>
        /// 已交金额
        /// </summary>
        public double AmountPaid { get; set; }
        /// <summary>
        /// 沟通内容
        /// </summary>
        public string CommunicationContent { get; set; }
        /// <summary>
        ///所属校区
        /// </summary>
        public int ShcoolId { get; set; }
        public virtual Shcool Shcool { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        [InverseProperty("OperatorAdminUsers")]
        public virtual AdminUser OperatorAdminUser { get; set; }
        /// <summary>
        /// 咨询日期
        /// </summary>
        public  DateTime ConsultationDate { get; set; }
        /// <summary>
        /// 所属班级
        /// </summary>
        public  int? TeamId { get; set; }
        public virtual Team Team { get; set; }
        /// <summary>
        /// 最后操作人
        /// </summary>
        [InverseProperty("ListOperatorAdminUsers")]
        public virtual AdminUser ListOperatorAdminUser { get; set; }
        /// <summary>
        /// 最后操作日期
        /// </summary>
        public DateTime ListOperatorDateTime { get; set; }

    }
}
