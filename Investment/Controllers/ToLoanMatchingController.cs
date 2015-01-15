using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Investment.Controllers
{
    public class ToLoanMatchingController : BaseController
    {
        //
        // GET: /ToLoanMatching/
        /// <summary>
        /// 借贷匹配
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int ?id)
        {
            FinancingMatchingModel FMModel = new FinancingMatchingModel();
            var fmlist = FMModel.GetMatching();
            var pagelist = fmlist.ToPagedList(id ?? 1, 15);
            return View(pagelist);

        }

    }
}
