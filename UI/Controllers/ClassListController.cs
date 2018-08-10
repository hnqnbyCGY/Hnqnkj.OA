using Hnqnkj.OA.DAL;
using Hnqnkj.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ClassListController : Controller
    {
        WorkUnit work = new WorkUnit();
        // GET: ClassList
        public ActionResult Index(int page = 0, int limit = 10, string sort = "Id", OrderMode order = OrderMode.Asc, int school = 0, string description = "")
        {
            if (Request.IsAjaxRequest())
            {
                var query = PredicateBuilder.True<Team>();
                return Json(new { count =work.Team.GetCount()});
            }
            return View();
        }
        
    }
}