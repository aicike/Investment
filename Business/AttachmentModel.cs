﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.IO;
using Entity.Enum;

namespace Business
{
    public class AttachmentModel : BaseModel<Attachment>
    {
        /// <summary>
        /// 复制临时文件到正式文件夹中
        /// 目录关系为：主目录下包含
        /// -------Company(公司文件目录)
        ///        -------Approval（审批文件目录）
        /// -------Organization(机构文件目录)
        /// </summary>
        /// <param name="companyID">公司ID</param>
        /// <param name="attachment">附件对象</param>
        /// <returns></returns>
        public Result CopyAttachment_Company(int companyID, Attachment attachment)
        {
            Result result = new Result();
            try
            {
                //判断是否有Company目录是否存在
                string directory_Logic = SystemConst.AttachmentPath.Substring(SystemConst.AttachmentPath.LastIndexOf('/') + 1) + "/" + "Company" + "/" + companyID;
                string directory_Physics = SystemConst.AttachmentPath + "/" + "Company" + "/" + companyID;
                if (Directory.Exists(directory_Physics) == false)
                {
                    Directory.CreateDirectory(directory_Physics);
                }
                string path_Logic = directory_Logic + "/" + attachment.FileName_Number;//正式文件逻辑路径
                string path_Physics = directory_Physics + "/" + attachment.FileName_Number;//正式文件物理路径
                File.Copy(attachment.FilePath, path_Physics, true);
                //文件保存成功后，存储Attachment数据
                attachment.FilePath = path_Physics;
                attachment.FileUrl = SystemConst.AttachmentUrl + path_Logic;
                result = base.Add(attachment);


            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 删除附件数据，包含物理文件
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="tableID">对象ID</param>
        /// <param name="fileName_Number">文件名（带序号的文件名）</param>
        /// <returns></returns>
        public Result DeleteOldFile(string tableName, int tableID, string fileName_Number)
        {
            var attachment = List().Where(a => a.TableName.Equals(tableName, StringComparison.CurrentCultureIgnoreCase) && a.TableID == tableID && a.FileName_Number == fileName_Number).FirstOrDefault();
            Result result = null;
            if (attachment != null)
            {
                try
                {
                    File.Delete(attachment.FilePath);
                    result = base.Delete(attachment.ID);
                }
                catch (Exception ex)
                {
                    result.Error = ex.Message;
                }
            }
            return result;
        }

        /// <summary>
        /// 根据表名和ID获取附件列表
        /// </summary>
        /// <returns></returns>
        public List<Attachment> GetAttachment(string tableName, int tableID)
        {
            return List().Where(a => a.TableName.Equals(tableName, StringComparison.CurrentCultureIgnoreCase) && a.TableID == tableID).ToList();
        }
    }
}