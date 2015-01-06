using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    /// <summary>
    /// 职位管理与员工中间表管理
    /// </summary>
    public class Position_AccountModel : BaseModel<Position_Account>
    {
        /// <summary>
        /// 根据集团用户ID 删除职位表
        /// </summary>
        /// <param name="CAID"></param>
        /// <returns></returns>
        public Result Del_ByGAID(int GAID)
        {
            Result result = new Result();
            string sql = "Delete  Position_Account where GroupAccountID = " + GAID;
            base.SqlExecute(sql);
            return result;
        }

        /// <summary>
        /// 根据集团用户ID 获取职位列表
        /// </summary>
        /// <param name="CAID"></param>
        /// <returns></returns>
        public List<Position_Account> GetInfo_ByGAID(int GAID)
        {
            var list = List().Where(a => a.GroupAccountID == GAID).ToList();
            return list;
        }

    }
}
