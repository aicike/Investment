using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class RoleAccountModel : BaseModel<RoleAccount>
    {
        /// <summary>
        /// 根据公司用户ID 获取权限列表
        /// </summary>
        /// <param name="CAID"></param>
        /// <returns></returns>
        public List<RoleAccount> GetInfo_ByCAID(int CAID)
        {
            var list = List().Where(a => a.CompanyAccountID == CAID).ToList();
            return list;
        }
        /// <summary>
        /// 根据集团用户ID 获取权限列表
        /// </summary>
        /// <param name="CAID"></param>
        /// <returns></returns>
        public List<RoleAccount> GetInfo_ByGAID(int GAID)
        {
            var list = List().Where(a => a.GroupAccountID == GAID).ToList();
            return list;
        }


        /// <summary>
        /// 根据公司用户ID 删除权限表
        /// </summary>
        /// <param name="CAID"></param>
        /// <returns></returns>
        public Result Del_ByCAID(int CAID)
        {
            Result result = new Result();
            string sql = "Delete RoleAccount where CompanyAccountID = "+CAID;
            base.SqlExecute(sql);
            return result;
        }

        /// <summary>
        /// 根据集团用户ID 删除权限表
        /// </summary>
        /// <param name="CAID"></param>
        /// <returns></returns>
        public Result Del_ByGAID(int GAID)
        {
            Result result = new Result();
            string sql = "Delete RoleAccount where GroupAccountID = " + GAID;
            base.SqlExecute(sql);
            return result;
        }
    }
}
