<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Address.aspx.cs" Inherits="Address" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Admin/js/jquery.js" type="text/javascript"></script>    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <select id="province"></select>
        <select id="city"></select>
        <select id="area"></select>
    </div>
    </form>


    <script language="javascript" type="text/javascript">

        $.ajax({
            type: "post",
            cache: false,
            async: false,
            url: "Address.aspx/Province",
            data: "{'id':'110000'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var arr = eval(msg.d);
                for (var i = 0; i < arr.length; i++) {
                    var opt = new Option( arr[i].name,arr[i].code);
                    document.getElementById("province").options[i] = opt;
                }
            },
            error: function (err) {
                alert("操作错误");
            }
        });



        $(function () {
            $("#province").change(function () {
                var id = this.value;
                $.ajax({
                    type: "post",
                    cache: false,
                    async: false,
                    url: "Address.aspx/City",
                    data: "{'id':'" + id + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        var arr = eval(msg.d);
                        $("#city").html("");
                        for (var i = 0; i < arr.length; i++) {
                            var opt = new Option(arr[i].name, arr[i].code);
                            document.getElementById("city").options[i] = opt;
                        }
                    },
                    error: function (err) {
                        alert("操作错误");
                    }
                });
                //禁用按钮的提交              
                return false;
            });
        });

        $(function () {
            $("#city").change(function () {
                var id = this.value;
                $.ajax({
                    type: "post",
                    cache: false,
                    async: false,
                    url: "Address.aspx/Area",
                    data: "{'id':'" + id + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        var arr = eval(msg.d);
                        $("#area").html("");
                        for (var i = 0; i < arr.length; i++) {
                            var opt = new Option(arr[i].name, arr[i].code);
                            document.getElementById("area").options[i] = opt;
                        }
                    },
                    error: function (err) {
                        alert("操作错误");
                    }
                });
                //禁用按钮的提交              
                return false;
            });
        });     
    </script>
</body>
</html>
