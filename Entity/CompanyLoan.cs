using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    /// <summary>
    /// 客户贷款基本信息
    /// </summary>
    public class CompanyLoan:BaseEntity
    {
        public int ID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string XiangMuMingCheng { get; set; }

        /// <summary>
        /// 项目类型
        /// </summary>
        public string XiangMuLeiXing { get; set; }

        /// <summary>
        /// 融资金额（本次贷款金额）
        /// </summary>
        public double RongZiJinE { get; set; }

        /// <summary>
        /// 融资期限（月？还是天）
        /// </summary>
        public double RongZiQiXian { get; set; }

        /// <summary>
        /// 融资成本
        /// </summary>
        public double RongZiChengBen { get; set; }

        /// <summary>
        /// 融资用途
        /// </summary>
        public string RongZiYongTu { get; set; }

        /// <summary>
        /// 还款来源
        /// </summary>
        public string HuanKuanLaiYuan { get; set; }

        /// <summary>
        /// 融资标的
        /// </summary>
        public string RongZiBiaoDi { get; set; }

        /// <summary>
        /// 增信措施
        /// </summary>
        public string ZengXinCuoShi { get; set; }

        /// <summary>
        /// 融资方案
        /// </summary>
        public string RongZiFangAn { get; set; }





        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
