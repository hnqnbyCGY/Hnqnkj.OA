using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace Hnqnkj.OA.Model
{
    /// <summary>
    /// 沟通记录
    /// </summary>
    public class CommunicationRecord : EntityBase
    {
       // public int StudentId { get; set; }
        /// <summary>
        /// 沟通类型
        /// </summary>
        public int ConsultingTypeId { get; set; }
        public virtual ConsultingType ConsultingType { get; set; }
        [NotMapped]
        public string ConType
        {
            get
            {
                return ConsultingType.TypeName;
            }
        }
        /// <summary>
        /// 沟通方式
        /// </summary>
        public int ConsultingWayId { get; set; }
        public virtual ConsultingWay ConsultingWay { get; set; }
        [NotMapped]
        public string ChatWay
        {
            get
            {
                return ConsultingWay.WayName;
            }
        }
        /// <summary>
        /// 意向程度
        /// </summary>
        public int IntentionDegreeId { get; set; }
        public virtual IntentionDegree IntentionDegree { get; set; }
        /// <summary>
        /// 沟通内容
        /// </summary>
        public string CommunicationContent { get; set; }
        /// <summary>
        /// 沟通结果
        /// </summary>
        public string CommunicationResults { get; set; }
        /// <summary>
        /// 经办校区
        /// </summary>
        public int ShcoolId { get; set; }
        public virtual Shcool Shcool { get; set; }
        /// <summary>
        /// 沟通日期
        /// </summary>
        public DateTime CommunicationDate { get; set; }
        /// <summary>
        /// 沟通人
        /// </summary>
        public int AdminUserId { get; set; }
        public virtual AdminUser AdminUser { get; set; }
        public virtual Student Student { get; set; }
        [NotMapped]
        public string StudentName { get => Student.Name; }
    }
}
