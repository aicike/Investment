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
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            ViewBag.HasGuanLian = true;
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

        //新增关联公司
        public ActionResult Add_GuanLian()
        {
            Company company = new Company();
            ViewBag.Layout = "~/Views/Shared/_Layout_noMenu.cshtml";
            ViewBag.HasGuanLian = false;
            return View("Add", company);
        }

        [HttpPost]
        public ActionResult Add_GuanLian(Company company)
        {
            CompanyModel companyModel = new CompanyModel();
            company.OwnerID = LoginAccount.UserID;
            company.Status = 1;
            List<Attachment> attachments = GetAttachment_Edit();
            Result result = companyModel.Add(company, attachments);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            var com = result.Entity as Company;
            return JavaScript("window.location.href='" + Url.Action("Edit", "Company", new { id = com.ID }) + "'");
        }

        public ActionResult Edit(int id)
        {
            CompanyModel companyModel = new CompanyModel();
            var company = companyModel.Get(id);
            if (company.Phone.Equals("0"))
            {
                company.Phone = "";
            }
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            ViewBag.HasGuanLian = true;
            ViewBag.CompanyID = company.ID;
            //查找借贷信息
            CompanyReferenceModel crmodel = new CompanyReferenceModel();
            var crlist = crmodel.GetInfo_byCID(company.ID);
            ViewBag.CRList = crlist;
            return View(company);
        }

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
            CompanyReferenceModel crmodel = new CompanyReferenceModel();
            var crlist = crmodel.GetInfo_byCID(company.ID);
            ViewBag.CRList = crlist;
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

            GroupAccountModel gam = new GroupAccountModel();
            var gaList = gam.GetListWithoutAdmin();
            List<SelectListItem> newGAList = new List<SelectListItem>();
            var ga_list = new SelectList(gaList, "ID", "Name");
            newGAList.Add(new SelectListItem { Text = "请选择B角", Value = "0", Selected = true });
            newGAList.AddRange(ga_list);
            ViewData["gaList"] = newGAList;

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
            if (financing.Owner_B_ID.HasValue && financing.Owner_B_ID.Value == 0)
            {
                financing.Owner_B_ID = null;
            }
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


            WorkFlowManagerModel wfmm = new WorkFlowManagerModel();
            var wfms = wfmm.List().OrderBy(a => a.ID).ToList();
            List<SelectListItem> newList = new List<SelectListItem>();
            var wfm_list = new SelectList(wfms, "ID", "Name");
            newList.Add(new SelectListItem { Text = "请选择项目类型", Value = "select", Selected = true });
            newList.AddRange(wfm_list);
            ViewData["wfm"] = newList;


            GroupAccountModel gam = new GroupAccountModel();
            var gaList = gam.GetListWithoutAdmin();
            List<SelectListItem> newGAList = new List<SelectListItem>();
            var ga_list = new SelectList(gaList, "ID", "Name");
            newGAList.Add(new SelectListItem { Text = "请选择B角", Value = "0", Selected = true });
            newGAList.AddRange(ga_list);
            ViewData["gaList"] = newGAList;

            return View(financing);
        }

        [HttpPost]
        public ActionResult EditFinancing(Financing financing, int page, int fromID)
        {
            Result result = null;
            FinancingModel fm = new FinancingModel();
            string RongZiXinXiFuJian = Request.Form["hid_attachment_1"];
            List<Attachment> attachments = null;
            if (string.IsNullOrEmpty(RongZiXinXiFuJian) == false)
            {
                attachments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attachment>>(RongZiXinXiFuJian);
            }
            if (financing.Owner_B_ID.HasValue && financing.Owner_B_ID.Value == 0)
            {
                financing.Owner_B_ID = null;
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
        /// 机构借贷信息控件
        /// </summary>
        /// <param name="Types">0 新增 1修改</param>
        /// <returns></returns>
        public ActionResult JGJDXX(int Types,int CompanyID, int? referenceID)
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
            else {
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
            return JavaScript("AddJGJDXX("+jsonreference+")");
            //return JavaScript(" window.location.href='" + Url.Action("Edit", "Company", new { id = companyreference.CompanyID}) + "';");
           
        }
        /// <summary>
        /// 删除借贷信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteJGJDXX(int id,int CID)
        {
            CompanyReferenceModel crmodel = new CompanyReferenceModel();
            var result = crmodel.Delete(id);
            AttachmentModel amodel = new AttachmentModel();
            amodel.DelInfo("CompanyReference",id);
            if (result.HasError)
            {
                return "<script>JMessage('" + result.Error + "',true)</script>";
            }

            return "<script>JMessage('删除成功',false);$('#JGJDtr_" + id + "').hide();</script>";
        }
        #endregion
    }
}
