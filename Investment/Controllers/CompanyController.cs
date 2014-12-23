using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace Investment.Controllers
{
    public class CompanyController : BaseController
    {
        public ActionResult Index(int? id)
        {
            CompanyModel cm = new CompanyModel();
            var list = cm.List().ToPagedList(id ?? 1,15);
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Company company, string hidYingYeZhiZhao)
        {
            CompanyModel companyModel = new CompanyModel();
            var result = companyModel.Add(company);

            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Index", "Company") + "'");
        }


    }
}
