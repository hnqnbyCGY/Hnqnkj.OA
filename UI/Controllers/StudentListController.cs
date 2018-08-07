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
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                var stus = work.Student.GetPageEntitys().ToList();

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
                               s.Id,
                               Comnundate = work.CommunicationRecord.GetCount(c => c.Student.Id == s.Id) == 0 ? "无" :work.CommunicationRecord.GetAll(c => c.Student.Id == s.Id).OrderByDescending(z => z.CommunicationDate).FirstOrDefault().ToString()
                               
                           };
                return Json(new { code = 0, count = stus.Count(), data = list }, JsonRequestBehavior.AllowGet);
              
            }
            return View();
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
        public ActionResult Add(Student student)
        {
            try
            {
                FormsIdentity identity = User.Identity as FormsIdentity;
                AdminUser admin = JsonConvert.DeserializeObject<AdminUser>(identity.Ticket.UserData);
                student.OperatorAdminUserId = admin.Id;
                student.ListOperatorAdminUserId = admin.Id;
                student.ListOperatorDateTime = DateTime.Now;
                work.Student.Insert(student);
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