using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqnkj.OA.Model;
using Hnqnkj.OA.DAL;
using System.Web.Security;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class StudentListController : Controller
    {
        WorkUnit work = new WorkUnit();
        // GET: StudentList
        public ActionResult Index(int page = 0, int limit = 10, string sort = "Id", OrderMode order = OrderMode.Asc, int school = 0, int state = 1, string description = "")
        {
          
            if (Request.IsAjaxRequest())
            {
                var where = PredicateBuilder.True<Student>();
                if (school!=0)
                {
                    where = where.And(s => s.ShcoolId == school);
                }
                if (state!=0)
                {
                    where = where.And(s => s.CustomerStateId == state);
                }
                if (description!="")
                {
                    where = where.And(s => s.Name.Contains(description)||s.ParentsPhone.Contains(description));
                }
                int offset = (page - 1) * limit;
                var stus = work.Student.GetPageEntitys(where,limit,offset,sort,order);
                var list = from s in stus
                           select new {
                               s.Name,
                               Birthday = (DateTime.Now.Year - s.Birthday.Year) + "岁",
                               s.ParentsPhone,
                               s.IntentionDegree.Leavl,
                               s.CustomerSource.Sourece,
                               s.CustomerState.StatusStr,
                               s.OperatorAdminUser.RealName,
                               ConsultationDate = s.ConsultationDate.ToString(),
                               Specialty = (work.ConsultMajor.GetCount(c => c.StudentId == s.Id) == 0 ? "无" : work.ConsultMajor.Where(c => c.StudentId == s.Id).ToList()[0].Specialty.Name),
                               s.Id,
                               Comnundate = work.CommunicationRecord.GetCount(c => c.Student.Id == s.Id) == 0 ? "无" : GetDate(work.CommunicationRecord.GetAll(c => c.Student.Id == s.Id).OrderByDescending(z => z.CommunicationDate).FirstOrDefault().CommunicationDate)
                               
                           };
                return Json(new { code = 0, count = stus.Count(), data = list }, JsonRequestBehavior.AllowGet);
            }
            ViewBag.Shcool = work.Shcool.GetAll();
            ViewBag.CustomerState = work.CustomerState.GetAll(s => s.Status);
            return View();
        }
        private string GetDate(DateTime date)
        {
            DateTime newDate = DateTime.Now;
            if (newDate.Year-date.Year>0)
            {
                return newDate.Year - date.Year + "年前";
            }
            if (newDate.Month-date.Month>0)
            {
                return newDate.Month - date.Month + "月前";
            }
            if (newDate.Day - date.Day > 15)
            {
                return "两周前";
            }
            if (newDate.Day - date.Day > 7)
            {
                return "一周前";
            }
            if (newDate.Day - date.Day>0)
            {
                return newDate.Day - date.Day + "天前";
            }
            if (newDate.Hour-date.Hour>0)
            {
                return newDate.Hour - date.Hour + "小时前";
            }
            if (newDate.Minute - date.Minute > 0)
            {
                return newDate.Minute - date.Minute + "分钟前";
            }
            return  "刚刚";
            
        }
        public ActionResult Update(int id)
        {
            Student stu = work.Student.GetEntityById(id);
            return View(stu);
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.sps = work.Specialty.GetAll().ToList();//所有专业
            ViewBag.CustomerStates = work.CustomerState.Where(m => m.Status).ToList();//客户状态
            ViewBag.IntentionDegree = work.IntentionDegree.Where(m => m.Status).ToList();//意向程度
            ViewBag.CustomerSource = work.CustomerSource.Where(m => m.Status).ToList();//客户来源
            ViewBag.Shcool = work.Shcool.Where(m => true);
            return View();
        } 
        [HttpPost]
        public ActionResult Add(Student student,List<int> ids)
        {
            try
            {
                int count = work.Student.GetCount(s => s.ParentsPhone == student.ParentsPhone && s.Name == student.Name);
                if (count>0)
                {
                    return Json(new { success = false });
                }
                FormsIdentity identity = User.Identity as FormsIdentity;
                AdminUser admin = JsonConvert.DeserializeObject<AdminUser>(identity.Ticket.UserData);
                student.OperatorAdminUserId = admin.Id;
                student.ListOperatorAdminUserId = admin.Id;
                student.ListOperatorDateTime = DateTime.Now;
                work.Student.Insert(student);
                work.Save();
                student = work.Student.Where(s => s.Name == student.Name && s.ParentsPhone == student.ParentsPhone).ToList()[0];
                foreach (var id in ids)
                {
                    work.ConsultMajor.Insert(new ConsultMajor { SpecialtyId = id, StudentId = student.Id });
                }
                work.Save();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }
    }
}