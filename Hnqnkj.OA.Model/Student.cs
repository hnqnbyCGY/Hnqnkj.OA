using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int CutomerState_Id { get; set; }
        public virtual CustomerState CustomerState { get; set; }
        /// <summary>
        /// 客户来源
        /// </summary>
        public int CustomerSource_Id { get; set; }
        public virtual CustomerSource CustomerSource { get; set; }
        /// <summary>
        /// 沟通内容
        /// </summary>
        public string CommunicationContent { get; set; }
        

    }
}
