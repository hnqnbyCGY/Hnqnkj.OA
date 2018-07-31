using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqnkj.OA.DAL;
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
        public ActionResult Index()
        {
            return View();
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
    }
}