using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace Investment.Controllers
{
    public class MechanismController : BaseController
    {
        //
        // GET: /Mechanism/
        /// <summary>
        /// 机构首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            MechanismModel MModel = new MechanismModel();
            var list = MModel.List().ToList();
            return View(list);
        }

        /// <summary>
        /// 添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {

            return View();
        }

        /// <summary>
        /// 添加功能
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(Mechanism mechanism)
        {
            MechanismModel MModel = new MechanismModel();
            MModel.Add(mechanism);
            return JavaScript("window.location.href='" + Url.Action("Index", "Mechanism") + "'");
        }

        /// <summary>
        /// 修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int ID)
        {
            MechanismModel MModel = new MechanismModel();
            var item = MModel.Get(ID);
            return View(item);
        }

        /// <summary>
        /// 修改功能
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Mechanism mechanism)
        {
            MechanismModel MModel = new MechanismModel();
            var result = MModel.Edit(mechanism);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Index", "Mechanism") + "'");
        }
    }
}
