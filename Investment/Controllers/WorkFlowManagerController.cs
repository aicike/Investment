using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;
using System.Transactions;

namespace Investment.Controllers
{
    public class WorkFlowManagerController : BaseController
    {
        //
        // GET: /WorkFlowManager/
        /// <summary>
        /// 流程分类列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //流程分类列表
            WorkFlowManagerModel wmModel = new WorkFlowManagerModel();
            var list = wmModel.List().ToList();
            return View(list);
        }

        /// <summary>
        /// 设置流程节点列表
        /// </summary>
        /// <returns></returns>
        public ActionResult SetNodeList(int WorkFlowID)
        {
            //节点列表
            WorkFlowManagerModel wmModel = new WorkFlowManagerModel();
            var item = wmModel.Get(WorkFlowID);
            return View(item);
        }

        /// <summary>
        /// 添加审批节点
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public ActionResult AddNode(int WorkFlowID)
        {
            WorkFlowManagerModel wmModel = new WorkFlowManagerModel();
            var item = wmModel.Get(WorkFlowID);
            //流程ID
            ViewBag.WorkFlowID = WorkFlowID;
            //流程名称
            ViewBag.WorkFlowName = item.Name;
            //获取流程节点
            WorkFlowNodeManagerModel wnmModel = new WorkFlowNodeManagerModel();
            ViewBag.Nodes = wnmModel.List().ToList();
            //获取Order数量
            WorkFlow_NodeModel wnModel = new WorkFlow_NodeModel();
            var Order = wnModel.GetWorkFlow_Node(WorkFlowID).Count + 1;
            ViewBag.Order = Order;
            return View();
        }

