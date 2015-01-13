using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Transactions;

namespace Business
{
    /// <summary>
    /// 工作流程表 Model
    /// </summary>
    public class WorkFlowModel : BaseModel<WorkFlow>
    {
        //申请表单锁
        private static object LockObj = new object();
        /// <summary>
        /// 根据负责人ID 和 状态 获取列表
        /// </summary>
        /// <param name="state">状态 0草稿，1进行中，2已完成，3未通过</param>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetListByState(int state, int groupAccountID)
        {
            return List().Where(a => a.State == state && a.Financing.Owner_A_ID == groupAccountID);
        }

        /// <summary>
        /// 我的申请
        /// </summary>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetMyApplication(int groupAccountID)
        {
            var list = List().Where(a => a.Financing.Owner_A_ID == groupAccountID&&a.State!=0);
            return list;
        }

        /// <summary>
        /// 我的待办
        /// </summary>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetBacklog(int groupAccountID)
        {
            var list = List().Where(a => a.ApprovalRecord.Any(b => b.Operation == -1 && b.GroupAccountID == groupAccountID));
            return list;
        }

        /// <summary>
        /// 我的已办
        /// </summary>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetHistory(int groupAccountID)
        {
            var list = List().Where(a => a.ApprovalRecord.Any(b => (b.Operation == 1 || b.Operation == 2 || b.Operation == 3) && b.GroupAccountID == groupAccountID));
            return list;
        }

        /// <summary>
        /// 我的辅助
        /// </summary>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetAssist(int groupAccountID)
        {
            var list = List().Where(a => a.Financing.Owner_B_ID == groupAccountID);
            return list;
        }

        /// <summary>
        /// 项目列表
        /// </summary>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetList()
        {
            var list = List().Where(a => a.State != 0);
            return list;
        }


        /// <summary>
        /// 根据流程ID获取 融资信息、公司信息的 json数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get_To_Json_Financing(int id)
        {
            var obj = Get(id);//工作流程表

            base.Context.Configuration.ProxyCreationEnabled = false;

            var financing = base.Context.Financings.Where(a => a.ID == obj.FinancingID).FirstOrDefault();//融资信息

            var company = base.Context.Company.Where(a => a.ID == obj.Financing.CompanyID).FirstOrDefault(); //公司信息

            //var wfmpIDs = obj.WorkFlowMechanismProduct.Select(a => a.MechanismProductsID).ToList();
            //base.Context.MechanismProducts.Where(a => wfmpIDs.Contains(a.ID));//机构产品信息

            financing.Company = company;


            string json = Newtonsoft.Json.JsonConvert.SerializeObject(financing);
            return json;
        }


