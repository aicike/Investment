using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace Investment.Controllers
{
    public class WorkLogController : BaseController
    {
        public ActionResult Index(int workFlowID, bool hasGroupAccount)
        {
            WorkFlowModel wfm = new WorkFlowModel();
            var workflow = wfm.Get(workFlowID);
            (workflow != null).NotAuthorizedPage();
            WorkLogModel wlm = new WorkLogModel();
            List<WorkLog> list = new List<WorkLog>();
            if (hasGroupAccount)
            {
                list = wlm.GetList(workFlowID, LoginAccount.UserID);
            }
            else
            {
                list = wlm.GetList(workFlowID, null);
            }
            ViewBag.workflow = workflow;
            ViewBag.List = list;
            ViewBag.hasGroupAccount = hasGroupAccount;
            return View();
        }

        [HttpPost]
        public ActionResult Add(WorkLog workLog, bool hasGroupAccount)
        {
            WorkLogModel wlm = new WorkLogModel();
            workLog.LogDate = DateTime.Now;
            workLog.GroupAccountID = LoginAccount.UserID;
            Result result = wlm.Add(workLog);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            if (hasGroupAccount)
            {
                return JavaScript("window.location.href='" + Url.Action("Index", "WorkLog", new { workFlowID = workLog.WorkFlowID, hasGroupAccount = true }) + "'");
            }
            else
            {
                return JavaScript("window.location.href='" + Url.Action("Index", "WorkLog", new { workFlowID = workLog.WorkFlowID, hasGroupAccount = false }) + "'");
            }
        }

        public string Delete(int id, int workFlowID, bool hasGroupAccount)
        {
            WorkLogModel wlm = new WorkLogModel();
            var result = wlm.Delete(id);
            if (result.HasError)
            {
                return "<script>JMessage('" + result.Error + "',true)</script>";
            }
            if (hasGroupAccount)
            {
                return "<script>window.location.href='" + Url.Action("Index", "WorkLog", new { workFlowID = workFlowID, hasGroupAccount = true }) + "';</script>";
            }
            else
            {
                return "<script>window.location.href='" + Url.Action("Index", "WorkLog", new { workFlowID = workFlowID, hasGroupAccount = false }) + "';</script>";
            }
        }

        public ActionResult MyWorkLog()
        {
            return View();
        }
    }
}
