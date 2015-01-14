using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace Investment.Controllers
{
    /// <summary>
    /// 审批流程表单——融资表单
    /// </summary>
    public class WorkFlow_Form_FinancingController : Controller
    {
        /// <summary>
        /// 表单
        /// </summary>
        public ActionResult Index(int financingID, int? workflowID)
        {
            Financing financing = null;
            if (workflowID.HasValue)
            {
                WorkFlowModel wfm = new WorkFlowModel();
                var wf = wfm.Get(workflowID.Value);
                if (wf != null)
                {
                    //只有当未通过和已完成时，才从json(快照)中取数据
                    if (wf.State == 2 || wf.State == 3)
                    {
                        financing = Newtonsoft.Json.JsonConvert.DeserializeObject<Financing>(wf.FormJson);
                    }
                }
            }
            if (financing == null)
            {
                FinancingModel fm = new FinancingModel();
                financing = fm.Get(financingID);
            }
            return PartialView(financing);
        }

        /// <summary>
        /// 右侧操作控件
        /// </summary>
        /// <returns></returns>
        public ActionResult RightOption(int? workflowID, int? financingID, int? companyID)
        {
            if (workflowID.HasValue)
            {
                WorkFlowModel wfm = new WorkFlowModel();
                var wf = wfm.Get(workflowID.Value);
                if (wf != null)
                {
                    ////只有当未通过和已完成时，才从json(快照)中取数据
                    //if (wf.State == 2 || wf.State == 3)
                    //{
                    //    var workflow_financing = Newtonsoft.Json.JsonConvert.DeserializeObject<Financing>(wf.FormJson);
                    //    if (workflow_financing != null)
                    //    {
                    //        financingID = workflow_financing.ID;
                    //    }
                    //    else {
                    //        financingID = wf.FinancingID;
                    //        companyID=workflow_financing
                    //    }
                    //}
                    financingID = wf.FinancingID;
                    companyID = wf.CompanyID;
                }
            }
            ViewBag.FinancingID = financingID;
            ViewBag.CompanyID = companyID;
            return PartialView();
        }

        /// <summary>
        /// 审批记录控件
        /// </summary>
        /// <param name="WrokFlowID"></param>
        /// <returns></returns>
        public ActionResult ApprovalRecord(int WorkFlowID)
        {
            ApprovalRecordModel ARModel = new ApprovalRecordModel();
            var list = ARModel.GetInfo_byWorkFlow(WorkFlowID);

            return PartialView(list);
        }

        /// <summary>
        /// 提交记录
        /// </summary>
        /// <returns></returns>
        public ActionResult CommitOpinion(int WorkFlowID)
        {
            return PartialView(WorkFlowID);
        }

        /// <summary>
        /// 机构产品信息
        /// </summary>
        /// <param name="Products"></param>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public ActionResult MechanismProducts(int Products, int? WorkFlowID)
        {

            return PartialView();
        }
    }
}
