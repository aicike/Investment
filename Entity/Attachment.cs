using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Attachment : BaseEntity
    {
        public int ID { get; set; }

        /// <summary>
        /// 附件名称（文件名称+编号）
        /// </summary>
        public string FileName_Number { get; set; }

        /// <summary>
        /// 附件名称(文件名称)
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 附件路径(物理路径)
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 附件路径(网址路径)
        /// </summary>
        public string FileUrl { get; set; }

        /// <summary>
        /// 附件对象表
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 附件对象ID
        /// </summary>
        public int TableID { get; set; }

        /// <summary>
        /// 附件业务分类
        /// </summary>
        public int EnumAttachmentType { get; set; }

        /// <summary>
        /// 附件格式
        /// </summary>
        public int EnumAttachmentFormat { get; set; }

        /// <summary>
        /// 删除状态：0 未删除   1删除
        /// </summary>
        public int Status { get; set; }
    }
}
