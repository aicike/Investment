﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity.Enum
{
    /// <summary>
    /// 附件业务分类
    /// </summary>
    public enum EnumAttachmentType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown=0,

        /// <summary>
        /// 营业执照正
        /// </summary>
        YingYeZhiZhao1 = 1,

        /// <summary>
        /// 营业执照反
        /// </summary>
        YingYeZhiZhao2 = 2,
        
        /// <summary>
        /// 组织机构代码证正
        /// </summary>
        ZuZhiJiGouDaiMa1 = 3,

        /// <summary>
        /// 组织机构代码证反
        /// </summary>
        ZuZhiJiGouDaiMa2 = 4,
        
        /// <summary>
        /// 税务正
        /// </summary>
        ShuiWu1 = 5,

        /// <summary>
        /// 税务反
        /// </summary>
        ShuiWu2 = 6,

        /// <summary>
        /// 验资报告
        /// </summary>
        YanZiBaoGao = 7
    }
}