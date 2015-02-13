using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Investment.Models
{
    public class CommonHelp
    {
        public static string GetQiYeXingZhi(int id)
        {
            string value = null;
            switch (id)
            {
                case 1:
                    value = "有限责任公司";
                    break;
                case 2:
                    value = "股份有限责任公司";
                    break;
                case 3:
                    value = "个人合伙企业";
                    break;
                case 4:
                    value = "个人独资企业";
                    break;
                case 5:
                    value = "全民所有制企业";
                    break;
                case 6:
                    value = "集体所有制企业";
                    break;
                case 7:
                    value = "个体工商户";
                    break;
            }
            return value;
        }
    }
}