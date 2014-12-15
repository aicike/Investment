using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class RoleMenu:BaseEntity
    {
        public int ID { get; set; }

        public int MenuID { get; set; }

        public virtual Menu Menu { get; set; }

        public int RoleID { get; set; }

        public virtual Role Role { get; set; }
    }
}
