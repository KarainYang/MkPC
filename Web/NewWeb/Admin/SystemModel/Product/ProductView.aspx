<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductView.aspx.cs" Inherits="Admin_SystemModel_Product_ProductView" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
    <script language="javascript" type="text/javascript">
        var i = 0; //序号
        //添加子商品
        function addChild() {
            i++;

            var html = "<div><table class=\"fromTable\">";
            html += "<tr>";
            html += "<th>名称</th>  ";
            html += '<td><input type="hidden" name="pid" value="0" />'
                 +'<input name="name" type="text" maxlength="60" class="inputCss" title="名称" GroupName="Validator" style="width:300px" LabelID="name' + i + '" /> '
                 +'<span id="name'+i+'">*</span></td>';
            html += "</tr>";

            html += "<tr>";
            html += "<th>编号</th>  ";
            html += '<td><input name="proNumber" type="text" maxlength="60" class="inputCss" title="编号" GroupName="Validator" style="width:300px" LabelID="proNumber' + i + '" /> '
                + '<span id="proNumber' + i + '">*</span></td>';
            html += "</tr>";

            html+="<tr>";
            html += "<th>颜色</th>  ";
            html += '<td><input name="color" type="text" maxlength="60" class="inputCss" title="颜色" GroupName="Validator" LabelID="color' + i + '" /> '
                + '<span id="color' + i + '">*</span></td>';
            html += "</tr>";

            html += "<tr>";
            html+="<th>采购价</th>  ";
            html += '<td><input name="purchasPrice" type="text" maxlength="60" class="inputCss" title="商品采购价" GroupName="Validator" Validator="小数" LabelID="purchasPrice' + i + '" /> '
                + '<span id="purchasPrice' + i + '">*</span></td>';
            html += "</tr>";

            html += "<tr>";
            html+="<th>市场价</th>  ";
            html += '<td><input name="marketPrice" type="text" maxlength="60" class="inputCss" title="市场价" GroupName="Validator" Validator="小数" LabelID="marketPrice' + i + '" /> '
                + '<span id="marketPrice' + i + '">*</span></td>';
            html += "</tr>";

            html += "<tr>";
            html+="<th>销售价</th>  ";
            html += '<td><input name="salesPrice" type="text" maxlength="60" class="inputCss" title="商品售价" GroupName="Validator" Validator="小数"  LabelID="salesPrice' + i + '" /> '
                + '<span id="salesPrice' + i + '">*</span></td>';
            html += "</tr>";

            html += "</table>";
            html += "<input type='button'  class='buttonCss' value='删除' onclick='removeChildDiv(this.parentNode)'/><br /><br /></div>";

            document.getElementById("infoList").innerHTML = html + document.getElementById("infoList").innerHTML;
        }
        //type为类型，是大人或小孩儿，默认0为大人
        function removeChildDiv(obj) {
            obj.parentNode.removeChild(obj);
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="BodyDiv"> 
         <div  class="tabTitle">         
             <a href="javascript:void(0)" class="tab">基本设置</a> 
             <a href="javascript:void(0)" class="tab">描述</a> 
             <a href="javascript:void(0)" class="tab">规格参数</a> 
             <a href="javascript:void(0)" class="tab">包装清单</a> 
             <a href="javascript:void(0)" class="tab">售后服务</a> 
             <a href="javascript:void(0)" class="tab">关联产品</a>
             <div class="removeFloatDiv"></div>
         </div>         
         <div class="BodyDiv">
             <%--基本设置--%>
             <div class="tabDiv">             
                 <table class="fromTable">
                    <tr>          
                        <th>商品类别：</th>
                        <td>
                            <yk:DropDownList runat="server" ID="DDLOneLevel" AutoPostBack="true" 
                                onselectedindexchanged="DDLOneLevel_SelectedIndexChanged"></yk:DropDownList>
                            <yk:DropDownList runat="server" ID="DDLTwoLevel" AutoPostBack="true" 
                                OnSelectedIndexChanged="DDLTwoLevel_SelectedIndexChanged"></yk:DropDownList>
                            <yk:DropDownList runat="server" ID="DDLThreeLevel" LabelID="LbCategory" AutoPostBack="true" 
                                GroupName="Validator" CssClass="inputCss" title="商品类别" OnSelectedIndexChanged="DDLThreeLevel_SelectedIndexChanged"></yk:DropDownList>
                            <span id="LbCategory">*</span>                             
                        </td>
                   </tr>             
                   <tr>          
                        <th>商品名称：</th>
                        <td>
                            <yk:TextBox ID="TbProductName" runat="server"  Width="300px" GroupName="Validator" CssClass="inputCss"
                            title="商品名称" LabelID="LbProductName"></yk:TextBox>
                            <span id="LbProductName">*</span> 
                        </td>
                   </tr>
                   <tr>
                         <th>商品编号：</th>
                        <td>
                            <yk:TextBox ID="TbProNumber" runat="server" Width="300px" MaxLength="60" GroupName="Validator"   CssClass="inputCss"
                            title="商品编号" LabelID="LbProNumber"></yk:TextBox>                        
                            <span id="LbProNumber">*</span>   
                        </td>
                   </tr>      
                   <tr>
                         <th>商品简介：</th>
                        <td>
                            <yk:TextBox ID="TbIntroduction" runat="server" Width="300px" MaxLength="60" CssClass="inputCss"></yk:TextBox>                         
                        </td>
                   </tr>    
                   <tr>
                         <th>商品品牌：</th>
                        <td>
                            <yk:DropDownList ID="DDLBrand" runat="server" LabelID="LbBrand" GroupName="Validator" CssClass="inputCss" title="商品品牌">
                            </yk:DropDownList> 
                            <span id="LbBrand">*</span>                 
                        </td>
                   </tr>  
                   <tr>
                         <th>小图片：</th>
                        <td>
                            <yk:FileUpload runat="server" ID="ProImg" DirectoryUrl="Userfiles/Products/" FileSuffix="jpg,jpeg,gif,png" />
                        </td>
                   </tr> 
                   <tr>
                         <th>大图片：</th>
                        <td>
                            <yk:FileUpload runat="server" ID="ProPic"  DirectoryUrl="Userfiles/Products/" FileSuffix="jpg,jpeg,gif,png"/>
                        </td>
                   </tr>
                   <tr>
                         <th>采购价：</th>
                        <td>
                            <yk:TextBox ID="TbPurchasPrice" runat="server" Width="300px" MaxLength="60" GroupName="Validator"   CssClass="inputCss"
                            title="商品采购价" Validator="小数" LabelID="LbPurchasPrice"></yk:TextBox>   
                            <span id="LbPurchasPrice">*</span>                     
                        </td>
                   </tr>  
                   <tr>
                         <th>市场价：</th>
                        <td>
                            <yk:TextBox ID="TbMarketPrice" runat="server" Width="300px" MaxLength="60" GroupName="Validator"   CssClass="inputCss"
                            title="市场价" Validator="小数" LabelID="LbMarketPrice"></yk:TextBox>   
                            <span id="LbMarketPrice">*</span>                     
                        </td>
                   </tr>   
                   <tr>
                         <th>销售价：</th>
                        <td>
                            <yk:TextBox ID="TbSalesPrice" runat="server" Width="300px" MaxLength="60" GroupName="Validator"   CssClass="inputCss"
                            title="商品售价" Validator="小数" LabelID="LbSalesPrice"></yk:TextBox>                        
                            <span id="LbSalesPrice">*</span>  
                        </td>
                   </tr>       
                   <tr>
                         <th>颜色：</th>
                        <td>
                            <asp:TextBox ID="TbColor" runat="server" Width="300px" MaxLength="60" CssClass="inputCss" ></asp:TextBox>                        
                        </td>
                   </tr>                   
                    <tr>
                         <th>关键字：</th>
                        <td>
                            <asp:TextBox ID="TbKeyWord" runat="server" Width="300px" MaxLength="60" CssClass="inputCss" ></asp:TextBox>                        
                        </td>
                   </tr>  
                   <tr>
                         <th>点击数：</th>
                        <td>
                            <asp:TextBox ID="TbClickCount" runat="server" Width="300px" MaxLength="60" CssClass="inputCss" ></asp:TextBox>                        
                        </td>
                   </tr>  
                   <tr>
                         <th>排序：</th>
                        <td>
                            <asp:TextBox ID="TbOrderBy" runat="server" Width="300px" MaxLength="60" CssClass="inputCss" ></asp:TextBox>                        
                        </td>
                   </tr>
                   <tr>
                         <th>标签：</th>
                        <td>
                            <asp:CheckBoxList ID="CheckBoxListMark" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="折扣专区" Value="1"></asp:ListItem>
                                <asp:ListItem Text="首页推荐商品" Value="2"></asp:ListItem>
                                <asp:ListItem Text="特价专区" Value="3"></asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                   </tr>
                   <tr>
                         <th>是否推荐：</th>
                        <td>
                            <asp:DropDownList ID="DDLVouchType" runat="server">
                                <asp:ListItem Text="不推荐" Value="0"></asp:ListItem>
                                <asp:ListItem Text="推荐" Value="1"></asp:ListItem>
                                <asp:ListItem Text="首页图片切换" Value="2"></asp:ListItem>                                
                            </asp:DropDownList>
                        </td>
                   </tr>
                   <tr>
                         <th>是否隐藏：</th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsHidden" runat="server" />
                        </td>
                   </tr>
                   <tr>
                         <th>日期：</th>
                        <td>
                            <yk:TextBox ID="TbDate" runat="server" Width="150" MaxLength="60" CssClass="inputCss" 
                            onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"   GroupName="Validator" 
                            title="日期"  LabelID="LbDate"></yk:TextBox>                        
                            <span id="LbDate">*</span>                     
                        </td>
                   </tr> 
                 </table>
             </div>
             <%--描述--%>
             <div class="tabDiv">           
                 <table class="fromTable">
                   <tr>
                         <th>描述：</th>
                        <td>
                            <yk:FCKeditor ID="FckDesc" runat="server" Height="300px">
                            </yk:FCKeditor>    
                        </td>
                   </tr> 
                 </table>
             </div>
             <%--规格参数--%>
             <div class="tabDiv">           
                <table class="fromTable">                 
                    <asp:Repeater ID="RepProperties" runat="server" OnItemDataBound="RepProperties_ItemDataBind">
                        <ItemTemplate>
                                <tr>                           
                                    <th> 
                                        <%# Eval("PropName")%>：
                                        <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                    </th>   
                                    <td>
                                        <yk:TextBox runat="server" ID="TbValue"  CssClass="inputCss"></yk:TextBox>
                                        <yk:DropDownList runat="server" ID="DDLValue"></yk:DropDownList>
                                        <asp:CheckBoxList runat="server" ID="CkValue" RepeatDirection="Horizontal"></asp:CheckBoxList>
                                        <asp:RadioButtonList runat="server" ID="RadioValue" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </td> 
                                </tr>
                        </ItemTemplate>
                    </asp:Repeater> 
                </table>
             </div>
             <%--包装清单--%>
             <div class="tabDiv">           
                <table class="fromTable">
                    <tr>
                         <th>包装清单：</th>
                        <td>
                            <yk:FCKeditor ID="FckPakingList" runat="server" Height="300px">
                            </yk:FCKeditor>    
                        </td>
                   </tr>  
                 </table>
             </div>
             <%--售后服务--%>
             <div class="tabDiv">           
                <table class="fromTable">
                    <tr>
                         <th>售后服务：</th>
                        <td>
                            <yk:FCKeditor ID="FckSalesService" runat="server" Height="300px">
                            </yk:FCKeditor>    
                        </td>
                   </tr>   
                 </table>
             </div>
             <%--关联商品--%>
             <div class="tabDiv">  
                 <asp:ScriptManager ID="ScriptManager1" runat="server">             
                 </asp:ScriptManager>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>                                       
                         <yk:Button runat="server" ID="BtnAddChild" CssClass="buttonCss" Text="添加" OnClick="BtnAddChild_Click" />
                         <yk:Repeater runat="server" ID="RepChildList" OnItemDataBound="RepChildList_DataBind" OnItemCommand="RepChildList_ItemCommand">
                            <ItemTemplate>          
                                <div>
                                    <table class="fromTable">
                                        <tr>
                                            <th>名称</th> 
                                            <td>
                                                <asp:HiddenField runat="server" ID="ID" Value='<%# Eval("ID") %>' />
                                                <asp:HiddenField runat="server" ID="Index" Value='<%# index %>' />
                                                <yk:TextBox runat="server" ID="ProName" CssClass="inputCss" title="名称" GroupName="Validator" 
                                                    style="width:300px" LabelID='<%# "ProName" + index %>' Text='<%# Eval("ProName") %>'></yk:TextBox>
                                                <span id="<%# "ProName" + index %>">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>编号</th>
                                            <td>
                                                <yk:TextBox runat="server" ID="proNumber" CssClass="inputCss" title="编号" GroupName="Validator" 
                                                   Text='<%# Eval("ProNumber") %>'  style="width:300px" LabelID='<%# "proNumber_" + index %>'></yk:TextBox>
                                                <span id="<%# "proNumber_" + index %>">*</span>
                                            </td>
                                        </tr>

                                        <tr>
                                            <th>颜色</th>
                                            <td>
                                                <yk:TextBox runat="server" ID="Color" CssClass="inputCss" title="颜色" GroupName="Validator" 
                                                   Text='<%# Eval("Color") %>'  style="width:300px" LabelID='<%# "Color" + index %>'></yk:TextBox>
                                                <span id="<%# "Color" + index %>">*</span>
                                            </td>
                                        </tr>

                                        <tr>
                                            <th>采购价</th>
                                            <td>
                                                <yk:TextBox runat="server" ID="PurchasPrice" CssClass="inputCss" title="商品采购价" GroupName="Validator"  Validator="小数"
                                                   Text='<%# Eval("PurchasPrice").ToDecimal() == 0 ? "" : Eval("PurchasPrice") %>'  style="width:300px" LabelID='<%# "PurchasPrice" + index %>'></yk:TextBox>
                                                <span id="<%# "PurchasPrice" + index %>">*</span>
                                            </td>
                                        </tr>

                                        <tr>
                                            <th>市场价</th>
                                            <td>
                                                <yk:TextBox runat="server" ID="MarketPrice" CssClass="inputCss" title="商品市场价" GroupName="Validator"  Validator="小数"
                                                   Text='<%# Eval("MarketPrice").ToDecimal() == 0 ? "" : Eval("MarketPrice") %>'  style="width:300px" LabelID='<%# "MarketPrice" + index %>'></yk:TextBox>
                                                <span id="<%# "MarketPrice" + index %>">*</span>
                                            </td>
                                        </tr>

                                        <tr>
                                            <th>销售价</th>
                                            <td>
                                                <yk:TextBox runat="server" ID="SalesPrice" CssClass="inputCss" title="商品售价" GroupName="Validator"  Validator="小数"
                                                   Text='<%# Eval("SalesPrice").ToDecimal() == 0 ? "" : Eval("SalesPrice") %>'  style="width:300px" LabelID='<%# "SalesPrice" + index %>'></yk:TextBox>
                                                <span id="<%# "SalesPrice" + index %>">*</span>
                                            </td>
                                        </tr>
                                    </table>
                                    <%# Eval("ID").ToInt() > 0 ? "<a href=\"javascript:showLayer('图片管理','PictureList.aspx?pid=" + Eval("ID") + "',800,500)\">图片管理</a>" : ""%>
                        
                      
                                    <asp:LinkButton runat="server" ID="LinkBtnDelete" CommandName="delete" CommandArgument="<%# index %>"> 删除 </asp:LinkButton>
                                    <br /><br />                            
                            </ItemTemplate>
                         </yk:Repeater>
                        <%--<input type='button'  class='buttonCss' value='添加' onclick='addChild()'/>
                        <div id="infoList">
                            <%
                                int num=0;
                             %>
                            <%
                                foreach(var item in childList)
                                {
                                    num++;
                             %>
                                    <div>
                                        <table class="fromTable">
                                            <tr>
                                                <th>名称</th> 
                                                <td>
                                                    <input type="hidden" name="pid" value="<%=item.ID %>" />
                                                    <input name="name" type="text" maxlength="60" class="inputCss" title="名称" value="<%=item.ProName %>"
                                                        GroupName="Validator" style="width:300px" LabelID="name<%=num %>" /> 
                                                    <span id="name<%=num %>">*</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>编号</th>
                                                <td>
                                                    <input name="proNumber" type="text" maxlength="60" class="inputCss" title="编号" value="<%=item.ProNumber %>"
                                                    GroupName="Validator" style="width:300px" LabelID="proNumber<%=num %>" /> 
                                                    <span id="proNumber<%=num %>">*</span>
                                                </td>
                                            </tr>

                                            <tr>
                                                <th>颜色</th>
                                                <td>
                                                    <input name="color" type="text" maxlength="60" class="inputCss" title="颜色" value="<%=item.Color %>"
                                                        GroupName="Validator" LabelID="color<%=num %>" /> 
                                                    <span id="color<%=num %>">*</span>
                                                </td>
                                            </tr>

                                            <tr>
                                                <th>采购价</th>
                                                <td>
                                                    <input name="purchasPrice" type="text" maxlength="60" class="inputCss" title="商品采购价" value="<%=item.PurchasPrice %>"
                                                        GroupName="Validator" Validator="小数" LabelID="purchasPrice<%=num %>" /> 
                                                    <span id="purchasPrice<%=num %>">*</span>
                                                </td>
                                            </tr>

                                            <tr>
                                                <th>市场价</th>
                                                <td>
                                                    <input name="marketPrice" type="text" maxlength="60" class="inputCss" title="市场价" value="<%=item.MarketPrice %>" 
                                                        GroupName="Validator" Validator="小数" LabelID="marketPrice<%=num %>" /> 
                                                    <span id="marketPrice<%=num %>">*</span>
                                                </td>
                                            </tr>

                                            <tr>
                                                <th>销售价</th>
                                                <td>
                                                    <input name="salesPrice" type="text" maxlength="60" class="inputCss" title="商品售价" value="<%=item.SalesPrice %>"
                                                        GroupName="Validator" Validator="小数"  LabelID="salesPrice<%=num %>" /> 
                                                <span id="salesPrice<%=num %>">*</span>
                                               </td>
                                            </tr>
                                        </table>
                                        <a href="javascript:frameElement.lhgDG.curWin.location='PictureList.aspx?pid=<%=item.ID %>'">图片管理</a>
                                        <input type='button'  class='buttonCss' value='删除' onclick='removeChildDiv(this.parentNode)'/>
                                        <br /><br />
                                    </div>
                            <%
                                }
                             %>
                            <script language="javascript" type="text/javascript">
                                i=<%=num %>;
                            </script>
                        </div>--%>
                        </div>
                     </ContentTemplate>
                 </asp:UpdatePanel>
             </div>
         </div>
        </div>          
        <div class="SubmitClass">
            <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss"  OnClick="BtnSave_Click" OnClientClick="return yk.core.validator.VerificationForm('Validator')"/>
                     <input type="button" value=" 取消 " class="buttonCss" id="cancleCss" onclick="closeLayer()"  />
        </div> 
        <div runat="Server" id="MessageDiv">            
        </div> 
    </form>
</body>
</html>
