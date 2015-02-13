using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace Investment.Controllers
{
    public class WorkFlowController : BaseController
    {
        /// <summary>
        /// 待定业务列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Pending(int? id)
        {
            WorkFlowModel wfm = new WorkFlowModel();
            var objs = wfm.GetListByState(0, LoginAccount.UserID);
            var list = objs.ToPagedList(id ?? 1, 15);
            return View(list);
        }

        /// <summary>
        /// 我的申请列表
        /// </summary>
        /// <returns></returns>
        public ActionResult MyApplication(int? id)
        {
            WorkFlowModel wfm = new WorkFlowModel();
            var objs = wfm.GetMyApplication(LoginAccount.UserID);
            var list = objs.ToPagedList(id ?? 1, 15);
            return View(list);
        }

        /// <summary>
        /// 我的待办列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Backlog(int? id)
        {
            WorkFlowModel wfm = new WorkFlowModel();
            var objs = wfm.GetBacklog(LoginAccount.UserID);
            var list = objs.ToPagedList(id ?? 1, 15);
            return View(list);
        }

        /// <summary>
        /// 我的已办列表
        /// </summary>
        /// <returns></returns>
        public ActionResult History(int? id)
        {
            WorkFlowModel wfm = new WorkFlowModel();
            var objs = wfm.GetHistory(LoginAccount.UserID);
            var list = objs.ToPagedList(id ?? 1, 15);
            return View(list);
        }

        /// <summary>
        /// 辅助项目
        /// </summary>
        /// <returns></returns>
        public ActionResult Assist(int? id)
        {
            WorkFlowModel wfm = new WorkFlowModel();
            var objs = wfm.GetAssist(LoginAccount.UserID);
            var list = objs.ToPagedList(id ?? 1, 15);
            return View(list);
        }

        /// <summary>
        /// 项目列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List(int? id)
        {
            WorkFlowModel wfm = new WorkFlowModel();
            var objs = wfm.GetList();
            var list = objs.ToPagedList(id ?? 1, 15);
            return View(list);
        }

        /// <summary>
        /// 流程进度图表
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public ActionResult WorkFlowSchedule(int WorkFlowID)
        {
            //流程信息
            WorkFlowModel wfm = new WorkFlowModel();
            var workflow = wfm.Get(WorkFlowID);
            ViewBag.number = workflow.Number;
            ViewBag.Types = workflow.Financing.WorkFlowManager.Name;
            if (workflow.WorkFlow_NodeID.HasValue)
            {
                ViewBag.Work_nodeOrder = workflow.WorkFlow_Node.Order;
            }
            else
            {
                ViewBag.Work_nodeOrder = 0;
            }
            //获取流程节点
            WorkFlow_NodeModel wfnmodel = new WorkFlow_NodeModel();
            var workflow_node = wfnmodel.GetWorkFlow_Node(workflow.Financing.WorkFlowManagerID.Value).OrderBy(a => a.Order).ToList();
            return View(workflow_node);
        }

        #region 更改项目AB角色
        /// <summary>
        /// 更改AB角色界面
        /// </summary>
        /// <returns></returns>
        public ActionResult EditABRole(int WorkFlowID)
        {
            WorkFlowModel wfm = new WorkFlowModel();
            var workflow = wfm.Get(WorkFlowID);
            GroupAccountModel gamodel = new GroupAccountModel();
            var GAlist = gamodel.GetListWithoutAdmin();
            ViewBag.GAlist = GAlist;
            return View(workflow);
        }

        /// <summary>
        /// 更改AB角色界面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditABRole(int FinancingID, int AuserID, int BuserID)
        {
            FinancingModel fm = new FinancingModel();
            fm.SetABRole(FinancingID, AuserID, BuserID);
            //邮件通知
            return JavaScript("ckbOk()");
        }
        #endregion
    }
}
