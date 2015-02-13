using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public static class SystemConst
    {
        /// <summary>
        /// 附件服务器Url
        /// </summary>
        public static string AttachmentUrl = System.Configuration.ConfigurationManager.AppSettings["AttachmentUrl"];

        /// <summary>
        /// 附件，临时文件路径
        /// </summary>
        public static string AttachmentPathTemp = System.Configuration.ConfigurationManager.AppSettings["AttachmentPathTemp"];
        /// <summary>
        /// 附件，正式文件路径
        /// </summary>
        public static string AttachmentPath = System.Configuration.ConfigurationManager.AppSettings["AttachmentPath"];

        public class Session
        {
            private Session() { }

            public const string LoginUser = "LoginUser";
        }

        public class Business
        {
            private Business() { }


            public const string key = "abcdefgh";
            public const string iv = "12345678";

        }

        public class TableName
        {
            public const string Company = "Company";

            public const string Financing = "Financing";

            public const string CompanyReference = "CompanyReference";

            public const string ApprovalRecord = "ApprovalRecord";
        }
    }

}
