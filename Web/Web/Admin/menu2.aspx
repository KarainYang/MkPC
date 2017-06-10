<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu2.aspx.cs" Inherits="Admin_menu" %>

<%@ Import Namespace="YK.Model" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="css/admin.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">
		function expand(el)
		{
			childObj = document.getElementById("child" + el);

			if (childObj.style.display == 'none')
			{
				childObj.style.display = 'block';
			}
			else
			{
				childObj.style.display = 'none';
			}
			return;
		}
    </script>

</head>
<body>
    <div>
        <table height="100%" cellspacing="0" cellpadding="0" width="170" background="images/menu_bg.jpg"
            border="0">
            <tr>
                <td valign="top" align="center">
                <!-- ------------1.用户管理-------------- -->
                    <table cellspacing="0" cellpadding="0" width="150" border="0">
                        <tr height="22">
                            <td style="padding-left: 30px" background="images/menu_bt_companyinfo.jpg">
                                <a class="menuParent" onclick="expand(-1)" href="javascript:void(0);">用户管理</a>
                            </td>
                        </tr>
                        <tr height="4">
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table id="child-1" style="display: none;" cellspacing="0" cellpadding="0" width="150"
                        border="0">
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Admin/UserList.aspx" target="main">用户管理</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Roles/RolesList.aspx" target="main">角色管理</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Roles/ResourceList.aspx" target="main">资源管理</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Admin/LogList.aspx" target="main">操作日志</a>
                            </td>
                        </tr>
                    </table>
                    <!-- ------------1.系统设置-------------- -->
                    <table cellspacing="0" cellpadding="0" width="150" border="0">
                        <tr height="22">
                            <td style="padding-left: 30px" background="images/menu_bt_companyinfo.jpg">
                                <a class="menuParent" onclick="expand(0)" href="javascript:void(0);">系统设置管理</a>
                            </td>
                        </tr>
                        <tr height="4">
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table id="child0" style="display: none;" cellspacing="0" cellpadding="0" width="150"
                        border="0">                        
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/System/WebSet.aspx" target="main">站点信息</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/System/EmailSet.aspx" target="main">邮件配置</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/System/EmailSend.aspx" target="main">发送邮件</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/System/ExcelModelList.aspx" target="main">导入导出模块管理</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/System/ExcelFieldsList.aspx" target="main">导入导出字段管理</a>
                            </td>
                        </tr>
                         <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/System/DictionaryTypeList.aspx" target="main">数据字典类型管理</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/System/DictionaryList.aspx" target="main">数据字典管理</a>
                            </td>
                        </tr>
                         <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/System/AdverCategoryList.aspx" target="main">广告类别管理</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/System/AdverList.aspx" target="main">广告管理</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/System/ClearCache.aspx" target="main">清理缓存</a>
                            </td>
                        </tr>
                        <tr height="4">
                            <td>
                            </td>
                        </tr>
                    </table>
                    <!-- ------------2.商品管理-------------- -->
                    <table cellspacing="0" cellpadding="0" width="150" border="0">
                        <tr height="22">
                            <td style="padding-left: 30px" background="images/menu_bt_companyinfo.jpg">
                                <a class="menuParent" onclick="expand(1)" href="javascript:void(0);">商品管理</a>
                            </td>
                        </tr>
                        <tr height="4">
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table id="child1" style="display: none;" cellspacing="0" cellpadding="0" width="150"
                        border="0">
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Product/Categorys.aspx" target="main">类别管理</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Product/BrandList.aspx" target="main">品牌管理</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Product/PropertieList.aspx" target="main">商品属性</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Product/ProductList.aspx" target="main">商品管理</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Product/GroupList.aspx" target="main">团购管理</a>
                            </td>
                        </tr>
                        <tr height="4">
                            <td>
                            </td>
                        </tr>
                    </table>
                    <!-- ------------3.订单管理-------------- -->
                    <table cellspacing="0" cellpadding="0" width="150" border="0">
                        <tr height="22">
                            <td style="padding-left: 30px" background="images/menu_bt_companyinfo.jpg">
                                <a class="menuParent" onclick="expand(2)" href="javascript:void(0);">订单管理</a>
                            </td>
                        </tr>
                        <tr height="4">
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table id="child2" style="display: none;" cellspacing="0" cellpadding="0" width="150"
                        border="0">
                        <%--<tr height="20">
					                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
					                  <td><A class="menuChild" href="SystemModel/Order/PaymentList.aspx" target="main">支付方式</A></td>
				                </tr>
				                <tr height="20">
					                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
					                  <td><A class="menuChild" href="SystemModel/Order/ConsigumentList.aspx" target="main">配送方式</A></td>
				                </tr>--%>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Order/OrderList.aspx" target="main">订单列表</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Order/DeleteList.aspx" target="main">弃购列表</a>
                            </td>
                        </tr>
                        <tr height="4">
                            <td>
                            </td>
                        </tr>
                    </table>
                    <!-- ------------4.会员管理-------------- -->
                    <table cellspacing="0" cellpadding="0" width="150" border="0">
                        <tr height="22">
                            <td style="padding-left: 30px" background="images/menu_bt_companyinfo.jpg">
                                <a class="menuParent" onclick="expand(3)" href="javascript:void(0);">会员管理</a>
                            </td>
                        </tr>
                        <tr height="4">
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table id="child3" style="display: none;" cellspacing="0" cellpadding="0" width="150"
                        border="0">
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Member/MemberList.aspx" target="main">会员列表</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Member/CouponList.aspx" target="main">优惠券列表</a>
                            </td>
                        </tr>
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Member/LevelList.aspx" target="main">会员级别</a>
                            </td>
                        </tr>
                        <tr height="4">
                            <td>
                            </td>
                        </tr>
                    </table>
                    <!-- ------------5.活动管理-------------- -->
                    <table cellspacing="0" cellpadding="0" width="150" border="0">
                        <tr height="22">
                            <td style="padding-left: 30px" background="images/menu_bt_companyinfo.jpg">
                                <a class="menuParent" onclick="expand(4)" href="javascript:void(0);">活动管理</a>
                            </td>
                        </tr>
                        <tr height="4">
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table id="child4" style="display: none;" cellspacing="0" cellpadding="0" width="150"
                        border="0">
                        <tr height="20">
                            <td align="center" width="30">
                                <img height="9" src="images/menu_icon.gif" width="9" alt="" />
                            </td>
                            <td>
                                <a class="menuChild" href="SystemModel/Activity/ActivityList.aspx" target="main">活动列表</a>
                            </td>
                        </tr>
                        <tr height="4">
                            <td>
                            </td>
                        </tr>
                    </table>
                    
                    <!-- ------------5.资讯管理-------------- -->
                    <table cellspacing="0" cellpadding="0" width="150" border="0">        
		                <tr height="22">
			                  <td style="PADDING-LEFT: 30px" background="images/menu_bt_companyinfo.jpg">
					                <A class="menuParent" onclick="expand(5)" href="javascript:void(0);">资讯管理</A>
			                   </td>
		                </tr>
		                <tr height="4">
		                  <td></td>
		                </tr>
                  </table>
                  <table id="child5" style="display:none;" cellspacing="0" cellpadding="0"  width="150" border="0">
		                <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Info/HelpCategoryList.aspx" target="main">帮助中心类别</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Info/HelpList.aspx" target="main">帮助中心</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Info/NewsCategoryList.aspx" target="main">新闻类别</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Info/NewsList.aspx" target="main">新闻列表</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Info/PageList.aspx" target="main">单篇页列表</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Info/LinksList.aspx" target="main">友情连接列表</A></td>
		                </tr>
		                <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Info/HotSearch.aspx" target="main">热门搜索列表</A></td>
		                </tr>
		                <tr height="4">
		                  <td></td>
		                </tr>				                
                  </table>   
                  
                  <!-- ------------6.报表管理-------------- -->
                    <table cellspacing="0" cellpadding="0" width="150" border="0">        
		                <tr height="22">
			                  <td style="PADDING-LEFT: 30px" background="images/menu_bt_companyinfo.jpg">
					                <A class="menuParent" onclick="expand(6)" href="javascript:void(0);">报表管理</A>
			                   </td>
		                </tr>
		                <tr height="4">
		                  <td></td>
		                </tr>
                  </table>
                  <table id="child6" style="display:none;" cellspacing="0" cellpadding="0"  width="150" border="0">
		                <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Report/SalesReport.aspx" target="main">销售报表</A></td>
		                </tr>
		                <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Report/BrowerRecord.aspx" target="main">客户浏览记录</A></td>
		                </tr>
		                <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Report/BrowerRecordDaysReport.aspx" target="main">客户浏览走势图</A></td>
		                </tr>
		                <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Report/SalesRankingReportChart.aspx" target="main">销量排行榜走势图</A></td>
		                </tr>
		                <tr height="4">
		                  <td></td>
		                </tr>				                
                  </table>   

                   <!-- ------------7.项目管理-------------- -->
                    <table cellspacing="0" cellpadding="0" width="150" border="0">        
		                <tr height="22">
			                  <td style="PADDING-LEFT: 30px" background="images/menu_bt_companyinfo.jpg">
					                <A class="menuParent" onclick="expand(7)" href="javascript:void(0);">项目管理</A>
			                   </td>
		                </tr>
		                <tr height="4">
		                  <td></td>
		                </tr>
                  </table>
                  <table id="child7" style="display:none;" cellspacing="0" cellpadding="0"  width="150" border="0">
		                <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Project/Project/ProjectList.aspx" target="main">项目审批</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Project/Project/MyProjectList.aspx" target="main">我的项目</A></td>
		                </tr>
		                <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Project/Task/AllTaskList.aspx" target="main">任务审批</A></td>
		                </tr>
		                <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Project/Task/TaskList.aspx" target="main">我发布的任务</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Project/Task/MyTaskList.aspx" target="main">我的任务</A></td>
		                </tr>
                         <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Project/Bug/BugList.aspx" target="main">缺陷管理</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Project/Bug/MyBugList.aspx" target="main">我的缺陷</A></td>
		                </tr>
		                <tr height="4">
		                  <td></td>
		                </tr>				                
                  </table>   

                  <!-- ------------8.客户关系管理-------------- -->
                    <table cellspacing="0" cellpadding="0" width="150" border="0">        
		                <tr height="22">
			                  <td style="PADDING-LEFT: 30px" background="images/menu_bt_companyinfo.jpg">
					                <A class="menuParent" onclick="expand(8)" href="javascript:void(0);">客户关系管理</A>
			                   </td>
		                </tr>
		                <tr height="4">
		                  <td></td>
		                </tr>
                  </table>
                  <table id="child8" style="display:none;" cellspacing="0" cellpadding="0"  width="150" border="0">
		                <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Customer/AllCustomerList.aspx" target="main">所有客户</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Customer/ShareCustomerList.aspx" target="main">共享客户</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Customer/CustomerList.aspx" target="main">我的客户</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Customer/OrderList.aspx" target="main">我的订单</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Customer/AllVisitRcordList.aspx" target="main">所有拜访/回访记录</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Customer/MyVisitRcordList.aspx" target="main">我的拜访/回访记录</A></td>
		                </tr>
		                <tr height="4">
		                  <td></td>
		                </tr>				                
                  </table>   

                  <!-- ------------9.员工管理-------------- -->
                    <table cellspacing="0" cellpadding="0" width="150" border="0">        
		                <tr height="22">
			                  <td style="PADDING-LEFT: 30px" background="images/menu_bt_companyinfo.jpg">
					                <A class="menuParent" onclick="expand(9)" href="javascript:void(0);">员工管理</A>
			                   </td>
		                </tr>
		                <tr height="4">
		                  <td></td>
		                </tr>
                  </table>
                  <table id="child9" style="display:none;" cellspacing="0" cellpadding="0"  width="150" border="0">
		                <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/DepartmentList.aspx" target="main">部门管理</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/DutyList.aspx" target="main">职位管理</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/EmployeeList.aspx" target="main">员工管理</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/LaborageList.aspx" target="main">工资管理</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/MyLaborageList.aspx" target="main">我的工资管理</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/LeaveApproveList.aspx" target="main">请假审批</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/LeaveList.aspx" target="main">我的请假管理</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/OvertimeApproveList.aspx" target="main">加班审批</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/OvertimeList.aspx" target="main">我的加班管理</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/AllWorkStatementList.aspx" target="main">所有工作报告</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/WorkStatementList.aspx" target="main">工作报告</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/OfficeSupplies/ApproveList.aspx" target="main">办公用品审批</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/OfficeSupplies/List.aspx" target="main">我的办公用品管理</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/Attendance/AllList.aspx" target="main">考勤管理</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/Attendance/List.aspx" target="main">我的考勤管理</A></td>
		                </tr>
		                <tr height="4">
		                  <td></td>
		                </tr>				                
                  </table>   

                  <!-- ------------9.内部信息管理-------------- -->
                    <table cellspacing="0" cellpadding="0" width="150" border="0">        
		                <tr height="22">
			                  <td style="PADDING-LEFT: 30px" background="images/menu_bt_companyinfo.jpg">
					                <A class="menuParent" onclick="expand(10)" href="javascript:void(0);">内部信息管理</A>
			                   </td>
		                </tr>
		                <tr height="4">
		                  <td></td>
		                </tr>
                  </table>
                  <table id="child10" style="display:none;" cellspacing="0" cellpadding="0"  width="150" border="0">
		                <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/Info/CategoryList.aspx" target="main">信息类别管理</A></td>
		                </tr>
                        <tr height="20">
			                  <td align="center" width="30"><img height="9" src="images/menu_icon.gif" width="9" alt="" /></td>
			                  <td><A class="menuChild" href="SystemModel/Employee/Info/InfoList.aspx" target="main">信息管理</A></td>
		                </tr>
                    </table>
		                  
                    <%
                        int i = 6;
                        foreach(TB_Admin_Resources resource in resources)
                        {
                            i++;
                            Response.Write(
                                "<table cellspacing=\"0\" cellpadding=\"0\" width=\"150\" border=\"0\">"  +      
		                        "<tr height=\"22\">"+
			                          "<td style=\"PADDING-LEFT: 30px\" background=\"images/menu_bt_companyinfo.jpg\">"+
					                        "<A class=\"menuParent\" onclick=\"expand("+i+")\" href=\"javascript:void(0);\">"+resource.ResourceName+"</A>"+
			                           "</td>"+
		                        "</tr>"+
		                        "<tr height=\"4\"><td></td></tr>"+
                                "</table>"
                            );
                            Response.Write("<table id=\"child"+i+"\" style=\"display:none;\" cellspacing=\"0\" cellpadding=\"0\"  width=\"150\" border=\"0\">");
                            foreach(TB_Admin_Resources child in resource.ChildTree)
                            {
                                Response.Write(
                                
                                    "<tr height=\"20\">" +
                                          "<td align=\"center\" width=\"30\"><img height=\"9\" src=\"images/menu_icon.gif\" width=\"9\" alt=\"\" /></td>" +
                                          "<td><A class=\"menuChild\" href=\""+child.Url+"\" target=\"main\">"+child.ResourceName+"</A></td>" +
                                    "</tr>" 
                              );
                            }
                            Response.Write("<tr height=\"4\"><td></td></tr></table>");	                          
	                    }
                    %>
                </td>
                <td width="1" bgcolor="#d1e6f7">
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
