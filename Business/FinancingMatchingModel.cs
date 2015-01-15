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
        /// 查找所有匹配融资意向的数据（只属于我的）
        /// </summary>
        /// <returns></returns>
        public IQueryable<FinancingMatching> GetMatching_BYAccountID(int AccountID)
        {
            var query = from a in Context.Financings
                        from b in Context.MechanismProducts
                        where a.Amount <= b.MaxQuota && a.Owner_A_ID==AccountID orderby a.ID
                        select new FinancingMatching { FID = a.ID,FName=a.Name,MID=b.ID,MName=b.Name};
            return query;
        }

        /// <summary>
        /// 查找所有匹配融资意向的数据（所有的）
        /// </summary>
        /// <returns></returns>
        public IQueryable<FinancingMatching> GetMatching()
        {
            var query = from a in Context.Financings
                        from b in Context.MechanismProducts
                        where a.Amount <= b.MaxQuota
                        orderby a.ID
                        select new FinancingMatching { FID = a.ID, FName = a.Name, MID = b.ID, MName = b.Name };
            return query;
        }
    }
}
