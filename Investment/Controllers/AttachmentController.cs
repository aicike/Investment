using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Investment.Models;
using Business;
using Entity;
using Business.Commons;
using System.IO;
using Entity.Enum;

namespace Investment.Controllers
{
    public class AttachmentController : Controller
    {
        #region 全部附件展示

        public ActionResult Index(string Sel_Str)
        {
            List<Attachment> list = null;
            var sel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AttachmentSel>>(Sel_Str);
            if (sel != null)
            {
                AttachmentModel attachmentModel = new AttachmentModel();
                list = attachmentModel.GetAttachment(sel);
            }
            else
            {
                list = new List<Attachment>();
            }
            foreach (var item in list)
            {
                item.EnumAttachmentType_str = GetEnumAttachmentType_Str((EnumAttachmentType)item.EnumAttachmentType);
            }
            return View(list);
        }

        private string GetEnumAttachmentType_Str(EnumAttachmentType eat)
        {
            string str = null;
            switch (eat)
            {
                case EnumAttachmentType.Unknown:
                    str = "未知";
                    break;
                case EnumAttachmentType.YingYeZhiZhao1:
                    str = "营业执照";
                    break;
                case EnumAttachmentType.ZuZhiJiGouDaiMa1:
                    str = "组织机构代码证";
                    break;
                case EnumAttachmentType.ShuiWu1:
                    str = "税务登记证";
                    break;
                case EnumAttachmentType.YanZiBaoGao:
                    str = "验资报告";
                    break;
                case EnumAttachmentType.KaiHuXuKe_XinYongDaiMa:
                    str = "开户许可证、信用代码证";
                    break;
                case EnumAttachmentType.GongSiZhangChengJiXiuZhengAn:
                    str = "公司章程及修正案";
                    break;
                case EnumAttachmentType.GongShangJiBenXinXiChaXunDan:
                    str = "工商基本信息查询单";
                    break;
                case EnumAttachmentType.GongSiJianJie:
                    str = "公司简介";
                    break;
                case EnumAttachmentType.QiYeZiZhi:
                    str = "企业资质";
                    break;
                case EnumAttachmentType.FaRenShenFenZheng_GeRenJianLi:
                    str = "法定代表人（证书）、法定代表人身份证、个人简历";
                    break;
                case EnumAttachmentType.GuDongGouCheng:
                    str = "股东构成、股权结构（及变动情况）、股东基本情况介绍";
                    break;
                case EnumAttachmentType.GuoWangFangDiChanKaiFaJingYan:
                    str = "过往房地产开发经验（已开发和正在开发项目简介）";
                    break;
                case EnumAttachmentType.XiangMuGongSiZuZhiJieGou:
                    str = "项目公司组织结构（部门/机构设置、人员）";
                    break;
                case EnumAttachmentType.XiangMuGongSiGuanLiCengJianJie:
                    str = "项目公司管理层简介（包括公司董事、监事、总经理及高级管理人员的基本情况）";
                    break;
                case EnumAttachmentType.GuanLianQiYeJiBenQingKuangJieShao:
                    str = "关联企业基本情况介绍和对外投资情况介绍";
                    break;
                case EnumAttachmentType.ZhengXinBaoGao:
                    str = "征信报告";
                    break;
                case EnumAttachmentType.GuDongShenFenZheng_GeRenJianLi:
                    str = "股东身份证、个人简历";
                    break;
                case EnumAttachmentType.GongSiDaiKuanMingXi:
                    str = "公司贷款明细，包含借款主体、期限、金额、方式、抵押或担保情况、到期日、贷款银行等，并提供贷款合同复印件";
                    break;
                case EnumAttachmentType.ShenJiBaoGao:
                    str = "公司近三年审计报告";
                    break;
                case EnumAttachmentType.ZengZhiShui_YingYeShui_SuoDeShui:
                    str = "公司最近一年的增值税、营业税、所得税纳税申请表和纳税凭证复印件";
                    break;
                case EnumAttachmentType.FangGuanJuDangAnChaXun:
                    str = "房管局档案查询";
                    break;
                case EnumAttachmentType.DiYaWuZhiLiao:
                    str = "抵押物资料（土地证、房产证、评估报告）";
                    break;
                case EnumAttachmentType.ErJiKeMuMingXi:
                    str = "近6个月财务报表（资产负债表、利润表和现金流量表）、往来款明细、固定资产清单";
                    break;
                case EnumAttachmentType.FaRenJiGuDongZhengXinBaoGao:
                    str = "法人及股东身的征信报告";
                    break;
                case EnumAttachmentType.KeXingXingBaoGao:
                    str = "项目可研报告";
                    break;
                case EnumAttachmentType.XiangMuXiangGuanPiWen:
                    str = "项目相关批文";
                    break;
                case EnumAttachmentType.WuZheng_1:
                    str = "建设用地规划许可证";
                    break;
                case EnumAttachmentType.WuZheng_2:
                    str = "建设工程规划许可证";
                    break;
                case EnumAttachmentType.WuZheng_3:
                    str = "建筑工程施工许可证";
                    break;
                case EnumAttachmentType.WuZheng_4:
                    str = "国有土地使用证";
                    break;
                case EnumAttachmentType.WuZheng_5:
                    str = "商品房预售许可证";
                    break;
                case EnumAttachmentType.XiaoShouMingXi:
                    str = "销售明细";
                    break;
                case EnumAttachmentType.ShiGongHeTong:
                    str = "施工合同";
                    break;
                case EnumAttachmentType.ShenPiGuoChengFuJian:
                    str = "审批过程中产生的附件";
                    break;
                case EnumAttachmentType.RongZiXinXiFuJian:
                    str = "审批过程中产生的附件";
                    break;
                case EnumAttachmentType.ZiChanQingDan:
                    str = "资产清单";
                    break;
                case EnumAttachmentType.DiYaWuQingDan:
                    str = "抵押物清单";
                    break;
                case EnumAttachmentType.HuanKuanLaiYuan:
                    str = "还款来源";
                    break;
                case EnumAttachmentType.XiangMuXianChangHeCha:
                    str = "项目现场核查";
                    break;
                default:
                    str = "未配置";
                    break;
            }
            return str;
        }

