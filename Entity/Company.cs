using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 客户信息主表
    /// </summary>
    public class Company : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Display(Name = "客户名称")]
        [Required(ErrorMessage = "请输入客户名称")]
        [StringLength(100, ErrorMessage = "不能超过100字")]
        public string Name { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [Display(Name = "详细地址")]
        [Required(ErrorMessage = "请输入详细地址")]
        [StringLength(100, ErrorMessage = "不能超过100字")]
        public string Address { get; set; }

        /// <summary>
        /// 成立时间
        /// </summary>
        public DateTime SetUpTime { get; set; }

        /// <summary>
        /// 成立时间及营业期限
        /// </summary>
        public string ChengLiShiJianJiYingYeQiXian { get; set; }

        /// <summary>
        /// 注册资本（万元）
        /// </summary>
        public double ZhuCheZiJin { get; set; }

        /// <summary>
        /// 实收资本（万元）
        /// </summary>
        public double ShiShouZiBen { get; set; }

        /// <summary>
        /// 法定代表人
        /// </summary>
        public string FaDingDaiBiaoRen { get; set; }

        /// <summary>
        /// 资产总额
        /// </summary>
        public double ZiChanZongE { get; set; }

        /// <summary>
        /// 负债总额
        /// </summary>
        public double FuZhaiZongE { get; set; }

        /// <summary>
        /// 主营业务收入
        /// </summary>
        public double ZhuYingYeWuShouRu { get; set; }

        /// <summary>
        /// 净利润
        /// </summary>
        public double JingLiRun { get; set; }

        /// <summary>
        /// 或有负债
        /// </summary>
        public double HuoYouFuZhai { get; set; }

        /// <summary>
        /// 可我供求关系
        /// </summary>
        public string KeWoGongQiuGuanXi { get; set; }

        /// <summary>
        /// 拟贷款银行
        /// </summary>
        public string NiDaiKuanYinHang { get; set; }

        /// <summary>
        /// 股权结构
        /// </summary>
        public string GuQuanJieGou { get; set; }

        /// <summary>
        /// 实际控制人信用记录
        /// </summary>
        public string ShiJiKongZhiRenXinYongJiLu { get; set; }

        /// <summary>
        /// 信用等级
        /// </summary>
        public string XinYongDengJi { get; set; }

        /// <summary>
        /// 经营情况及其变动
        /// </summary>
        public string JingYingQingKuangJiQiBianDong { get; set; }

        /// <summary>
        /// 核心竞争力
        /// </summary>
        public string HeXinJingZhengLi { get; set; }

        /// <summary>
        /// 财务情况及其变动
        /// </summary>
        public string CaiWuQingKuangJiQiBianDong { get; set; }

        /// <summary>
        /// 财务情况
        /// </summary>
        public string CaiWuQingKuang { get; set; }

        /// <summary>
        /// 关联方及关联方交易
        /// </summary>
        public string GuanLianFangJiGuanLianFangJiaoYi { get; set; }

        /// <summary>
        /// 目前贷款、担保执行情况
        /// </summary>
        public string MuQianDaiKuanDanBaoZhiXingQingKuang { get; set; }

        /// <summary>
        /// 抵质押反担保
        /// </summary>
        public string DiZhiYaFanDanBao { get; set; }

        /// <summary>
        /// 企业性质
        /// </summary>
        public string QiYeXingZhi { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        public string YingYeZhiZhao { get; set; }
        
        /// <summary>
        /// 经营范围
        /// </summary>
        public string JingYingFanWei { get; set; }

        //----------------------子表------------------------------------------
        /// <summary>
        /// 公司用户表
        /// </summary>
        public virtual ICollection<CompanyAccount> CompanyAccount { get; set; }

        public virtual ICollection<CompanyLoan> CompanyLoans { get; set; }

    }
}
