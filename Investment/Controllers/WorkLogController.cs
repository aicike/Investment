﻿using System;
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
        public ActionResult Add(WorkLog workLog, bool hasGroupAccount, int page = 0)
        {
            WorkLogModel wlm = new WorkLogModel();
            if (page != -1)
            {
                workLog.LogDate = DateTime.Now;
            }
            if (workLog.LogDate.Year <= 2000)
            {
                return JavaScript("JMessage('请输入正确的填写时间。',true)");
            }
            workLog.GroupAccountID = LoginAccount.UserID;
            workLog.Month = workLog.LogDate.Month;
            workLog.day = workLog.LogDate.Day;
            Result result = wlm.Add(workLog);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            if (page == -1)
            {
                //从 MyWorklog页面跳转过来，Ajax刷新
                return JavaScript("JMessage('操作成功。',false);$('#Log').val('');LoadWorkLog('" + workLog.LogDate.ToShortDateString() + "');");
            }
            else
            {
                if (hasGroupAccount)
                {
                    return JavaScript("window.location.href='" + Url.Action("Index", "WorkLog", new { workFlowID = workLog.WorkFlowID, hasGroupAccount = true }) + "'");
                }
                else
                {
                    return JavaScript("window.location.href='" + Url.Action("Index", "WorkLog", new { workFlowID = workLog.WorkFlowID, hasGroupAccount = false }) + "'");
                }
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

        #region MyWorkLog用到的方法

        public ActionResult MyWorkLog()
        {
            //WorkFlowModel wfm = new WorkFlowModel();
            //var workflow = wfm.Get(workFlowID);
            //(workflow != null).NotAuthorizedPage();
            WorkLogModel wlm = new WorkLogModel();
            List<WorkLog> list = wlm.GetList(LoginAccount.UserID, DateTime.Now);
            ViewBag.List = list;
            return View();
        }

        //Ajax列表页面
        public PartialViewResult GetMyWorkLog(DateTime dt)
        {
            WorkLogModel wlm = new WorkLogModel();
            List<WorkLog> list = wlm.GetList(LoginAccount.UserID, dt);

            var allMonth = wlm.GetAllMonthList(LoginAccount.UserID, dt);
            var group = allMonth.GroupBy(a => a.day).ToList();
            List<JSON_WorkLog> json_worklogList = new List<JSON_WorkLog>();
            foreach (var item in group)
            {
                json_worklogList.Add(new JSON_WorkLog() { title = item.Count() + "条日志", start = item.FirstOrDefault().LogDate.ToString("yyyy-MM-dd") });
            }
            var msg = Newtonsoft.Json.JsonConvert.SerializeObject(json_worklogList);
            ViewBag.Msg = msg;
            return PartialView(list);
        }

        public string Delete_MyWrokLog(int id, DateTime date, int? workFlowID)
        {
            WorkLogModel wlm = new WorkLogModel();
            var result = wlm.Delete(id);
            if (result.HasError)
            {
                return "<script>JMessage('" + result.Error + "',true)</script>";
            }
            return "<script>JMessage('操作成功。',false);LoadWorkLog('" + date.ToShortDateString() + "');</script>";
        }

        public class JSON_WorkLog
        {
            public string title { get; set; }
            public string start { get; set; }
        }

        #endregion
    }
}