        #endregion

        #region 多文件

        public ActionResult Manage(AttachmentControl ac)
        {
            AttachmentModel attachmentModel = new AttachmentModel();
            var attachmentList = attachmentModel.GetAttachment(ac.Table, ac.TableId);
            if (ac.EnumAttachmentType.HasValue)
            {
                attachmentList = attachmentList.Where(a => a.EnumAttachmentType == (int)ac.EnumAttachmentType).ToList();
            }
            ViewBag.AC = ac;
            return PartialView(attachmentList);
        }

        public ActionResult GetJS(string formID, int enumAttachmentType, string table, int tableID)
        {
            string javascrpit = string.Format(
                  @"var new_attachment_count_{0} = 0;
                  var array_attachment_{0} = [];
                  var deleteAttachmentUrl = '/Attachment/DeleteAttachment';
                  $(function () {{
                      var UpImgUrl = '/Ajax/UploadAttachment?enumAttachmentType={2}&table={3}&tableID={4}';
                      $('#file_upload_attachment_{0}').uploadify({{
                          height: 30,
                          swf: '/Scripts/uploadify/uploadify.swf',
                          uploader: UpImgUrl,
                          width: 150,
                          fileSizeLimit: '15MB',
                          buttonText: '上传附件',
                          multi: false,
                          fileTypeExts: '*.jpg;*.jpge;*.gif;*.png;*.bmp;*.doc;*.docx',
                          onUploadSuccess: function (file, data, response) {{
                             if (data == '' || data == undefined || data == 'false') {{
                                 JMessage('上传失败请重新上传！', true);
                                 return;
                             }}
                             var json = JSON.parse(data);
                             new_attachment_count_{0}++;
                             $('#div_newAttachment_{0}').append('<div><span class={1}inline{1} >' + json.FileName + '</span><a style={1}cursor: pointer;margin-left:20px;{1} class={1}inline link_delete_attachment_{0}{1} link_id=' + new_attachment_count_{0} + '>删除</a></div>');
                             array_attachment_{0}.push(json);
                             changeText_{0}();
                          }}
                      }});
                      $('.link_delete_attachment_{0}').live('click', function () {{
                          new_attachment_count_{0}--;
                          var link_id = $(this).attr('link_id');
                          //移除数组
                          array_attachment_{0}.splice(link_id - 1, 1);
                          $(this).parent().remove();
                          changeText_{0}();
                      }});
                      $('.link_delete_old_attachment_{0}').live('click',function () {{
                          if (confirm('删除后将无法还原，确定删除该附件？')) {{
                              var obj=$(this);
                              var tid = obj.attr('tid');
                              var id = obj.attr('link_id');
                              $.post(deleteAttachmentUrl, {{ tableId: tid, id: id }}, function (data) {{
                                  if (data.HasError) {{
                                      JMessage('删除失败！', true);
                                  }} else {{
                                      obj.parent().remove();
                                  }}
                              }}, 'json');
                              return true;
                          }}
                      }});
                  }});
                  function changeText_{0}() {{
                      if (new_attachment_count_{0} <= 0) {{
                          new_attachment_count_{0} = 0;
                          $('#label_new_attachment_{0}').text('');
                      }} else {{
                          $('#label_new_attachment_{0}').text('新附件（' + new_attachment_count_{0} + '）个');
                      }}
                      var json_val = JSON.stringify(array_attachment_{0});
                      $('#hid_attachment_{0}').val(json_val);
                  }}", formID, "\"", enumAttachmentType, table, tableID);
            return JavaScript(javascrpit);
        }

        public ActionResult DeleteAttachment(int tableId, int id)
        {
            AttachmentModel attachmentModel = new AttachmentModel();
            var result = attachmentModel.DeleteAttachment( id);
            return Json(result);
        }

        #endregion

        #region 单文件

