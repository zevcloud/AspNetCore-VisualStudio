////加载更多.js

//$(function () {
//    if (!jsonData) {
//        console.log("数据加载异常");
//        return;
//    }
//    console.log(jsonData);
//    InitData();//加载初始化数据

//    $("#ShowMoreInfo").click(function () {
//          log_click_loading($(this));
//    });
//})

//function InitData() {
//    //初始化
//    var is_init = jsonData.ReturnCode;
//    if (is_init === 0) {
//        console.log("数据为空,不加载数据");
//        return false;
//    }
//    //数据列表
//    var objectList = jsonData.CustomObject.dyList;
//    var appendHtml = template("append_html", { list: objectList });
//    $(".tbody-table").empty().html(appendHtml);
//    //获取是否还有数据继续渲染
//    var totalCount = jsonData.CustomObject.total_page;
//    if (totalCount > 1) {
//        $("#ShowMoreInfo").fadeIn(1500);
//    }
//}
