
//日志列表页点击加载返回
function RollbackLogLoading($item,$this) {
    if ($item.ReturnCode == 0) {
        ToastSimpleMessageError($item.Message);
        isClick = false;
        return;
    }
    if ($item.CustomObject.total_page < pageIndex) {
        return false;
    }
    var html = template('append_html', { list: $item.CustomObject.dyList });
    $(".tbody-table").append(html);
    pagetoal = $item.CustomObject.total_page;
    if (pagetoal > pageIndex) {
        pageIndex++;
        isClick = false;
    }
    else {
        $("#ShowMoreInfo").remove();
    }
}