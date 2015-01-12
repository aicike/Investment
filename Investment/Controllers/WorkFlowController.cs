using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Investment.Controllers
{
    public class WorkFlowController : BaseController
    {
        /// <summary>
        /// 待定业务列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Pending(int? id)
        {
            WorkFlowModel wfm = new WorkFlowModel();
            var objs = wfm.GetListByState(0, LoginAccount.UserID);
            var list = objs.ToPagedList(id ?? 1, 15);
            return View(list);
        }

        /// <summary>
        /// 我的申请列表
        /// </summary>
        /// <returns></returns>
        public ActionResult MyApplication(int? id)
        {
            WorkFlowModel wfm = new WorkFlowModel();
            var objs = wfm.GetMyApplication(LoginAccount.UserID);
            var list = objs.ToPagedList(id ?? 1, 15);
            return View(list);
        }



       


    }
}
