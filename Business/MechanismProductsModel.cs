using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    /// <summary>
    /// 机构产品表 Model
    /// </summary>
    public class MechanismProductsModel : BaseModel<MechanismProducts>
    {
        /// <summary>
        /// 根据机构ID查询产品信息
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public List<MechanismProducts> GetList_ByMID(int MID)
        {
            var list = List().Where(a=>a.MechanismID==MID).ToList();
            return list;
        }
    }
}
