$(function () {
    $(".btnCommitOpinion").click(function () {
        try {
            var url = $(this).attr("commit");
            var value = $(this).parent().parent().find(".txtCommitOpinion").val().trim();
            var approvalrecord = $(this).attr("status");
            if (approvalrecord == "approvalrecord2" || approvalrecord == "approvalrecord3") {
                if (value.length <= 0) {
                    JMessage("请填写审批意见。", true);
                    return false;
                }
            }
            open_modal_div();
            var returnID = 0;
            if (approvalrecord == "approvalrecord2") {
                returnID = $("#select_return").val();
            }
            if (returnID != 0) {
                $.post(url, { WorkFlowID: CommitOpinion_WorkFlowID, Opinion: value, Node: returnID }, function (result) {
                    close_modal_div();
                    if (result.HasError) {
                        JMessage("操作失败，请联系管理员。", true);
                    } else {
                        window.location = "/WorkFlow/Backlog";
                    }
                });
            } else {
                $.post(url, { WorkFlowID: CommitOpinion_WorkFlowID, Opinion: value }, function (result) {
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
});
