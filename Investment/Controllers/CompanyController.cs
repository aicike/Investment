using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;
using Entity.Enum;

namespace Investment.Controllers
{
    public class CompanyController : BaseController
    {
        public ActionResult Index(int? id)
        {
            CompanyModel cm = new CompanyModel();
            var list = cm.List().ToPagedList(id ?? 1, 15);
            return View(list);
        }

        public ActionResult Add()
        {
            Company company = new Company();
            return View(company);
        }

        [HttpPost]
        public ActionResult Add(Company company, string hidYingYeZhiZhao)
        {
            CompanyModel companyModel = new CompanyModel();
            Result result = null;
            if (hidYingYeZhiZhao.Length > 0)
            {
                var attachment_YingYeZhiZhao = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(hidYingYeZhiZhao);
                result = companyModel.Add(company, attachment_YingYeZhiZhao);
            }
            else
            {
                result = companyModel.Add(company, null);
            }
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Index", "Company") + "'");
        }

        public ActionResult Edit(int id)
        {
            CompanyModel companyModel = new CompanyModel();
            var company = companyModel.Get(id);
            AttachmentModel attachmentModel = new AttachmentModel();
            var attachmentList = attachmentModel.GetAttachment(SystemConst.TableName.Company, id);
            ViewBag.A_YingYeZhiZhao = attachmentList.Where(a => a.EnumAttachmentType == (int)EnumAttachmentType.YingYeZhiZhao).FirstOrDefault();


            return View(company);
        }

        [HttpPost]
        public ActionResult Edit(Company company, string hidYingYeZhiZhao)
        {
            Result result = null;
            CompanyModel companyModel = new CompanyModel();
            if (hidYingYeZhiZhao.Length > 0)
            {
                List<string> oldFiles = new List<string>();
                oldFiles.Add(Request.Form["hidYingYeZhiZhaoOld"]);
                var attachment_YingYeZhiZhao = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(hidYingYeZhiZhao);
                result = companyModel.Edit(company, attachment_YingYeZhiZhao, oldFiles);
            }
            else
            {
                result = companyModel.Edit(company, null, null);
            }
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Index", "Company") + "'");
        }


    }
}
