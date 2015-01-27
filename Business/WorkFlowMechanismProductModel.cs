using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    /// <summary>
    /// 流程对应产品信息表model
    /// </summary>
    public class WorkFlowMechanismProductModel : BaseModel<WorkFlowMechanismProduct>
    {

        /// <summary>
        /// 根据流程ID获取流程对接机构
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public List<WorkFlowMechanismProduct> GetInfo_ByWorkFlowID(int WorkFlowID)
        {
            var list = base.List().Where(a=>a.WorkFlowID==WorkFlowID).ToList();
            return list;
        }

        /// <summary>
        /// 根据流程ID 删除对应机构信息
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public Result DelInfo_BYWorkFlowID(int WorkFlowID)
        {
            Result result = new Result();
            string sql = "delete WorkFlowMechanismProduct where WorkFlowID ="+WorkFlowID;
            int cnt = base.SqlExecute(sql);
            if (cnt <= 0)
            {
                //result.HasError = true;
            }
            return result;
        }
    }
}
