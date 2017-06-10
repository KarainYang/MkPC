
//局部刷新方法
var yk = {
    //局部刷新，url 地址,showId 显示模块ID
    get: function (url, showId) {
        xmlHttpRequest = yk.getXmlHttpRequest();
        var returnText = "";

        xmlHttpRequest.onreadystatechange = function () {
            if (xmlHttpRequest.readyState == 4 && xmlHttpRequest.status == 200) {
                returnText = xmlHttpRequest.responseText;
            }
        }
        //open 第三个参数为是否异步请求，true为异步请求，false为同步请求
        xmlHttpRequest.open("GET", url, false);
        xmlHttpRequest.send();

        if (showId != undefined) {
            document.getElementById(showId).innerHTML = returnText;
        }
        else {
            return returnText;
        }
    },
    //局部刷新，url 地址,paras 参数列表，showId 显示模块ID
    post: function (url, paras, showId) {
        xmlHttpRequest = yk.getXmlHttpRequest();
        var returnText = "";

        xmlHttpRequest.onreadystatechange = function () {
            if (xmlHttpRequest.readyState == 4 && xmlHttpRequest.status == 200) {
                returnText = xmlHttpRequest.responseText;
            }
        }
        //open 第三个参数为是否异步请求，true为异步请求，false为同步请求
        xmlHttpRequest.open("POST", url, false);
        xmlHttpRequest.setRequestHeader("Content-Length", paras.lenght);
        xmlHttpRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded;");
        xmlHttpRequest.send(paras);
        if (showId != undefined) {
            document.getElementById(showId).innerHTML = returnText;
        }
        else {
            return returnText;
        }
    },
    //获取 XMLHttpRequest 对象
    getXmlHttpRequest: function () {
        xmlHttpRequest = null;
        if (window.ActiveXObject) {
            xmlHttpRequest = new ActiveXObject("Microsoft.XMLHTTP");
        } else if (window.XMLHttpRequest) {
            xmlHttpRequest = new XMLHttpRequest();
        }
        return xmlHttpRequest;
    },
    //设定cookie值
    setCookie:function(cookieName,value,day){
        var d=new Date();
        d.setDate(day);
        document.cookie= cookieName+"="+escape(value)+ ";expires="+d.toGMTString()+";path=/;domain=x-life.com;secure";  
    },
    //读取cookie值
    getCookie:function(cookieName,key){
        var cookies= document.cookie.split(';') ;
        for(var i=0;i < cookies.length ;i++)
        {        
            var c=cookies[i].split('=');        
            //单参数数值,判断coolie是否只设置了一个值
            if(c.length==2)
            {
                return c[1];
            }
            else
            {
                //多参数设置
                if(c[0]==cookieName)
                {
                    var arr=cookies[i].replace(cookieName+"=","").split('&');
                    for(var j=0;j < arr.length ;j++)
                    {
                        var para=arr[j].split('=');
                        
                        if(para[0]==key)
                        {
                            return arr[j].replace(key+"=","");
                        }
                    }
                }
            }        
        }
    },
    //删除cookie值
    deleteCookie:function(cookieName){
        var d=new Date();
        d.setTime(d.getTime()-1);        
        document.cookie= cookieName+"=;expires="+d.toGMTString();
    },
    checkLogin:function()
    {
        var bool=false;        
        if(yk.getCookie("MemberInfo","MemberName")!="")
        {
            bool=true;
        }
        return bool;
    }
};


 
    

   

