
/*
 // ---
 // Alert & Confirm 窗口组件
 // ---
 示例:
Modal.alert({
    msg: '内容',
    title: '标题',
    okBtn: '确定',
    cancelBtn:'取消',
    type:'info'
});

 Modal.confirm({
     msg: '内容',
     title: '标题',
     okBtn: '确定',
     cancelBtn:'取消',
     type:'question'
 }).on( function (r,ev,el) {
     //callback...
     alert("返回结果：" + r);
 });
 */

;

$.ajaxSetup({
    cache: false,
    error: function (jqXHR, textStatus, errorThrown) {
        toastr.remove();
        switch (jqXHR.status) {
            case(500):
                toastr.error("服务器系统内部错误");
                break;
            case(401):
                toastr.error("未登录");
                break;
            case(403):
                toastr.error("无权限执行此操作");
                break;
            case(408):
                toastr.error("请求超时");
                break;
            case(302):
			    var Redirect = jqXHR.getResponseHeader("X-Redirect");
				Modal.alert({
					msg:'您登陆超时或者无权访问该页，点击"确定"返回登陆页面。',
					type:'error'
				}).on(function(r){
					if(r){
						window.location.href = Redirect;
					}
				});
                break;
            case(0):
                break;
            default:
                toastr.error("未知错误");
        }
    }
});

$(function () {
    //Alert&Confirm窗口模版
    var alertTpl =  '<div id="bs-alert" class="modal" role="dialog">' +
        '<div class="modal-dialog modal-sm"><div class="modal-content">' +
        '<div class="modal-header">' +
        '<button type="button" class="close" data-dismiss="modal">' +
        '<span aria-hidden="true">×</span><span class="sr-only">Close</span></button>' +
        '<h5 class="modal-title"><i class="fa fa-exclamation-circle"></i> [Title]</h5>' +
        '</div>' +
        '<div class="modal-body small">' +
        '<div class="dialog_tip">' +
        '<span class="tip_icon [Type]"></span>' +
        '<div class="text">[Message]</div>' +
        '</div>' +
        '</div>' +
        '<div class="modal-footer" >' +
        '<button type="button" class="btn btn-primary ok" data-dismiss="modal">[OkBtn]</button>' +
        '<button type="button" class="btn btn-default cancel" data-dismiss="modal">[CancelBtn]</button>' +
        '</div></div> </div></div>';

    $(document.body).append($(alertTpl));
    window.Modal = function () {
        var reg = new RegExp("\\[([^\\[\\]]*?)\\]", 'igm');
        var alertEl = $("#bs-alert");
        var alertHtml = alertEl.html();

        var _alert = function (options) {
            alertEl.html(alertHtml);
            alertEl.find('.cancel').hide();
            _dialog(options);
            if(!options.type){
                var msg = alertEl.find('.text').html();
                alertEl.find('.modal-body').html(msg)
            }
            return {
                on: function (callback) {
                    if (callback && callback instanceof Function) {
                        alertEl.find('.ok').click(function (e) {
                            callback(true,e,alertEl);
                        });
                    }
                }
            };
        };

        var _confirm = function (options) {
            alertEl.html(alertHtml);
            alertEl.find('.cancel').show();
            _dialog(options);
            if(!options.type){
                var msg = alertEl.find('.text').html();
                alertEl.find('.modal-body').html(msg)
            }
            return {
                on: function (callback) {
                    if (callback && callback instanceof Function) {
                        alertEl.find('.ok').click(function (e) {
                            callback(true,e,alertEl)
                        });
                        alertEl.find('.cancel').click(function (e) {
                            callback(false,e,alertEl)
                        });
                    }
                }
            };
        };

        var _dialog = function (options) {
            var defaultOptions = {
                msg: "内容",
                title: "提示",
                okBtn: "确定",
                cancelBtn: "取消",
                type: "info",
                width: 400
            };

            $.extend(defaultOptions, options);
            alertEl.find('.modal-dialog').width(defaultOptions.width);
            var html = alertEl.html().replace(reg, function (node, key) {
                return {
                    Title: defaultOptions.title,
                    Message: defaultOptions.msg,
                    OkBtn: defaultOptions.okBtn,
                    CancelBtn: defaultOptions.cancelBtn,
                    Type: defaultOptions.type
                }[key];
            });

            alertEl.html(html);
            alertEl.modal({
                backdrop: 'static'
            }).on('hidden.bs.modal', function (e) {
                alertEl.find('.modal-dialog').width(300);
            })
        };
        return {
            alert: _alert,
            confirm: _confirm
        }
    }();
});


/*
// ---
// 加载组件
// ---
示例：
 loader.show({msg:'加载中...'});
 loader.hide();
*/


;$(function () {
    var loaderTpl = '<div class="modal" id="loader"><div class="loaderwrap"><div class="loader"></div><span></span></div></div>';
    window.loader = function () {
    	var defaultOptions = {msg:''};
    	
       var _show = function(options){
           if( $('#loader').length){
               $('#loader').remove();
           }
           
           $.extend(defaultOptions, options);
           $(document.body).append($(loaderTpl));
           $('#loader').find('span').html(defaultOptions.msg);

           $('#loader').show();
           $('#loader .loaderwrap').css({
               'margin-left': Math.round('-' + $('#loader .loaderwrap').width() / 2),
               'margin-top': Math.round('-' + $('#loader .loaderwrap').height() / 2)
           })
       };
        var _hide = function(){
            $('#loader').remove();
       };

       var _update = function(options) {
           $.extend(defaultOptions, options);
       	   $('#loader').find('span').html(defaultOptions.msg);
       }

        return{
            show: _show,
            hide: _hide,
            update:_update,
        }
    }()
})

/* center modal */
function centerModals(){
    $('.modal').each(function(i){
        var $clone = $(this).clone().css('display', 'block').appendTo('body');
        var top = Math.round(($clone.height() - $clone.find('.modal-content').height()) / 2);
        top = top > 0 ? top : 0;
        $clone.remove();
        $(this).find('.modal-content').css("margin-top", top);
    });
    //$('.modal-body').on('resize', centerModals);
    if($.fn.placeholder){$('input, textarea').placeholder()}
};
$(document).on('loaded.bs.modal','.modal', centerModals);
$(document).on('show.bs.modal',".modal", centerModals);
$(window).on('resize', centerModals);


//toastr全局配置
toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-top-center",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "1500",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut",
    "onShow":function(el){
        //使toast-top-center根据内容居中
        $(el).css('margin-left','-'+($(el).width()+65)/2+'px');
        var fixTop = 0;
        if($(el).parent().find('.toast').length > 1){
            $(el).parent().find('.toast').each(function(i,e){
                if(i==1) return;
                fixTop += $(this).height() + 30;
            });
            $(el).css('top',fixTop + 'px');
        }
    }
};


