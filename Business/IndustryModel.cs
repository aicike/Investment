using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class IndustryModel : BaseModel<Industry>
    {
        /// <summary>
        /// 获取所有行业
        /// </summary>
        /// <returns></returns>
        public List<Industry> GetList()
        {
            return List().OrderBy(a => a.ID).ToList();
        }
    }
}
