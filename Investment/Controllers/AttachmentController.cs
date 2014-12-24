using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Investment.Models;

namespace Investment.Controllers
{
    public class AttachmentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manage(AttachmentControl ac)
        {
            
            return PartialView(ac);
        }
    }
}
