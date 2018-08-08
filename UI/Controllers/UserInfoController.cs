using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Hnqnkj.OA.DAL;
using Hnqnkj.OA.Model;
namespace UI.Controllers
{
    public class UserInfoController : Controller
    {
        private WorkUnit unit = new WorkUnit();
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        // GET: UserInfo
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(AdminUser admin)
        {
            try
            {
                admin.AccountPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(admin.AccountPwd, "md5");
                admin.LoginCount = 0;
                admin.LastLogingTime = DateTime.Now;
                unit.Admin.Insert(admin);
                unit.Save();
                return Json(new { success=true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }      
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AccountList()
        {
            if (Request.IsAjaxRequest())
            {
                var data = unit.Admin.GetAll();
                return Json(new { code = 0, msg = "", count = data.Count(), data }, JsonRequestBehavior.AllowGet);
            }
            return View();        
        }   
        [HttpPost]
        public ActionResult Del(int id)
        {
            try
            {
                unit.Admin.Delete(id);
                unit.Save();
                return Json(new { msg = "ok" });
            }
            catch (Exception)
            {
               return Json(new { msg = "error" });
            }     
        }
    }
}