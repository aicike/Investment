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
        /// <param name="WorkFlowManagerID"></param>
        /// <returns></returns>
        public List<WorkFlow_Node> GetWorkFlow_Node(int WorkFlowManagerID)
        {
            var list = List().Where(a => a.WorkFlowManagerID == WorkFlowManagerID).ToList();
            return list;
        }


        /// <summary>
        /// 根据WorkFlowNodeID获取以往节点
        /// </summary>
        /// <param name="WorkFlowNodeID"></param>
        /// <returns></returns>
        public List<WorkFlow_Node> GetWorkFlow_Node_WorkFlowNodeID(int WorkFlowNodeID)
        {
            var current= List().Where(a => a.ID == WorkFlowNodeID).FirstOrDefault();
            var list = List().Where(a => a.WorkFlowManagerID == current.WorkFlowManager.ID && a.Order < current.Order).ToList();
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

        /// <summary>
        /// 根据流程类型ID 与order 查找数据
        /// </summary>
        /// <param name="WorkFlowManagerID">流程类型ID</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public WorkFlow_Node Getwork_node(int WorkFlowManagerID, int order)
        {
            var item = base.List().Where(a => a.Order == order && a.WorkFlowManagerID == WorkFlowManagerID).FirstOrDefault();
            return item;
        }

        /// <summary>
        /// 根据流程类型ID 与 中间表ID 查找下一节点
        /// </summary>
        /// <param name="WorkFlowManagerID"></param>
        /// <param name="WorkFlow_NodeID"></param>
        /// <returns></returns>
        public WorkFlow_Node GetNextWorkFlow_Node(int WorkFlowManagerID,int WorkFlow_NodeID)
        {
            //获取当前节点
            var thisitem = base.Get(WorkFlow_NodeID);
            int order = thisitem.Order + 1;
            var nextItem = base.List().Where(a => a.WorkFlowManagerID == WorkFlowManagerID && a.Order == order).FirstOrDefault();
            return nextItem;
        }
    }
}
