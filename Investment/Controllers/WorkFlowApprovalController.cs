﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;
using System.Transactions;

namespace Investment.Controllers
{
    public class WorkFlowApprovalController : BaseController
    {
        //
        // GET: /WorkFlowApproval/

        #region 预览界面
        private static object LockObj = new object();

        /// <summary>
        /// 预览界面
        /// </summary>
        /// <param name="financingID">贷款意向</param>
        /// <returns></returns>
        public ActionResult Preview(int financingID)
        {
            ViewBag.financingID = financingID;
            FinancingModel FModel = new FinancingModel();
            var financing = FModel.Get(financingID);
            //获取匹配机构
            MechanismProductsModel MPModel = new MechanismProductsModel();
            var MatchingProduct = MPModel.GetInfo_Matching(financingID);
            ViewBag.MatchingProduct = MatchingProduct;
            //获取所有机构
            var AllProduct = MPModel.GetAllInfo();
            ViewBag.AllProduct = AllProduct;
            //是否为自有业务
            if (financing.WorkFlowManagerID == 4)
            {
                ViewBag.ISZY = 1;
            }

            return View(financing);
        }

        /// <summary>
        /// 生成待定义业务单
        /// </summary>
        /// <param name="financingID">贷款意向</param>
        /// <param name="Products">对接机构 数据结构1,2,3</param>
        /// <returns></returns>
        public ActionResult SetPendingForm(int financingID, string Products)
        {
            Result result = new Result();

            using (TransactionScope scope = new TransactionScope())
            {
                //查看是否生成待定业务单
                WorkFlowModel WFModel = new WorkFlowModel();
                var ispeding = WFModel.GetISCreatePending(financingID);
                if (ispeding.HasError)
                {
                    return JavaScript("JMessage('" + ispeding.Error + "',true)");
                }
                //贷款意向
                FinancingModel FModel = new FinancingModel();
                var financing = FModel.Get(financingID);
                //更改贷款意向状态
                financing.Status =3;
                FModel.Edit(financing);
                //流程数据
                WorkFlow workflow = new WorkFlow();
                workflow.BeginDate = DateTime.Now;
                workflow.FinancingID = financingID;
                workflow.FormJson = "";
                workflow.State = 0;
                workflow.IsSendEmail = false;
                workflow.CompanyID = financing.CompanyID;
                result = WFModel.Add(workflow);
                if (!string.IsNullOrEmpty(Products))
                {
                    //添加流程机构信息
                    WorkFlowMechanismProductModel wmpModel = new WorkFlowMechanismProductModel();
                    //机构ID集合
                    Products = Products.TrimEnd(',');
                    var pros = Products.Split(',').Select(a => int.Parse(a));
                    foreach (var item in pros)
                    {
                        WorkFlowMechanismProduct wmp = new WorkFlowMechanismProduct();
                        wmp.WorkFlowID = workflow.ID;
                        wmp.State = 0;
                        wmp.MechanismProductsID = item;
                        wmp.FormJson = "";
                        wmpModel.Add(wmp);
                    }
                }
                scope.Complete();

            }
            if (result.HasError)
            {
                return JavaScript("JMessage('生成失败 请稍后再试',true)");

            }
            else
            {
                return JavaScript("JMessage('生成成功',false);setTimeout(function(){window.location.href='" + Url.Action("IndexAll", "ToLoanMatching") + "'},1000);");
            }
        }
        #endregion

        #region 待定业务单界面
        /// <summary>
        /// 待定义务页面
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public ActionResult Pending(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            return View(item);
        }

        /// <summary>
        /// 提交申请
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public ActionResult SetSubmitForm(int WorkFlowID)
        {
            WorkFlowModel WKModel = new WorkFlowModel();
            var result = WKModel.SubWorkFlow(WorkFlowID, LoginAccount.UserID);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Pending", "WorkFlow") + "'");
        }

        /// <summary>
        /// 删除待定单
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public string DeletePeding(int WorkFlowID)
        {
            WorkFlowModel WKModel = new WorkFlowModel();
            WorkFlowMechanismProductModel wmpmodel = new WorkFlowMechanismProductModel();
            Result result = new Result();
            //更改贷款意向状态
            FinancingModel FModel = new FinancingModel();
            var fina = WKModel.Get(WorkFlowID);
            var financing = FModel.Get(fina.FinancingID);
            financing.Status = 0;
            result= FModel.Edit(financing);
            if (result.HasError)
            {
                return "<script>JMessage('更改状态时出错，请联系管理员！',true)</script>";

            }
            result = wmpmodel.DelInfo_BYWorkFlowID(WorkFlowID);
            if (result.HasError)
            {
                return "<script>JMessage('删除机构产品时出错，请联系管理员！',true)</script>";

            }
            result = WKModel.Delete(WorkFlowID);
            if (result.HasError)
            {
                return "<script>JMessage('" + result.Error + "',true)</script>";

            }
            
            return "<script>window.location.href='" + Url.Action("Pending", "WorkFlow") + "';</script>";

        }
        #endregion

        #region 查看流程表单界面
        /// <summary>
        /// 查看流程表单界面
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public ActionResult SelInfoPath(int WorkFlowID)
        {
            WorkFlowModel WKModel = new WorkFlowModel();
            var item = WKModel.Get(WorkFlowID);
            ViewBag.financingID = item.FinancingID;
            return View(item);
        }
        #endregion

