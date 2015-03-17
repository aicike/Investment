using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace Investment.Controllers
{
    public class ToLoanMatchingController : BaseController
    {
        //
        // GET: /ToLoanMatching/
        /// <summary>
        /// 借贷匹配（只匹配自己的客户）
        /// </summary>
        /// <param name="Types">类型 1或无：贷款业务，2自有资金</param>
        /// <returns></returns>
        public ActionResult Index(int? id, int? Types)
        {
            FinancingMatchingModel FMModel = new FinancingMatchingModel();
            IQueryable<FinancingMatching> fmlist;
            if (Types.HasValue)
            {
                if (Types.Value == 1) //贷款业务
                {
                    fmlist = FMModel.GetMatching_BYAccountID(LoginAccount.UserID);
                }
                else //自有
                {
                    fmlist = FMModel.GetMatchingZY_BYAccountID(LoginAccount.UserID);
                }
            }
            else //贷款业务
            {
                fmlist = FMModel.GetMatching_BYAccountID(LoginAccount.UserID);
            }
            ViewBag.Types = 1;
            if (Types.HasValue)
            {
                ViewBag.Types = Types.Value;
            }
            var pagelist = fmlist.ToPagedList(id ?? 1, 15);
            return View(pagelist);

        }

        /// <summary>
        /// 借贷匹配 (全用户)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Types">类型 1或无：贷款业务，2自有资金</param>
        /// <returns></returns>
        public ActionResult IndexAll(int ? id,int ?Types)
        {
            FinancingMatchingModel FMModel = new FinancingMatchingModel();
            IQueryable<FinancingMatching> fmlist;
            if (Types.HasValue)
            {
                if (Types.Value == 1) //贷款业务
                {
                    fmlist = FMModel.GetMatching();
                }
                else //自有
                {
                    fmlist = FMModel.GetMatchingZY();
                }
            }
            else //贷款业务
            {
                fmlist = FMModel.GetMatching();
            }
            ViewBag.Types = 1;
            if (Types.HasValue)
            {
                ViewBag.Types = Types.Value;
            }
            var pagelist = fmlist.ToPagedList(id ?? 1, 50);
            return View(pagelist);
        }

    }
}
