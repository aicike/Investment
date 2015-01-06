using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    /// <summary>
    /// 流程与节点中间表
    /// </summary>
    public class WorkFlow_NodeModel : BaseModel<WorkFlow_Node>
    {
        /// <summary>
        /// 获取流程的所有节点
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public List<WorkFlow_Node> GetWorkFlow_Node(int WorkFlowID)
        {
            var list = List().Where(a => a.WorkFlowManagerID == WorkFlowID).ToList();
            return list;
        }

        /// <summary>
        /// 新增时更改排序
        /// </summary>
        /// <param name="WorkFlowID">WorkFlowID</param>
        /// <param name="order">排序</param>
        ///  <param name="ID">流程与节点表ID</param>
        /// <returns></returns>
        public Result SetOrder_add(int WorkFlowID, int order,int ID)
        {
            Result result = new Result();
            string sql = string.Format("update WorkFlow_Node set [Order]=([Order]+1) where WorkFlowManagerID={0} and [Order]>={1} and id<>{2}", WorkFlowID, order, ID);
            int cnt = base.SqlExecute(sql);
            if (cnt <= 0)
            {
                result.HasError = true;
            }
            return result;
        }

        /// <summary>
        /// 修改时更改排序
        /// </summary>
        /// <param name="WorkFlowID">WorkFlowID</param>
        /// <param name="orderNow">当前排序</param>
        /// <param name="orderlast">之前排序</param>
        /// <returns></returns>
        public Result SetOrder_edit(int WorkFlowID, int orderNow, int orderlast, int ID)
        {
            Result result = new Result();
            string sql = "";
            if (orderNow > orderlast)//向下
            {
                sql = string.Format("update WorkFlow_Node set [Order]=([Order]-1) where WorkFlowManagerID={0} and [Order]>{1} and [Order]<={2} and id<>{3}", WorkFlowID, orderlast, orderNow, ID);
            }
            else { //向上 
                sql = string.Format("update WorkFlow_Node set [Order]=([Order]+1) where WorkFlowManagerID={0} and [Order]<{1} and [Order]>={2} and id<>{3}", WorkFlowID, orderlast, orderNow, ID);
            }
            
            int cnt = base.SqlExecute(sql);
            if (cnt <= 0)
            {
                result.HasError = true;
            }
            return result;
        }

        /// <summary>
        /// 删除时更改排序
        /// </summary>
        /// <param name="WorkFlowID">WorkFlowID</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public Result SetOrder_del(int WorkFlowID, int order)
        {
            Result result = new Result();
            string sql = string.Format("update WorkFlow_Node set [Order]=([Order]-1) where WorkFlowManagerID={0} and [Order]>={1}", WorkFlowID, order);
            int cnt = base.SqlExecute(sql);
            if (cnt <= 0)
            {
                result.HasError = true;
            }
            return result;
        }


    }
}
