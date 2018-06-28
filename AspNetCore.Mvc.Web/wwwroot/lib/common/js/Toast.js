

function ToastSimpleMessageError(msg) {
    layer.alert(msg, {
        icon: 5,
        title:"错误!",
    });
}

function ToastSimpleMessageSuccess(msg) {
    layer.alert(msg, {
        icon: 6,
        title: "成功!",
    });
}