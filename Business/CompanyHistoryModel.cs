using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class CompanyHistoryModel : BaseModel<CompanyHistory>
    {
        public Result Add(int CompanyID)
        {
            CompanyModel cm = new CompanyModel();
            var company = cm.Get(CompanyID);
            CompanyHistory ch = new CompanyHistory();
            ch.CompanyID = CompanyID;
            ch.CreatDateTime = DateTime.Now;
            ch.CreatGroupAccountID = company.OwnerID.Value;
            ch.Status = company.Status;
            ch.OwnerID = company.OwnerID;
            ch.IndustryID = company.IndustryID;
            ch.IndustryLevelID = company.IndustryLevelID;
            ch.IsComplete = company.IsComplete;
            ch.Name = company.Name;
            ch.WebSite = company.WebSite;
            ch.Phone = company.Phone;
            ch.Fax = company.Fax;
            ch.Address = company.Address;
            ch.SetUpTime = company.SetUpTime;
            ch.ChengLiShiJianJiYingYeQiXian = company.ChengLiShiJianJiYingYeQiXian;
            ch.ZhuCheZiJin = company.ZhuCheZiJin;
            ch.ShiShouZiBen = company.ShiShouZiBen;
            ch.FaDingDaiBiaoRen = company.FaDingDaiBiaoRen;
            ch.GuDong = company.GuDong;
            ch.ZiChanZongE = company.ZiChanZongE;
            ch.FuZhaiZongE = company.FuZhaiZongE;
            ch.ZhuYingYeWuShouRu = company.ZhuYingYeWuShouRu;
            ch.ChengBen = company.ChengBen;
            ch.ZhuYingYeWu = company.ZhuYingYeWu;
            ch.JingYingFanWei = company.JingYingFanWei;
            ch.JingLiRun = company.JingLiRun;
            ch.HuoYouFuZhai = company.HuoYouFuZhai;
            ch.KeWoGongQiuGuanXi = company.KeWoGongQiuGuanXi;
            ch.NiDaiKuanYinHang = company.NiDaiKuanYinHang;
            ch.GuQuanJieGou = company.GuQuanJieGou;
            ch.ShiJiKongZhiRen = company.ShiJiKongZhiRen;
            ch.ShiJiKongZhiRenXinYongJiLu = company.ShiJiKongZhiRenXinYongJiLu;
            ch.XinYongDaiMaZhengHao = company.XinYongDaiMaZhengHao;
            ch.JingYingQingKuangJiQiBianDong = company.JingYingQingKuangJiQiBianDong;
            ch.HeXinJingZhengLi = company.HeXinJingZhengLi;
            ch.CaiWuQingKuangJiQiBianDong = company.CaiWuQingKuangJiQiBianDong;
            ch.CaiWuQingKuang = company.CaiWuQingKuang;
            ch.GuanLianFangJiGuanLianFangJiaoYi = company.GuanLianFangJiGuanLianFangJiaoYi;
            ch.MuQianDaiKuanDanBaoZhiXingQingKuang = company.MuQianDaiKuanDanBaoZhiXingQingKuang;
            ch.DiZhiYaFanDanBao = company.DiZhiYaFanDanBao;
            ch.QiYeXingZhi = company.QiYeXingZhi;
            ch.YingYeZhiZhao = company.YingYeZhiZhao;
            ch.ZuZhiJiGouDaiMaZheng = company.ZuZhiJiGouDaiMaZheng;
            ch.SuiWuDengJi = company.SuiWuDengJi;
            ch.KaiHuXuKeZheng = company.KaiHuXuKeZheng;
            ch.DaiKuanKa = company.DaiKuanKa;
            ch.QiYeZiZhi = company.QiYeZiZhi;
            ch.GuanLianGongSi = company.GuanLianGongSi;
            return base.Add(ch);
        }
    }
}
