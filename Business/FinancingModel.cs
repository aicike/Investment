using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Runtime.Serialization;
using System.IO;
using System.Data;

namespace Business
{
    public class FinancingModel : BaseModel<Financing>
    {
        public IQueryable<Financing> GetByCompanyID(int companyID)
        {
            return List().Where(a => a.CompanyID == companyID);
        }

        /// <summary>
        /// 找到我所操作的融资信息
        /// </summary>
        /// <param name="ownerID"></param>
        /// <returns></returns>
        public IQueryable<Financing> GetByMyList(int ownerID)
        {
            return List().Where(a => a.Owner_A_ID == ownerID || a.Owner_B_ID == ownerID);
        }

        public Result Add(Financing financing, List<Attachment> attachments)
        {
            Result result = base.Add(financing);
            if (result.HasError == false && attachments != null)
            {
                AttachmentModel attachmentModel = new AttachmentModel();
                foreach (Attachment item in attachments)
                {
                    item.TableID = financing.ID;
                    result = attachmentModel.CopyAttachment_Company(financing.CompanyID, item, "/Financing");
                }
            }
            return result;
        }

        public Result Edit(Financing financing, List<Attachment> attachments)
        {
            Result result = base.Edit(financing);
            if (result.HasError == false && attachments != null)
            {
                AttachmentModel attachmentModel = new AttachmentModel();
                foreach (Attachment item in attachments)
                {
                    item.TableID = financing.ID;
                    result = attachmentModel.CopyAttachment_Company(financing.CompanyID, item, "/Financing");
                }
            }
            return result;
        }

        /// <summary>
        /// 检查是否有业务数据引用，有的话无法删除。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ownerID"></param>
        /// <returns></returns>
        public Result Delete_Check(int id, int ownerID)
        {
            Result result = new Result();
            var hasObj = List().Any(a => a.ID == id && a.Owner_A_ID == ownerID);
            if (hasObj)
            {
                //检查业务数据引用，引用了无法删除
                result = base.Delete(id);
                if (result.HasError)
                {
                    result.Error = "该数据已经使用，无法删除。";
                }
            }
            else
            {
                result.Error = "未找到该数据，无法删除。";
            }
            return result;
        }

        /// <summary>
        /// 更改AB角色
        /// </summary>
        /// <param name="FID"></param>
        /// <param name="AuserID"></param>
        /// <param name="BuserID"></param>
        /// <returns></returns>
        public Result SetABRole(int FID, int AuserID, int BuserID)
        {
            Result result = new Result();
            string sql = "update Financing set Owner_A_ID=" + AuserID;
            if (BuserID > 0)
            {
                sql = sql + ",Owner_B_ID=" + BuserID;
            }
            sql = sql + " where id=" + FID;
            base.SqlExecute(sql);
            return result;
        }

        /// <summary>
        /// 更改融资信息审核状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status">0：未审核  1：审核通过  2：审核不通过</param>
        /// <returns></returns>
        public Result ChangeAuditStatus(int id, int status)
        {
            Result result = new Result();
            string sql = "update Financing set AuditStatus=" + status + " where id=" + id;
            int i= base.SqlExecute(sql);
            if (i == 0) {
                result.Error = "操作失败。";
            }
            return result;
        }
    }
}
