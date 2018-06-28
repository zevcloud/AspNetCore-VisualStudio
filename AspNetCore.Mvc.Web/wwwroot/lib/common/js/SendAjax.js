var SendAjaxParameter = {};

var pageIndex = 2;//默认分页第二页
var pagetoal=1;//总页数
var isClick = false;//是否可以继续点击
SendAjaxParameter.OperActionKeyQuery = "Query";//查询
SendAjaxParameter.OperActionKeyPost = "Post";//新增/修改
SendAjaxParameter.OperActionKeyDelete = "Delete";//删除
SendAjaxParameter.OperActionKeyExport = "Export";//导出

$(function () {
    var jsLoad = '<script src="/lib/common/js/SendKey.js"></script>' +
        '<script src="/lib/common/js/SendRespone.js"></script>';
    var head = $("head").html();
    $("head").append(jsLoad);
})


///发送Ajax指令
function SendAjaxCloudRequire($this, url, data, key) {
    var currentVal = $($this).val();
    $.ajax({
        url: url,
        data: data,
        dataType: "json",
        type: "post",
        beforeSend: function () {
            $($this).attr("disabled", true);
            $($this).val("请求中...请稍后");
        },
        success: function (item) {
            SendAjaxCloudCallBack(item, key, $this);
        }, error: function () {
            ToastSimpleMessageError("Connection Failure");
            return false;
        }, complete: function () {
            $($this).removeAttr("disabled", true);
            $($this).val(currentVal);
        }
    });
}

//Success返回指令
function SendAjaxCloudCallBack(item, key, $this) {
    switch (key) {
        case SendActionKey["log_click_loading"]:
            RollbackLogLoading(item, $this);
            break;
    }
}

//日志加载列表
function log_click_loading($this) {
    var api = "/api/query/log";
    var data = {
        keyword: "",
        pageIndex: pageIndex,
        operId: -1
    };
    SendAjaxCloudRequire($this, api, data, SendActionKey["log_click_loading"]);
}
