using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.IO;
using Entity.Enum;

namespace Business
{
    /// <summary>
    /// 公司Model
    /// </summary>
    public class CompanyModel : BaseModel<Company>
    {

        public Result Add(Company company, List<Attachment> attachments)
        {
            if (string.IsNullOrEmpty(company.Name) || string.IsNullOrEmpty(company.Address) || string.IsNullOrEmpty(company.ChengLiShiJianJiYingYeQiXian) ||
                company.ZhuCheZiJin <= 0 || company.ShiShouZiBen <= 0 || company.ZiChanZongE <= 0 || company.FuZhaiZongE <= 0 || company.ZhuYingYeWuShouRu <= 0 || company.JingLiRun <= 0 ||
                company.HuoYouFuZhai <= 0 ||
                string.IsNullOrEmpty(company.FaDingDaiBiaoRen) || string.IsNullOrEmpty(company.KeWoGongQiuGuanXi) || string.IsNullOrEmpty(company.NiDaiKuanYinHang) ||
                string.IsNullOrEmpty(company.GuQuanJieGou) || string.IsNullOrEmpty(company.ShiJiKongZhiRenXinYongJiLu)  ||
                string.IsNullOrEmpty(company.JingYingQingKuangJiQiBianDong) || string.IsNullOrEmpty(company.HeXinJingZhengLi) || string.IsNullOrEmpty(company.CaiWuQingKuangJiQiBianDong) ||
                string.IsNullOrEmpty(company.CaiWuQingKuang) || string.IsNullOrEmpty(company.GuanLianFangJiGuanLianFangJiaoYi) || string.IsNullOrEmpty(company.MuQianDaiKuanDanBaoZhiXingQingKuang) ||
                string.IsNullOrEmpty(company.DiZhiYaFanDanBao) || string.IsNullOrEmpty(company.QiYeXingZhi) || string.IsNullOrEmpty(company.YingYeZhiZhao) ||
                string.IsNullOrEmpty(company.JingYingFanWei))
            {
                company.IsComplete = false;
            }
            var result = base.Add(company);
            if (result.HasError == false && attachments != null)
            {
                UploadAttachment(company.ID, attachments);
                result.Entity = company;
            }
            return result;
        }

        /// <summary>
        /// 修改客户信息
        /// </summary>
        /// <param name="company"></param>
        /// <param name="attachment_YingYeZhiZhao">营业执照附件</param>
        /// <param name="deleteFileNameNumbers">需要删除的文件</param>
        /// <returns></returns>
        public new Result Edit(Company company, List<Attachment> attachments)
        {
            if (string.IsNullOrEmpty(company.Name) || string.IsNullOrEmpty(company.Address) || string.IsNullOrEmpty(company.ChengLiShiJianJiYingYeQiXian) ||
                   company.ZhuCheZiJin <= 0 || company.ShiShouZiBen <= 0 || company.ZiChanZongE <= 0 || company.FuZhaiZongE <= 0 || company.ZhuYingYeWuShouRu <= 0 || company.JingLiRun <= 0 ||
                   company.HuoYouFuZhai <= 0 ||
                   string.IsNullOrEmpty(company.FaDingDaiBiaoRen) || string.IsNullOrEmpty(company.KeWoGongQiuGuanXi) || string.IsNullOrEmpty(company.NiDaiKuanYinHang) ||
                   string.IsNullOrEmpty(company.GuQuanJieGou) || string.IsNullOrEmpty(company.ShiJiKongZhiRenXinYongJiLu)  ||
                   string.IsNullOrEmpty(company.JingYingQingKuangJiQiBianDong) || string.IsNullOrEmpty(company.HeXinJingZhengLi) || string.IsNullOrEmpty(company.CaiWuQingKuangJiQiBianDong) ||
                   string.IsNullOrEmpty(company.CaiWuQingKuang) || string.IsNullOrEmpty(company.GuanLianFangJiGuanLianFangJiaoYi) || string.IsNullOrEmpty(company.MuQianDaiKuanDanBaoZhiXingQingKuang) ||
                   string.IsNullOrEmpty(company.DiZhiYaFanDanBao) || string.IsNullOrEmpty(company.QiYeXingZhi) || string.IsNullOrEmpty(company.YingYeZhiZhao) ||
                   string.IsNullOrEmpty(company.JingYingFanWei))
            {
                company.IsComplete = false;
            }
            var result = base.Edit(company);
            if (result.HasError == false && attachments != null)
            {
                UploadAttachment(company.ID, attachments);
            }
            return result;
        }

        /// <summary>
        /// 上传附件(公司基本信息附件)
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="attachmentList"></param>
        /// <returns></returns>
        private Result UploadAttachment(int companyID, List<Attachment> attachmentList)
        {
            Result result = new Result();
            AttachmentModel attachmentModel = new AttachmentModel();
            if (attachmentList != null)
            {
                foreach (Attachment item in attachmentList)
                {
                    result = attachmentModel.CopyAttachment_Company(companyID, item, "/Base");
                }
            }
            return result;
        }

        /// <summary>
        /// 审批是否通过
        /// </summary>
        public void ChangeStatus(int id, int status)
        {
            string sql = "UPDATE dbo.Company SET Status=" + status + " WHERE ID=" + id;
            int i = base.SqlExecute(sql);
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
            var hasObj = List().Any(a => a.ID == id && a.OwnerID == ownerID);
            if (hasObj)
            {
                //检查业务数据引用，引用了无法删除
                result = base.Delete(id);
                if (result.HasError) {
                    result.Error = "该数据已经使用，无法删除。";
                }
            }
            else {
                result.Error = "未找到该数据，无法删除。";
            }
            return result;
        }
    }
}
