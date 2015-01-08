using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace Investment.Controllers
{
    /// <summary>
    /// 审批流程表单——融资表单
    /// </summary>
    public class WorkFlow_Form_FinancingController : Controller
    {
        public ActionResult Index(int financingID, int? workflowID)
        {
            Financing financing = null;
            if (workflowID.HasValue)
            {
                WorkFlowModel wfm = new WorkFlowModel();
                var wf = wfm.Get(workflowID.Value);
                //只有当未通过和已完成时，才从json(快照)中取数据
                if (wf.State == 2 || wf.State == 3)
                {
                    financing = Newtonsoft.Json.JsonConvert.DeserializeObject<Financing>(wf.FormJson);
                }
            }
            if (financing == null)
            {
                FinancingModel fm = new FinancingModel();
                financing = fm.Get(financingID);
            }
            return PartialView(financing);
        }

    }
}
