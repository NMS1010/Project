$.ajaxSetup({
    beforeSend: function () {
        $("#loader").show()
    },
    complete: function () {
        $("#loader").hide()
    },
    //success: function () {
    //    $("#loader").hide()
    //}
});
$(function () {
    var url = window.location.pathname;
    urlRegExp = new RegExp(url.replace(/\/$/, '') + "$");
    if (url == '/') {
        $('#home').addClass('active');
    } else {
        $('#home').removeClass('active');
    }
    $('a').each(function () {
        $(this).parent().find('a').removeClass('active');
        if (url == '/') {
            $('#home').addClass('active');
        }
        if (urlRegExp.test(this.href.replace(/\/$/, '')) && url != "/") {
            $(this).addClass('active');
        }
    });
});
function goback() {
    //window.history.back();
    history.back();
    history.go(-1);
    return false;
}

$(document).on('focus', ':input', function () {
    $(this).attr('autocomplete', 'off');
});
var config = {
    STATUS_API: {
        SUCCESS: 200,
        ERROR: 500,
        MISSING_PARAM: 400,
        VALIDATE: 300
    }
}

function renderActionAjax(controllerName, actionName, idvTab) {
    $.ajax({
        type: "GET",
        //url: '@Url.Action('+ actionName+', '+controllerName+')',
        url: '../../' + controllerName + '/' + actionName,
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        cache: false,
        success: function (response) {
            $(idvTab).html(response)
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function renderActionAjaxPost(controllerName, actionName, idvTab) {
    $.ajax({
        type: "POST",
        url: '../../' + controllerName + '/' + actionName,
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        cache: false,
        success: function (response) {
            $(idvTab).html(response)
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}
function deleteAjax(text_confirm, url, id) {
    if (confirm(text_confirm)) {
        callAPI(url, { id: id }, function (res) {
            window.location.reload();
        }, true)
    }
}
function display(message) {
    alert(message);
}

function get(url, data, callback, state) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        data: data,
        cache: false,
        success: function (response) {
            if (state)
                return callback(response);
            if (response.code == 200) {
                if (callback && typeof callback == "function")
                    return callback(response.data);
            }
            return callback(false);
        },
        error: function (response) {
            if (callback && typeof callback == "function")
                return callback({ error: "Hệ thống đang bận. Vui lòng thử lại sau" });
        }
    });
}

function callAPI(url, data, callback, state) {
    $.ajax({
        type: "POST",
        url: url,
        dataType: "json",
        data: data,
        cache: false,
        success: function (response) {
            if (state)
                return callback(response);
            if (response.code == 200) {
                if (callback && typeof callback == "function")
                    return callback(response.data);
            }
            return callback(false);
        },
        error: function (response) {
            if (callback && typeof callback == "function")
                return callback({ error: "Hệ thống đang bận. Vui lòng thử lại sau" });
        }
    });
}
function callAPIBCT(url, data, callback, state) {
    $.ajax({
        type: "POST",
        url: url,
        contentType: false,
        processData: false,
        data: data,
        cache: false,
        success: function (response) {
            if (state)
                return callback(response);
            if (response.code == 200) {
                if (callback && typeof callback == "function")
                    return callback(response.data);
            }
            return callback(false);
        },
        error: function (response) {
            if (callback && typeof callback == "function")
                return callback({ error: "Hệ thống đang bận. Vui lòng thử lại sau" });
        }
    });
}
function callAPIPost(url, data, callback, state) {
    $.ajax({
        type: "POST",
        url: url,
        dataType: "json",
        data: data,
        cache: false,
        success: function (response) {
            if (state)
                return callback(response);
            if (response.code == 200) {
                if (callback && typeof callback == "function")
                    return callback(response.data);
            }
            return callback(false);
        },
        error: function (response) {
            if (callback && typeof callback == "function")
                return callback({ error: "Hệ thống đang bận. Vui lòng thử lại sau" });
        }
    });
}

function callAPIFile(url, data, callback, state) {
    $.ajax({
        type: "POST",
        url: url,
        data: data,
        cache: false,
        contentType: false,
        processData: false,
        success: function (response) {
            if (state)
                return callback(response);;
            if (response.code == 200) {
                if (callback && typeof callback == "function")
                    return callback(response.data);
            }
            return callback(false);
        },
        error: function (response) {
            if (callback && typeof callback == "function")
                return callback({ error: "Hệ thống đang bận. Vui lòng thử lại sau" });
        }
    });
}
function callAPIHtml(url, method, data, callback, state) {
    $.ajax({
        type: method,
        url: url,
        dataType: "html",
        data: data,
        cache: false,
        success: function (response) {
            if (state)
                return callback(response);
            if (response.code == 200) {
                if (callback && typeof callback == "function")
                    return callback(response.data);
            }
            return callback(false);
        },
        error: function (response) {
            if (callback && typeof callback == "function")
                return callback({ error: "Hệ thống đang bận. Vui lòng thử lại sau" });
        }
    });
}

function getDataTable2(idTable, scrollX, scrollY, paging, bInfo, searching) {
    var t = $(idTable).DataTable();
    return t;
}
function getDataTable(idTable, scrollX, scrollY, paging, bInfo, searching) {
    var t = $(idTable).DataTable({
        "scrollY": scrollY,
        "scrollX": scrollX,
        "bAutoWidth": true,
        "paging": paging,
        "bInfo": bInfo,
        "scrollCollapse": false,
        "searching": searching,
        "language": {
            "search": "Tìm kiếm nhanh:",
            "lengthMenu": "Hiển thị _MENU_ dòng mỗi trang",
            "zeroRecords": "Xin lỗi, không tìm thấy dữ liệu !",
            "info": "Trang _PAGE_ / _PAGES_",
            "infoEmpty": "Không có dữ liệu !",
            "infoFiltered": "(đã lọc từ tổng _MAX_ dòng)",
            "paginate": {
                "first": "Trang đầu",
                "last": "Trang cuối",
                "next": "Tiếp",
                "previous": "Trước"
            },
            "columnDefs": [{
                "searchable": false,
                "orderable": false,
                "targets": 0
            }],
            "order": [[1, 'asc']],
        }
    });
    //t.columns.adjust().draw();
    //t.columns.adjust();
    $(".dataTables_scroll").css('overflow', 'auto');
    t.on('order.dt search.dt', function () {
        t.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();

    $(".collapse.in").each(function () {
        $(this).siblings(".panel-heading").find(".glyphicon").addClass("glyphicon-minus").removeClass("glyphicon-plus");
    });

    // Toggle plus minus icon on show hide of collapse element
    $(".collapse").on('show.bs.collapse', function () {
        $(this).parent().find(".glyphicon").removeClass("glyphicon-plus").addClass("glyphicon-minus");
    }).on('hide.bs.collapse', function () {
        $(this).parent().find(".glyphicon").removeClass("glyphicon-minus").addClass("glyphicon-plus");
    });

    t.columns.adjust().draw();

    return t;
}
function stt(t) {
    $(".dataTables_scroll").css('overflow', 'auto');
    t.on('order.dt search.dt', function () {
        t.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
}

function updateSelect(id, val, text, selected) {
    $("#" + id).append(new Option(text, val));
    if (selected) {
        $("#" + id).val(val);
    }
}
function updateSelectize(selectize, val, text, selected) {
    selectize.addOption({
        value: val,
        text: text
    });
    selectize.refreshOptions();
    if (selected) {
        selectize.setValue(val);
    }
}
function convertArrayToQuery(array, prefix) {
    if (array.length > 0) {
        var qr = "";
        for (var i = 0; i < array.length; i++) {
            qr += "&" + prefix + "=" + array[i];
        }
        return qr;
    } else {
        return "";
    }
}

function clearSelectize(id) {
    var $select = $(id).selectize();
    var control = $select[0].selectize;
    control.clear();
}