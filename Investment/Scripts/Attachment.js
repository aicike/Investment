$(function () {
    var UpImgUrl = '@Url.Action("UploadImage", "Ajax")';

    $("#file_upload_zhengben").uploadify({
        height: 30,
        swf: '/Scripts/uploadify/uploadify.swf',
        uploader: UpImgUrl,
        width: 150,
        fileSizeLimit: '5MB',
        buttonText: '上传营业执照（正本）',
        multi: false,
        fileTypeExts: '*.jpg;*.jpge;*.gif;*.png;*.bmp',
        onUploadSuccess: function (file, data, response) {
            if (data == "" || data == undefined || data == "false") {
                JMessage("上传失败请重新上传！", true);
                return;
            }
            var json = JSON.parse(data);
            $("#imgYingYeZhiZhao_zhengben").attr('src', json.FileUrl);
            $("#hidYingYeZhiZhao_zhengben").val(data);
        }
    });
})