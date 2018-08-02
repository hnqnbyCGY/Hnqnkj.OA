using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqnkj.OA.DAL;
using Hnqnkj.OA.Model;

namespace UI.Controllers
{
    public class ChatTypeController : Controller
    {
        WorkUnit work = new WorkUnit();
        // GET: ChatType
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                var list = work.ConsultingType.Where(m => 1 == 1).ToList();
                return Json(new { code = 0, msg = "", data = list }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Add(ConsultingType model)
        {
            try
            {
                work.ConsultingType.Insert(model);
                work.Save();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
 
            }
        }
    }
}