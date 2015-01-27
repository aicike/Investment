using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Investment.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {

            WorkFlowModel wfmodel = new WorkFlowModel();
            //获取待定业务数
            var WFDDList = wfmodel.GetListByState(0, LoginAccount.UserID);
            ViewBag.DDCnt = WFDDList.Count();

            //获取待处理业务数
            ApprovalRecordModel arModel = new ApprovalRecordModel();
            var DBList = arModel.GetList_ByUID(LoginAccount.UserID);
            ViewBag.DBCnt = DBList.Count();
            return View();


        }
    }
}
