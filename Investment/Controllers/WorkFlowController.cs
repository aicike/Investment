using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

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





        #region 预览界面
        private static object LockObj = new object();

        /// <summary>
        /// 预览界面
        /// </summary>
        /// <param name="financingID">融资意向</param>
        /// <param name="Products">对接机构 数据结构1,2,3</param>
        /// <returns></returns>
        public ActionResult Preview(int financingID, string Products)
        {
            ViewBag.financingID = financingID;
            return View();
        }

        /// <summary>
        /// 生成待定义业务单
        /// </summary>
        /// <returns></returns>
        public ActionResult SetPendingForm()
        {
            lock (LockObj)
            {
                WorkFlowModel WFModel = new WorkFlowModel();


            }
            return View();
        }
        #endregion



    }
}
