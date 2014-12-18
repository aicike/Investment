using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Commons;
using System.IO;
using System.Drawing;
using Budget.Controllers;

namespace Investment.Controllers
{
    public class AjaxController : BaseController, IController
    {
        //
        // GET: /Ajax/
        /// <summary>
        /// 上传头像（公司）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string UpHeadPortrait_Company()
        {
            if (Request.Files.Count > 0)
            {
                //获取临时文件夹
                string Path = ToolImage.GetTemporaryPath();
                Common con = new Common();
                var token = DateTime.Now.ToString("yyyyMMddHHmmss");
                var LastName = token + con.CreateRandom("", 5) + Request.Files[0].FileName.GetFileSuffix();
                //图片显示界面
                var ImagePath = Path + "\\" + LastName;
                var mapePath = Server.MapPath(Path) + "\\" + LastName;
                int dataLengthToRead = (int)Request.Files[0].InputStream.Length;//获取下载的文件总大小
                byte[] buffer = new byte[dataLengthToRead];

                int r = Request.Files[0].InputStream.Read(buffer, 0, dataLengthToRead);//本次实际读取到字节的个数
                Stream tream = new MemoryStream(buffer);
                Image img = Image.FromStream(tream);

                ToolImage.SuperGetPicThumbnail(img, mapePath, 70, 1280, 0, System.Drawing.Drawing2D.SmoothingMode.HighQuality, System.Drawing.Drawing2D.CompositingQuality.HighQuality, System.Drawing.Drawing2D.InterpolationMode.High);


                return Url.Content(ImagePath);

            }
            else
            {
                return "false";
            }

        }

    }
}
