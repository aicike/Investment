using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Investment.Controllers
{
    public class WorkFlowController : Controller
    {
        //
        // GET: /WorkFlow/

        /// <summary>
        /// 预览界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Preview()
        {
            return View();
        }

    }
}
