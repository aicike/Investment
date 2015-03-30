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

            //是否有分配用户权限
            RoleAccountModel RAM = new RoleAccountModel();
            var ralist = RAM.GetInfo_ByGAID(LoginAccount.UserID);
            ViewBag.ISDSH = "false";
            foreach (var item in ralist)
            {
                if (item.Role.ID == 13)
                {
                    ViewBag.ISDSH = "true";
                    //获取待审批客户数
                    FinancingModel fm = new FinancingModel();
                    var dshCnt = fm.List().Where(a => a.AuditStatus==0).Count();
                    ViewBag.dshCnt = dshCnt;
                    break;
                }
            }


            return View();


        }
    }
}