        /// <summary>
        /// 添加审批节点功能
        /// </summary>
        /// <param name="WorkFlowID">流程ID</param>
        /// <param name="AccountIDs">负责人</param>
        /// <param name="PositionIDs">职位</param>
        /// <param name="WorkFlowNodeISSince">当前节点是否子审批</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNode(WorkFlow_Node workFlow_node, string WorkFlowNodeISSince, string AccountIDs, string PositionIDs)
        {
            //添加节点
            WorkFlow_NodeModel wnModel = new WorkFlow_NodeModel();
            var result = wnModel.Add(workFlow_node);
            if (!result.HasError)
            {
                //更改排序
                wnModel.SetOrder_add(workFlow_node.WorkFlowManagerID, workFlow_node.Order, workFlow_node.ID);

                if (WorkFlowNodeISSince == "False")
                {
                    //处理审批人
                    WorkFlowApprovalManagerModel wamModel = new WorkFlowApprovalManagerModel();
                    var AIDS = AccountIDs.Split(','); //员工
                    var PIDS = PositionIDs.Split(','); //职位
                    for (int i = 0; i < AIDS.Count(); i++)
                    {
                        if (AIDS[i] != "")
                        {
                            WorkFlowApprovalManager wfam = new WorkFlowApprovalManager();
                            wfam.GroupAccountID = int.Parse(AIDS[i]);
                            wfam.PositionID = int.Parse(PIDS[i]);
                            wfam.WorkFlow_NodeID = workFlow_node.ID;
                            wamModel.Add(wfam);
                        }
                    }
                }
            }
            else
            {
                return JavaScript("JMessage('添加失败 请稍后再试',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("SetNodeList", "WorkFlowManager", new { WorkFlowID = workFlow_node.WorkFlowManagerID }) + "'");
        }

        /// <summary>
        /// 修改页面
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <param name="W_NID">流程与节点中间表ID</param>
        /// <returns></returns>
        public ActionResult EditNode(int WorkFlowID, int W_NID)
        {
            WorkFlowManagerModel wmModel = new WorkFlowManagerModel();
            var item = wmModel.Get(WorkFlowID);
            //流程ID
            ViewBag.WorkFlowID = WorkFlowID;
            //流程名称
            ViewBag.WorkFlowName = item.Name;
            //获取流程节点
            WorkFlowNodeManagerModel wnmModel = new WorkFlowNodeManagerModel();
            ViewBag.Nodes = wnmModel.List().ToList();
            //获取Order数量
            WorkFlow_NodeModel wnModel = new WorkFlow_NodeModel();
            var Order = wnModel.GetWorkFlow_Node(WorkFlowID).Count;
            ViewBag.Order = Order;
            WorkFlow_NodeModel wfnModel = new WorkFlow_NodeModel();
            var wfnitem = wfnModel.Get(W_NID);

            return View(wfnitem);
        }

        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="workFlow_node"></param>
        /// <param name="WorkFlowNodeISSince"></param>
        /// <param name="AccountIDs"></param>
        /// <param name="PositionIDs"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditNode(WorkFlow_Node workFlow_node, string WorkFlowNodeISSince, string AccountIDs, string PositionIDs)
        {
            //修改节点
            WorkFlow_NodeModel wnModel = new WorkFlow_NodeModel();
            var wnitem = wnModel.Get(workFlow_node.ID);
            var result = wnModel.Edit(workFlow_node);
            if (!result.HasError)
            {
                //更改排序
                wnModel.SetOrder_edit(workFlow_node.WorkFlowManagerID, workFlow_node.Order, wnitem.Order, workFlow_node.ID);

                if (WorkFlowNodeISSince == "False")
                {
                    //处理审批人
                    WorkFlowApprovalManagerModel wamModel = new WorkFlowApprovalManagerModel();
                    wamModel.DelInfo(workFlow_node.ID);
                    var AIDS = AccountIDs.Split(','); //员工
                    var PIDS = PositionIDs.Split(','); //职位
                    for (int i = 0; i < AIDS.Count(); i++)
                    {
                        if (AIDS[i] != "")
                        {
                            WorkFlowApprovalManager wfam = new WorkFlowApprovalManager();
                            wfam.GroupAccountID = int.Parse(AIDS[i]);
                            wfam.PositionID = int.Parse(PIDS[i]);
                            wfam.WorkFlow_NodeID = workFlow_node.ID;
                            wamModel.Add(wfam);
                        }
                    }
                }
            }
            else
            {
                return JavaScript("JMessage('添加失败 请稍后再试',true)");
            }

            return JavaScript("window.location.href='" + Url.Action("SetNodeList", "WorkFlowManager", new { WorkFlowID = workFlow_node.WorkFlowManagerID }) + "'");
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="workFlow_nodeID"></param>
        /// <returns></returns>
        public string Delete(int workFlow_nodeID, int WorkFlowID)
        {
            WorkFlow_NodeModel wnModel = new WorkFlow_NodeModel();
            var wnitem = wnModel.Get(workFlow_nodeID);

            WorkFlowApprovalManagerModel wamModel = new WorkFlowApprovalManagerModel();
            Result result = new Result();
            using (TransactionScope scope = new TransactionScope())
            {
                //删除审批人
                wamModel.DelInfo(wnitem.ID);
                
                //删除节点
                result = wnModel.Delete(workFlow_nodeID);
                wnModel.SetOrder_del(WorkFlowID, wnitem.Order);
                scope.Complete();
            }


            if (result.HasError)
            {
                return "<script>JMessage('" + result.Error + "',true)</script>";

            }
            return "<script>window.location.href='" + Url.Action("SetNodeList", "WorkFlowManager", new { WorkFlowID = WorkFlowID }) + "';</script>";

        }


        /// <summary>
        /// 根据姓名 职位 查询用户
        /// </summary>
        /// <param name="Str"></param>
        /// <returns>json</returns>
        public string GetAccountList(string Str)
        {
            GroupAccountModel gaModel = new GroupAccountModel();
            var list = gaModel.GetInfo_BYStr(Str);
            return Newtonsoft.Json.JsonConvert.SerializeObject(list);
        }
    }

}
