using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Investment.Controllers
{
    public class CompanyController : BaseController
    {
        public ActionResult Index(int? id)
        {
            CompanyModel cm = new CompanyModel();
            var list = cm.List().ToPagedList(id ?? 1, 5);
            return View(list);
        }

    }
}
