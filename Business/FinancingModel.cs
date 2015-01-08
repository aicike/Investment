using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class FinancingModel : BaseModel<Financing>
    {
        public IQueryable<Financing> GetByCompanyID(int companyID)
        {
            return List().Where(a => a.CompanyID == companyID);
        }

        public Result Add(Financing financing, List<Attachment> attachments)
        {
            Result result = base.Add(financing);
            if (result.HasError == false && attachments!=null)
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
            if (result.HasError==false&&attachments!=null)
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
            var hasObj = List().Any(a => a.ID == id && a.Owner_A_ID== ownerID);
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
    }
}
