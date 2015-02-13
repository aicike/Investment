
/**
* 消息提示
* @param                {String}                消息内容
* @param                {bool}                  是否错误消息(默认true)
* @param                {bool}                  是否刷新(默认false)
* @param                {String}                刷新URL(可选)
* @param                {millisecond}           刷新等待时间(单位毫秒)
*/
function JMessage(msg, isError, isRefresh, refresh_url, millisecond) {
    $('#jmessage').html(msg);
    if (isError != undefined && isError == true) {
        $('#jmessage').showTopbarMessage({ background: "#f00", close: 3000 });
    } else {
        $('#jmessage').showTopbarMessage({ background: "#093", close: 3000 });
    }
    if (isRefresh != undefined && isRefresh == true) {
        if (millisecond == undefined) {
            millisecond = 2000;
        }
        if (refresh_url != undefined && refresh_url.length > 0) {
            window.setTimeout("location.href = '" + refresh_url + "';", millisecond);
        } else {
            window.setTimeout("window.location.reload();", millisecond);
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
    try {
        $(".active").removeClass("active");
        if (_menuID == undefined) {
            _menuID = 0;
        }
        $("a[mid='" + _menuID + "']").parents(".myli").addClass("active");
        $("a[mid='" + _menuID + "']").parent().addClass("active");
    } catch (e) {

    }
    //处理双击问题
    $("form").attr("data-ajax-complete", "close_modal_div()");
    $("form").attr("data-ajax-begin", "open_modal_div()");
    $(":button:enabled,a:enabled").addClass("submitBtn").click(function () {
        var obj = $(this);
        obj.addClass("disabled").attr("disabled", "disabled");
        var resetfun = function () {
            obj.removeClass("disabled").removeAttr("disabled");
        }
        window.setTimeout(resetfun(), 3000);
    });

    //处理内容页面最小高度问题
    var windowHeight = document.body.scrollHeight;
    var contentHeight = windowHeight - 80;
    $(".page-content").css("min-height", contentHeight);

    //处理页面未加载完成就立即操作问题
    close_modal_div();
});

//处理双击问题
function close_modal_div() {
    var id = $(".submitDiv").attr("elementID");
    $(".submitDiv").remove();
    $(".submitbtn").removeClass("disabled").removeAttr("disabled");
}
function open_modal_div() {
    var submitDiv = $("<div class='modal-backdrop fade in submitDiv' style='z-index: 10049;'><div style='top: 40%;position: absolute;width:100%'><div style='margin: 0px auto;width: 300px;width: 300px;text-align: center;color:#fff;font-size: 28px;font-weight: bolder;'><img src='/image/DD.gif'>请&nbsp;&nbsp;稍&nbsp;&nbsp;等&nbsp;.&nbsp;.&nbsp;.</div></div></div>");
    $("body").append(submitDiv);
    $(".submitbtn").addClass("disabled").attr("disabled", "disabled");
}


//单元格合并
jQuery.fn.rowspan = function (colIdx) { //封装的一个JQuery小插件 
    return this.each(function () {
        var that;
        $('tr', this).each(function (row) {
            $('td:eq(' + colIdx + ')', this).filter(':visible').each(function (col) {
                if (that != null && $(this).html() == $(that).html()) {
                    rowspan = $(that).attr("rowSpan");
                    if (rowspan == undefined) {
                        $(that).attr("rowSpan", 1);
                        rowspan = $(that).attr("rowSpan");
                    }
                    rowspan = Number(rowspan) + 1;
                    $(that).attr("rowSpan", rowspan);
                    $(this).hide();
                }
                else {
                    that = this;
                }
            });
        });
    });
}


//teatArea高度自动

/**
* 文本框根据输入内容自适应高度
* @param                {HTMLElement}        输入框元素
* @param                {Number}                设置光标与输入框保持的距离(默认0)
* @param                {Number}                设置最大高度(可选)
*/
var autoTextarea = function (elem, extra, maxHeight) {
    extra = extra || 0;
    var isFirefox = !!document.getBoxObjectFor || 'mozInnerScreenX' in window,
        isOpera = !!window.opera && !!window.opera.toString().indexOf('Opera'),
                addEvent = function (type, callback) {
                    elem.addEventListener ?
                                elem.addEventListener(type, callback, false) :
                                elem.attachEvent('on' + type, callback);
                },
                getStyle = elem.currentStyle ? function (name) {
                    var val = elem.currentStyle[name];

                    if (name === 'height' && val.search(/px/i) !== 1) {
                        var rect = elem.getBoundingClientRect();
                        return rect.bottom - rect.top -
                                        parseFloat(getStyle('paddingTop')) -
                                        parseFloat(getStyle('paddingBottom')) + 'px';
                    };

                    return val;
                } : function (name) {
                    return getComputedStyle(elem, null)[name];
                },
                minHeight = parseFloat(getStyle('height'));

    elem.style.resize = 'none';

    var change = function () {
        var scrollTop, height,
                        padding = 0,
                        style = elem.style;

        if (elem._length === elem.value.length) return;
        elem._length = elem.value.length;

        if (!isFirefox && !isOpera) {
            padding = parseInt(getStyle('paddingTop')) + parseInt(getStyle('paddingBottom'));
        };
        scrollTop = document.body.scrollTop || document.documentElement.scrollTop;

        elem.style.height = minHeight + 'px';
        if (elem.scrollHeight > minHeight) {
            if (maxHeight && elem.scrollHeight > maxHeight) {
                height = maxHeight - padding;
                style.overflowY = 'auto';
            } else {
                height = elem.scrollHeight - padding;
                style.overflowY = 'hidden';
            };
            style.height = height + extra + 'px';
            scrollTop += parseInt(style.height) - elem.currHeight;
            document.body.scrollTop = scrollTop;
            document.documentElement.scrollTop = scrollTop;
            elem.currHeight = parseInt(style.height);
        };
    };

    addEvent('propertychange', change);
    addEvent('input', change);
    addEvent('focus', change);
    change();
};