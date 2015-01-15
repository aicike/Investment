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

        /// <summary>
        /// 根据多个机构ID 获取产品列表信息
        /// </summary>
        /// <param name="PIDS"></param>
        /// <returns></returns>
        public List<MechanismProducts> GetList_ByIDS(int[] PIDS)
        {
            var list = List().Where(a=>PIDS.Contains(a.ID)).ToList();
            return list;
        }

        /// <summary>
        /// 查询所有产品数据 模糊查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<MechanismProducts> GetAllList_ByName(string name)
        {
            var list = List().Where(a => a.Name.Contains(name)).ToList();
            return list;
        }

        /// <summary>
        /// 根据意向ID 匹配产品
        /// </summary>
        /// <param name="FinancingID"></param>
        /// <returns></returns>
        public List<MechanismProducts> GetInfo_Matching(int FinancingID)
        {
            var list = List().Where(a=>a.IsEnable==true).ToList();
            return list;
        }

        /// <summary>
        /// 获取所有未禁用产品
        /// </summary>
        /// <param name="FinancingID"></param>
        /// <returns></returns>
        public List<MechanismProducts> GetAllInfo()
        {
            var list = List().Where(a => a.IsEnable == true).ToList();
            return list;
        }



    }
}
