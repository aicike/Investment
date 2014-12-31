var new_attachment_count = 0;
var array_attachment = [];
$(function () {
    var UpImgUrl = '/Ajax/UploadAttachment';
    $("#file_upload_attachment").uploadify({
        height: 30,
        swf: '/Scripts/uploadify/uploadify.swf',
        uploader: UpImgUrl,
        width: 150,
        fileSizeLimit: '10MB',
        buttonText: '上传附件',
        multi: false,
        fileTypeExts: '*.jpg;*.jpge;*.gif;*.png;*.bmp;*.doc;*.docx',
        onUploadSuccess: function (file, data, response) {
            if (data == "" || data == undefined || data == "false") {
                JMessage("上传失败请重新上传！", true);
                return;
            }
            var json = JSON.parse(data);
            new_attachment_count++;
            $("#div_newAttachment").append("<div><span class='inline' >" + json.FileName + "</span><a style='cursor: pointer;margin-left:20px;' class='inline link_delete_attachment' link_id='" + new_attachment_count + "'>删除</a></div>");
            changeText();
            array_attachment.push(data);
        }
    });

    $('.link_delete_attachment').live("click", function () {
        new_attachment_count--;
        var link_id = $(this).attr("link_id");
        //移除数组
        array_attachment.splice(link_id - 1, 1);
        $(this).parent().remove();
        changeText();

    });
})
function changeText() {
    if (new_attachment_count <= 0) {
        new_attachment_count = 0;
        $("#label_new_attachment").text("");
    } else {
        $("#label_new_attachment").text("新附件（" + new_attachment_count + "）个");
    }
    var json_val = JSON.stringify(array_attachment);
    $("#hid_attachment").val(json_val);
}