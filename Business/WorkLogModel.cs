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

        /// <summary>
        /// 根据人员ID和时间获取工作日志
        /// </summary>
        /// <param name="groupAccountID">人员ID</param>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public List<WorkLog> GetList(int groupAccountID,DateTime dt)
        {
            var nextDate = dt.Date.AddDays(1);
            var list = List().Where(a => a.GroupAccountID == groupAccountID && (a.LogDate >= dt.Date && a.LogDate < nextDate));

            return list.OrderByDescending(a => a.LogDate).ToList();
        }

        /// <summary>
        /// 获取当月日志统计
        /// </summary>
        public List<WorkLog> GetAllMonthList(int groupAccountID, DateTime dt)
        {
            var begin= Convert.ToDateTime(dt.ToString("yyyy-MM-01")).Date;
            var end = Convert.ToDateTime(dt.AddMonths(1).ToString("yyyy-MM-01")).Date;
            var list = List().Where(a => a.GroupAccountID == groupAccountID && (a.LogDate >= begin && a.LogDate < end));
            return list.OrderByDescending(a => a.LogDate).ToList();
        }
    }
}
