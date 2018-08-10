using Hnqnkj.OA.DAL;
using Hnqnkj.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class SchoolInfoController : Controller
    {
        WorkUnit unit = new WorkUnit();
        // GET: SchoolInfo
        public ActionResult SchoolList()
        {
            if (Request.IsAjaxRequest())
            {
                var data = unit.School.GetAll();
                return Json(new { code = 0, msg = "", count = data.Count(), data }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
           
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(School school)
        {
            try
            {
                school.CreateTime = DateTime.Now;
                unit.School.Insert(school);
                unit.Save();
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }        
        }
        public ActionResult Edit(int id)
        {        
            ViewBag.model = unit.School.Where(m => m.Id == id).First(); ;
            return View();
        }

        public ActionResult Updata(School school)
        {
            try
            {
                unit.School.Update(school,"CreateTime");
                unit.Save();
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }
        public ActionResult Del(int id)
        {
            try
            {
                unit.School.Delete(id);
                unit.Save();
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }
    }
}