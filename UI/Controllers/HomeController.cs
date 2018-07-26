using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqnkj.OA.DAL;
using System.Web.Security;
using Newtonsoft.Json;
using Hnqnkj.OA.Model;
using Hnqnkj.OA.Common;

namespace UI.Controllers
{
    public class HomeController : Controller
    {

        WorkUnit Work = new WorkUnit();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name,string pwd)
        {
            var user = new { name = "admin", pwd = "123456" };
            string userdata = JsonConvert.SerializeObject(user);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                user.name, DateTime.Now, DateTime.Now.AddDays(1), true, userdata, FormsAuthentication.CookieDomain);
            HttpCookie co = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            Response.Cookies.Add(co);
                HttpCookie coLoginName = new HttpCookie("Key", DES.Encrypt(user.name, "12345678", "87654321"));
                coLoginName.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(coLoginName);
                HttpCookie coLoginPwd = new HttpCookie("Value", user.pwd);
                coLoginPwd.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(coLoginPwd);
            return Json(new { success = true });
        }
        [HttpPost]
        //public ActionResult AutoLogin()
        //{

        //}
    }
}