        #region 审批节点

        #region 提交申请
        public ActionResult TiJiaoShenQing(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }
        #endregion

        #region 贷款立项初审

        public ActionResult RongZiLiXiangChuShen(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion

        #region 项目立项

        public ActionResult XiangMuLiXiang(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion

        #region 签署协议

        public ActionResult QianShuXieYi(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion

        #region 协议确认

        public ActionResult XieYiQueRen(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion

        #region 调查辅导

        public ActionResult DiaoChaFuDao(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion

        #region 机构对接

        public ActionResult JiGouDuiJie(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion

        #region 落实放款

        public ActionResult LuoShiFangKuan(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion

        #region 确认收取费用

        public ActionResult QueRenShouQuFeiYong(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion

        #region 详尽调查

        public ActionResult XiangJinDiaoCha(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion

        #region 风控审核

        public ActionResult FengKongShenHe(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion

        #region 落实放款条件

        public ActionResult LuoShiFangKuanTiaoJian(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion

        #region 放款审批

        public ActionResult FangKuanShenPi(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion

        #region 放款

        public ActionResult FangKuan(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion

        #region 确认放款日期

        public ActionResult FangKuanRiQi(int WorkFlowID)
        {
            WorkFlowModel WFModel = new WorkFlowModel();
            var item = WFModel.Get(WorkFlowID);
            CheckGroupAccount(item);
            return View(item);
        }

        #endregion




        /// <summary>
        /// 检查是否有权限查看此页面
        /// </summary>
        private void CheckGroupAccount(WorkFlow wf)
        {
            wf.ApprovalRecord.Any(a => a.Operation == -1 && a.GroupAccountID == LoginAccount.UserID).NotAuthorizedPage();
        }

        #endregion

        #region 审批操作（同意，不同意，驳回）


        /// <summary>
        /// 同意
        /// </summary>
        /// <returns></returns>
        public ActionResult Agree(int WorkFlowID, string Opinion, string hid_attachment, string CustomFun_Json = null)
        {
            WorkFlowModel wfm = new WorkFlowModel();
            var workFlow = wfm.Get(WorkFlowID);
            var result = wfm.WorkFlow_Agree(WorkFlowID, LoginAccount.UserID, Opinion);
            if (result.HasError == false)
            {
                if (string.IsNullOrEmpty(hid_attachment) == false)
                {
                    var attachment = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(hid_attachment);
                    AttachmentModel attachmentModel = new AttachmentModel();
                    foreach (var item in attachment)
                    {
                        attachmentModel.CopyAttachment_Company(workFlow.CompanyID, item, "/Approval" + WorkFlowID);
                    }
                }
                //执行自定义函数
                if (CustomFun_Json != null && CustomFun_Json.Length > 0)
                {
                    var cf = Newtonsoft.Json.JsonConvert.DeserializeObject<CustomFun>(CustomFun_Json);
                    if (cf != null) { cf.Exec(); }
                }

            }
            return Json(result);
        }

        /// <summary>
        /// 不同意
        /// </summary>
        /// <returns></returns>
        public ActionResult Disagree(int WorkFlowID, string Opinion, string hid_attachment, string CustomFun_Json = null)
        {
            WorkFlowModel wfm = new WorkFlowModel();
            var result = wfm.WorkFlow_Disagree(WorkFlowID, LoginAccount.UserID, Opinion);
            if (result.HasError == false)
            {
                //执行自定义函数
                if (CustomFun_Json != null && CustomFun_Json.Length > 0)
                {
                    var cf = Newtonsoft.Json.JsonConvert.DeserializeObject<CustomFun>(CustomFun_Json);
                    if (cf != null) { cf.Exec(); }
                }
            }
            return Json(result);
        }

        /// <summary>
        /// 驳回
        /// </summary>
        /// <returns></returns>
        public ActionResult Reject(int WorkFlowID, string Opinion, int Node)
        {
            WorkFlowModel wfm = new WorkFlowModel();
            var result = wfm.WorkFlow_Reject(WorkFlowID, LoginAccount.UserID, Node, Opinion);
            return Json(result);
        }

        /// <summary>
        /// 自定义函数委托
        /// </summary>
        public class CustomFun
        {
            /// <summary>
            /// 函数名称
            /// </summary>
            public string FunName { get; set; }

            /// <summary>
            /// 函数参数
            /// </summary>
            public dynamic FunParam { get; set; }

            public Result Exec()
            {
                Result reslut = null;
                switch (FunName)
                {
                    case "FangKuanRiQi":
                        reslut = FangKuanRiQi(FunParam);
                        break;
                }
                return reslut;
            }

            public Result GMY(dynamic FunParam)
            {
                int a = FunParam.A;
                int b = FunParam.B;
                return null;
            }
            public Result FangKuanRiQi(dynamic FunParam)
            {
                Result reslut = null;
                WorkFlowModel wmodel = new WorkFlowModel();
                int workflowID = FunParam.WorkFlowID;
                var witem = wmodel.Get(workflowID);
                witem.LoanDay = FunParam.Date;
                wmodel.Edit(witem);
                return reslut;
            }
        }

        #endregion


    }
}
