using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    /// <summary>
    /// 流程审批人
    /// </summary>
    public class WorkFlowApprovalManagerModel : BaseModel<WorkFlowApprovalManager>
    {
        /// <summary>
        /// 根据流程节点删除数据
        /// </summary>
        /// <param name="WorkFlow_NodeID">流程表与节点中间表ID</param>
        /// <returns></returns>
        public Result DelInfo(int WorkFlow_NodeID)
        {
            Result result = new Result();
            string sql = "delete WorkFlowApprovalManager where WorkFlow_NodeID=" + WorkFlow_NodeID;
            base.SqlExecute(sql);

            return result;
        }

        
    }
}
