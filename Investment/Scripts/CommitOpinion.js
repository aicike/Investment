$(function () {
    $(".btnCommitOpinion").click(function () {
        var url = $(this).attr("commit");
        var value = $(this).parent().parent().find(".txtCommitOpinion").val().trim();
        $.post(url, { WorkFlowID: CommitOpinion_WorkFlowID, Opinion: value }, function (result) {

        });
    });
});
