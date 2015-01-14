
function JMessage(msg, isError, isRefresh,refresh_url) {
    $('#jmessage').html(msg);
    if (isError != undefined && isError == true) {
        $('#jmessage').showTopbarMessage({ background: "#f00", close: 3000 });
    } else {
        $('#jmessage').showTopbarMessage({ background: "#093", close: 3000 });
    }
    if (isRefresh != undefined && isRefresh == true) {
        if (refresh_url != undefined && refresh_url.length > 0) {
            window.setTimeout("location.href = '" + refresh_url + "';", 2000);
        } else {
            window.setTimeout("window.location.reload();", 2000);
        }
    }
}


function AppDelete(msg, url, fun) {
    if (confirm(msg)) {
        if (url != undefined && url.length > 0) {
            $.post(url, null, function (data) {
                if (data) { $("alert").html(data); };
            });
        }
        return true;
    }
    return false;
}

$(function () {
    $(".active").removeClass("active");
    if (_menuID == undefined) {
        _menuID = 0;
    }
    $("a[mid='" + _menuID + "']").parents(".myli").addClass("active");
    $("a[mid='" + _menuID + "']").parent().addClass("active");

    $("form").attr("data-ajax-complete", "close_submit_div()");
    $("form").attr("data-ajax-complete", "open_submit_div()");
});

function close_modal_div() {
    var id = $(".submitDiv").attr("elementID");
    $(".submitDiv").remove();
    $(".submitbtn").removeClass("disabled").removeAttr("disabled");
}
function open_modal_div() {
    var submitDiv = $("<div class='modal-backdrop fade in submitDiv' style='z-index: 10049;'></div>");
    $("body").append(submitDiv);
    $(".submitbtn").addClass("disabled").attr("disabled", "disabled");
}