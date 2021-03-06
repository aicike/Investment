﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class RoleOption : BaseEntity
    {
        public int ID { get; set; }

        public int RoleID { get; set; }

        public virtual Role Role { get; set; }

        public int MenuOptionID { get; set; }

        public virtual MenuOption MenuOption { get; set; }
    }
}
