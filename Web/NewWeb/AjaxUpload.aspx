<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AjaxUpload.aspx.cs" Inherits="AjaxUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Admin/js/yk.js"></script>
    <script src="Admin/js/yk.core.common.js"></script>
<script type="text/javascript">
    function UpladFile() {
        var fileObj = document.getElementById("file").files[0]; // 获取文件对象
        var FileController = "saveFile.aspx";                    // 接收上传文件的后台地址
        // FormData 对象
        var form = new FormData();
        form.append("file", fileObj);// 文件对象
        // XMLHttpRequest 对象
        var xhr = new XMLHttpRequest();
        xhr.open("post", FileController, true);
        xhr.onload = function () {
            alert("上传完成!");
        };
        xhr.send(form);
    }
    function postFile() {
        var fileObj = document.getElementById("file").files[0]; // 获取文件对象
        // FormData 对象
        var form = new FormData();
        form.append("file", fileObj);// 文件对象
        var msg = yk.post("saveFile.aspx", form);
        alert(msg);
    }
</script>

</head>

<body>

<input type="file" id="file" name="myfile" />

<input type="button" onclick="yk.core.common.postFile('file')" value="上传" />

</body>

</html>
