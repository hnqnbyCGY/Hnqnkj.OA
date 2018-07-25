using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqnkj.OA.DAL;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        OADBContext context = new OADBContext();
  
        public ActionResult Index()
        {
            context.AdminUsers.Add(new Hnqnkj.OA.Model.AdminUser());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}