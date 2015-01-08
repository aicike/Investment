using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Investment.Controllers
{
    /// <summary>
    /// 审批流程表单——融资表单
    /// </summary>
    public class WorkFlow_Form_FinancingController : Controller
    {
        public ActionResult Index(int financingID,int workflowID)
        {
            FinancingModel fm = new FinancingModel();
            var financing= fm.Get(financingID);
            return PartialView(financing);
        }

    }
}
