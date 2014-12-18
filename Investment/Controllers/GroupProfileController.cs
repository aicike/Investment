using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Investment.Controllers;
using Entity;
using System.IO;

namespace Investment.Controllers
{
    public class GroupProfileController : BaseController
    {
        //
        // GET: /GroupProfile/

        /// <summary>
        /// 平台个人信息修改
        /// </summary>
        /// <param name="imgIsOk">1 修改头像成功,2移除成功</param>
        /// <returns></returns>
        public ActionResult ProFile(int? imgIsOk)
        {
            GroupAccountModel GAModel = new GroupAccountModel();
            var item = GAModel.Get(LoginAccount.UserID);
            ViewBag.imgIsOk = 0;
            if (imgIsOk.HasValue)
            {
                ViewBag.imgIsOk = imgIsOk;
            }
            return View(item);
        }
        /// <summary>
        /// 修改个人信息(平台)
        /// </summary>
        /// <returns></returns>
        public ActionResult UPProFile(GroupAccount groupAccount)
        {
            GroupAccountModel GAModel = new GroupAccountModel();
            var result = GAModel.Edit(groupAccount);
            if (result.HasError)
            {
                return JavaScript("JMessage('保存失败，稍后再试！',true)");
            }
            else
            {
                return JavaScript("JMessage('保存成功！',false)");
            }

        }
        /// <summary>
        /// 修改个人密码(平台)
        /// </summary>
        /// <returns></returns>
        public ActionResult UPPwd(string LsPWD, string newPwd)
        {
            GroupAccountModel GAModel = new GroupAccountModel();
            var istrue = GAModel.GetPwdIsRight(LoginAccount.ID, DESEncrypt.Encrypt(LsPWD));
            if (!istrue)
            {
                return JavaScript("JMessage('原始密码错误！',true)");
            }
            var result = GAModel.Up_Pwd(LoginAccount.ID, DESEncrypt.Encrypt(newPwd));
            if (result.HasError)
            {
                return JavaScript("JMessage('密码修改失败，稍后再试！',true)");
            }
            else
            {
                return JavaScript("JMessage('密码修改成功！',false)");
            }

        }

        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="ImageURL">头像地址</param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="tw"></param>
        /// <param name="th"></param>
        /// <returns></returns>
        public ActionResult UpImage(string ImgPath, int w, int h, int x1, int y1, int tw, int th)
        {
            GroupAccountModel GAModel = new GroupAccountModel();
            var result = GAModel.Up_Image(Server.MapPath(ImgPath), LoginAccount.UserID, w, h, x1, y1, tw, th);
            if (result.HasError)
            {
                return JavaScript("JMessage('上传失败,请重试！',true)");
            }
            System.IO.File.Delete(Server.MapPath(ImgPath));
            LoginAccount.HeadImg = result.Entity.ToString();
            return JavaScript("window.location.href='" + Url.Action("ProFile", "GroupProfile", new { imgIsOk = 1 }) + "'");
        }

        /// <summary>
        /// 移除头像
        /// </summary>
        /// <returns></returns>
        public ActionResult DelImage()
        {
            GroupAccountModel GAModel = new GroupAccountModel();
            var result = GAModel.Del_Image(LoginAccount.UserID);
            if (result.HasError)
            {
                return JavaScript("JMessage('上传失败,请重试！',true)");
            }
            LoginAccount.HeadImg = "";
            return JavaScript("window.location.href='" + Url.Action("ProFile", "GroupProfile", new { imgIsOk = 2 }) + "'");
        }

    }
}
