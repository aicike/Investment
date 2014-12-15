using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    /// <summary>
    /// 自定义表 字段临时类
    /// </summary>
    public class ColumnOption
    {
        /// <summary>
        /// 字段ID
        /// </summary>
        public int? ID { get; set; }
        /// <summary>
        /// 字段名
        /// </summary>
        public string Option { get; set; }

        /// <summary>
        /// 字段类型（枚举 Enum_CustomTable_ColumnType.cs）
        /// </summary>
        public int TypeVal { get; set; }
    }
}
