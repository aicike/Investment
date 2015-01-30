using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 公司信息主表
    /// </summary>
    public class Company : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 状态：0未审核   1:审核通过    2:审核不通过
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 平台负责人ID
        /// </summary>
        public int? OwnerID { get; set; }

        public virtual GroupAccount Owner { get; set; }

        /// <summary>
        /// 信息是否齐全
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [Display(Name = "公司名称")]
        [Required(ErrorMessage = "请输入公司名称")]
        [StringLength(100, ErrorMessage = "不能超过100字")]
        public string Name { get; set; }

        /// <summary>
        /// 公司网址
        /// </summary>
        [Display(Name = "公司网址")]
        public string WebSite { get; set; }

        /// <summary>
        /// 公司电话
        /// </summary>
        [Display(Name = "公司电话")]
        [Required(ErrorMessage = "请输入公司电话")]
        public string Phone { get; set; }

        /// <summary>
        /// 公司传真
        /// </summary>
        [Display(Name = "公司传真")]
        public string Fax { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [Display(Name = "详细地址")]
        [Required(ErrorMessage = "请输入详细地址")]
        [StringLength(200, ErrorMessage = "不能超过200字")]
        public string Address { get; set; }

        /// <summary>
        /// 成立时间
        /// </summary>
        [Display(Name = "成立时间")]
        [Required(ErrorMessage = "请输入成立时间")]
        public DateTime SetUpTime { get; set; }

        /// <summary>
        /// 成立时间及营业期限
        /// </summary>
        [Display(Name = "有效期限")]
        [Required(ErrorMessage = "请输入有效期限")]
        public string ChengLiShiJianJiYingYeQiXian { get; set; }

        /// <summary>
        /// 注册资本（万元）
        /// </summary>
        [Display(Name = "注册资本")]
        [Required(ErrorMessage = "请输入注册资本")]
        public double ZhuCheZiJin { get; set; }

        /// <summary>
        /// 实收资本（万元）
        /// </summary>
        [Display(Name = "实收资本")]
        [Required(ErrorMessage = "请输入实收资本")]
        public double ShiShouZiBen { get; set; }

        /// <summary>
        /// 法定代表人
        /// </summary>
        [Display(Name = "法人姓名及身份证号")]
        [Required(ErrorMessage = "法人姓名及身份证号")]
        public string FaDingDaiBiaoRen { get; set; }

        /// <summary>
        /// 股东
        /// </summary>
        [Display(Name = "股东姓名及身份证号")]
        [Required(ErrorMessage = "股东姓名及身份证号")]
        public string GuDong { get; set; }

        /// <summary>
        /// 资产总额
        /// </summary>
        [Display(Name = "资产总额")]
        public double ZiChanZongE { get; set; }

        /// <summary>
        /// 负债总额
        /// </summary>
        [Display(Name = "负债总额")]
        public double FuZhaiZongE { get; set; }

        /// <summary>
        /// 主营业务收入
        /// </summary>
        [Display(Name = "主营业务收入")]
        public double ZhuYingYeWuShouRu { get; set; }

        /// <summary>
        /// 成本
        /// </summary>
        [Display(Name = "成本")]
        public double ChengBen { get; set; }

        /// <summary>
        /// 主营业务
        /// </summary>
        [Display(Name = "主营业务")]
        [Required(ErrorMessage = "请输入主营业务")]
        public string ZhuYingYeWu { get; set; }

        /// <summary>
        /// 经营范围
        /// </summary>
        [Display(Name = "经营范围")]
        [Required(ErrorMessage = "请输入经营范围")]
        public string JingYingFanWei { get; set; }


        /// <summary>
        /// 净利润
        /// </summary>
        [Display(Name = "净利润")]
        public double JingLiRun { get; set; }

        /// <summary>
        /// 或有负债
        /// </summary>
        [Display(Name = "或有负债")]
        public double HuoYouFuZhai { get; set; }

        /// <summary>
        /// 客我供求关系
        /// </summary>
        [Display(Name = "客我供求关系")]
        public string KeWoGongQiuGuanXi { get; set; }

        /// <summary>
        /// 拟贷款银行
        /// </summary>
        [Display(Name = "拟贷款银行")]
        public string NiDaiKuanYinHang { get; set; }

        /// <summary>
        /// 股权结构
        /// </summary>
        [Display(Name = "股权结构")]
        public string GuQuanJieGou { get; set; }

        /// <summary>
        /// 实际控制人
        /// </summary>
        [Display(Name = "实际控制人")]
        [Required(ErrorMessage = "请输入实际控制人及身份证号")]
        public string ShiJiKongZhiRen { get; set; }

        /// <summary>
        /// 实际控制人信用记录
        /// </summary>
        [Display(Name = "实际控制人信用记录")]
        public string ShiJiKongZhiRenXinYongJiLu { get; set; }

        /// <summary>
        /// 信用代码证号
        /// </summary>
        [Display(Name = "信用代码证号")]
        public string XinYongDaiMaZhengHao { get; set; }

        /// <summary>
        /// 经营情况及其变动
        /// </summary>
        [Display(Name = "经营情况及其变动")]
        public string JingYingQingKuangJiQiBianDong { get; set; }

        /// <summary>
        /// 核心竞争力
        /// </summary>
        [Display(Name = "核心竞争力")]
        public string HeXinJingZhengLi { get; set; }

        /// <summary>
        /// 财务情况及其变动
        /// </summary>
        [Display(Name = "财务情况及其变动")]
        public string CaiWuQingKuangJiQiBianDong { get; set; }

        /// <summary>
        /// 财务情况
        /// </summary>
        [Display(Name = "财务情况")]
        public string CaiWuQingKuang { get; set; }

        /// <summary>
        /// 关联方及关联方交易
        /// </summary>
        [Display(Name = "关联方及关联方交易")]
        public string GuanLianFangJiGuanLianFangJiaoYi { get; set; }

        /// <summary>
        /// 目前贷款、担保执行情况
        /// </summary>
        [Display(Name = "目前贷款、担保执行情况")]
        public string MuQianDaiKuanDanBaoZhiXingQingKuang { get; set; }

        /// <summary>
        /// 抵质押反担保
        /// </summary>
        [Display(Name = "抵质押反担保")]
        public string DiZhiYaFanDanBao { get; set; }

        /// <summary>
        /// 企业性质
        /// </summary>
        [Display(Name = "企业性质")]
        [Required(ErrorMessage = "请输入企业性质")]
        public string QiYeXingZhi { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        [Display(Name = "营业执照号")]
        public string YingYeZhiZhao { get; set; }


        /// <summary>
        /// 组织机构代码证号
        /// </summary>
        [Display(Name = "组织机构代码证号")]
        public string ZuZhiJiGouDaiMaZheng { get; set; }


        /// <summary>
        /// 税务登记证号
        /// </summary>
        [Display(Name = "税务登记证号")]
        public string SuiWuDengJi { get; set; }


        /// <summary>
        /// 开户许可证号
        /// </summary>
        [Display(Name = "开户许可证号")]
        public string KaiHuXuKeZheng { get; set; }

        /// <summary>
        /// 贷款卡
        /// </summary>
        [Display(Name = "贷款卡")]
        public string DaiKuanKa { get; set; }

        [Display(Name = "企业资质")]
        public string QiYeZiZhi { get; set; }

        /// <summary>
        /// 关联公司
        /// </summary>
        [Display(Name = "关联公司")]
        public string GuanLianGongSi { get; set; }

        //----------------------子表------------------------------------------
        /// <summary>
        /// 公司用户表
        /// </summary>
        public virtual ICollection<CompanyAccount> CompanyAccount { get; set; }

        public virtual ICollection<CompanyLoan> CompanyLoans { get; set; }

        public virtual ICollection<CompanyRelation> CompanyRelations { get; set; }

        public virtual ICollection<Financing> Financings { get; set; }

        public virtual ICollection<WorkFlow> WorkFlows { get; set; }

    }
}
