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

        //[HttpPost]
        //public ActionResult Add(Company company, string hidYingYeZhiZhao)
        //{
        //    CompanyModel companyModel = new CompanyModel();
        //    Result result = null;
        //    if (hidYingYeZhiZhao.Length > 0)
        //    {
        //        var attachment_YingYeZhiZhao = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(hidYingYeZhiZhao);
        //        result = companyModel.Add(company, attachment_YingYeZhiZhao);
        //    }
        //    else
        //    {
        //        result = companyModel.Add(company, null);
        //    }
        //    if (result.HasError)
        //    {
        //        return JavaScript("JMessage('" + result.Error + "',true)");
        //    }
        //    return JavaScript("window.location.href='" + Url.Action("Index", "Company") + "'");
        //}

        [HttpPost]
        public ActionResult Add(Company company)
        {
            CompanyModel companyModel = new CompanyModel();
            Result result = companyModel.Add(company, null);
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
            ViewBag.A_YingYeZhiZhao1 = attachmentList.Where(a => a.EnumAttachmentType == (int)EnumAttachmentType.YingYeZhiZhao1).FirstOrDefault();
            ViewBag.A_YingYeZhiZhao2 = attachmentList.Where(a => a.EnumAttachmentType == (int)EnumAttachmentType.YingYeZhiZhao2).FirstOrDefault();


            return View(company);
        }

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            Result result = null;
            CompanyModel companyModel = new CompanyModel();
            result = companyModel.Edit(company);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            else
            {
                return JavaScript("JMessage('保存成功！',false,true)");
            }
        }

        [HttpPost]
        public ActionResult EditAttachment(Company company)
        {
            List<Attachment> attachmentList = new List<Attachment>();
            string YanZhiBaoGao = Request.Form["hid_attachment_1"];
            if (string.IsNullOrEmpty(YanZhiBaoGao) == false)
            {
                var attachment_YanZhiBaoGao = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(YanZhiBaoGao);
                attachmentList.AddRange(attachment_YanZhiBaoGao);
            }
            string QiTa = Request.Form["hid_attachment_2"];
            if (string.IsNullOrEmpty(QiTa) == false)
            {
                var attachment_QiTa = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(QiTa);
                attachmentList.AddRange(attachment_QiTa);
            }
            string FaRen1 = Request.Form["hid_attachment_single_1"];
            if (string.IsNullOrEmpty(FaRen1) == false)
            {
                var attachment_FaRen1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(FaRen1);
                attachmentList.Add(attachment_FaRen1);
            }
            string FaRen2 = Request.Form["hid_attachment_single_2"];
            if (string.IsNullOrEmpty(FaRen2) == false)
            {
                var attachment_FaRen2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(FaRen2);
                attachmentList.Add(attachment_FaRen2);
            }
            string YingYeZhiZhao1 = Request.Form["hid_attachment_single_3"];
            if (string.IsNullOrEmpty(YingYeZhiZhao1) == false)
            {
                var attachment_YingYeZhiZhao1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(YingYeZhiZhao1);
                attachmentList.Add(attachment_YingYeZhiZhao1);
            }
            string YingYeZhiZhao2 = Request.Form["hid_attachment_single_4"];
            if (string.IsNullOrEmpty(YingYeZhiZhao2) == false)
            {
                var attachment_YingYeZhiZhao2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(YingYeZhiZhao2);
                attachmentList.Add(attachment_YingYeZhiZhao2);
            }
            string ZuZhiJiGouDaiMa1 = Request.Form["hid_attachment_single_5"];
            if (string.IsNullOrEmpty(ZuZhiJiGouDaiMa1) == false)
            {
                var attachment_ZuZhiJiGouDaiMa1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(ZuZhiJiGouDaiMa1);
                attachmentList.Add(attachment_ZuZhiJiGouDaiMa1);
            }
            string ZuZhiJiGouDaiMa2 = Request.Form["hid_attachment_single_6"];
            if (string.IsNullOrEmpty(ZuZhiJiGouDaiMa2) == false)
            {
                var attachment_ZuZhiJiGouDaiMa2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(ZuZhiJiGouDaiMa2);
                attachmentList.Add(attachment_ZuZhiJiGouDaiMa2);
            }
            string ShuiWu1 = Request.Form["hid_attachment_single_7"];
            if (string.IsNullOrEmpty(ShuiWu1) == false)
            {
                var attachment_ShuiWu1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(ShuiWu1);
                attachmentList.Add(attachment_ShuiWu1);
            }
            string ShuiWu2 = Request.Form["hid_attachment_single_8"];
            if (string.IsNullOrEmpty(ShuiWu2) == false)
            {
                var attachment_ShuiWu2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(ShuiWu2);
                attachmentList.Add(attachment_ShuiWu2);
            }
            string DaiKuanKa = Request.Form["hid_attachment_single_9"];
            if (string.IsNullOrEmpty(DaiKuanKa) == false)
            {
                var attachment_DaiKuanKa = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(DaiKuanKa);
                attachmentList.Add(attachment_DaiKuanKa);
            }








            CompanyModel companyModel = new CompanyModel();
            Result result = companyModel.UploadAttachment(company.ID, attachmentList);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            else
            {
                return JavaScript("JMessage('保存成功！',false,true);");
            }
        }
    }
}
