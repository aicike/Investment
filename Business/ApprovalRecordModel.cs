using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    /// <summary>
    /// 审批记录表 model
    /// </summary>
    public class ApprovalRecordModel : BaseModel<ApprovalRecord>
    {
        /// <summary>
        /// 查询审批记录 根据流程
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public List<ApprovalRecord> GetInfo_byWorkFlow(int WorkFlowID)
        {
            var list = List().Where(a => a.WorkFlowID == WorkFlowID && a.Operation != -1).OrderBy(a => a.Date).ToList();
            return list;
        }


        /// <summary>
        /// 添加未审批记录
        /// </summary>
        /// <param name="workflow_node"></param>
        /// <param name="WorkFlowID">流程ID</param>
        /// <returns></returns>
        public Result AddunapprovedInfo(WorkFlow_Node workflow_node, int WorkFlowID)
        {
            Result result = new Result();
            //是否自审批
            if (workflow_node.WorkFlowNodeManager.IsSinceApproval)
            {
                WorkFlowModel WFModel = new WorkFlowModel();
                var workflow = WFModel.Get(WorkFlowID);
                ApprovalRecord approvalrecord = new ApprovalRecord();
                approvalrecord.AccountName = workflow.Financing.Owner_A.Name;
                approvalrecord.AccountPosition = "项目经理";
                approvalrecord.Date = DateTime.Now;
                approvalrecord.GroupAccountID = workflow.Financing.Owner_A_ID.Value;
                approvalrecord.NodeName = workflow_node.WorkFlowNodeManager.Name; ;
                approvalrecord.Operation = -1;
                approvalrecord.Opinion = "";
                approvalrecord.WorkFlowID = WorkFlowID;
                base.Add(approvalrecord);
            }
            else
            {
                foreach (var item in workflow_node.WorkFlowApprovalManager)
                {
                    ApprovalRecord approvalrecord = new ApprovalRecord();
                    approvalrecord.AccountName = item.GroupAccount.Name;
                    approvalrecord.AccountPosition = item.Position.Name;
                    approvalrecord.Date = DateTime.Now;
                    approvalrecord.GroupAccountID = item.GroupAccount.ID;
                    approvalrecord.NodeName = workflow_node.WorkFlowNodeManager.Name;
                    approvalrecord.Operation = -1;
                    approvalrecord.Opinion = "";
                    approvalrecord.WorkFlowID = WorkFlowID;
                    base.Add(approvalrecord);
                }
            }
            return result;
        }

        /// <summary>
        /// 判断当前流程节点是否全部审批完
        /// </summary>
        /// <param name="WorkFLowID"></param>
        /// <returns></returns>
        public bool JudgeThisNodeIsOver(int WorkFLowID)
        {
            bool IsOver = false;
            var list = base.List().Where(a => a.WorkFlowID == WorkFLowID && a.Operation == -1 ).ToList();
            if (list.Count > 0)
            {
                IsOver = true;
            }
            return IsOver;
        }

        /// <summary>
        /// 更新节点审批记录
        /// </summary>
        /// <param name="WorkFLowID">工作流ID</param>
        /// <param name="GroupAccountID">审批人ID</param>
        /// <param name="Content">审批意见</param>
        /// <param name="Operation">审批操作 -1未操作，0提交申请,1通过，2不通过，3驳回</param>
        /// <returns></returns>
        public Result UPDApprovedInfo(int WorkFLowID, int GroupAccountID, string Content, int Operation)
        {
            Result result = new Result();
            var approvalrecord = base.List().Where(a => a.WorkFlowID == WorkFLowID && a.Operation == -1 && a.GroupAccountID == GroupAccountID).FirstOrDefault();
            approvalrecord.Opinion = Content;
            approvalrecord.Operation = Operation;
            result = base.Edit(approvalrecord);
            return result;
        }

        /// <summary>
        /// 当流程不通过 或 驳回时删除多余的审批记录
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public void DelunapprovedInfo(int WorkFlowID)
        {
            string sql = string.Format("delete ApprovalRecord where WorkFlowID={0} and Operation=-1",WorkFlowID);
            int cnt = base.SqlExecute(sql);
        }
    }
}
