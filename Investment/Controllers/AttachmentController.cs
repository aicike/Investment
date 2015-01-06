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

namespace Investment.Controllers
{
    public class AttachmentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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
            var result = attachmentModel.DeleteAttachment(tableId, id);
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