        /// <summary>
        /// 提交申请
        /// </summary>
        /// <param name="WorkFlowID">工作流ID</param>
        /// <param name="GroupAccountID">审批人ID</param>
        /// <returns></returns>
        public Result SubWorkFlow(int WorkFlowID, int GroupAccountID)
        {
            Result result = new Result();
            lock (LockObj)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    //获取流程信息
                    var workflow = base.Get(WorkFlowID);
                    //生成单号
                    Commons.Common com = new Commons.Common();
                    var number = com.SqlQuery<string>("select dbo.GetWorkFlowNumber('ZH',3)");
                    workflow.Number = number.FirstOrDefault();
                    workflow.State = 1;
                    //查找下一节点
                    WorkFlow_NodeModel w_nModel = new WorkFlow_NodeModel();
                    var workflow_node = w_nModel.Getwork_node(workflow.Financing.WorkFlowManagerID, 2);
                    if (workflow_node == null)
                    {
                        result.HasError = true;
                        result.Error = "该流程尚未配置！";
                        return result;
                    }
                    workflow.WorkFlow_NodeID = workflow_node.ID;
                    base.Edit(workflow);
                    //添加审批记录
                    ApprovalRecordModel ARModel = new ApprovalRecordModel();
                    ApprovalRecord approvalrecord = new ApprovalRecord();
                    approvalrecord.AccountName = workflow.Financing.Owner_A.Name;
                    approvalrecord.AccountPosition = "项目经理";
                    approvalrecord.Date = DateTime.Now;
                    approvalrecord.GroupAccountID = GroupAccountID;
                    approvalrecord.NodeName = "提交业务申请";
                    approvalrecord.Operation = 0;
                    approvalrecord.Opinion = "";
                    approvalrecord.WorkFlowID = WorkFlowID;
                    ARModel.Add(approvalrecord);
                    //添加下一节点审批人记录
                    ARModel.AddunapprovedInfo(workflow_node, WorkFlowID);
                    scope.Complete();
                }
            }
            return result;
        }

        /// <summary>
        /// 审批通过公共方法
        /// </summary>
        /// <param name="WorkFlowID">工作流ID</param>
        /// <param name="GroupAccountID">审批人ID</param>
        /// <param name="Content">审批意见</param>
        /// <returns></returns>
        public Result WorkFlow_Agree(int WorkFlowID, int GroupAccountID, string Content)
        {
            Result result = new Result();
            using (TransactionScope scope = new TransactionScope())
            {
                ApprovalRecordModel ARModel = new ApprovalRecordModel();
                //获取流程信息
                var workflow = base.Get(WorkFlowID);
                //更新审批记录
                ARModel.UPDApprovedInfo(WorkFlowID, GroupAccountID, Content, 1);
                //判断当前节点是否审批完成
                var IsOver = ARModel.JudgeThisNodeIsOver(WorkFlowID);
                //查找下一节点
                WorkFlow_NodeModel w_nModel = new WorkFlow_NodeModel();
                if (IsOver)
                {
                    var Nextworkflow_node = w_nModel.GetNextWorkFlow_Node(workflow.Financing.WorkFlowManagerID, workflow.WorkFlow_NodeID.Value);
                    //流程结束
                    if (Nextworkflow_node == null)
                    {
                        //更改流程状态
                        workflow.State = 2;//已完成
                        base.Edit(workflow);
                        //生成快照

                    }
                    else
                    {
                        //更改下一流程节点
                        workflow.WorkFlow_NodeID = Nextworkflow_node.ID;
                        base.Edit(workflow);
                        //添加下一节点审批人记录
                        ARModel.AddunapprovedInfo(Nextworkflow_node, WorkFlowID);
                    }
                }
                scope.Complete();
            }
            return result;
        }

        /// <summary>
        /// 审批不通过公共方法
        /// </summary>
        /// <param name="WorkFlowID">工作流ID</param>
        /// <param name="GroupAccountID">审批人ID</param>
        /// <param name="Content">审批意见</param>
        /// <returns></returns>
        public Result WorkFlow_Disagree(int WorkFlowID, int GroupAccountID,string Content)
        {
            Result result = new Result();
            using (TransactionScope scope = new TransactionScope())
            {
                ApprovalRecordModel ARModel = new ApprovalRecordModel();
                //获取流程信息
                var workflow = base.Get(WorkFlowID);
                //更新流程状态
                workflow.State = 3;
                base.Edit(workflow);
                //更新审批记录
                ARModel.UPDApprovedInfo(WorkFlowID, GroupAccountID, Content,2);
                //删除多余记录
                ARModel.DelunapprovedInfo(WorkFlowID);
                //生成快照
                

                scope.Complete();
            }
            return result;
        }

        /// <summary>
        /// 驳回公共方法
        /// </summary>
        /// <param name="WorkFlowID">工作流ID</param>
        /// <param name="GroupAccountID">审批人ID</param>
        /// <param name="WorkFlow_NodeID">驳回到的节点ID</param>
        /// <param name="Content">审批意见</param>
        /// <returns></returns>
        public Result WorkFlow_Reject(int WorkFlowID, int GroupAccountID, int WorkFlow_NodeID, string Content)
        {
            Result result = new Result();
            using (TransactionScope scope = new TransactionScope())
            {
                ApprovalRecordModel ARModel = new ApprovalRecordModel();
                //获取流程信息
                var workflow = base.Get(WorkFlowID);
                //更新流程节点
                workflow.WorkFlow_NodeID = WorkFlow_NodeID;
                base.Edit(workflow);
                //更新审批记录
                ARModel.UPDApprovedInfo(WorkFlowID, GroupAccountID, Content,3);
                //删除多余记录
                ARModel.DelunapprovedInfo(WorkFlowID);
                scope.Complete();
            }
            return result;
        }


    }
}
