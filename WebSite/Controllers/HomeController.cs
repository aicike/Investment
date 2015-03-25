using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Index2()
        {
            return View();
        }

    }
}
