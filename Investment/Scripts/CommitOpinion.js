$(function () {
    $(".btnCommitOpinion").click(function () {
        try {
            var url = $(this).attr("commit");
            var CustomFun_Json = $(this).attr("CustomFun");
            if (CustomFun_Json == undefined || CustomFun_Json == null) {
                CustomFun_Json = "";
            }
            var value = $(this).parent().parent().find(".txtCommitOpinion").val().trim();
            var approvalrecord = $(this).attr("status");
            if (approvalrecord == "approvalrecord2" || approvalrecord == "approvalrecord3") {
                if (value.length <= 0) {
                    JMessage("请填写审批意见。", true);
                }
            }
            open_modal_div();
            var returnID = 0;
            if (approvalrecord == "approvalrecord2") {
                returnID = $("#select_return").val();
            }
            var hid_attachment = "";
            hid_attachment = $("#hid_attachment_1").val();


            if (returnID != 0) {
                //驳回
                $.post(url, { WorkFlowID: CommitOpinion_WorkFlowID, Opinion: value, Node: returnID }, function (result) {
                    close_modal_div();
                    if (result.HasError) {
                        JMessage("操作失败，请联系管理员。", true);
                    } else {
                        window.location = "/WorkFlow/Backlog";
                    }
                });
            } else {
                //同意，不同意
                $.post(url, { WorkFlowID: CommitOpinion_WorkFlowID, Opinion: value, hid_attachment: hid_attachment, CustomFun_Json: CustomFun_Json }, function (result) {
                    close_modal_div();
                    if (result.HasError) {
                        JMessage("操作失败，请联系管理员。", true);
                    } else {
                        window.location = "/WorkFlow/Backlog";
                    }
                });
            }
        } catch (e) {
            close_modal_div();
        }
    });
    $("#responsive_1,#btn_attachment_close_1").click(function (e) {
        $(".modal-backdrop:last").click();
        e.stopPropagation();
    });
});
