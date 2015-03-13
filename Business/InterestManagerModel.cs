using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Transactions;

namespace Business
{
    /// <summary>
    /// 利息管理
    /// </summary>
    public class InterestManagerModel : BaseModel<Interest>
    {

        /// <summary>
        /// 根据流程ID 获取利息列表
        /// </summary>
        /// <param name="workflowID"></param>
        /// <returns></returns>
        public List<Interest> GetList_ByWFID(int workflowID)
        {
            var list = List().Where(a => a.WorkFlowID == workflowID).OrderBy(a => a.BeginDate).ToList();
            return list;
        }

        /// <summary>
        /// 业务结束后 添加收利息月份
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public Result InsertInterest(int financingID,int workflowID)
        {
            Result result = new Result();
            FinancingModel fmodel = new FinancingModel();
            var fitem = fmodel.Get(financingID);
            int mindate = fitem.MinTimeLimit;
            int maxdate = fitem.MaxTimeLimit ?? 0;
            //月份
            var datecnt = mindate + maxdate;
            WorkFlowModel wmodel = new WorkFlowModel();
            var witem = wmodel.Get(workflowID);
            //放款日期
            var fkdate = witem.LoanDay.Value;
            DateTime begindate = fkdate;
            using (TransactionScope scope = new TransactionScope())
            {
                Interest interest = new Interest();
                interest.IsCharge = false;
                interest.WorkFlowID = workflowID;
                for (int i = 0; i < mindate; i++)
                {
                    interest.type = 0;
                    interest.BeginDate = begindate;
                    interest.EndDate = begindate.AddMonths(1);
                    begindate = begindate.AddMonths(1);
                    base.Add(interest);
                }
                for (int i = 0; i < maxdate; i++)
                {
                    interest.type = 1;
                    interest.BeginDate = begindate;
                    interest.EndDate = begindate.AddMonths(1);
                    begindate = begindate.AddMonths(1);
                    base.Add(interest);
                }

                scope.Complete();
            }
            return result;
        }
    }
}
