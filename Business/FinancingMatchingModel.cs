using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    /// <summary>
    /// 意向匹配数据
    /// </summary>
    public class FinancingMatchingModel : BaseModel<FinancingMatching>
    {

        /// <summary>
        /// 查找所有匹配贷款意向的数据（只属于我的）
        /// </summary>
        /// <returns></returns>
        public IQueryable<FinancingMatching> GetMatching_BYAccountID(int AccountID)
        {
            var query = from a in Context.Financings
                        from b in Context.MechanismProducts
                        where a.WorkFlowManagerID != 4 && a.Amount <= b.MaxQuota && a.Owner_A_ID == AccountID && a.Status == 0 && (a.MinTimeLimit + a.MaxTimeLimit ?? 0) <= b.MaxMonth
                        orderby a.ID
                        select new FinancingMatching { FID = a.ID, FName = a.Name, MID = b.ID, MName = b.Name };
            return query;
        }


        /// <summary>
        /// 查找所有匹配贷款意向的数据（只属于我的） 自有资金
        /// </summary>
        /// <returns></returns>
        public IQueryable<FinancingMatching> GetMatchingZY_BYAccountID(int AccountID)
        {
            var query = from a in Context.Financings
                        where a.WorkFlowManagerID == 4 && a.Owner_A_ID == AccountID && a.Status == 0
                        orderby a.ID
                        select new FinancingMatching { FID = a.ID, FName = a.Name, MID = a.ID, MName = a.Name };
            return query;
        }



        /// <summary>
        /// 查找所有匹配贷款意向的数据（所有的）
        /// </summary>
        /// <returns></returns>
        public IQueryable<FinancingMatching> GetMatching()
        {
            var query = from a in Context.Financings
                        from b in Context.MechanismProducts
                        where a.WorkFlowManagerID != 4 && a.Amount <= b.MaxQuota && a.Status == 0 && (a.MinTimeLimit + a.MaxTimeLimit ?? 0) <= b.MaxMonth
                        orderby a.ID
                        select new FinancingMatching { FID = a.ID, FName = a.Name, MID = b.ID, MName = b.Name };
            return query;
        }

        /// <summary>
        /// 查找所有匹配贷款意向的数据（所有的）自有资金
        /// </summary>
        /// <returns></returns>
        public IQueryable<FinancingMatching> GetMatchingZY()
        {
            var query = from a in Context.Financings
                        where a.WorkFlowManagerID == 4 && a.Status == 0
                        orderby a.ID
                        select new FinancingMatching { FID = a.ID, FName = a.Name, MID = a.ID, MName = a.Name };
            return query;
        }
    }
}
