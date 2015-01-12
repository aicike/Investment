using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace Investment.Controllers
{
    public class WorkFlowApprovalController : BaseController
    {
        //
        // GET: /WorkFlowApproval/

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
            ViewBag.Products = Products;
            return View();
        }

        /// <summary>
        /// 生成待定义业务单
        /// </summary>
        /// <param name="financingID">融资意向</param>
        /// <param name="Products">对接机构 数据结构1,2,3</param>
        /// <returns></returns>
        public ActionResult SetPendingForm(int financingID, string Products)
        {
            Result result = new Result();
            lock (LockObj)
            {
                //融资意向
                FinancingModel FModel = new FinancingModel();
                var financing = FModel.Get(financingID);
                //流程数据
                WorkFlowModel WFModel = new WorkFlowModel();
                WorkFlow workflow = new WorkFlow();
                workflow.BeginDate = DateTime.Now;
                workflow.FinancingID = 1;
                workflow.FormJson = "";
                workflow.GroupAccountID = LoginAccount.UserID;
                workflow.State = 0;
                workflow.WorkFlowManagerID = financing.WorkFlowManagerID;
                result = WFModel.Add(workflow);
            }
            if (result.HasError)
            {
                return JavaScript("JMessage('生成失败 请稍后再试',true)");

            }
            else
            {
                return JavaScript("window.location.href='" + Url.Action("Pending", "WorkFlow") + "'");
            }
        }
        #endregion

    }
}
