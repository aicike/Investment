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
        /// <summary>
        /// 根据负责人ID 和 状态 获取列表
        /// </summary>
        /// <param name="state">状态 0草稿，1进行中，2已完成，3未通过</param>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetListByState(int state, int groupAccountID)
        {
            return List().Where(a => a.State == state && a.Financing.Owner_A_ID == groupAccountID);
        }

        /// <summary>
        /// 我的申请
        /// </summary>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetMyApplication(int groupAccountID)
        {
            var list = List().Where(a => a.Financing.Owner_A_ID == groupAccountID&&a.State!=0);
            return list;
        }

        /// <summary>
        /// 我的待办
        /// </summary>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetBacklog(int groupAccountID)
        {
            var list = List().Where(a => a.ApprovalRecord.Any(b => b.Operation == -1 && b.GroupAccountID == groupAccountID));
            return list;
        }

        /// <summary>
        /// 我的已办
        /// </summary>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetHistory(int groupAccountID)
        {
            var list = List().Where(a => a.ApprovalRecord.Any(b => (b.Operation == 1 || b.Operation == 2 || b.Operation == 3) && b.GroupAccountID == groupAccountID));
            return list;
        }

        /// <summary>
        /// 我的辅助
        /// </summary>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetAssist(int groupAccountID)
        {
            var list = List().Where(a => a.Financing.Owner_B_ID==groupAccountID);
            return list;
        }

        /// <summary>
        /// 项目列表
        /// </summary>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetList()
        {
            var list = List().Where(a => a.State != 0);
            return list;
        }


        /// <summary>
        /// 根据流程ID获取 融资信息、公司信息的 json数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get_To_Json_Financing(int id)
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
