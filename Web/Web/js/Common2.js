//////////////////////////////////////////////////////////////////
// JScript 文件
//通过验证提示
var ThroughTooltip = "<img src='true.jpg'/>";
var ValidatorForm = {
    Regeexp: {
        identitycode: /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])(\d{4}|\d{3}x)$/i, //身份证
        phoneormobile: /(^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$)|(^((\(\d{3}\))|(\d{3}\-))?(1[358]\d{9})$)/, //手机或电话号码     
        mobile: /^15[0123689]|18[689]|13[068]\d{8}$/, //手机
        phone: /(^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$)/, //电话号码的函数(包括验证国内区号,国际区号,分机号)
        postalcode: /^[1-9][0-9]{5}$/, //邮政编码       
        fax: /^(\d{3,4}-)?\d{7,8}$/, //传真       
        email: /^[a-z\d]+(\.[a-z\d]+)*@([\da-z](-[\da-z])?)+(\.{1,2}[a-z]+)+$/, //电子邮箱        
        float: /^(\-?\d{0,8}\.?\d{0,4}|10\.?{0-4})$/, //小数   
        integer: /^[0-9]*$/, //整数
        onlynumber: /^\-?\d+\.?\d+$/, //数字
        blankerror: /\s+/, //空字符
        onlychinese: /^[\u2e80-\u9fff]+$/, //只能是中文
        hasnotchinese: /[\u2e80-\u9fff]/, //含有中文 
        dataortime: /^([1-9]\d{3}|([1-9]\d{3}\-(0?[0-9]|1[0-2])\-(0?[0-9]|[1-2]\d|3[0-1]))|([1-9]\d{3}\/(0?[0-9]|1[0-2])\/(0?[0-9]|[1-2]\d|3[0-1])))$/
    },
    //非空验证,(验证控件编号，提示文字，提示标记编号)
    NotNullValidator: function (ID, Tooltip, LabelID) {
        if ($("#" + ID).val() == "") {
            $("#" + LabelID).html(Tooltip);
            return false;
        }
        else {
            $("#" + LabelID).html(ThroughTooltip);
        }
    },
    //手机验证,(验证控件编号，提示文字，提示标记编号)
    Mobile: function (ID, Tooltip, LabelID) {
        if (!ValidatorForm.Regeexp.mobile.test($("#" + ID).val())) {
            $("#" + LabelID).html(Tooltip);
            return false;
        }
        else {
            $("#" + LabelID).html(ThroughTooltip);
        }
    },
    //邮箱验证,(验证控件编号，提示文字，提示标记编号)
    Email: function (ID, Tooltip, LabelID) {
        if (!ValidatorForm.Regeexp.email.test($("#" + ID).val())) {
            $("#" + LabelID).html(Tooltip);
            return false;
        }
        else {
            $("#" + LabelID).html(ThroughTooltip);
        }
    },
    //电话号码验证,(验证控件编号，提示文字，提示标记编号)
    Phone: function (ID, Tooltip, LabelID) {
        if (!ValidatorForm.Regeexp.phone.test($("#" + ID).val())) {
            $("#" + LabelID).html(Tooltip);
            return false;
        }
        else {
            $("#" + LabelID).html(ThroughTooltip);
        }
    },
    //传真验证,(验证控件编号，提示文字，提示标记编号)
    Fax: function (ID, Tooltip, LabelID) {
        if (!ValidatorForm.Regeexp.fax.test($("#" + ID).val())) {
            $("#" + LabelID).html(Tooltip);
            return false;
        }
        else {
            $("#" + LabelID).html(ThroughTooltip);
        }
    },
    //整数,(验证控件编号，提示文字，提示标记编号)
    Integer: function (ID, Tooltip, LabelID) {
        if (!ValidatorForm.Regeexp.integer.test($("#" + ID).val())) {
            $("#" + LabelID).html(Tooltip);
            return false;
        }
        else {
            $("#" + LabelID).html(ThroughTooltip);
        }
    }
};