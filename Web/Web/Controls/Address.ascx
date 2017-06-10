<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Address.ascx.cs" Inherits="Controls_Address" %>
        <asp:DropDownList runat="server" ID="province">
            <asp:ListItem Text="请选择省份" Value=""></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="city">
            <asp:ListItem Text="请选择城市" Value=""></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="area">
            <asp:ListItem Text="请选择区域" Value=""></asp:ListItem>
        </asp:DropDownList>     
        <asp:HiddenField runat="server" ID="TbText" />
        <asp:HiddenField runat="server" ID="TbValue" />

<%@ Import Namespace="YK.Common" %>
    <script language="javascript" type="text/javascript">

    //省
        $.ajax({
            type: "get",
            cache: false,
            async: false,
            url: "<%=CommonClass.AppPath %>Address.ashx?type=1",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var arr = eval(msg);
                for (var i = 0; i < arr.length; i++) {
                    var opt = new Option(arr[i].name, arr[i].code);
                    document.getElementById("<%=province.ClientID %>").options[i+1] = opt;
                }
            },
            error: function (err) {
                alert("操作错误");
            }
        });


        //市
        function GetCity(code) {
            $.ajax({
                type: "get",
                cache: false,
                async: false,
                url: "<%=CommonClass.AppPath %>Address.ashx?type=2&code=" + code,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    var arr = eval(msg);
                    $("#<%=city.ClientID %>").html("<option value=''>请选择城市</option>");                    
                    for (var i = 0; i < arr.length; i++) {
                        var opt = new Option(arr[i].name, arr[i].code);
                        document.getElementById("<%=city.ClientID %>").options[i+1] = opt;
                    }
                },
                error: function (err) {
                    alert("操作错误");
                }
            });
            //禁用按钮的提交              
            return false;
        }
        $(function () {
            $("#<%=province.ClientID %>").change(function () {
                var code = this.value;
                GetCity(code);
                GetArea($("#<%=city.ClientID %>").val());
                
                $("#<%=TbValue.ClientID %>").val("");
                $("#<%=TbText.ClientID %>").val("");
            });
        });
        //区
        function GetArea(code) {
            $.ajax({
                type: "get",
                cache: false,
                async: false,
                url: "<%=CommonClass.AppPath %>Address.ashx?type=3&code=" + code,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    var arr = eval(msg);
                    $("#<%=area.ClientID %>").html("<option value=''>请选择区域</option>");
                    for (var i = 0; i < arr.length; i++) {
                        var opt = new Option(arr[i].name, arr[i].code);
                        document.getElementById("<%=area.ClientID %>").options[i + 1] = opt;
                    }
                },
                error: function (err) {
                    alert("操作错误");
                }
            });
            //禁用按钮的提交              
            return false;
        }

        $(function () {
            $("#<%=city.ClientID %>").change(function () {
                var code = this.value;
                GetArea(code);
                
                $("#<%=TbValue.ClientID %>").val("");
                $("#<%=TbText.ClientID %>").val("");
            });
        });
    //文本框赋值
        $(function () {
            $("#<%=area.ClientID %>").change(function () {
                var val = $("#<%=province.ClientID %>").val() + "," +
                $("#<%=city.ClientID %>").val() + "," +
                $("#<%=area.ClientID %>").val();
                $("#<%=TbValue.ClientID %>").val(val);

                var text = $("#<%=province.ClientID %>").find("option:selected").text() + "," +
                $("#<%=city.ClientID %>").find("option:selected").text() + "," +
                $("#<%=area.ClientID %>").find("option:selected").text();

                $("#<%=TbText.ClientID %>").val(text);
            });
        });

        var val = $("#<%=TbValue.ClientID %>").val();
        if(val!="") {
            var arr = val.split(',');
            $("#<%=province.ClientID %>").val(arr[0]);
            GetCity(arr[0]);
            $("#<%=city.ClientID %>").val(arr[1]);
            GetArea(arr[1]);
            $("#<%=area.ClientID %>").val(arr[2]);
        }
    </script>