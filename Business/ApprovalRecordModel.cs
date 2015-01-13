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
    }
}
