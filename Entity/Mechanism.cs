using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 机构管理
    /// </summary>
    public class Mechanism : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        [Display(Name = "机构名称")]
        [Required(ErrorMessage = "请输入登录账号")]
        public string Name { get; set; }

        /// <summary>
        /// 官方网站
        /// </summary>
        [Display(Name = "官方网站")]
        [RegularExpression(@"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?", ErrorMessage = "请输入正确的网址")]
        public string WebSite { get; set; }
    }
}
