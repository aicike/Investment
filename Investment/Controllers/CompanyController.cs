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
            company.Status = 1;

            List<Attachment> attachments = GetAttachment();

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
            List<Attachment> attachments = GetAttachment();
            result = companyModel.Edit(company, attachments);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            else
            {
                return JavaScript("JMessage('保存成功！',false,true)");
            }
        }

        private List<Attachment> GetAttachment()
        {
            List<Attachment> attachmentList = new List<Attachment>();

            string QiYeZiZhi = Request.Form["hid_attachment_1"];
            if (string.IsNullOrEmpty(QiYeZiZhi) == false)
            {
                var attachment_QiYeZiZhi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(QiYeZiZhi);
                attachmentList.AddRange(attachment_QiYeZiZhi);
            }
            string YingYeZhiZhao = Request.Form["hid_attachment_2"];
            if (string.IsNullOrEmpty(YingYeZhiZhao) == false)
            {
                var attachment_YingYeZhiZhao = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(YingYeZhiZhao);
                attachmentList.AddRange(attachment_YingYeZhiZhao);
            }
            string ZuZhiJiGouDaiMa = Request.Form["hid_attachment_3"];
            if (string.IsNullOrEmpty(ZuZhiJiGouDaiMa) == false)
            {
                var attachment_ZuZhiJiGouDaiMa = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(ZuZhiJiGouDaiMa);
                attachmentList.Add(attachment_ZuZhiJiGouDaiMa);
            }
            string ShuiWu = Request.Form["hid_attachment_4"];
            if (string.IsNullOrEmpty(ZuZhiJiGouDaiMa) == false)
            {
                var attachment_ShuiWu = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(ShuiWu);
                attachmentList.Add(attachment_ShuiWu);
            }
            string KaiHuXuKeZheng = Request.Form["hid_attachment_5"];
            if (string.IsNullOrEmpty(KaiHuXuKeZheng) == false)
            {
                var attachment_KaiHuXuKeZheng = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(KaiHuXuKeZheng);
                attachmentList.Add(attachment_KaiHuXuKeZheng);
            }
            string YanZiBaoGao = Request.Form["hid_attachment_6"];
            if (string.IsNullOrEmpty(YanZiBaoGao) == false)
            {
                var attachment_YanZiBaoGao = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(YanZiBaoGao);
                attachmentList.Add(attachment_YanZiBaoGao);
            }
            string GongSiZhangCheng = Request.Form["hid_attachment_7"];
            if (string.IsNullOrEmpty(GongSiZhangCheng) == false)
            {
                var attachment_GongSiZhangCheng = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(GongSiZhangCheng);
                attachmentList.Add(attachment_GongSiZhangCheng);
            }
            string GongShangChaXun = Request.Form["hid_attachment_8"];
            if (string.IsNullOrEmpty(GongShangChaXun) == false)
            {
                var attachment_GongShangChaXun = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(GongShangChaXun);
                attachmentList.Add(attachment_GongShangChaXun);
            }
            string XinYongDaiMaZheng = Request.Form["hid_attachment_9"];
            if (string.IsNullOrEmpty(XinYongDaiMaZheng) == false)
            {
                var attachment_XinYongDaiMaZheng = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(XinYongDaiMaZheng);
                attachmentList.Add(attachment_XinYongDaiMaZheng);
            }
            string GongSiJianJie = Request.Form["hid_attachment_10"];
            if (string.IsNullOrEmpty(GongSiJianJie) == false)
            {
                var attachment_GongSiJianJie = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(GongSiJianJie);
                attachmentList.Add(attachment_GongSiJianJie);
            }
            string FaRen = Request.Form["hid_attachment_11"];
            if (string.IsNullOrEmpty(FaRen) == false)
            {
                var attachment_FaRen = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(FaRen);
                attachmentList.Add(attachment_FaRen);
            }
            string GuDong = Request.Form["hid_attachment_12"];
            if (string.IsNullOrEmpty(GuDong) == false)
            {
                var attachment_GuDong = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(GuDong);
                attachmentList.Add(attachment_GuDong);
            }
            string FaRenGuDongZhengXinBaoGao = Request.Form["hid_attachment_13"];
            if (string.IsNullOrEmpty(FaRenGuDongZhengXinBaoGao) == false)
            {
                var attachment_FaRenGuDongZhengXinBaoGao = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(FaRenGuDongZhengXinBaoGao);
                attachmentList.Add(attachment_FaRenGuDongZhengXinBaoGao);
            }
            string GuDongGouCheng = Request.Form["hid_attachment_14"];
            if (string.IsNullOrEmpty(GuDongGouCheng) == false)
            {
                var attachment_GuDongGouCheng = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(GuDongGouCheng);
                attachmentList.Add(attachment_GuDongGouCheng);
            }
            string ZuZhiJieGou = Request.Form["hid_attachment_15"];
            if (string.IsNullOrEmpty(ZuZhiJieGou) == false)
            {
                var attachment_ZuZhiJieGou = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(ZuZhiJieGou);
                attachmentList.Add(attachment_ZuZhiJieGou);
            }
            string GuanLiChengJianJie = Request.Form["hid_attachment_16"];
            if (string.IsNullOrEmpty(GuanLiChengJianJie) == false)
            {
                var attachment_GuanLiChengJianJie = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(GuanLiChengJianJie);
                attachmentList.Add(attachment_GuanLiChengJianJie);
            }
            string GuanLianQiYe = Request.Form["hid_attachment_17"];
            if (string.IsNullOrEmpty(GuanLianQiYe) == false)
            {
                var attachment_GuanLianQiYe = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(GuanLianQiYe);
                attachmentList.Add(attachment_GuanLianQiYe);
            }
            string JieDaiXinXi = Request.Form["hid_attachment_18"];
            if (string.IsNullOrEmpty(JieDaiXinXi) == false)
            {
                var attachment_JieDaiXinXi = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(JieDaiXinXi);
                attachmentList.Add(attachment_JieDaiXinXi);
            }
            string SanNianShenJiBaoGao = Request.Form["hid_attachment_19"];
            if (string.IsNullOrEmpty(SanNianShenJiBaoGao) == false)
            {
                var attachment_SanNianShenJiBaoGao = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(SanNianShenJiBaoGao);
                attachmentList.Add(attachment_SanNianShenJiBaoGao);
            }
            string LiuYueCaiWuBaoBiao = Request.Form["hid_attachment_20"];
            if (string.IsNullOrEmpty(LiuYueCaiWuBaoBiao) == false)
            {
                var attachment_LiuYueCaiWuBaoBiao = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(LiuYueCaiWuBaoBiao);
                attachmentList.Add(attachment_LiuYueCaiWuBaoBiao);
            }
            string ZengZhiShuiYingYeShui = Request.Form["hid_attachment_21"];
            if (string.IsNullOrEmpty(ZengZhiShuiYingYeShui) == false)
            {
                var attachment_ZengZhiShuiYingYeShui = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(ZengZhiShuiYingYeShui);
                attachmentList.Add(attachment_ZengZhiShuiYingYeShui);
            }
            string DiYaWu = Request.Form["hid_attachment_22"];
            if (string.IsNullOrEmpty(DiYaWu) == false)
            {
                var attachment_DiYaWu = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(DiYaWu);
                attachmentList.Add(attachment_DiYaWu);
            }
            string KeXingXingBaoGao = Request.Form["hid_attachment_23"];
            if (string.IsNullOrEmpty(KeXingXingBaoGao) == false)
            {
                var attachment_KeXingXingBaoGao = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(KeXingXingBaoGao);
                attachmentList.Add(attachment_KeXingXingBaoGao);
            }


            string XiangMuXiangGuanPiWen = Request.Form["hid_attachment_24"];
            if (string.IsNullOrEmpty(XiangMuXiangGuanPiWen) == false)
            {
                var attachment_XiangMuXiangGuanPiWen = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(XiangMuXiangGuanPiWen);
                attachmentList.Add(attachment_XiangMuXiangGuanPiWen);
            }
            string WuZheng = Request.Form["hid_attachment_25"];
            if (string.IsNullOrEmpty(WuZheng) == false)
            {
                var attachment_WuZheng = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(WuZheng);
                attachmentList.Add(attachment_WuZheng);
            }
            string ShiGongHeTong = Request.Form["hid_attachment_26"];
            if (string.IsNullOrEmpty(ShiGongHeTong) == false)
            {
                var attachment_ShiGongHeTong = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(ShiGongHeTong);
                attachmentList.Add(attachment_ShiGongHeTong);
            }
            string XiaoShouMingXi = Request.Form["hid_attachment_27"];
            if (string.IsNullOrEmpty(XiaoShouMingXi) == false)
            {
                var attachment_XiaoShouMingXi = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(XiaoShouMingXi);
                attachmentList.Add(attachment_XiaoShouMingXi);
            }


            string QiShui = Request.Form["hid_attachment_28"];
            if (string.IsNullOrEmpty(QiShui) == false)
            {
                var attachment_QiShui = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(QiShui);
                attachmentList.Add(attachment_QiShui);
            }
            string GuoWangJingYan = Request.Form["hid_attachment_29"];
            if (string.IsNullOrEmpty(GuoWangJingYan) == false)
            {
                var attachment_GuoWangJingYan = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(GuoWangJingYan);
                attachmentList.Add(attachment_GuoWangJingYan);
            }
            string FangGuanJuDangAnChaXun = Request.Form["hid_attachment_30"];
            if (string.IsNullOrEmpty(FangGuanJuDangAnChaXun) == false)
            {
                var attachment_FangGuanJuDangAnChaXun = Newtonsoft.Json.JsonConvert.DeserializeObject<Attachment>(FangGuanJuDangAnChaXun);
                attachmentList.Add(attachment_FangGuanJuDangAnChaXun);
            }
            return attachmentList;
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
            CompanyModel companyModel = new CompanyModel();
            var company = companyModel.Get(id);
            return View(company);
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
            var wfms = wfmm.List().OrderBy(a => a.ID).ToList();
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
