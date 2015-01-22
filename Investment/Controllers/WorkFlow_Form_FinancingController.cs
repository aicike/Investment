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
        /// 右侧操作控件(1:workflowID   2:financingID,companyID)
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
            ViewBag.workflowID = workflowID;
            ViewBag.FinancingID = financingID;
            ViewBag.CompanyID = companyID;
            List<AttachmentSel> sel = new List<AttachmentSel>();
            sel.Add(new AttachmentSel() { TableName = SystemConst.TableName.Company, TableID = companyID.Value });
            sel.Add(new AttachmentSel() { TableName = SystemConst.TableName.Financing, TableID = financingID.Value });
            ViewBag.Sel_Str = Newtonsoft.Json.JsonConvert.SerializeObject(sel);
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
            WorkFlowModel wfmodel = new WorkFlowModel();
            var workFlow = wfmodel.Get(WorkFlowID);

            //获取当前审批记录
            var SessionLoginUser = Session["SessionLoginUser"] as SessionLoginUser;
            var approvalRecord = workFlow.ApprovalRecord.Where(a => a.WorkFlowID == WorkFlowID && a.GroupAccountID == SessionLoginUser.UserID && a.Operation == -1).FirstOrDefault();
            if (approvalRecord != null)
            {
                ViewBag.approvalRecordID = approvalRecord.ID;//审批记录ID，上传控件使用
            }
            var currentNode = workFlow.WorkFlow_Node;//当前审批节点
            WorkFlow_NodeModel wfnm = new WorkFlow_NodeModel();
            var list = wfnm.GetWorkFlow_Node_WorkFlowNodeID(currentNode.ID);
            ViewBag.WFM = list;
            return PartialView(WorkFlowID);
        }

        /// <summary>
        /// 机构产品信息控件
        /// </summary>
        /// <param name="Products">机构产品ID 多个用“，”分割</param>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public ActionResult MechanismProducts(string Products, int? WorkFlowID)
        {
            List<MechanismProducts> mchanismproducts = new List<MechanismProducts>();
            int Static = 0; // 0待定（预览界面），1进行中，2结束，3放款机构
            //已生成流程
            if (WorkFlowID.HasValue)
            {
                //查询流程状态
                WorkFlowModel wfmodel = new WorkFlowModel();
                var workflow = wfmodel.Get(WorkFlowID.Value);
                //获取流程对接机构列表
                WorkFlowMechanismProductModel wmpModel = new WorkFlowMechanismProductModel();
                var workflowmchanismproducts = wmpModel.GetInfo_ByWorkFlowID(WorkFlowID.Value);

                foreach (var item in workflowmchanismproducts)
                {
                    //流程结束 取快照
                    if (workflow.State == 2 || workflow.State == 3)
                    {
                        MechanismProducts mp = Newtonsoft.Json.JsonConvert.DeserializeObject<MechanismProducts>(item.FormJson);
                        mp.State = item.State;
                        mchanismproducts.Add(mp);
                    }
                    else
                    {
                        var mp = item.MechanismProducts;
                        mp.State = item.State;
                        mchanismproducts.Add(mp);
                    }
                    //return Newtonsoft.Json.JsonConvert.SerializeObject(list);
                }
            }
            else
            {
                //机构ID集合
                var pros = Products.Split(',').Select(a => int.Parse(a)).ToArray();
                //获取机构列表信息
                MechanismProductsModel mpModel = new MechanismProductsModel();
                mchanismproducts = mpModel.GetList_ByIDS(pros);
            }

            return PartialView(mchanismproducts);
        }
    }
}
