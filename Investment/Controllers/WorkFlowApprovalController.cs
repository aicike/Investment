﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

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
        /// <param name="financingID">融资意向</param>
        /// <param name="Products">对接机构 数据结构1,2,3</param>
        /// <returns></returns>
        public ActionResult Preview(int financingID, string Products)
        {
            ViewBag.financingID = financingID;
            ViewBag.Products = Products;
            FinancingModel FModel = new FinancingModel();
            var financing = FModel.Get(financingID);
            return View(financing);
        }

        /// <summary>
        /// 生成待定义业务单
        /// </summary>
        /// <param name="financingID">融资意向</param>
        /// <param name="Products">对接机构 数据结构1,2,3</param>
        /// <returns></returns>
        public ActionResult SetPendingForm(int financingID, string Products)
        {
            Result result = new Result();
            lock (LockObj)
            {
                //融资意向
                FinancingModel FModel = new FinancingModel();
                var financing = FModel.Get(financingID);
                //流程数据
                WorkFlowModel WFModel = new WorkFlowModel();
                WorkFlow workflow = new WorkFlow();
                workflow.BeginDate = DateTime.Now;
                workflow.FinancingID = financingID;
                workflow.FormJson = "";
                workflow.State = 0;
                workflow.CompanyID = financing.CompanyID;
                result = WFModel.Add(workflow);
            }
            if (result.HasError)
            {
                return JavaScript("JMessage('生成失败 请稍后再试',true)");

            }
            else
            {
                return JavaScript("window.location.href='" + Url.Action("Pending", "WorkFlow") + "'");
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
            var result = WKModel.Delete(WorkFlowID);
            if (result.HasError)
            {
                return "<script>JMessage('" + result.Error + "',true)</script>";

            }
            return "<script>window.location.href='" + Url.Action("Pending", "WorkFlow") + "';</script>";

        }
        #endregion
    }
}