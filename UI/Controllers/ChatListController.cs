using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqnkj.OA.Model;
using Hnqnkj.OA.DAL;
using System.Linq.Expressions;

namespace UI.Controllers
{
    public class ChatListController : Controller
    {
        WorkUnit work = new WorkUnit();
        // GET: ChatList
        public ActionResult Index(int page = 0,int limit = 10, string sort = "Id",OrderMode order = OrderMode.Asc,int school =0 ,int type =0, int way = 0,string description ="")
        {
            if (Request.IsAjaxRequest())
            {
                var querylist = PredicateBuilder.True<CommunicationRecord>() ;
                if (type!=0)
                {
                  querylist = querylist.And(m => m.ConsultingTypeId == type);
                }
                if (way!=0)
                {
                    querylist = querylist.And(m => m.ConsultingWayId == way);
                    
                }
                if (!string.IsNullOrEmpty(description))
                {
                    querylist = querylist.And(m=>m.StudentName.Contains(description));
                }
                int offset = (page - 1) * limit;
                var query = work.CommunicationRecord.GetPageEntitys(querylist,limit,offset,sort,order);
                var list = from s in query
                           select new { s.ChatWay, s.CommunicationContent, s.IntentionDegree.Leavl,s.ConType,s.Shcool.Name,s.Id };
                return Json(new { code=0,count=query.Count(),data=list},JsonRequestBehavior.AllowGet);
            }
            ViewBag.Shcool =  work.Shcool.Where(m => 1 == 1).ToList();
            ViewBag.Type = work.ConsultingType.Where(PredicateBuilder.True<ConsultingType>());
            ViewBag.Way = work.ConsultingWay.Where(m => 1 == 1);
            return View();
        }
        [HttpGet]
        public ActionResult Add(int id=1)
        {
            ViewBag.Student = work.Student.GetEntityById(id);
            ViewBag.Shcool = work.Shcool.Where(m => 1 == 1).ToList();
            ViewBag.Type = work.ConsultingType.Where(PredicateBuilder.True<ConsultingType>());
            ViewBag.Way = work.ConsultingWay.Where(m => 1 == 1);
            ViewBag.Intention = work.IntentionDegree.GetAll(m=>m.Status).ToList();
            ViewBag.Student = work.Student.GetEntityById(id);
            ViewBag.Users = work.Admin.GetAll(m => m.Status);
            return View();
        }
        [HttpPost]
        public ActionResult Add(CommunicationRecord model)
        {
            try
            {
                model.Student =work.Student.GetEntityById(Convert.ToInt32(Request.Params["Student"]));
                work.CommunicationRecord.Insert(model);
                work.Save();
                return Json(new { success = true });
            }
            catch (Exception e)
            { 
                return Json(new { success = false,msg =e.Message });
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(work.CommunicationRecord.GetEntityById(id));
        }
        //[HttpPost]
        //public ActionResult Edit(CommunicationRecord model)
        //{

        //}
    }
}