using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business;

namespace Investment.Controllers
{
    public class PositionController : BaseController
    {
        //
        // GET: /Position/
        /// <summary>
        /// 职位管理 列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            PositionModel PModel = new PositionModel();
            var list = PModel.List().ToList();
            return View(list);
        }

        /// <summary>
        /// 添加界面
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
        public ActionResult Add(Position position)
        {
            PositionModel PModel = new PositionModel();
            var result = PModel.Add(position);
            return JavaScript("window.location.href='" + Url.Action("Index", "Position") + "'");
        }

        /// <summary>
        /// 更改界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int ID)
        {
            PositionModel PModel = new PositionModel();
            var item = PModel.Get(ID);
            return View(item);
        }

        /// <summary>
        /// 更改功能
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Position position)
        {
            PositionModel PModel = new PositionModel();
            var result = PModel.Edit(position);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            else
            {
                return JavaScript("JMessage('修改成功',false)");
            }

        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int ID)
        {
            PositionModel PModel = new PositionModel();
            var result = PModel.Delete(ID);
            if(result.HasError)
            {
                return JavaScript("JMessage('删除失败',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Index", "Position") + "'");
        }
    }
}
