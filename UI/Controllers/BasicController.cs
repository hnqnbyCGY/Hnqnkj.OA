using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqnkj.OA.DAL;

namespace UI.Controllers
{
    public class BasicController : Controller
    {
        WorkUnit unit = new WorkUnit();
        // GET: Test
        public ActionResult TypeList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetTypeList()
        {
            if (Request.IsAjaxRequest())
            {
                var data = unit.ConsultingType.GetAll();
                return Json(new { code = 0, msg = "", count = data.Count(), data }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        public ActionResult WayList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetWayList()
        {
            if (Request.IsAjaxRequest())
            {
                var data = unit.ConsultingWay.GetAll();
                return Json(new { code = 0, msg = "", count = data.Count(), data }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }


        
    }
}