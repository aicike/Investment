using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class RoleAccount : BaseEntity
    {
        public int ID { get; set; }

        public int RoleID { get; set; }

        public virtual Role Role { get; set; }

        public int? GroupAccountID { get; set; }

        public virtual GroupAccount GroupAccount { get; set; }

        public int? CompanyAccountID { get; set; }

        public virtual CompanyAccount CompanyAccount { get; set; }
    }
}
