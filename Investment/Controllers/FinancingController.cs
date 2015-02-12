using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Investment.Controllers
{
    public class FinancingController : BaseController
    {
        /// <summary>
        /// 只能查看自己所有权的贷款信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public ActionResult Index(int? id,string Name)
        {
            FinancingModel fm = new FinancingModel();

            var objs = fm.List().Where(a => a.Company.OwnerID == LoginAccount.UserID);

            if (!string.IsNullOrEmpty(Name))
            {
                objs = objs.Where(a => a.Name.Contains(Name));
            }
            var list = objs.ToPagedList(id ?? 1, 15);
            ViewBag.LoginUesrID = LoginAccount.UserID;
            return View(list);
        }


        /// <summary>
        /// 查看所有的贷款信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public ActionResult IndexAll(int? id, string Name)
        {
            FinancingModel fm = new FinancingModel();

            var objs = fm.List();

            if (!string.IsNullOrEmpty(Name))
            {
                objs = objs.Where(a => a.Name.Contains(Name));
            }
            var list = objs.ToPagedList(id ?? 1, 15);
            return View(list);
        }

        public ActionResult Detail(int id)
        {
            FinancingModel fm = new FinancingModel();
            //todo:此处需要判断是否有权限
            var obj = fm.Get(id);
            return View(obj);
        }

    }
}
