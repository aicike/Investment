using System;
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
        Unknown = 0,

        /// <summary>
        /// 营业执照正
        /// </summary>
        YingYeZhiZhao1 = 1,

        ///// <summary>
        ///// 营业执照反
        ///// </summary>
        //YingYeZhiZhao2 = 2,

        /// <summary>
        /// 组织机构代码证正
        /// </summary>
        ZuZhiJiGouDaiMa1 = 3,

        ///// <summary>
        ///// 组织机构代码证反
        ///// </summary>
        //ZuZhiJiGouDaiMa2 = 4,

        /// <summary>
        /// 税务正
        /// </summary>
        ShuiWu1 = 5,

        ///// <summary>
        ///// 税务反
        ///// </summary>
        //ShuiWu2 = 6,

        /// <summary>
        /// 验资报告
        /// </summary>
        YanZiBaoGao = 7,

        ///// <summary>
        ///// 法人身份证 正面
        ///// </summary>
        //FaRen1 = 8,

        ///// <summary>
        ///// 法人身份证 反面
        ///// </summary>
        //FaRen2 = 9,

        ///// <summary>
        ///// 贷款卡
        ///// </summary>
        //DaiKuanKa=10,

        /// <summary>
        /// 开户许可证、信用代码证
        /// </summary>
        KaiHuXuKe_XinYongDaiMa = 11,

        /// <summary>
        /// 公司章程及修正案
        /// </summary>
        GongSiZhangChengJiXiuZhengAn = 12,

        /// <summary>
        /// 工商基本信息查询单
        /// </summary>
        GongShangJiBenXinXiChaXunDan = 13,

        /// <summary>
        /// 公司简介
        /// </summary>
        GongSiJianJie = 14,

        /// <summary>
        /// 企业资质
        /// </summary>
        QiYeZiZhi = 15,

        /// <summary>
        /// 法定代表人（证书）、法定代表人身份证、个人简历
        /// </summary>
        FaRenShenFenZheng_GeRenJianLi = 16,

        /// <summary>
        /// 股东构成、股权结构（及变动情况）、股东基本情况介绍
        /// </summary>
        GuDongGouCheng = 17,

        /// <summary>
        /// 过往房地产开发经验（已开发和正在开发项目简介）
        /// </summary>
        GuoWangFangDiChanKaiFaJingYan = 18,

        /// <summary>
        ///项目公司组织结构（部门/机构设置、人员）
        /// </summary>
        XiangMuGongSiZuZhiJieGou = 19,

        /// <summary>
        ///项目公司管理层简介（包括公司董事、监事、总经理及高级管理人员的基本情况）
        /// </summary>
        XiangMuGongSiGuanLiCengJianJie = 20,

        /// <summary>
        ///关联企业基本情况介绍和对外投资情况介绍
        /// </summary>
        GuanLianQiYeJiBenQingKuangJieShao = 21,

        /// <summary>
        ///征信报告
        /// </summary>
        ZhengXinBaoGao = 22,

        /// <summary>
        /// 股东身份证、个人简历
        /// </summary>
        GuDongShenFenZheng_GeRenJianLi = 23,

        /// <summary>
        /// 公司贷款明细，包含借款主体、期限、金额、方式、抵押或担保情况、到期日、贷款银行等，并提供贷款合同复印件
        /// </summary>
        GongSiDaiKuanMingXi = 24,

        /// <summary>
        /// 公司近三年审计报告
        /// </summary>
        ShenJiBaoGao = 25,

        /// <summary>
        /// 公司最近一年的增值税、营业税、所得税纳税申请表和纳税凭证复印件
        /// </summary>
        ZengZhiShui_YingYeShui_SuoDeShui = 26,

        
        /// <summary>
        /// 房管局档案查询
        /// </summary>
        FangGuanJuDangAnChaXun = 28,

        /// <summary>
        /// 抵押物资料（土地证、房产证、评估报告）
        /// </summary>
        DiYaWuZhiLiao = 29,

        /// <summary>
        /// 近6个月财务报表（资产负债表、利润表和现金流量表）、往来款明细、固定资产清单
        /// </summary>
        ErJiKeMuMingXi = 30,


        /// <summary>
        /// 法人及股东身的征信报告
        /// </summary>
        FaRenJiGuDongZhengXinBaoGao = 31,

        /// <summary>
        /// 项目可研报告
        /// </summary>
        KeXingXingBaoGao = 32,

        /// <summary>
        /// 项目相关批文
        /// </summary>
        XiangMuXiangGuanPiWen = 33,

        /// <summary>
        /// 建设用地规划许可证
        /// </summary>
        WuZheng_1 = 34,

        /// <summary>
        /// 销售明细
        /// </summary>
        XiaoShouMingXi = 35,

        /// <summary>
        /// 施工合同
        /// </summary>
        ShiGongHeTong =36,

        /// <summary>
        /// 审批过程中产生的附件
        /// </summary>
        ShenPiGuoChengFuJian = 37,

        /// <summary>
        /// 融资信息附件全部附件
        /// </summary>
        RongZiXinXiFuJian = 38,

        /// <summary>
        /// 资产清单
        /// </summary>
        ZiChanQingDan = 39,

        /// <summary>
        /// 建设工程规划许可证
        /// </summary>
        WuZheng_2 = 40,

        /// <summary>
        /// 建筑工程施工许可证
        /// </summary>
        WuZheng_3 = 41,

        /// <summary>
        /// 国有土地使用证
        /// </summary>
        WuZheng_4 = 42,

        /// <summary>
        /// 商品房预售许可证
        /// </summary>
        WuZheng_5 = 43,

        ///// <summary>
        ///// 验质证书
        ///// </summary>
        //YanZhiZhengShu = 13,

        ///// <summary>
        ///// 高管简历
        ///// </summary>
        //GaoGuanJianLi = 16,



        ///// <summary>
        ///// 项目简介及效果图
        ///// </summary>
        //XiangMuJianJieJiXiaoGuoTu = 19,

        ///// <summary>
        ///// 融资申请书及还款计划书
        ///// </summary>
        //RongZhiShenQingShuJiHuanKuanJiHuaShu = 21,






        ///// <summary>
        ///// 申请人的所有账号近一年的银行对账单
        ///// </summary>
        //ShenQingRenYinHangDuiZhangDan = 29,


        ///// <summary>
        ///// 公司实际经营者及主要股东个人财产清单及相关产权证书复印件
        ///// </summary>
        //CaiChanQingDan = 31,

        ///// <summary>
        ///// 关联公司资料
        ///// </summary>
        //GuanLianGongSiZiLiao = 32,



    }
}
