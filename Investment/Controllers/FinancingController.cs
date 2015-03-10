using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace Investment.Controllers
{
    public class FinancingController : BaseController
    {
        /// <summary>
        /// 只能查看自己所有权的贷款信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public ActionResult Index(int? id, string Name)
        {
            FinancingModel fm = new FinancingModel();
            var objs = fm.GetByMyList(LoginAccount.UserID);
            if (!string.IsNullOrEmpty(Name))
            {
                objs = objs.Where(a => a.Name.Contains(Name));
            }
            var list = objs.ToPagedList(id ?? 1, 15);
            ViewBag.LoginUesrID = LoginAccount.UserID;
            return View(list);
        }


        /// <summary>
        /// 查看所有的贷款信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public ActionResult IndexAll(int? id, string Name)
        {
            FinancingModel fm = new FinancingModel();

            var objs = fm.List().Where(a=>a.AuditStatus!=-1);

            if (!string.IsNullOrEmpty(Name))
            {
                objs = objs.Where(a => a.Name.Contains(Name));
            }
            var list = objs.ToPagedList(id ?? 1, 15);
            return View(list);
        }

        public ActionResult Detail(int id)
        {
            MenuModel mm = new MenuModel();
            bool hasPermissions = false;
            if (LoginAccount.UserID == 1)
            {
                //超级管理员
                hasPermissions = true;
            }
            else
            {
                hasPermissions = mm.CheckHasPermissions(LoginAccount.RoleIDs, "IndexALL", "Financing", null);
            }
            ViewBag.hasPermissions = hasPermissions;

            FinancingModel fm = new FinancingModel();
            //todo:此处需要判断是否有权限
            var obj = fm.Get(id);
            WorkFlowManagerModel wfmm = new WorkFlowManagerModel();
            var wfms = wfmm.List().Where(a => a.ID != 4).OrderBy(a => a.ID).ToList();
            List<SelectListItem> newList = new List<SelectListItem>();
            var wfm_list = new SelectList(wfms, "ID", "Name");
            newList.AddRange(wfm_list);
            ViewData["wfm"] = newList;

            GroupAccountModel gam = new GroupAccountModel();
            var gaList = gam.GetListWithoutAdmin();
            List<SelectListItem> newGAList = new List<SelectListItem>();
            var ga_list = new SelectList(gaList, "ID", "Name");
            newGAList.Add(new SelectListItem { Text = "未指定", Value = "0", Selected = true });
            newGAList.AddRange(ga_list);
            ViewData["gaList"] = newGAList;

            return View(obj);
        }

        [HttpPost]
        public ActionResult Detail(int id, Financing financing)
        {
            FinancingModel fm = new FinancingModel();
            var oldFinancing = fm.Get(id);
            if (oldFinancing != null)
            {
                oldFinancing.BusinessType = financing.BusinessType;

                switch (oldFinancing.BusinessType)
                {
                    case 0:
                        oldFinancing.WorkFlowManagerID = null;
                        break;
                    case 1:
                        oldFinancing.WorkFlowManagerID = 4;
                        break;
                    case 2:
                        oldFinancing.WorkFlowManagerID = financing.WorkFlowManagerID;
                        break;
                }
                if (financing.Owner_A_ID == 0)
                {
                    oldFinancing.Owner_A_ID = null;
                }
                else
                {
                    oldFinancing.Owner_A_ID = financing.Owner_A_ID;
                }
                if (financing.Owner_B_ID == 0)
                {
                    oldFinancing.Owner_B_ID = null;
                }
                else
                {
                    oldFinancing.Owner_B_ID = financing.Owner_B_ID;
                }
            }
            Result result = fm.Edit(oldFinancing);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            else
            {
                return JavaScript("JMessage('操作成功！',false,true,null,200)");
            }
        }

        /// <summary>
        /// 修改审核状态
        /// </summary>
        public ActionResult ChangeStatus(int id, int status)
        {
            FinancingModel fm = new FinancingModel();
            var result = fm.ChangeAuditStatus(id, status);
            return Json(result);
        }

        /// <summary>
        /// 提交审核
        /// </summary>
        public string Commit(int id)
        {
            FinancingModel fm = new FinancingModel();
            var result = fm.ChangeAuditStatus(id, 0);
            fm.ChangeEditStatus(id, 0);
            if (result.HasError)
            {
                return "<script>JMessage('" + result.Error + "',true)</script>";
            }
            else
            {
                return "<script>JMessage('操作成功。',false,true,'" + Request.UrlReferrer.AbsoluteUri + "',500);</script>";
            }
        }
        
        /// <summary>
        /// 申请修改
        /// </summary>
        public string CommitEdit(int id)
        {
            FinancingModel fm = new FinancingModel();
            var result = fm.ChangeEditStatus(id,1);
            if (result.HasError)
            {
                return "<script>JMessage('" + result.Error + "',true)</script>";
            }
            else
            {
                return "<script>JMessage('操作成功。',false,true,'" + Request.UrlReferrer.AbsoluteUri + "',500);</script>";
            }
        }

        /// <summary>
        /// 更改申请修改状态
        /// </summary>
        public ActionResult ChangeEditStatus(int id, int status)
        {
            FinancingModel fm = new FinancingModel();
            if (status == 2) {
                //同意修改后，审核状态为未提交审核
                fm.ChangeAuditStatus(id, -1);
            }
            var result = fm.ChangeEditStatus(id, status);
            return Json(result);
        }
    }
}
