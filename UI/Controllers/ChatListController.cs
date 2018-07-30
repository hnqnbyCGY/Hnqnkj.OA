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
                var query = work.CommunicationRecord.GetPageEntitys(m=>1==1,limit,offset,sort,order);
                var list = from s in query
                           select new { s.ChatWay, s.CommunicationContent, s.IntentionDegree.Leavl,s.ConType,s.Shcool.Name,s.Id };
                return Json(new { code=0,count=query.Count(),data=list},JsonRequestBehavior.AllowGet);
            }
            return View();
        }
    }
}