        public ActionResult SingleManage(AttachmentControl ac)
        {
            AttachmentModel attachmentModel = new AttachmentModel();
            var attachmentList = attachmentModel.GetAttachment(ac.Table, ac.TableId);
            Attachment obj = null;
            if (ac.EnumAttachmentType.HasValue)
            {
                obj = attachmentList.Where(a => a.EnumAttachmentType == (int)ac.EnumAttachmentType).FirstOrDefault();
            }
            ViewBag.AC = ac;
            return PartialView(obj);
        }


        public ActionResult GetJS_Single(string formID, int enumAttachmentType, string table, int tableID)
        {
            string javascrpit = string.Format(
                  @"var deleteAttachmentUrl = '/Attachment/DeleteAttachment';
                    $(function () {{
                        var UpUrl_Single_{0} = '/Ajax/UploadAttachment_Single?enumAttachmentType={2}&table={3}&tableID={4}';
                        var url_swf = '/plupload-2.0.0/js/Moxie.swf';
                        var url_xap = '/plupload-2.0.0/js/Moxie.xap';
                        var uploader = new plupload.Uploader({{
                            runtimes: 'html5,flash,silverlight,html4',
                            browse_button: 'link_single_{0}', 
                            url: UpUrl_Single_{0},
                            flash_swf_url: url_swf,
                            silverlight_xap_url: url_xap,
                            filters: {{
                                max_file_size: '15mb',
                                mime_types: [{{ title: {1}Image files{1}, extensions:{1}jpg,jpge,gif,png,bmp,doc,docx{1} }}]
                            }},
                            init: {{
                                FilesAdded: function (up, files) {{
                                    plupload.each(files, function (file) {{
                                        
                                    }});
                                uploader.start();
                                }},
                                Error: function (up, err) {{
                                }},
                                UploadComplete: function (up, files) {{
                                }},
                                FileUploaded: function (up, file, info) {{
                                    var result=JSON.parse(info.response).result;
                                    var json_val = JSON.stringify(result);
                                    $('#hid_attachment_{0}').val(json_val);
                                    if(result.EnumAttachmentFormat==1){{
                                        document.getElementById('span_single_{0}').innerHTML =' <a href={1}javascript:;{1} class={1}inline popovers{1} data-trigger={1}hover{1} data-placement={1}bottom{1} data-html={1}true{1} data-content={1}<img style=\'max-width:400px;max-height:400px\' src=\''+result.FileUrl+'\'></img>{1} data-original-title={1}{1}>'+result.FileName+'</a><a style={1}cursor: pointer;margin-left:20px;{1} class={1}inline link_delete_attachment_single_{0}{1}>删除</a>';
                                    }}else{{
                                        document.getElementById('span_single_{0}').innerHTML =' <a href={1}javascript:;{1} class={1}inline popovers{1} data-trigger={1}hover{1} data-placement={1}bottom{1} data-html={1}true{1} data-content={1}无预览内容{1} data-original-title={1}{1}>'+result.FileName+'</a><a style={1}cursor: pointer;margin-left:20px;{1} class={1}inline link_delete_attachment_single_{0}{1}>删除</a>';
                                    }}
                                    App.init();                
                                }},
                            }}
                        }});
                        uploader.init();

                        $('.link_delete_attachment_single_{0}').live('click',function () {{
                              if (confirm('确定删除该附件？')) {{
                                  $(this).parent().html({1}{1});
                                  $('#hid_attachment_{0}').val({1}{1});
                                  return true;
                              }}
                        }});

                        $('.link_delete_attachment_single_old_{0}').live('click',function () {{
                              if (confirm('删除后将无法还原，确定删除该附件？')) {{
                                  var obj=$(this);
                                  var tid = obj.attr('tid');
                                  var id = obj.attr('link_id');
                                  $.post(deleteAttachmentUrl, {{ tableId: tid, id: id }}, function (data) {{
                                      if (data.HasError) {{
                                          JMessage('删除失败！', true);
                                      }} else {{
                                          obj.parent().html({1}{1});
                                          $('#hid_attachment_{0}').val({1}{1});
                                      }}
                                  }}, 'json');
                                  return true;
                              }}
                          }});
                    }});", formID, "\"", enumAttachmentType, table, tableID);
            return JavaScript(javascrpit);
        }

        #endregion

        #region 预览 下载

        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ActionResult ViewOffice(string url)
        {
            Common common = new Common();
            //url = "http://121.42.10.158/test.docx";
            url = "http://video.ch9.ms/build/2011/slides/TOOL-532T_Sutter.pptx";
            var viewUrl = common.GetOfficeUrl(url);
            ViewBag.Url = viewUrl;

            return View();
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FileStreamResult Download(int id)
        {
            AttachmentModel attachmentModel = new AttachmentModel();
            var attachment = attachmentModel.Get(id);
            (attachment != null).NotAuthorizedPage();
            return File(new FileStream(attachment.FilePath, FileMode.Open), "application/octet-stream", Server.UrlEncode(attachment.FileName));
        }

        #endregion

    }
}
