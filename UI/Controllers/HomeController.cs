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
using UI.Models;

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
            HttpCookie coName = Request.Cookies["Key"];
            HttpCookie coPwd = Request.Cookies["Value"];
            if (coName != null && coPwd != null)
            {
                string name = DES.Decrypt(coName.Value,"12345678","87654321");
                AdminUser user = Work.Admin.Where(u => u.AccountName == name && u.AccountPwd == coPwd.Value && (u.Status)).FirstOrDefault();
                if (user != null)
                {
                    string userdata = JsonConvert.SerializeObject(user);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                        user.AccountName, DateTime.Now, DateTime.Now.AddDays(1), true, userdata, FormsAuthentication.CookieDomain);
                    HttpCookie co = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    Response.Cookies.Add(co);
                    return RedirectToAction("Index");
                }
                else
                {
                    HttpCookie coLoginName = Request.Cookies["Key"];
                    if (coLoginName != null)
                    {
                        coLoginName.Expires = DateTime.Now.AddYears(-1);
                        Response.Cookies.Add(coLoginName);
                    }
                    HttpCookie coLoginPwd = Request.Cookies["Value"];
                    if (coLoginPwd != null)
                    {
                        coLoginPwd.Expires = DateTime.Now.AddYears(-1);
                        Response.Cookies.Add(coLoginPwd);
                    }
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            
            if (Session["code"] == null)
            {
                return Json(new { success = false, message = "验证码过期" });
            }
            if (model.Code.ToLower() != Session["code"].ToString().ToLower())
            {
                return Json(new { success = false, message = "验证码错误" });
            }
            model.LoginPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(model.LoginPwd, "md5");
            AdminUser user = Work.Admin.Where(u => u.AccountName == model.LoginName && u.AccountPwd == model.LoginPwd).FirstOrDefault();
            if (user != null)
            {
                string userdata = JsonConvert.SerializeObject(user);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    user.AccountName, DateTime.Now, DateTime.Now.AddDays(1), true, userdata, FormsAuthentication.CookieDomain);
                HttpCookie co = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                Response.Cookies.Add(co);
                if (model.IsRemember)
                {
                    HttpCookie coLoginName = new HttpCookie("Key", DES.Encrypt(model.LoginName, "12345678", "87654321"));
                    coLoginName.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(coLoginName);
                    HttpCookie coLoginPwd = new HttpCookie("Value", model.LoginPwd);
                    coLoginPwd.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(coLoginPwd);
                }
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "登录名或者密码错误" });
            }
        }
        [AllowAnonymous]
        public ActionResult ShowCode(double? id)
        {
            ValidataCode valideataCode = new ValidataCode();
            string strcode = valideataCode.getCode(4);
            Session["code"] = strcode;
            byte[] imgBytes = valideataCode.CreateValidateGraphic(strcode);
            return File(imgBytes, @"img/jpeg");
        }
        public ActionResult LogOff()
        {
            // FormsAuthentication.SignOut();
            Session.Abandon();
            HttpCookie coAuto = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (coAuto != null)
            {
                coAuto.Expires = DateTime.Now.AddYears(-1);

            }
            Response.Cookies.Add(coAuto);
            HttpCookie coLoginName = Request.Cookies["Key"];
            if (coLoginName != null)
            {
                coLoginName.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(coLoginName);
            }
            HttpCookie coLoginPwd = Request.Cookies["Value"];
            if (coLoginPwd != null)
            {
                coLoginPwd.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(coLoginPwd);
            }
            return RedirectToAction("Login");
        }
    }
}
