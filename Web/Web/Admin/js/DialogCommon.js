//封装的方法
//DG.removeBtn('ok'); 移除按钮，ok为id

//取消
function cancel() {
    var dg = frameElement.lhgDG;
    dg.cancel();
}

///////////////////////////-----reload------//////////////////////////////
//刷新父窗体
function reload1() {
    frameElement.lhgDG.curWin.location.reload();
}
//弹出提示，刷新父窗体
function reload2(msg) {
    var dialogObject = new J.showLayer({
        title: '提示框',
        html: msg, minBtn: false, maxBtn: false,
        cancelBtnTxt: '确定', xButton: false,
        width: 200, height: 100,
        onCancel: function () { reload1(); }
    });
    dialogObject.ShowshowLayer();
}

//刷新父窗体
function reload(msg) {
    if (msg == null) {
        reload1();
    }
    else {
        reload2(msg);
    }
}

////////////////////////////////---------Dialog----------//////////////////////////////

//titleValue标题，linkUrl连接路径，widthValue宽度，heightValue高度
function showLayer(titleValue, linkUrl, widthValue, heightValue) {
    var dialogObject = new J.showLayer({ page: thisAddress+linkUrl,
        width: widthValue, height: heightValue, title: titleValue,
        cancelBtn: true, btnBar: true
    });
    dialogObject.ShowshowLayer();
}

////////////////////////////////////////////////--alert---/////////////////////////////////////

//提示内容
function alert1(msg) {
    var dialogObject = new J.showLayer({ title: '提示框', html: msg, minBtn: false, maxBtn: false,
        cancelBtnTxt: '确定', xButton: false, width: 300, height: 150
    });
    dialogObject.ShowshowLayer();
}
function alert2(msg, url) {
    var dialogObject = new J.showLayer({ title: '提示框', html: msg, width: 200, height: 100, minBtn: false,
        maxBtn: false, cancelBtnTxt: '确定', xButton: false,
        onCancel: function () { window.location = url; }
    });
    dialogObject.ShowshowLayer();
}

//提示内容并且跳转到指定页面
function alert(msg, url) {
    if (url == null) {
        alert1(msg);
    }
    else {
        alert2(msg, url);
    }
}

//J('.runCss').showLayer({title:"" ,html:"1.htm",timer:2,minBtn:false ,maxBtn:false,xButton:false,cancelBtn:true,btnBar:true,cancelBtnTxt:'确定',onCancel:function(){alert('提示窗！！！');}});
