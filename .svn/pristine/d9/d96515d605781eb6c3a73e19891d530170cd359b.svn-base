
var editTableAjax = {};

var editTableUrl = new Array();
editTableUrl[0] = "/api/update/rolename1d";//修改权限名称

var editTableKey = {};
editTableKey.UpdateRoleName = 0;

//提交
editTableAjax.TranSubmit = function ($this, $key, $value) {
    id = $($this).attr("id");
    value = $($value);
    var data = JSON.stringify({
        "id": id,
        "value": value
    });
    if (!editTableAjax.GetUrl($key)) {
        return false;
    }
    var url = editTableAjax.GetUrl($key);
    var send = editTableAjax.Send(url, data);
    return send;
};

//获取URL
editTableAjax.GetUrl = function (_key) {
    try {
        var result = editTableUrl[_key];
        if (!result) {
            throw "获取URL错误";
        }
        return result;
    }
    catch (error) {
        alert(error);
        return "";
    }
}

//发送ajax、请求
editTableAjax.Send = function (url, data) {
    var result = "连接服务器失败";
    var errorcode = 0;
    var sendResult = [];
    $.ajax({
        url: url,
        data: data,
        dataType: "json",
        type: "post",
        async: false,
        success: function (item) {
            sendResult.push({
                result: item.msg,
                errorcode: item.error
            });       
        }, error: function () {
            sendResult.push({
                result: result,
                errorcode: errorcode
            })
           
        }
    });
    return sendResult;
}