using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    /// <summary>
    /// 工作流程表 Model
    /// </summary>
    public class WorkFlowModel : BaseModel<WorkFlow>
    {
        public string Get_To_Json(int id)
        {
            var obj = Get(id);//工作流程表

            base.Context.Configuration.ProxyCreationEnabled = false;

            var financing = base.Context.Financings.Where(a => a.ID == obj.FinancingID).FirstOrDefault();//融资信息

            var company = base.Context.Company.Where(a => a.ID == obj.Financing.CompanyID).FirstOrDefault(); //公司信息

            //var wfmpIDs = obj.WorkFlowMechanismProduct.Select(a => a.MechanismProductsID).ToList();
            //base.Context.MechanismProducts.Where(a => wfmpIDs.Contains(a.ID));//机构产品信息

            financing.Company = company;


            string json = Newtonsoft.Json.JsonConvert.SerializeObject(financing);
            return json;
        }
    }
}
