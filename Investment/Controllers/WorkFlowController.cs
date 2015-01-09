using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Investment.Controllers
{
    public class WorkFlowController : Controller
    {
        //
        // GET: /WorkFlow/

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
            return View();
        }

        /// <summary>
        /// 生成待定义业务单
        /// </summary>
        /// <returns></returns>
        public ActionResult SetPendingForm()
        {
            lock (LockObj)
            {
                WorkFlowModel WFModel = new WorkFlowModel();


            }
            return View();
        }
        #endregion



    }
}
