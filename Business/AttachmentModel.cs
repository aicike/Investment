using System;
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
        ///        -------Base（公司基本信息目录）
        ///        -------Financing（融资信息文件目录）
        ///        -------Approval（审批文件目录）
        /// -------Organization(机构文件目录)
        /// </summary>
        /// <param name="companyID">公司ID</param>
        /// <param name="attachment">附件对象</param>
        /// <param name="subDirectory">子文件夹名称，可为空</param>
        /// <returns></returns>
        public Result CopyAttachment_Company(int companyID, Attachment attachment, string subDirectory)
        {
            Result result = new Result();
            try
            {
                //判断是否有Company目录是否存在
                string directory_Logic = SystemConst.AttachmentPath.Substring(SystemConst.AttachmentPath.LastIndexOf('/') + 1) + "/" + "Company" + "/" + companyID;
                string directory_Physics = SystemConst.AttachmentPath + "/" + "Company" + "/" + companyID;
                if (!string.IsNullOrEmpty(subDirectory))
                {
                    directory_Logic += subDirectory;
                    directory_Physics += subDirectory;
                }
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
        /// 正式附件删除（目前只限制于公司基本资料的删除）
        /// </summary>
        /// <returns></returns>
        public Result DeleteAttachment(int tableID, int id)
        {
            //找到未删除的该附件
            var attachment = List().Where(a => a.TableName.Equals(SystemConst.TableName.Company, StringComparison.CurrentCultureIgnoreCase) &&
                                               a.TableID == tableID &&
                                               a.ID == id &&
                                               a.Status == 0).FirstOrDefault();
            Result result = new Result();
            if (attachment != null)
            {
                attachment.Status = 1;
                result = Edit(attachment);
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
            return List().Where(a => a.TableName.Equals(tableName, StringComparison.CurrentCultureIgnoreCase) && a.TableID == tableID && a.Status == 0).ToList();
        }


        /// <summary>
        /// 根据List<AttachmentSel>获取附件列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<Attachment> GetAttachment(List<AttachmentSel> objs)
        {
            List<Attachment> list = new List<Attachment>();
            foreach (var item in objs)
            {
                var obj = List().Where(a => a.Status == 0).Where(a => a.TableName == item.TableName && a.TableID == item.TableID).ToList();
                if (obj != null && obj.Count > 0)
                {
                    list.AddRange(obj);
                }
            }
            return list.OrderBy(a => a.EnumAttachmentType).ToList();
        }

    }
}
