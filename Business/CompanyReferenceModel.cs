using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    /// <summary>
    /// 客户机构借贷信息
    /// </summary>
    public class CompanyReferenceModel : BaseModel<CompanyReference>
    {
        /// <summary>
        /// 根据客户ID查询借贷信息
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public List<CompanyReference> GetInfo_byCID(int CID)
        {
            var list = List().Where(a=>a.CompanyID==CID);
            return list.ToList();
        }
    }
}
