using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class WorkLogModel : BaseModel<WorkLog>
    {
        /// <summary>
        /// 根据流程ID获取工作日志
        /// </summary>
        /// <param name="workflowID">流程ID</param>
        /// <param name="groupAccountID">值为空时，查找全部</param>
        /// <returns></returns>
        public List<WorkLog> GetList(int workflowID, int? groupAccountID)
        {
            var list = List().Where(a => a.WorkFlowID == workflowID);

            if (groupAccountID.HasValue)
            {
                list = list.Where(a => a.GroupAccountID == groupAccountID);
            }
            return list.OrderByDescending(a => a.LogDate).ToList();
        }
    }
}
