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

        public ActionResult Index(int? id, string Name, int? radio_gl)
        {
            CompanyModel cm = new CompanyModel();
            var objs = cm.List();
            if (!string.IsNullOrEmpty(Name))
            {
                objs = objs.Where(a => a.Name.Contains(Name));
            }
            if (radio_gl.HasValue == false || radio_gl == 0)
            {
                ViewBag.Radio = 0;
            }
            else
            {
                objs = objs.Where(a => a.Financings.Any());
                ViewBag.Radio = 1;
            }
            ViewBag.Name = Name;
            var list = objs.Where(a => a.OwnerID == LoginAccount.UserID || a.Financings.Any(b => b.Owner_A_ID == LoginAccount.UserID)).ToPagedList(id ?? 1, 15);
            return View(list);
        }

        /// <summary>
        /// 关联公司列表
        /// </summary>
        /// <param name="id">主公司</param>
        /// <returns></returns>
        public ActionResult Index_gl(int id)
        {
            CompanyModel cm = new CompanyModel();
            var objs = cm.List().Where(a => a.ID == id).FirstOrDefault();
            ViewBag.Com = objs;
            var list = objs.CompanyRelations2.Select(a => a.Company).ToList();
            return View(list);
        }

        public ActionResult Add()
        {
            Company company = new Company();
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            ViewBag.HasGuanLian = true;

            IndustryModel industryModel = new IndustryModel();
            var industrys = industryModel.GetList();
            List<SelectListItem> industrysList = new List<SelectListItem>();
            var industrys_list = new SelectList(industrys, "ID", "Name");
            industrysList.Add(new SelectListItem { Text = "请选择行业", Value = "select", Selected = true });
            industrysList.AddRange(industrys_list);
            ViewData["Industry"] = industrysList;

            return View(company);
        }

        [HttpPost]
        public ActionResult Add(Company company)
        {
            CompanyModel companyModel = new CompanyModel();
            company.OwnerID = LoginAccount.UserID;
            company.Status = 1;
            if (string.IsNullOrEmpty(company.Phone))
            {
                company.Phone = "0";
            }
            List<Attachment> attachments = GetAttachment_Add();
            Result result = companyModel.Add(company, attachments);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            var com = result.Entity as Company;
            return JavaScript("window.location.href='" + Url.Action("Edit", "Company", new { id = com.ID }) + "'");
        }

        /// <summary>
        /// 更改行业后，返回公司规模
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeIndustry(int industryID, double ZhuCheZiJin)
        {
            IndustryLevelModel ilm = new IndustryLevelModel();
            var il= ilm.GetIndustry(industryID, ZhuCheZiJin);
            return Json(il,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增关联公司
        /// </summary>
        /// <param name="companyID">主关联公司ID</param>
        /// <returns></returns>
        public ActionResult Add_GuanLian(int companyID)
        {
            Company company = new Company();
            ViewBag.Layout = "~/Views/Shared/_Layout_noMenu.cshtml";
            ViewBag.HasGuanLian = false;
            ViewBag.CompanyID = companyID;

            IndustryModel industryModel = new IndustryModel();
            var industrys = industryModel.GetList();
            List<SelectListItem> industrysList = new List<SelectListItem>();
            var industrys_list = new SelectList(industrys, "ID", "Name");
            industrysList.Add(new SelectListItem { Text = "请选择行业", Value = "select", Selected = true });
            industrysList.AddRange(industrys_list);
            ViewData["Industry"] = industrysList;

            return View("Add", company);
        }

        [HttpPost]
        public ActionResult Add_GuanLian(Company company, int hidCompanyID)
        {
            CompanyModel companyModel = new CompanyModel();
            company.OwnerID = LoginAccount.UserID;
            company.Status = 1;
            List<Attachment> attachments = GetAttachment_Edit();
            Result result = companyModel.Add(company, attachments);
            Company com = null;
            if (result.HasError == false)
            {
                com = result.Entity as Company;
                CompanyRelationModel crm = new CompanyRelationModel();
                result = crm.Add(new CompanyRelation() { RelationObjectID = hidCompanyID, CompanyID = com.ID });
            }
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }

            var javascript = "$('body',parent.document).find('#table_guanlian').append('<tr><td>" + com.Name + "</td><td>" + com.ZhuCheZiJin + "</td><td>" + com.JingYingFanWei + "</td><td>查看</td></tr>');$('body',parent.document).find('.modal-backdrop:last').click();";

            return JavaScript(javascript);
        }


        /// <summary>
        /// 更改公司基本资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            CompanyModel companyModel = new CompanyModel();
            var company = companyModel.Get(id);
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            ViewBag.HasGuanLian = true;
            ViewBag.CompanyID = company.ID;
            //查找借贷信息
            CompanyReferenceModel crmodel = new CompanyReferenceModel();
            var crlist = crmodel.GetInfo_byCID(company.ID);
            ViewBag.CRList = crlist;

            IndustryModel industryModel = new IndustryModel();
            var industrys = industryModel.GetList();
            List<SelectListItem> industrysList = new List<SelectListItem>();
            var industrys_list = new SelectList(industrys, "ID", "Name");
            industrysList.Add(new SelectListItem { Text = "请选择行业", Value = "select", Selected = true });
            industrysList.AddRange(industrys_list);
            ViewData["Industry"] = industrysList;

            return View(company);
        }

        /// <summary>
        /// 更改公司基本资料
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Company company)
        {
            Result result = null;
            CompanyModel companyModel = new CompanyModel();
            List<Attachment> attachments = GetAttachment_Edit();
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
        /// <summary>
        /// 更改公司详细资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditWith(int id)
        {
            CompanyModel companyModel = new CompanyModel();
            var company = companyModel.Get(id);
            if (company.Phone!=null&& company.Phone == "0")
            {
                company.Phone = "";
            }
            ViewBag.CompanyID = company.ID;
            return View(company);
        }

        /// <summary>
        ///  更改公司详细资料
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditWith(Company company)
        {
            Result result = null;
            CompanyModel companyModel = new CompanyModel();
            List<Attachment> attachments = GetAttachment_Edit();
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
        /// <summary>
        /// 更改公司财务资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditFinance(int id)
        {
            //查找借贷信息
            CompanyReferenceModel crmodel = new CompanyReferenceModel();
            var crlist = crmodel.GetInfo_byCID(id);
            ViewBag.CRList = crlist;
            ViewBag.CompanyID = id;
            return View();
        }
        /// <summary>
        /// 更改公司财务资料
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditFinances(int companyID)
        {
            Result result = null;
            CompanyModel companyModel = new CompanyModel();
            List<Attachment> attachments = GetAttachment_Edit();
            var company = companyModel.Get(companyID);
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

        /// <summary>
        /// 更改公司项目资料（房地产）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditRealEstate(int id)
        {

            ViewBag.CompanyID = id;
            return View();
        }
        /// <summary>
        /// 更改公司项目资料（房地产）
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditRealEstates(int CompanyID)
        {
            Result result = null;
            CompanyModel companyModel = new CompanyModel();
            List<Attachment> attachments = GetAttachment_Edit();
            var company = companyModel.Get(CompanyID);
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

        private List<Attachment> GetAttachment_Add()
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
                var attachment_ZuZhiJiGouDaiMa = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(ZuZhiJiGouDaiMa);
                attachmentList.AddRange(attachment_ZuZhiJiGouDaiMa);
            }
            string ShuiWu = Request.Form["hid_attachment_4"];
            if (string.IsNullOrEmpty(ZuZhiJiGouDaiMa) == false)
            {
                var attachment_ShuiWu = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(ShuiWu);
                attachmentList.AddRange(attachment_ShuiWu);
            }
            string KaiHuXuKeZheng = Request.Form["hid_attachment_5"];
            if (string.IsNullOrEmpty(KaiHuXuKeZheng) == false)
            {
                var attachment_KaiHuXuKeZheng = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(KaiHuXuKeZheng);
                attachmentList.AddRange(attachment_KaiHuXuKeZheng);
            }
            string XinYongDaiMaZheng = Request.Form["hid_attachment_6"];
            if (string.IsNullOrEmpty(XinYongDaiMaZheng) == false)
            {
                var attachment_XinYongDaiMaZheng = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(XinYongDaiMaZheng);
                attachmentList.AddRange(attachment_XinYongDaiMaZheng);
            }
            return attachmentList;
        }

        private List<Attachment> GetAttachment_Edit()
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
                var attachment_ZuZhiJiGouDaiMa = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(ZuZhiJiGouDaiMa);
                attachmentList.AddRange(attachment_ZuZhiJiGouDaiMa);
            }
            string ShuiWu = Request.Form["hid_attachment_4"];
            if (string.IsNullOrEmpty(ShuiWu) == false)
            {
                var attachment_ShuiWu = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(ShuiWu);
                attachmentList.AddRange(attachment_ShuiWu);
            }
            string KaiHuXuKeZheng = Request.Form["hid_attachment_5"];
            if (string.IsNullOrEmpty(KaiHuXuKeZheng) == false)
            {
                var attachment_KaiHuXuKeZheng = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(KaiHuXuKeZheng);
                attachmentList.AddRange(attachment_KaiHuXuKeZheng);
            }
            string XinYongDaiMaZheng = Request.Form["hid_attachment_6"];
            if (string.IsNullOrEmpty(XinYongDaiMaZheng) == false)
            {
                var attachment_XinYongDaiMaZheng = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(XinYongDaiMaZheng);
                attachmentList.AddRange(attachment_XinYongDaiMaZheng);
            }


            string GongSiJianJie = Request.Form["hid_attachment_7"];
            if (string.IsNullOrEmpty(GongSiJianJie) == false)
            {
                var attachment_GongSiJianJie = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(GongSiJianJie);
                attachmentList.AddRange(attachment_GongSiJianJie);
            }
            string GongSiZhangCheng = Request.Form["hid_attachment_8"];
            if (string.IsNullOrEmpty(GongSiZhangCheng) == false)
            {
                var attachment_GongSiZhangCheng = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(GongSiZhangCheng);
                attachmentList.AddRange(attachment_GongSiZhangCheng);
            }
            string GongShangChaXun = Request.Form["hid_attachment_9"];
            if (string.IsNullOrEmpty(GongShangChaXun) == false)
            {
                var attachment_GongShangChaXun = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(GongShangChaXun);
                attachmentList.AddRange(attachment_GongShangChaXun);
            }
            string YanZhiBaoGao = Request.Form["hid_attachment_9"];
            if (string.IsNullOrEmpty(YanZhiBaoGao) == false)
            {
                var attachment_YanZhiBaoGao = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(YanZhiBaoGao);
                attachmentList.AddRange(attachment_YanZhiBaoGao);
            }
            string FaRen = Request.Form["hid_attachment_10"];
            if (string.IsNullOrEmpty(FaRen) == false)
            {
                var attachment_FaRen = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(FaRen);
                attachmentList.AddRange(attachment_FaRen);
            }
            string FaDingDaiBiaoRen = Request.Form["hid_attachment_11"];
            if (string.IsNullOrEmpty(FaDingDaiBiaoRen) == false)
            {
                var attachment_FaDingDaiBiaoRen = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(FaDingDaiBiaoRen);
                attachmentList.AddRange(attachment_FaDingDaiBiaoRen);
            }
            string GuDong = Request.Form["hid_attachment_12"];
            if (string.IsNullOrEmpty(GuDong) == false)
            {
                var attachment_GuDong = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(GuDong);
                attachmentList.AddRange(attachment_GuDong);
            }
            string FaRenGuDongZhengXinBaoGao = Request.Form["hid_attachment_13"];
            if (string.IsNullOrEmpty(FaRenGuDongZhengXinBaoGao) == false)
            {
                var attachment_FaRenGuDongZhengXinBaoGao = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(FaRenGuDongZhengXinBaoGao);
                attachmentList.AddRange(attachment_FaRenGuDongZhengXinBaoGao);
            }
            string GuDongGouCheng = Request.Form["hid_attachment_14"];
            if (string.IsNullOrEmpty(GuDongGouCheng) == false)
            {
                var attachment_GuDongGouCheng = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(GuDongGouCheng);
                attachmentList.AddRange(attachment_GuDongGouCheng);
            }
            string ZuZhiJieGou = Request.Form["hid_attachment_15"];
            if (string.IsNullOrEmpty(ZuZhiJieGou) == false)
            {
                var attachment_ZuZhiJieGou = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(ZuZhiJieGou);
                attachmentList.AddRange(attachment_ZuZhiJieGou);
            }
            string GuanLianQiYe = Request.Form["hid_attachment_16"];
            if (string.IsNullOrEmpty(GuanLianQiYe) == false)
            {
                var attachment_GuanLianQiYe = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(GuanLianQiYe);
                attachmentList.AddRange(attachment_GuanLianQiYe);
            }
            string JieDaiXinXi = Request.Form["hid_attachment_17"];
            if (string.IsNullOrEmpty(JieDaiXinXi) == false)
            {
                var attachment_JieDaiXinXi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(JieDaiXinXi);
                attachmentList.AddRange(attachment_JieDaiXinXi);
            }
            string SanNianShenJiBaoGao = Request.Form["hid_attachment_18"];
            if (string.IsNullOrEmpty(SanNianShenJiBaoGao) == false)
            {
                var attachment_SanNianShenJiBaoGao = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(SanNianShenJiBaoGao);
                attachmentList.AddRange(attachment_SanNianShenJiBaoGao);
            }
            string LiuYueCaiWuBaoBiao = Request.Form["hid_attachment_19"];
            if (string.IsNullOrEmpty(LiuYueCaiWuBaoBiao) == false)
            {
                var attachment_LiuYueCaiWuBaoBiao = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(LiuYueCaiWuBaoBiao);
                attachmentList.AddRange(attachment_LiuYueCaiWuBaoBiao);
            }
            string ZengZhiShuiYingYeShui = Request.Form["hid_attachment_20"];
            if (string.IsNullOrEmpty(ZengZhiShuiYingYeShui) == false)
            {
                var attachment_ZengZhiShuiYingYeShui = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(ZengZhiShuiYingYeShui);
                attachmentList.AddRange(attachment_ZengZhiShuiYingYeShui);
            }
            string DiYaWu = Request.Form["hid_attachment_21"];
            if (string.IsNullOrEmpty(DiYaWu) == false)
            {
                var attachment_DiYaWu = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(DiYaWu);
                attachmentList.AddRange(attachment_DiYaWu);
            }
            string KeXingXingBaoGao = Request.Form["hid_attachment_22"];
            if (string.IsNullOrEmpty(KeXingXingBaoGao) == false)
            {
                var attachment_KeXingXingBaoGao = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(KeXingXingBaoGao);
                attachmentList.AddRange(attachment_KeXingXingBaoGao);
            }


            string XiangMuXiangGuanPiWen = Request.Form["hid_attachment_23"];
            if (string.IsNullOrEmpty(XiangMuXiangGuanPiWen) == false)
            {
                var attachment_XiangMuXiangGuanPiWen = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(XiangMuXiangGuanPiWen);
                attachmentList.AddRange(attachment_XiangMuXiangGuanPiWen);
            }
            string WuZheng = Request.Form["hid_attachment_24"];
            if (string.IsNullOrEmpty(WuZheng) == false)
            {
                var attachment_WuZheng = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(WuZheng);
                attachmentList.AddRange(attachment_WuZheng);
            }
            string ShiGongHeTong = Request.Form["hid_attachment_25"];
            if (string.IsNullOrEmpty(ShiGongHeTong) == false)
            {
                var attachment_ShiGongHeTong = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(ShiGongHeTong);
                attachmentList.AddRange(attachment_ShiGongHeTong);
            }
            string XiaoShouMingXi = Request.Form["hid_attachment_26"];
            if (string.IsNullOrEmpty(XiaoShouMingXi) == false)
            {
                var attachment_XiaoShouMingXi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(XiaoShouMingXi);
                attachmentList.AddRange(attachment_XiaoShouMingXi);
            }


            string QiShui = Request.Form["hid_attachment_27"];
            if (string.IsNullOrEmpty(QiShui) == false)
            {
                var attachment_QiShui = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(QiShui);
                attachmentList.AddRange(attachment_QiShui);
            }
            string GuoWangJingYan = Request.Form["hid_attachment_28"];
            if (string.IsNullOrEmpty(GuoWangJingYan) == false)
            {
                var attachment_GuoWangJingYan = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(GuoWangJingYan);
                attachmentList.AddRange(attachment_GuoWangJingYan);
            }
            string FangGuanJuDangAnChaXun = Request.Form["hid_attachment_29"];
            if (string.IsNullOrEmpty(FangGuanJuDangAnChaXun) == false)
            {
                var attachment_FangGuanJuDangAnChaXun = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(FangGuanJuDangAnChaXun);
                attachmentList.AddRange(attachment_FangGuanJuDangAnChaXun);
            }

            string ZiChanQingDan = Request.Form["hid_attachment_30"];
            if (string.IsNullOrEmpty(ZiChanQingDan) == false)
            {
                var attachment_ZiChanQingDan = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(ZiChanQingDan);
                attachmentList.AddRange(attachment_ZiChanQingDan);
            }

            string JianSheYongDi = Request.Form["hid_attachment_31"];
            if (string.IsNullOrEmpty(JianSheYongDi) == false)
            {
                var attachment_JianSheYongDi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(JianSheYongDi);
                attachmentList.AddRange(attachment_JianSheYongDi);
            }
            string JianSheGongChengGuiHua = Request.Form["hid_attachment_32"];
            if (string.IsNullOrEmpty(JianSheGongChengGuiHua) == false)
            {
                var attachment_JianSheGongChengGuiHua = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(JianSheGongChengGuiHua);
                attachmentList.AddRange(attachment_JianSheGongChengGuiHua);
            }
            string JianSheGongChengShiGong = Request.Form["hid_attachment_33"];
            if (string.IsNullOrEmpty(JianSheGongChengShiGong) == false)
            {
                var attachment_JianSheGongChengShiGong = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(JianSheGongChengShiGong);
                attachmentList.AddRange(attachment_JianSheGongChengShiGong);
            }
            string ShangPinFangYuShou = Request.Form["hid_attachment_34"];
            if (string.IsNullOrEmpty(ShangPinFangYuShou) == false)
            {
                var attachment_ShangPinFangYuShou = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(ShangPinFangYuShou);
                attachmentList.AddRange(attachment_ShangPinFangYuShou);
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
            if (company.Phone.Equals("0"))
            {
                company.Phone = "";
            }
            CompanyReferenceModel crmodel = new CompanyReferenceModel();
            var crlist = crmodel.GetInfo_byCID(company.ID);
            ViewBag.CRList = crlist;
            return View(company);
        }

        #endregion

        #region 贷款信息

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

            return View();
        }

        [HttpPost]
        public ActionResult AddFinancing(Financing financing, int page)
        {
            FinancingModel fm = new FinancingModel();

            string RongZiXinXiFuJian = Request.Form["hid_attachment_1"];
            List<Attachment> attachments = new List<Attachment>();
            if (string.IsNullOrEmpty(RongZiXinXiFuJian) == false)
            {
                attachments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(RongZiXinXiFuJian);
            }
            string DiYaWuQingDan = Request.Form["hid_attachment_2"];
            if (string.IsNullOrEmpty(DiYaWuQingDan) == false)
            {
                attachments.AddRange(Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(DiYaWuQingDan));
            }
            string HuanKuanLaiYuan = Request.Form["hid_attachment_3"];
            if (string.IsNullOrEmpty(HuanKuanLaiYuan) == false)
            {
                attachments.AddRange(Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(HuanKuanLaiYuan));
            }
            string XiangMuXianChangHeCha = Request.Form["hid_attachment_4"];
            if (string.IsNullOrEmpty(XiangMuXianChangHeCha) == false)
            {
                attachments.AddRange(Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(XiangMuXianChangHeCha));
            }
            //financing.Owner_A_ID = LoginAccount.UserID;
            //if (financing.Owner_B_ID.HasValue && financing.Owner_B_ID.Value == 0)
            //{
            //    financing.Owner_B_ID = null;
            //}
            financing.BusinessType = 0;//业务类型，未确定
            Result result = fm.Add(financing, attachments);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Financing", "Company", new { companyID = financing.CompanyID, page = page }) + "'");
        }

        public ActionResult EditFinancing(int id, int companyID, int page, int fromID)
        {
            FinancingModel fm = new FinancingModel();
            var financing = fm.Get(id);
            (financing.CompanyID == companyID).NotAuthorizedPage();
            ViewBag.Page = page;
            ViewBag.fromID = fromID;
            //GroupAccountModel gam = new GroupAccountModel();
            //var gaList = gam.GetListWithoutAdmin();
            //List<SelectListItem> newGAList = new List<SelectListItem>();
            //var ga_list = new SelectList(gaList, "ID", "Name");
            //newGAList.Add(new SelectListItem { Text = "请选择B角", Value = "0", Selected = true });
            //newGAList.AddRange(ga_list);
            //ViewData["gaList"] = newGAList;

            return View(financing);
        }

        [HttpPost]
        public ActionResult EditFinancing(Financing financing, int page, int fromID)
        {
            Result result = null;
            FinancingModel fm = new FinancingModel();
            string RongZiXinXiFuJian = Request.Form["hid_attachment_1"];
            List<Attachment> attachments = new List<Attachment>();
            if (string.IsNullOrEmpty(RongZiXinXiFuJian) == false)
            {
                attachments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(RongZiXinXiFuJian);
            }
            string DiYaWuQingDan = Request.Form["hid_attachment_2"];
            if (string.IsNullOrEmpty(DiYaWuQingDan) == false)
            {
                attachments.AddRange(Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(DiYaWuQingDan));
            }
            string HuanKuanLaiYuan = Request.Form["hid_attachment_3"];
            if (string.IsNullOrEmpty(HuanKuanLaiYuan) == false)
            {
                attachments.AddRange(Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(HuanKuanLaiYuan));
            }
            string XiangMuXianChangHeCha = Request.Form["hid_attachment_4"];
            if (string.IsNullOrEmpty(XiangMuXianChangHeCha) == false)
            {
                attachments.AddRange(Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(XiangMuXianChangHeCha));
            }
            //if (financing.Owner_B_ID.HasValue && financing.Owner_B_ID.Value == 0)
            //{
            //    financing.Owner_B_ID = null;
            //}
            if (financing.BusinessType == 1)
            {
                financing.WorkFlowManagerID = 4;
            }
            result = fm.Edit(financing, attachments);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            if (fromID == 1)
            {
                return JavaScript("window.location.href='" + Url.Action("Financing", "Company", new { companyID = financing.CompanyID, page = page }) + "'");
            }
            else
            {
                return JavaScript("window.location.href='" + Url.Action("Index", "Financing", new { id = page }) + "'");
            }
        }

        public string DeleteFinancing(int id, int companyID, int page, int fromID)
        {
            FinancingModel fm = new FinancingModel();
            var result = fm.Delete_Check(id, LoginAccount.UserID);
            if (result.HasError)
            {
                return "<script>JMessage('" + result.Error + "',true)</script>";
            }
            if (fromID == 1)
            {
                return "<script>window.location.href='" + Url.Action("Financing", "Company", new { companyID = companyID, page = page }) + "';</script>";
            }
            else
            {
                return "<script>window.location.href='" + Url.Action("Index", "Financing", new { id = page }) + "';</script>";
            }
        }

        #endregion

        #region 客户信息用户控件

        /// <summary>
        /// 借贷信息列表
        /// </summary>
        /// <param name="Cid">公司ID</param>
        /// <returns></returns>
        public ActionResult JGJDXXList(int Cid)
        {
            //查找借贷信息
            CompanyReferenceModel crmodel = new CompanyReferenceModel();
            var crlist = crmodel.GetInfo_byCID(Cid);
            return View(crlist);
        }

        /// <summary>
        /// 机构借贷信息控件
        /// </summary>
        /// <param name="Types">0 新增 1修改</param>
        /// <returns></returns>
        public ActionResult JGJDXX(int Types, int CompanyID, int? referenceID)
        {
            CompanyReferenceModel crmodel = new CompanyReferenceModel();
            CompanyReference crf = new CompanyReference();
            if (Types == 1)
            {
                crf = crmodel.Get(referenceID.Value);
            }
            ViewBag.CompanyID = CompanyID;
            return View(crf);
        }

        /// <summary>
        /// 机构借贷信息控件
        /// </summary>
        /// <param name="Types">0 新增 1修改</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddJGJDXX(CompanyReference companyreference)
        {
            CompanyReferenceModel crmodel = new CompanyReferenceModel();
            //修改
            if (companyreference.ID > 0)
            {
                crmodel.Edit(companyreference);
            }
            else
            {
                crmodel.Add(companyreference);
            }
            AttachmentModel amodel = new AttachmentModel();
            List<Attachment> attachmentList = new List<Attachment>();
            string fj = Request.Form["hid_attachment_JGJDXX"];
            if (string.IsNullOrEmpty(fj) == false)
            {
                var fjjson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(fj);
                foreach (var item in fjjson)
                {
                    item.TableID = companyreference.ID;
                    amodel.Add(item);
                }

                //attachmentList.AddRange(fjjson);
            }
            var jsonreference = Newtonsoft.Json.JsonConvert.SerializeObject(companyreference);
            return JavaScript("AddJGJDXX(" + jsonreference + ")");
            //return RedirectToAction("JGJDXXList","Company", new { Cid = companyreference.CompanyID});

        }
        /// <summary>
        /// 刷新机构贷款列表
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public ActionResult ReadJGJDXX(int CID)
        {
            return RedirectToAction("JGJDXXList", "Company", new { Cid = CID });
        }
        /// <summary>
        /// 删除借贷信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteJGJDXX(int id, int CID)
        {
            CompanyReferenceModel crmodel = new CompanyReferenceModel();
            var result = crmodel.Delete(id);
            AttachmentModel amodel = new AttachmentModel();
            amodel.DelInfo("CompanyReference", id);
            if (result.HasError)
            {
                return "<script>JMessage('" + result.Error + "',true)</script>";
            }

            return "<script>JMessage('删除成功',false);$('#JGJDtr_" + id + "').hide();</script>";
        }
        #endregion
    }
}
