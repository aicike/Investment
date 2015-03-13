using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Investment.Controllers
{
    /// <summary>
    /// 利息管理
    /// </summary>
    public class InterestManagerController : BaseController
    {
        //
        // GET: /InterestManager/
        public ActionResult Index(int WorkFlowID)
        {
            WorkFlowModel wfmodel = new WorkFlowModel();
            var item = wfmodel.Get(WorkFlowID);

            InterestManagerModel immodel = new InterestManagerModel();
            var intlist = immodel.GetList_ByWFID(WorkFlowID);
            ViewBag.intlist = intlist;
            return View(item);
        }

        //更改利息状态
        public string EditInterest(int id)
        {
            InterestManagerModel immodel = new InterestManagerModel();
            var im = immodel.Get(id);
            im.IsCharge = true;
            var result = immodel.Edit(im);
            if (result.HasError)
            {
                return "<script>JMessage('" + result.Error + "',true)</script>";
            }
            return "<script>window.location.href='" + Url.Action("Index", "InterestManager", new { WorkFlowID =im.WorkFlowID}) + "';</script>";
        }

        //确认收回本金
        public ActionResult EditSHBJ(int WorkFlowID)
        {
            WorkFlowModel wfmodel = new WorkFlowModel();
            var item = wfmodel.Get(WorkFlowID);
            item.IsInterest = true;
            var result = wfmodel.Edit(item);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Index", "InterestManager", new { WorkFlowID = WorkFlowID }) + "'");
        }

    }
}
