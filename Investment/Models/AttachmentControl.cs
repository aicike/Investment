using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity.Enum;

namespace Investment.Models
{
    public class AttachmentControl
    {
        private string text;

        /// <summary>
        /// 显示的文字
        /// </summary>
        public string Text
        {
            get { return text ?? "附件管理"; }
            set { text = value; }
        }

        public string Table { get; set; }

        public int Id { get; set; }

        public EnumAttachmentType? EnumAttachmentType { get; set; }
    }
}