//////////////////////////////////////////////////////////////////
// JScript 文件

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
    NotNullValidator:function(ID)
    {
        if($("#"+ID).val()=="")
        {
            return false;
        }
    },
    //手机验证
    Mobile: function (ID) {
        if (!ValidatorForm.Regeexp.mobile.test($("#"+ID).val())) {
            return false;
        }
    },
    //邮箱验证
    Email: function (ID) {
        if (!ValidatorForm.Regeexp.email.test($("#"+ID).val())) {
            return false;
        }
    },
    //电话号码验证
    Phone: function (ID) {
        if (!ValidatorForm.Regeexp.phone.test($("#"+ID).val())) {
            alert(Tooltip);
            return false;
        }
    },
    //传真验证
    Fax: function (ID) {
        if (!ValidatorForm.Regeexp.fax.test($("#"+ID).val())) {
            return false;
        }
    },
    //整数
    Integer: function (ID) {
        if (!ValidatorForm.Regeexp.integer.test($("#"+ID).val())) {
            return false;
        }
    }
};



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