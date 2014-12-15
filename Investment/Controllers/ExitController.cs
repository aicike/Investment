using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Budget.Controllers
{
    public class ExitController : Controller
    {
        [NoClientCache]
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();
            if (Response.Cookies["USER_COOKIE"] != null)
            {
                Response.Cookies["USER_COOKIE"].Expires = DateTime.Now;
            }
            return View();
        }

        [HttpPost]
        [NoClientCache]
        public ActionResult Index2()
        {
            return RedirectToAction("Exit", "Exit", new { Area = "" });
        }

        [NoClientCache]
        public ActionResult Exit()
        {
            ViewBag.ExitUrl = Url.Action("Index", "Login");
            return RedirectToAction("Index", "Login");
        }
    }
}
