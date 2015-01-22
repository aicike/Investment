using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Transactions;
using System.Data.Entity;

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

            var financing = base.Context.Financings.Where(a => a.ID == obj.FinancingID).AsNoTracking().FirstOrDefault();//融资信息

            var company = base.Context.Company.Where(a => a.ID == obj.Financing.CompanyID).AsNoTracking().FirstOrDefault(); //公司信息

            //var wfmpIDs = obj.WorkFlowMechanismProduct.Select(a => a.MechanismProductsID).ToList();
            //base.Context.MechanismProducts.Where(a => wfmpIDs.Contains(a.ID));//机构产品信息

            financing.Company = company;


            string json = Newtonsoft.Json.JsonConvert.SerializeObject(financing);
            return json;
        }

        /// <summary>
        /// 根据流程ID 存储产品快照
        /// </summary>
        /// <param name="WorkFlowID">流程ID</param>
        /// <returns></returns>
        public Result Get_To_Json_Product(int WorkFlowID)
        {
            Result result = new Result();
            //获取流程中选择的机构
            WorkFlowMechanismProductModel WFMPModel = new WorkFlowMechanismProductModel();
            var wfmps = WFMPModel.GetInfo_ByWorkFlowID(WorkFlowID);
            MechanismProductsModel mpModel = new MechanismProductsModel();
            //生成快照
            foreach (var item in wfmps)
            {
                var mp = mpModel.Get(item.MechanismProductsID);
                item.FormJson = Newtonsoft.Json.JsonConvert.SerializeObject(mp);
                WFMPModel.Edit(item);
            }
            return result;
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
                    //更改融资意向状态
                    FinancingModel FModel = new FinancingModel();
                    var financing = FModel.Get(workflow.FinancingID);
                    financing.Status = 1;
                    FModel.Edit(financing);

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
                        //生成意向快照
                        workflow.FormJson = Get_To_Json_Financing(WorkFlowID);
                        base.Edit(workflow);
                        //生成产品快照
                        Get_To_Json_Product(WorkFlowID);
                        //更改融资意向状态
                        FinancingModel FModel = new FinancingModel();
                        var financing = FModel.Get(workflow.FinancingID);
                        financing.Status = 2;
                        FModel.Edit(financing);
                        
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
                //生成意向快照
                workflow.FormJson = Get_To_Json_Financing(WorkFlowID);
                base.Edit(workflow);
                //生成产品快照
                Get_To_Json_Product(WorkFlowID);
                //更新审批记录
                ARModel.UPDApprovedInfo(WorkFlowID, GroupAccountID, Content,2);
                //删除多余记录
                ARModel.DelunapprovedInfo(WorkFlowID);
                //更改融资意向状态
                FinancingModel FModel = new FinancingModel();
                var financing = FModel.Get(workflow.FinancingID);
                financing.Status = 0;
                FModel.Edit(financing);
                
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
                //添加下一节点审批人记录
                WorkFlow_NodeModel w_nModel = new WorkFlow_NodeModel();
                var Nextworkflow_node = w_nModel.Get(WorkFlow_NodeID);
                ARModel.AddunapprovedInfo(Nextworkflow_node, WorkFlowID);
                scope.Complete();
            }
            return result;
        }

        /// <summary>
        /// 查询该意向是否生成待定单或已提交申请
        /// </summary>
        /// <param name="FinancingID"></param>
        /// <returns>true 已生成</returns>
        public Result GetISCreatePending(int FinancingID)
        {
            Result result = new Result();
            var item = List().Where(a=>a.FinancingID==FinancingID).FirstOrDefault();
            if (item != null)
            {
                if (item.State == 0)
                {
                    result.HasError = true;
                    result.Error = "此业务已生成待定业务，请在‘待定业务’中查看";
                }
                else if (item.State == 1)
                {
                    result.HasError = true;
                    result.Error = "此业务正在审批中，请在‘我的申请’中查看";
                }
                else if (item.State == 2)
                {
                    result.HasError = true;
                    result.Error = "此业务已完成业务流程，请在‘我的申请’中查看";
                }
            }
            return result;
        }
    }
}
