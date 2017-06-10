//////////////////////////////////////////////////////////////////
// JScript 文件
//通过验证提示
var ThroughTooltip = "";

//验证
var ValidatorForm = {
    Regeexp: {
        identitycode: /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])(\d{4}|\d{3}x)$/i, //身份证
        phoneormobile: /(^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$)|(^((\(\d{3}\))|(\d{3}\-))?(1[358]\d{9})$)/, //手机或电话号码     
        mobile: /^15[0123689]|18[689]|13[068]\d{8}$/, //手机
        phone: /^(([0\\+]\\d{2,3}-)?(0\\d{2,3})-)?(\\d{7,8})(-(\\d{3,}))?$/, //电话号码的函数(包括验证国内区号,国际区号,分机号)
        postalcode: /^[1-9][0-9]{5}$/, //邮政编码       
        fax: /^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$/, //传真       
        email: /^[a-z\d]+(\.[a-z\d]+)*@([\da-z](-[\da-z])?)+(\.{1,2}[a-z]+)+$/, //电子邮箱        
        float: /^(\-?\d{0,8}\.?\d{0,4}|10\.?{0-4})$/, //小数   
        integer: /^[0-9]*$/, //整数
        onlynumber: /^\-?\d+\.?\d+$/, //数字
        blankerror: /\s+/, //空字符
        onlychinese: /^[\u2e80-\u9fff]+$/, //只能是中文
        hasnotchinese: /[\u2e80-\u9fff]/, //含有中文 
        dataortime: /^([1-9]\d{3}|([1-9]\d{3}\-(0?[0-9]|1[0-2])\-(0?[0-9]|[1-2]\d|3[0-1]))|([1-9]\d{3}\/(0?[0-9]|1[0-2])\/(0?[0-9]|[1-2]\d|3[0-1])))$/
    },
    //非空验证
    NotNullValidator: function (val) {
        if (val == "") {
            return false;
        }
    },
    //手机验证
    Mobile: function (val) {
        return ValidatorForm.Regeexp.mobile.test(val);
    },
    //邮箱验证
    Email: function (val) {
         return ValidatorForm.Regeexp.email.test(val);
    },
    //电话号码验证
    Phone: function (val) {
        return ValidatorForm.Regeexp.phone.test(val);
    },
    //传真验证
    Fax: function (val) {
        return ValidatorForm.Regeexp.fax.test(val);
    },
    //整数
    Integer: function (val) {
        return ValidatorForm.Regeexp.integer.test(val);
    },
    //数字
    OnlyNumber: function (val) {
        return ValidatorForm.Regeexp.onlynumber.test(val);
    },
    //小数
    Float: function (val) {        
        return ValidatorForm.Regeexp.float.test(val);
    }
};

//表单验证
function VerificationForm(GroupName) {
    var b = true;
    $("[GroupName='" + GroupName + "']").each(function () {
        var LabelID=this.attributes["LabelID"].value;//提示标签的ID
        if (this.value == "") {   
            $("#" + LabelID).html("请输入"+this.title + "！");
            $("#" + LabelID).css("color","red");
            b = false;
        }
        else {
        
            $("#" + LabelID).html("");               
            var ValidatorTooltip = this.title + "格式不正确，请重新输入！";                    
            switch (this.Validator) {
                case "手机":
                    if (ValidatorForm.Mobile(this.value, ValidatorTooltip,LabelID) == false) {
                        b = false;
                        $("#" + LabelID).html(ValidatorTooltip);
                    }
                    else {
                        $("#" + LabelID).html(ThroughTooltip);
                    }
                    break;
                case "邮箱":
                    if (ValidatorForm.Email(this.value) == false) {
                        b = false;
                        $("#" + LabelID).html(ValidatorTooltip);
                    }
                    else {
                        $("#" + LabelID).html(ThroughTooltip);
                    }
                    break;
                case "电话":
                    if (ValidatorForm.Phone(this.value) == false) {
                        b = false;
                        $("#" + LabelID).html(ValidatorTooltip);
                    }
                    else {
                        $("#" + LabelID).html(ThroughTooltip);
                    }
                    break;
                case "传真":
                    if (ValidatorForm.Fax(this.value) == false) {
                        b = false;
                        $("#" + LabelID).html(ValidatorTooltip);
                    }
                    else {
                        $("#" + LabelID).html(ThroughTooltip);
                    }
                    break;
               case "整数":
                    if (ValidatorForm.Integer(this.value) == false) {
                        b = false;
                        $("#" + LabelID).html(ValidatorTooltip);
                    }
                    else {
                        $("#" + LabelID).html(ThroughTooltip);
                    }                           
                    break;
              case "数字":                            
                    if (ValidatorForm.OnlyNumber(this.value) == false) {
                        b = false;
                        $("#" + LabelID).html(ValidatorTooltip);
                    }
                    else {
                        $("#" + LabelID).html(ThroughTooltip);
                    } 
                    break;
              case "小数":
                    if (ValidatorForm.Float(this.value) == false) {
                        b = false;
                        $("#" + LabelID).html(ValidatorTooltip);
                    }
                    else {
                        $("#" + LabelID).html(ThroughTooltip);
                    } 
                    break;
            }
        }
    });
    return b;
}	 

//点击时进行脚本判断
function CheckChoose(ClassName) {
    var i = 0;
    $("."+ClassName+" input").each(function (index) {
        if (this.type == "checkbox") {                               
            if (this.checked == true) {
                i++;
            }
        }
    });
    return i;
}


//onpaste="return false;" 禁止向控件粘贴内容
//只允许输入数字
function ReturnNumber()
{
   if((event.keyCode>=48&&event.keyCode<=57)||(event.keyCode>=96&&event.keyCode<=105)||event.keyCode==8)
   {
    return event.returnValue=true;
   }
   else
   {
     alert('输入错误');
     return event.returnValue=false;
   }
}
function MouseRightClick()
{
   if(event.button==2)
   {
    alert('不允许使用右键');
   }
}

//////////////////////////////////////////////////////////////////////////////

//鼠标移动改变表格行的颜色

// JScript 文件
$(function(){
    //    $(".fromTable tr").click(function(){
    //        $(".fromTable tr").css("background-color","white");
    //        $(this).css("background-color","#CBE2F4");
    //    });
    $(".fromTable tr").mouseover(function(){
       $(this).css("background-color","#CBE2F4");
    });
    $(".fromTable tr").mouseout(function(){
       $(this).css("background-color","white");
    });
});

/////////////////////////////////////////////////////////////////////////////////////

//选择，包括全选、反选 -----------------------
var num=0;
function choose()
{
    var inp=document.getElementsByTagName("input");
    if(num==1)
    {		    	
	    for(var i=0;i<inp.length;i++)
	    {
		    if(inp[i].type=="checkbox")
		    {
		        inp[i].checked="";
		    }			
	    }		
	    num--;
    }
    else
    {		        
	    var inp=document.getElementsByTagName("input");
	    for(var i=0;i<inp.length;i++)
	    {
		    if(inp[i].type=="checkbox")
		    {
		        inp[i].checked="checked";
		    }			
	    }		
	    num++;
    }
}
//全选
function quanxuan()
{
	var inp=document.getElementsByTagName("input");
	for(var i=0;i<inp.length;i++)
	{
		if(inp[i].type=="checkbox")
		{
		    inp[i].checked="checked";
		}			
	}			
}
//反选
function fanxuan()
{
  var inp=document.getElementsByTagName("input");
	for(var i=0;i<inp.length;i++)
	{
		if(inp[i].type=="checkbox")
		{
		    inp[i].checked=!inp[i].checked;
		}			
	}	
}