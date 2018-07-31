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
            return View();
        }
        [HttpPost]
        public ActionResult Index(int i)
        {
            return Json(new{ });
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.sps = work.Specialty.Where(m => true).ToList();//所有专业
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