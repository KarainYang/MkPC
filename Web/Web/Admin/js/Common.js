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

window.onload = function () {
    var marks = new Array();
    marks[0] = "input";
    marks[1] = "select";
    marks[2] = "textarea";

    var csss = new Array();
    csss[0] = "inputCss";
    csss[1] = "inputCss";
    csss[2] = "inputCss";

    for (var i = 0; i < marks.length; i++) {
        var controls = document.getElementsByTagName(marks[i]);
        for (var j = 0; j < controls.length; j++) {
            if (controls[j].attributes["GroupName"] != null) {
                controls[j].onblur = function () { checkObject(this); }
            }
            controls[j].className = csss[i];
            if (i == 0) {
                if (controls[j].type == "button" || controls[j].type == "submit") {
                    controls[j].className = "buttonCss";
                }
            }
        }
    }
}
//表单验证
function VerificationForm(GroupName) {
    var b = true;
    $("[GroupName='" + GroupName + "']").each(function () {
        var isOk = checkObject(this);
        if (isOk == false) {
            b = false;
        }
    });
    return b;
}

function checkObject(obj) {
    var b = true;
    var LabelID = obj.attributes["LabelID"]; //提示标签的ID     
    var ValidatorTooltip = "";

    if (obj.value == "") {
        ValidatorTooltip = "请输入" + obj.title + "！";
        b = false;
    }
    else {
        ValidatorTooltip = obj.title + "格式不正确，请重新输入！";
        switch (obj.Validator) {
            case "手机":
                b = ValidatorForm.Mobile(obj.value);
                break;
            case "邮箱":
                b = ValidatorForm.Email(obj.value);
                break;
            case "电话":
                b = ValidatorForm.Phone(obj.value);
                break;
            case "传真":
                b = ValidatorForm.Fax(obj.value);
                break;
            case "整数":
                b = ValidatorForm.Integer(obj.value);
                break;
            case "数字":
                b = ValidatorForm.OnlyNumber(obj.value);
                break;
            case "小数":
                b = ValidatorForm.Float(obj.value);
                break;
        }
    }
    if (LabelID != null) {
        $("#" + LabelID.value).html("");
        $("#" + LabelID.value).css("color", "red");
    }
    if (b == false) {
        if (LabelID != null) {
            $("#" + LabelID.value).html(ValidatorTooltip);
        }
        obj.style.borderColor = "red";
        obj.style.backgroundColor = "yellow";
    }
    return b;
}

////////////////////////////////////////////////选项卡效果////////////////////////////////////////////

function tabDiv(i) {
    $(".tabDiv").css("display", "none");
    $(".tabDiv").each(function (index) {
        if (index == i) {
            this.style.display = "block";
        }
    })
}
$(function () {
    $(".tab").each(function (index) {
        if (index == 0) {
            tabDiv(index);
        }
        this.onmouseover = function () { tabDiv(index); }
    });
});

////////////////////////////////////////////////快捷键模块////////////////////////////////////////////////////////////////

//鼠标移动改变表格行的颜色
var thisChangeRowIndex = 0; //当前选中行的行号
var editId = 0; //编辑行对应的ID
var isOperation = false; //是否可以操作快捷键

document.onkeydown = function () {
    if (event.keyCode == 32) {
        isOperation = true;
    }
}

document.onkeyup = function () {
    try {
        if (isOperation == true) {
            //点击键e进行编辑
            if (event.keyCode == 69) {
                if (editId > 0) {
                    update(editId);
                }
                else {
                    alert("请选中编辑的行");
                }
            }

            //点击键a进行添加
            if (event.keyCode == 65) {
                add();
            }
        }

        //点击键Esc进行撤销
        if (event.keyCode == 27) {
            cancel();
        }

        if (event.keyCode == 32) {
            isOperation = false;
        }

    } catch (e) {

    }
} 
//////////////////////////////////////////////////////////行选中效果////////////////////////////////////////////////////////////////
// JScript 文件
$(function(){
    $(".listTable tr").click(function () {
            $(".listTable tr").css("background-color", "white");
            $(this).css("background-color","#CBE2F4");
            thisChangeRowIndex=event.srcElement.parentElement.rowIndex;
            
            var inputs=this.getElementsByTagName("input");
            editId=0;//重新赋值，确定每次重新赋值编辑的ID
            for(var i=0;i<inputs.length;i++)
            {
                if(inputs[i].type=="hidden")
                {
                    editId=inputs[i].value;
                }
            }
            //this.cells[0].childNodes[0].type
        });
   $(".listTable tr").mouseover(function () {
        if(event.srcElement.parentElement.rowIndex!=thisChangeRowIndex)
        {
            $(this).css("background-color","#CBE2F4");
        }
    });
    $(".listTable tr").mouseout(function () {   
       if(event.srcElement.parentElement.rowIndex!=thisChangeRowIndex)
        {
            $(this).css("background-color","white");
        }       
    });
});

//////////////////////////////////////////树形结构展示/////////////////////////////////////////////////////////////
//显示或隐藏下级
function onShowOrHiddenTr(id, display) {
    $(".parent_" + id).each(function () {
        if (display == null) {
            //隐藏或显示下级
            if (this.style.display == "block") {
                this.style.display = "none";
            }
            else {
                this.style.display = "block";
            }
        }
        else {
            this.style.display = display;
        }
        //隐藏一级下级之外的所有下级，只显示子一级
        onShowOrHiddenTr(this.attributes["tid"].value, "none");
    });
}
//初始化
window.onload = function () {
    $(".listTable tr").each(function () {
        if (this.attributes["tid"] != undefined) {
            this.style.display = "none";
            this.style.cursor = "pointer";
            this.ondblclick = function () { onShowOrHiddenTr(this.attributes["tid"].value) };
        }
    });
    $(".parent_0").css("display", "block");
}

/////////////////////////////////////////////////////////////////////////////////////


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
//不允许使用右键
function MouseRightClick()
{
   if(event.button==2)
   {
    alert('不允许使用右键');
   }
}

//////////////////////////////////////////////////////////////////////////////////////

//点击时进行脚本判断
function CheckChoose(ClassName) {
    var i = 0;
    $("." + ClassName + " input").each(function (index) {
        if (this.type == "checkbox") {
            if (this.checked == true) {
                i++;
            }
        }
    });
    return i;
}


//////////////////////////////////////////////////////////////////////////////


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