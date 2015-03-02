using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.Entity;

namespace Business
{
    public class IndustryLevelModel : BaseModel<IndustryLevel>
    {
        public IndustryLevel GetIndustry(int industryID, double ZhuCheZiJin)
        {
            base.Context.Configuration.ProxyCreationEnabled = false;
            IndustryLevel il = null;
            var list = List().Where(a => a.IndustryID == industryID && ZhuCheZiJin >a.YingYeShouRu).OrderByDescending(a => a.YingYeShouRu).ToList();
            if (list == null||list.Count==0)
            {
                il = List().Where(a => a.IndustryID == industryID).OrderBy(a => a.YingYeShouRu).FirstOrDefault();
            }
            else
            {
                il = list.FirstOrDefault();
            }
            return il;
        }
    }
}
