using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace Investment.Controllers
{
    /// <summary>
    /// 机构产品信息
    /// </summary>
    public class MechanismProductsController : BaseController
    {
        //
        // GET: /MechanismProducts/
        /// <summary>
        /// 机构产品列表
        /// </summary>
        /// <param name="GAID">机构ID</param>
        /// <returns></returns>
        public ActionResult Index(int MID)
        {
            MechanismProductsModel mpModel = new MechanismProductsModel();
            var list = mpModel.GetList_ByMID(MID);
            //产讯机构信息
            MechanismModel MModel = new MechanismModel();
            var item = MModel.Get(MID);
            ViewBag.MName = item.Name;
            ViewBag.MID = MID;
            return View(list);
        }

        /// <summary>
        /// 添加页面
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public ActionResult Add(int MID)
        {
            //产讯机构信息
            MechanismModel MModel = new MechanismModel();
            var item = MModel.Get(MID);
            ViewBag.MName = item.Name;
            ViewBag.MID = MID;
            return View();
        }

        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="mechanismProducts"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(MechanismProducts mechanismProducts)
        {
            MechanismProductsModel mpModel = new MechanismProductsModel();
            var result = mpModel.Add(mechanismProducts);
            if (result.HasError)
            {
                return JavaScript("JMessage('添加失败 请稍后再试',true)");

            }
            return JavaScript("window.location.href='" + Url.Action("Index", "MechanismProducts", new { MID = mechanismProducts.MechanismID }) + "'");
        }


        /// <summary>
        /// 修改页面
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public ActionResult Edit(int MID, int MPID)
        {
            //产品机构信息
            MechanismModel MModel = new MechanismModel();
            var item = MModel.Get(MID);
            ViewBag.MName = item.Name;
            ViewBag.MID = MID;
            //产品信息
            MechanismProductsModel mpModel = new MechanismProductsModel();
            var mpitem = mpModel.Get(MPID);
            return View(mpitem);
        }

        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="mechanismProducts"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(MechanismProducts mechanismProducts)
        {
            MechanismProductsModel mpModel = new MechanismProductsModel();
            var result = mpModel.Edit(mechanismProducts);
            if (result.HasError)
            {
                return JavaScript("JMessage('修改失败 请稍后再试',true)");

            }
            return JavaScript("window.location.href='" + Url.Action("Index", "MechanismProducts", new { MID = mechanismProducts.MechanismID }) + "'");
        }

        /// <summary>
        /// 所有机构产品列表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public ActionResult SelAll(int? id, string Name)
        {
            MechanismProductsModel mpModel = new MechanismProductsModel();

            var mplist = mpModel.List();
            if (!string.IsNullOrEmpty(Name))
            {
                if (Name.Trim().Length > 0)
                {
                    mplist = mplist.Where(a => a.Name.Contains(Name));
                    ViewBag.Name = Name;
                }
            }
            var pagelist = mplist.ToPagedList(id ?? 1, 15);
            int index = (id ?? 1) - 1;
            ViewBag.Index = 15 * index;

            return View(pagelist);
        }

        /// <summary>
        /// 查看详细界面
        /// </summary>
        /// <param name="MPID">公司产品信息</param>
        /// <returns></returns>
        public ActionResult GetInfo(int MPID)
        {
            //获取详细
            MechanismProductsModel mpModel = new MechanismProductsModel();
            var item = mpModel.Get(MPID);
            //获取机构
            MechanismModel mModel = new MechanismModel();
            ViewBag.Mechanis = mModel.Get(item.MechanismID.Value);
            return View(item);
        }
    }
}
