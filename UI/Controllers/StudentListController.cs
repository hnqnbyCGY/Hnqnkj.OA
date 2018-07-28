using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqnkj.OA.Model;
using Hnqnkj.OA.DAL;

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
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Add(Student student)
        {
            try
            {
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