using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity.Enum;

namespace Investment.Models
{
    public class AttachmentControl
    {
        public string ID { get; set; }

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

        public int TableId { get; set; }

        public EnumAttachmentType? EnumAttachmentType { get; set; }

        private bool isEnabled = true;

        /// <summary>
        /// 是否启用（默认启用）
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
            }
        }
    }
}