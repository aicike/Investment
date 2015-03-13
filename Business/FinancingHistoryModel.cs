using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class FinancingHistoryModel : BaseModel<FinancingHistory>
    {
        public Result Add(int financingID)
        {
            FinancingModel fm = new FinancingModel();
            var financing= fm.Get(financingID);
            FinancingHistory fh = new FinancingHistory();
            fh.CreatDateTime = DateTime.Now;
            fh.CreatGroupAccountID = financing.Owner_A_ID.Value;
            fh.CompanyID = financing.CompanyID;
            fh.Owner_A_ID = financing.Owner_A_ID;
            fh.Owner_B_ID = financing.Owner_B_ID;
            fh.Status = financing.Status;
            fh.AuditStatus = financing.AuditStatus;
            fh.EditStatus = financing.EditStatus;
            fh.Name = financing.Name;
            fh.Amount = financing.Amount;
            fh.MinTimeLimit = financing.MinTimeLimit;
            fh.MaxTimeLimit = financing.MaxTimeLimit;
            fh.ShouYiLvType = financing.ShouYiLvType;
            fh.ShouYiLv = financing.ShouYiLv;
            fh.Purpose = financing.Purpose;
            fh.Repayment = financing.Repayment;
            fh.DiYaWuQingDan = financing.DiYaWuQingDan;
            fh.ZengXinCuoShi = financing.ZengXinCuoShi;
            fh.RongZiFangAn = financing.RongZiFangAn;
            fh.Remark = financing.Remark;
            fh.BusinessResource = financing.BusinessResource;
            fh.BusinessType = financing.BusinessType;
            fh.WorkFlowManagerID = financing.WorkFlowManagerID;
            return base.Add(fh);
        }
    }
}
