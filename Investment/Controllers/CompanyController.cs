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
        #region 客户信息

        public ActionResult Index(int? id, string Name)
        {
            CompanyModel cm = new CompanyModel();
            var objs = cm.List();
            if (!string.IsNullOrEmpty(Name))
            {
                objs = objs.Where(a => a.Name.Contains(Name));
            }
            //var list = objs.ToPagedList(id ?? 1, 15);
            var list = cm.List().Where(a => a.OwnerID == LoginAccount.UserID).ToPagedList(id ?? 1, 15);
            return View(list);
        }

        public ActionResult Add()
        {
            Company company = new Company();
            return View(company);
        }

        [HttpPost]
        public ActionResult Add(Company company)
        {
            CompanyModel companyModel = new CompanyModel();
            company.OwnerID = LoginAccount.UserID;
            company.Status = 2;
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
            return View(company);
        }

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            Result result = null;
            CompanyModel companyModel = new CompanyModel();
            result = companyModel.Edit(company);
            if (result.HasError == false)
            {
                result = EditAttachment(company);
            }
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            else
            {
                return JavaScript("JMessage('保存成功！',false,true)");
            }
        }

        private Result EditAttachment(Company company)
        {
            List<Attachment> attachmentList = new List<Attachment>();

            string FaRen1 = Request.Form["hid_attachment_1"];
            if (string.IsNullOrEmpty(FaRen1) == false)
            {
                var attachment_FaRen1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(FaRen1);
                attachmentList.Add(attachment_FaRen1);
            }
            string FaRen2 = Request.Form["hid_attachment_2"];
            if (string.IsNullOrEmpty(FaRen2) == false)
            {
                var attachment_FaRen2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(FaRen2);
                attachmentList.Add(attachment_FaRen2);
            }
            string YingYeZhiZhao1 = Request.Form["hid_attachment_3"];
            if (string.IsNullOrEmpty(YingYeZhiZhao1) == false)
            {
                var attachment_YingYeZhiZhao1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(YingYeZhiZhao1);
                attachmentList.Add(attachment_YingYeZhiZhao1);
            }
            string YingYeZhiZhao2 = Request.Form["hid_attachment_4"];
            if (string.IsNullOrEmpty(YingYeZhiZhao2) == false)
            {
                var attachment_YingYeZhiZhao2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(YingYeZhiZhao2);
                attachmentList.Add(attachment_YingYeZhiZhao2);
            }
            string ZuZhiJiGouDaiMa1 = Request.Form["hid_attachment_5"];
            if (string.IsNullOrEmpty(ZuZhiJiGouDaiMa1) == false)
            {
                var attachment_ZuZhiJiGouDaiMa1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(ZuZhiJiGouDaiMa1);
                attachmentList.Add(attachment_ZuZhiJiGouDaiMa1);
            }
            string ZuZhiJiGouDaiMa2 = Request.Form["hid_attachment_6"];
            if (string.IsNullOrEmpty(ZuZhiJiGouDaiMa2) == false)
            {
                var attachment_ZuZhiJiGouDaiMa2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(ZuZhiJiGouDaiMa2);
                attachmentList.Add(attachment_ZuZhiJiGouDaiMa2);
            }
            string ShuiWu1 = Request.Form["hid_attachment_7"];
            if (string.IsNullOrEmpty(ShuiWu1) == false)
            {
                var attachment_ShuiWu1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(ShuiWu1);
                attachmentList.Add(attachment_ShuiWu1);
            }
            string ShuiWu2 = Request.Form["hid_attachment_8"];
            if (string.IsNullOrEmpty(ShuiWu2) == false)
            {
                var attachment_ShuiWu2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(ShuiWu2);
                attachmentList.Add(attachment_ShuiWu2);
            }
            string DaiKuanKa = Request.Form["hid_attachment_9"];
            if (string.IsNullOrEmpty(DaiKuanKa) == false)
            {
                var attachment_DaiKuanKa = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(DaiKuanKa);
                attachmentList.Add(attachment_DaiKuanKa);
            }
            string KaiHuXuKeZheng = Request.Form["hid_attachment_10"];
            if (string.IsNullOrEmpty(KaiHuXuKeZheng) == false)
            {
                var attachment_KaiHuXuKeZheng = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(KaiHuXuKeZheng);
                attachmentList.AddRange(attachment_KaiHuXuKeZheng);
            }
            string YanZhiZhengShu = Request.Form["hid_attachment_11"];
            if (string.IsNullOrEmpty(YanZhiZhengShu) == false)
            {
                var attachment_YanZhiZhengShu = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(YanZhiZhengShu);
                attachmentList.Add(attachment_YanZhiZhengShu);
            }
            string GongSiZhangChengJiXiuZhengAn = Request.Form["hid_attachment_12"];
            if (string.IsNullOrEmpty(GongSiZhangChengJiXiuZhengAn) == false)
            {
                var attachment_GongSiZhangChengJiXiuZhengAn = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(GongSiZhangChengJiXiuZhengAn);
                attachmentList.AddRange(attachment_GongSiZhangChengJiXiuZhengAn);
            }
            string YanZhiBaoGao = Request.Form["hid_attachment_13"];
            if (string.IsNullOrEmpty(YanZhiBaoGao) == false)
            {
                var attachment_YanZhiBaoGao = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(YanZhiBaoGao);
                attachmentList.AddRange(attachment_YanZhiBaoGao);
            }
            string GongShangJiBenXinXiChaXunDan = Request.Form["hid_attachment_14"];
            if (string.IsNullOrEmpty(GongShangJiBenXinXiChaXunDan) == false)
            {
                var attachment_GongShangJiBenXinXiChaXunDan = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(GongShangJiBenXinXiChaXunDan);
                attachmentList.Add(attachment_GongShangJiBenXinXiChaXunDan);
            }
            string FaRenJiGuDongShenFenZheng = Request.Form["hid_attachment_15"];
            if (string.IsNullOrEmpty(FaRenJiGuDongShenFenZheng) == false)
            {
                var attachment_FaRenJiGuDongShenFenZheng = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(FaRenJiGuDongShenFenZheng);
                attachmentList.AddRange(attachment_FaRenJiGuDongShenFenZheng);
            }
            string GaoGuanJianLi = Request.Form["hid_attachment_16"];
            if (string.IsNullOrEmpty(GaoGuanJianLi) == false)
            {
                var attachment_GaoGuanJianLi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(GaoGuanJianLi);
                attachmentList.AddRange(attachment_GaoGuanJianLi);
            }
            string XiangMuXiangGuanPiWen = Request.Form["hid_attachment_17"];
            if (string.IsNullOrEmpty(XiangMuXiangGuanPiWen) == false)
            {
                var attachment_XiangMuXiangGuanPiWen = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(XiangMuXiangGuanPiWen);
                attachmentList.AddRange(attachment_XiangMuXiangGuanPiWen);
            }
            string KeXingXingBaoGao = Request.Form["hid_attachment_18"];
            if (string.IsNullOrEmpty(KeXingXingBaoGao) == false)
            {
                var attachment_KeXingXingBaoGao = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(KeXingXingBaoGao);
                attachmentList.AddRange(attachment_KeXingXingBaoGao);
            }
            string XiangMuJianJieJiXiaoGuoTu = Request.Form["hid_attachment_19"];
            if (string.IsNullOrEmpty(XiangMuJianJieJiXiaoGuoTu) == false)
            {
                var attachment_XiangMuJianJieJiXiaoGuoTu = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(XiangMuJianJieJiXiaoGuoTu);
                attachmentList.AddRange(attachment_XiangMuJianJieJiXiaoGuoTu);
            }
            string GongSiJianJie = Request.Form["hid_attachment_20"];
            if (string.IsNullOrEmpty(GongSiJianJie) == false)
            {
                var attachment_GongSiJianJie = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(GongSiJianJie);
                attachmentList.Add(attachment_GongSiJianJie);
            }
            string RongZhiShenQingShuJiHuanKuanJiHuaShu = Request.Form["hid_attachment_21"];
            if (string.IsNullOrEmpty(RongZhiShenQingShuJiHuanKuanJiHuaShu) == false)
            {
                var attachment_RongZhiShenQingShuJiHuanKuanJiHuaShu = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(RongZhiShenQingShuJiHuanKuanJiHuaShu);
                attachmentList.Add(attachment_RongZhiShenQingShuJiHuanKuanJiHuaShu);
            }
            string WuZheng = Request.Form["hid_attachment_22"];
            if (string.IsNullOrEmpty(WuZheng) == false)
            {
                var attachment_WuZheng = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(WuZheng);
                attachmentList.AddRange(attachment_WuZheng);
            }
            string GongSiJinSanNianJiDangNianCaiWuBaoBiaoHeShenJiBaoGao = Request.Form["hid_attachment_23"];
            if (string.IsNullOrEmpty(GongSiJinSanNianJiDangNianCaiWuBaoBiaoHeShenJiBaoGao) == false)
            {
                var attachment_GongSiJinSanNianJiDangNianCaiWuBaoBiaoHeShenJiBaoGao = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(GongSiJinSanNianJiDangNianCaiWuBaoBiaoHeShenJiBaoGao);
                attachmentList.AddRange(attachment_GongSiJinSanNianJiDangNianCaiWuBaoBiaoHeShenJiBaoGao);
            }
            string ErJiKeMuMingXi = Request.Form["hid_attachment_24"];
            if (string.IsNullOrEmpty(ErJiKeMuMingXi) == false)
            {
                var attachment_ErJiKeMuMingXi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(ErJiKeMuMingXi);
                attachmentList.AddRange(attachment_ErJiKeMuMingXi);
            }
            string ZengZhiShui_YingYeShui_SuoDeShui = Request.Form["hid_attachment_25"];
            if (string.IsNullOrEmpty(ZengZhiShui_YingYeShui_SuoDeShui) == false)
            {
                var attachment_ZengZhiShui_YingYeShui_SuoDeShui = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(ZengZhiShui_YingYeShui_SuoDeShui);
                attachmentList.AddRange(attachment_ZengZhiShui_YingYeShui_SuoDeShui);
            }
            string GongSiDaiKuanMingXi = Request.Form["hid_attachment_26"];
            if (string.IsNullOrEmpty(GongSiDaiKuanMingXi) == false)
            {
                var attachment_GongSiDaiKuanMingXi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(GongSiDaiKuanMingXi);
                attachmentList.AddRange(attachment_GongSiDaiKuanMingXi);
            }
            string ShiGongHeTong = Request.Form["hid_attachment_27"];
            if (string.IsNullOrEmpty(ShiGongHeTong) == false)
            {
                var attachment_ShiGongHeTong = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(ShiGongHeTong);
                attachmentList.AddRange(attachment_ShiGongHeTong);
            }
            string XiaoShouMingXi = Request.Form["hid_attachment_28"];
            if (string.IsNullOrEmpty(XiaoShouMingXi) == false)
            {
                var attachment_XiaoShouMingXi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(XiaoShouMingXi);
                attachmentList.AddRange(attachment_XiaoShouMingXi);
            }
            string ShenQingRenYinHangDuiZhangDan = Request.Form["hid_attachment_29"];
            if (string.IsNullOrEmpty(ShenQingRenYinHangDuiZhangDan) == false)
            {
                var attachment_ShenQingRenYinHangDuiZhangDan = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(ShenQingRenYinHangDuiZhangDan);
                attachmentList.AddRange(attachment_ShenQingRenYinHangDuiZhangDan);
            }
            string DiYaWuZhiLiao = Request.Form["hid_attachment_30"];
            if (string.IsNullOrEmpty(DiYaWuZhiLiao) == false)
            {
                var attachment_DiYaWuZhiLiao = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(DiYaWuZhiLiao);
                attachmentList.AddRange(attachment_DiYaWuZhiLiao);
            }
            string CaiChanQingDan = Request.Form["hid_attachment_31"];
            if (string.IsNullOrEmpty(CaiChanQingDan) == false)
            {
                var attachment_CaiChanQingDan = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(CaiChanQingDan);
                attachmentList.AddRange(attachment_CaiChanQingDan);
            }
            string GuanLianGongSiZiLiao = Request.Form["hid_attachment_32"];
            if (string.IsNullOrEmpty(GuanLianGongSiZiLiao) == false)
            {
                var attachment_GuanLianGongSiZiLiao = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(GuanLianGongSiZiLiao);
                attachmentList.AddRange(attachment_GuanLianGongSiZiLiao);
            }
            string QiTa = Request.Form["hid_attachment_50"];
            if (string.IsNullOrEmpty(QiTa) == false)
            {
                var attachment_QiTa = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(QiTa);
                attachmentList.AddRange(attachment_QiTa);
            }
            CompanyModel companyModel = new CompanyModel();
            Result result = companyModel.UploadAttachment(company.ID, attachmentList);
            return result;
        }

        public ActionResult ChangeStatus(int id, int status)
        {
            CompanyModel companyModel = new CompanyModel();
            companyModel.ChangeStatus(id, status);
            return JavaScript("JMessage('操作成功',false,true,'" + Url.Action("Index", "Company") + "')");
        }

        public string Delete(int id)
        {
            CompanyModel companyModel = new CompanyModel();
            var result = companyModel.Delete_Check(id, LoginAccount.UserID);
            if (result.HasError)
            {
                return "<script>JMessage('" + result.Error + "',true)</script>";
            }
            return "<script>window.location.href='" + Url.Action("Index", "Company") + "';</script>";
        }

        public ActionResult Detail(int id)
        {
            return View();
        }

        #endregion

        #region 融资信息

        public ActionResult Financing(int? id, int companyID, int page, string Name)
        {
            CompanyModel companyModel = new CompanyModel();
            var company = companyModel.Get(companyID);
            (company != null).NotAuthorizedPage();
            ViewBag.Company = company;
            ViewBag.Page = page;
            ViewBag.LoginUesrID = LoginAccount.UserID;
            FinancingModel fm = new FinancingModel();

            var objs = fm.GetByCompanyID(companyID).Where(a => (a.Owner_A_ID == LoginAccount.UserID || a.Owner_B_ID == LoginAccount.UserID));

            if (!string.IsNullOrEmpty(Name))
            {
                objs = objs.Where(a => a.Name.Contains(Name));
            }


            var list = objs.ToPagedList(id ?? 1, 15);
            return View(list);
        }

        public ActionResult AddFinancing(int companyID, int page)
        {
            ViewBag.CompanyID = companyID;
            ViewBag.Page = page;

            WorkFlowManagerModel wfmm = new WorkFlowManagerModel();
            var wfms = wfmm.List().OrderBy(a => a.ID).ToList();
            List<SelectListItem> newList = new List<SelectListItem>();
            var wfm_list = new SelectList(wfms, "ID", "Name");
            newList.Add(new SelectListItem { Text = "请选择项目类型", Value = "select", Selected = true });
            newList.AddRange(wfm_list);
            ViewData["wfm"] = newList;
            return View();
        }

        [HttpPost]
        public ActionResult AddFinancing(Financing financing, int page)
        {
            FinancingModel fm = new FinancingModel();

            string RongZiXinXiFuJian = Request.Form["hid_attachment_1"];
            List<Attachment> attachments = null;
            if (string.IsNullOrEmpty(RongZiXinXiFuJian) == false)
            {
                attachments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(RongZiXinXiFuJian);
            }
            financing.Owner_A_ID = LoginAccount.UserID;
            Result result = fm.Add(financing, attachments);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Financing", "Company", new { companyID = financing.CompanyID, page = page }) + "'");
        }

        public ActionResult EditFinancing(int id, int companyID, int page)
        {
            FinancingModel fm = new FinancingModel();
            var financing = fm.Get(id);
            (financing.CompanyID == companyID).NotAuthorizedPage();
            ViewBag.Page = page;


            WorkFlowManagerModel wfmm = new WorkFlowManagerModel();
            var wfms = wfmm.List().OrderBy(a=>a.ID).ToList();
            List<SelectListItem> newList = new List<SelectListItem>();
            var wfm_list = new SelectList(wfms, "ID", "Name");
            newList.Add(new SelectListItem { Text = "请选择项目类型", Value = "select", Selected = true });
            newList.AddRange(wfm_list);
            ViewData["wfm"] = newList;

            return View(financing);
        }

        [HttpPost]
        public ActionResult EditFinancing(Financing financing, int page)
        {
            Result result = null;
            FinancingModel fm = new FinancingModel();
            string RongZiXinXiFuJian = Request.Form["hid_attachment_1"];
            List<Attachment> attachments = null;
            if (string.IsNullOrEmpty(RongZiXinXiFuJian) == false)
            {
                attachments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(RongZiXinXiFuJian);
            }
            result = fm.Edit(financing, attachments);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Financing", "Company", new { companyID = financing.CompanyID, page = page }) + "'");
        }

        public string DeleteFinancing(int id, int companyID, int page)
        {
            FinancingModel fm = new FinancingModel();
            var result = fm.Delete_Check(id, LoginAccount.UserID);
            if (result.HasError)
            {
                return "<script>JMessage('" + result.Error + "',true)</script>";
            }
            return "<script>window.location.href='" + Url.Action("Financing", "Company", new { companyID = companyID, page = page }) + "';</script>";
        }

        #endregion
    }
}
