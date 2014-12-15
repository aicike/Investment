using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class MenuOption : BaseEntity
    {
        public int ID { get; set; }

        public int MenuID { get; set; }

        public virtual Menu Menu { get; set; }

        /// <summary>
        /// 操作名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 操作Controller
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// 操作Action
        /// </summary>
        public string Action { get; set; }

        public int Order { get; set; }

        public virtual ICollection<RoleOption> RoleOptions { get; set; }
    }
}
