﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Commons;
using System.IO;
using System.Drawing;
using Investment.Controllers;
using Entity;
using Entity.Enum;

namespace Investment.Controllers
{
    public class AjaxController : BaseController, IController
    {
        /// <summary>
        /// 上传图片通用方法
        /// </summary>
        [HttpPost]
        public string UploadImage()
        {
            if (Request.Files.Count > 0)
            {
                //获取临时文件夹
                var Paths = ToolImage.GetTemporaryPath();
                Common con = new Common();
                var token = DateTime.Now.ToString("yyyyMMddHHmmss");
                var LastName = token + con.CreateRandom("", 5) + Request.Files[0].FileName.GetFileSuffix();
                //图片显示界面
                var ImagePath = Paths[0] + "/" + LastName; //网页路径
                var mapePath = Paths[1] + "/" + LastName;  //物理路径
                int dataLengthToRead = (int)Request.Files[0].InputStream.Length;//获取下载的文件总大小
                byte[] buffer = new byte[dataLengthToRead];

                int r = Request.Files[0].InputStream.Read(buffer, 0, dataLengthToRead);//本次实际读取到字节的个数
                Stream tream = new MemoryStream(buffer);
                Image img = Image.FromStream(tream);

                ToolImage.SuperGetPicThumbnail(img, mapePath, 70, 1280, 0, System.Drawing.Drawing2D.SmoothingMode.HighQuality, System.Drawing.Drawing2D.CompositingQuality.HighQuality, System.Drawing.Drawing2D.InterpolationMode.High);

                Attachment attachment = new Attachment();
                attachment.FileName_Number = LastName;
                attachment.FileName = Request.Files[0].FileName;
                attachment.FilePath = mapePath;
                attachment.FileUrl = ImagePath;
                return Newtonsoft.Json.JsonConvert.SerializeObject(attachment);
            }
            else
            {
                return "false";
            }
        }


        /// <summary>
        /// 多文件上传附件通用方法
        /// </summary>
        [HttpPost]
        public string UploadAttachment(int enumAttachmentType, string table, int tableID)
        {
            if (Request.Files.Count > 0)
            {
                //获取临时文件夹
                var Paths = ToolImage.GetTemporaryPath();
                Common con = new Common();
                var token = DateTime.Now.ToString("yyyyMMddHHmmss");
                string suffix = Request.Files[0].FileName.GetFileSuffix();
                var LastName = token + con.CreateRandom("", 5) + suffix;
                //图片显示界面
                var ImagePath = Paths[0] + "/" + LastName; //网页路径
                var mapePath = Paths[1] + "/" + LastName;  //物理路径
                Request.Files[0].SaveAs(mapePath);
                Attachment attachment = new Attachment();
                attachment.FileName_Number = LastName;
                attachment.FileName = Request.Files[0].FileName;
                attachment.FilePath = mapePath;
                attachment.FileUrl = ImagePath;
                attachment.EnumAttachmentType = enumAttachmentType;
                attachment.EnumAttachmentFormat = (int)GetAttachmentFormat(suffix);
                attachment.TableName = table;
                attachment.TableID = tableID;
                return Newtonsoft.Json.JsonConvert.SerializeObject(attachment);
            }
            else
            {
                return "false";
            }
        }

        /// <summary>
        /// 单文件上传附件通用方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string UploadAttachment_Single(int enumAttachmentType, string table, int tableID)
        {
            if (Request.Files.Count > 0)
            {
                //获取临时文件夹
                var Paths = ToolImage.GetTemporaryPath();
                Common con = new Common();
                var token = DateTime.Now.ToString("yyyyMMddHHmmss");
                string suffix = Request.Files[0].FileName.GetFileSuffix();
                var LastName = token + con.CreateRandom("", 5) + suffix;
                //图片显示界面
                var ImagePath = Paths[0] + "/" + LastName; //网页路径
                var mapePath = Paths[1] + "/" + LastName;  //物理路径
                Request.Files[0].SaveAs(mapePath);
                Attachment attachment = new Attachment();
                attachment.FileName_Number = LastName;
                attachment.FileName = Request.Files[0].FileName;
                attachment.FilePath = mapePath;
                attachment.FileUrl = ImagePath;
                attachment.EnumAttachmentType = enumAttachmentType; 
                attachment.EnumAttachmentFormat = (int)GetAttachmentFormat(suffix);
                attachment.TableName = table;
                attachment.TableID = tableID;
                return Newtonsoft.Json.JsonConvert.SerializeObject(new { jsonrpc = "2.0", result = attachment });
            }
            else
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(new { jsonrpc = "2.0", error = "{'code': 103, 'message': '文件上传失败。'}" });
            }
        }

        private EnumAttachmentFormat GetAttachmentFormat(string format)
        {
            EnumAttachmentFormat f = EnumAttachmentFormat.Other;
            switch (format)
            {
                case ".jpg":
                case ".jpge":
                case ".gif":
                case ".png":
                case ".bmp":
                    f = EnumAttachmentFormat.Image;
                    break;
                case ".doc":
                case ".docx":
                case ".xls":
                case ".xlsx":
                case ".ppt":
                case ".pptx":
                    f = EnumAttachmentFormat.Office;
                    break;
            }
            return f;
        }


        //
        // GET: /Ajax/
        /// <summary>
        /// 上传头像（公司）
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //public string UpHeadPortrait_Company()
        //{
        //    if (Request.Files.Count > 0)
        //    {
        //        //获取临时文件夹
        //        string Path = ToolImage.GetTemporaryPath();
        //        Common con = new Common();
        //        var token = DateTime.Now.ToString("yyyyMMddHHmmss");
        //        var LastName = token + con.CreateRandom("", 5) + Request.Files[0].FileName.GetFileSuffix();
        //        //图片显示界面
        //        var ImagePath = Path + "\\" + LastName;
        //        var mapePath = Server.MapPath(Path) + "\\" + LastName;
        //        int dataLengthToRead = (int)Request.Files[0].InputStream.Length;//获取下载的文件总大小
        //        byte[] buffer = new byte[dataLengthToRead];

        //        int r = Request.Files[0].InputStream.Read(buffer, 0, dataLengthToRead);//本次实际读取到字节的个数
        //        Stream tream = new MemoryStream(buffer);
        //        Image img = Image.FromStream(tream);

        //        ToolImage.SuperGetPicThumbnail(img, mapePath, 70, 1280, 0, System.Drawing.Drawing2D.SmoothingMode.HighQuality, System.Drawing.Drawing2D.CompositingQuality.HighQuality, System.Drawing.Drawing2D.InterpolationMode.High);


        //        return Url.Content(ImagePath);

        //    }
        //    else
        //    {
        //        return "false";
        //    }

        //}

    }
}
