using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqnkj.OA.Model;
using Hnqnkj.OA.DAL;

namespace UI.Controllers
{
    public class ChatListController : Controller
    {
        WorkUnit work = new WorkUnit();
        // GET: ChatList
        public ActionResult Index(int page = 0, int offset=0 ,int limit = 10, string sort = "Id",OrderMode order= OrderMode.Asc)
        {
            if (Request.IsAjaxRequest())
            {
                var list = work.CommunicationRecord.GetPageEntitys(m=>1==1,limit,offset,sort,order).ToList();
                return Json(new { code=0,count=list.Count,data=list},JsonRequestBehavior.AllowGet);
            }
            return View();
        }
    }
}