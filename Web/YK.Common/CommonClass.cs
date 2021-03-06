using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.IO;
using System.Data;
using YK.Model;
using System.Linq;
using System.Reflection;

using YK.Core;

namespace YK.Common
{
    /// <summary>
    /// 通用类
    /// </summary>
    public static partial class CommonClass
    {

        /// <summary>
        /// 获取目录路径
        /// </summary>
        public static string AppPath = HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";


        //获取完整站点路径
        public static string SiteUrl = (HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.RawUrl, "") + HttpContext.Current.Request.ApplicationPath).TrimEnd('/') + "/";

        /// <summary>
        /// 应用程序的物理目录﻿
        /// </summary>
        public static string PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath;

        /// <summary>
        /// 获取完整路径
        /// </summary>
        public static string FullAppPath
        {
            get
            {
                string[] arr = System.Web.HttpContext.Current.Request.Url.ToStr().Split('/');
                string fullUrl = arr[0] + "//" + arr[2];
                return fullUrl.TrimEnd('/') + AppPath;
            }
        }

        /// <summary>
        /// ajax输出
        /// </summary>
        /// <returns></returns>
        public static string AjaxReponse(bool isSuccess, string message, object data)
        {
            var result = new
            {
                isSuccess = isSuccess,
                message = message,
                data = data
            };
            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 在地址栏设置当前参数，允许多参数
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="paras">当前需要加入的参数，多参数请将每个之间用,逗号隔开</param>
        /// <param name="values">参数值,多参数请使用string,且每个值之间用,逗号隔开</param>
        /// <returns></returns>
        public static string SetUrlParas(string url, string paras, object values)
        {
           string[] parasList = paras.ToLower().Split(',');
           string[] valuesList = values.ToStr().Split(',');

           string[] split = url.Split('?'); //分割判断是否存在参数
           if (split.Length > 1)
           {
               url = split[0] + "?"; //获取无参数的地址

               string[] paraList = split[1].Split('&'); //分割获取参数信息

               foreach (string info in paraList)
               {
                   string paraName = info.Split('=')[0].ToLower();//获取参数名

                   //如果有相同的参数名，则取当前的
                   if (!parasList.Contains(paraName))
                   {
                       url += info + "&";
                   }
               }               
           }
           else
           {
               url += "?";
           }

           for (int i = 0; i < parasList.Length; i++)
           {
               url += parasList[i] + "=" + valuesList[i] + "&";
           }

           return url.TrimEnd('&');
        }

        /// <summary>
        /// 移除地址里面的参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="removeParas"></param>
        /// <returns></returns>
        public static string RemoveUrlParas(string url, string removeParas)
        {
            string[] deleteParas = removeParas.ToLower().Split(',');

            string[] split = url.Split('?'); //分割判断是否存在参数
            if (split.Length > 1)
            {
                url = split[0] + "?"; //获取无参数的地址

                string[] paraList = split[1].Split('&'); //分割获取参数信息

                foreach (string info in paraList)
                {
                    string paraName = info.Split('=')[0].ToLower();//获取参数名

                    //该参数是否在需要被移除的参数列表里面
                    if (!deleteParas.Contains(paraName))
                    {
                        url += info + "&";
                    }
                }  
            }

            return url.TrimEnd('&');
        }

        /// <summary>
        /// 返回字符串值
        /// </summary>
        /// <param name="para">参数</param>
        /// <returns></returns>
        public static string ReturnRequestStr(string para)
        {
            if (HttpContext.Current.Request.QueryString[para] != null)
            {
                return HttpContext.Current.Request.QueryString[para].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 返回字符串值
        /// </summary>
        /// <param name="para">参数</param>
        /// <param name="def">默认值</param>
        /// <returns></returns>
        public static int ReturnRequestInt(string para,int defaultVal)
        {
            int num = defaultVal;
            if (HttpContext.Current.Request.QueryString[para] != null)
            {
                if (int.TryParse(HttpContext.Current.Request.QueryString[para].ToString(), out num))
                {

                }
            }
            return num;
        }

        /// <summary>
        /// 返回字符串值，默认值为0
        /// </summary>
        /// <param name="para">参数</param>
        /// <returns></returns>
        public static int ReturnRequestInt(string para)
        {
            return ReturnRequestInt(para,0);
        }

        /// <summary>
        /// 返回提示字符串
        /// </summary>
        /// <param name="str">提示内容</param>
        /// <returns></returns>
        public static string Alert(string str)
        {
            return "<script>window.onload = function (){ alert('" + str + "'); }</script>";
        }

        /// <summary>
        /// 返回提示字符串,并跳转到制定页面
        /// </summary>
        /// <param name="str">提示内容</param>
        /// <param name="Url">跳转路径</param>
        /// <returns></returns>
        public static string Alert(string str, string Url)
        {
            return "<script>window.onload = function (){ alert('" + str + "','" + Url + "'); } </script>";
        }

        /// <summary>
        /// 返回提示内容,并刷新父窗口
        /// </summary>
        /// <param name="str">提示内容</param>
        /// <returns></returns>
        public static string Reload(string str)
        {
            return "<script>window.onload = function (){ window.top.yk.core.layer.closeReloadParentLayer('" + str + "'); }</script>";
        }

        
        /// <summary>
        /// 将数据表转换为实体列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Tentity> DataTableToEntityList<Tentity>(DataTable dt) where Tentity : new()
        {
            return ConvertEntityByEmit.GetList<Tentity>(dt);
            //List<Tentity> entityList = new List<Tentity>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    //实体
            //    Tentity entity = new Tentity();
            //    //循环属性
            //    foreach (PropertyInfo prop in entity.GetType().GetProperties())
            //    {
            //        //判断数据表中是否存在该列
            //        if (dt.Columns.Contains(prop.Name))
            //        {
            //            //属性类型
            //            prop.SetValue(entity, Convert.ChangeType(dr[prop.Name], prop.PropertyType), null);                        
            //        }
            //    }
            //    entityList.Add(entity);
            //}
            //return entityList;
        }

        /// <summary>
        /// 将实体列表转换为数据表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable EntityListToDataTable<Tentity>(List<Tentity> list) where Tentity : new()
        {
            //实体
            Tentity entity = new Tentity();
            //数据表
            DataTable dt = new DataTable(entity.GetType().Name);
            //创建列
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = prop.Name;
                dc.DataType = typeof(string);
                dt.Columns.Add(dc);
            }
            //填充行
            foreach (Tentity model in list)
            {
                DataRow dr = dt.NewRow();
                //循环属性
                foreach (PropertyInfo prop in model.GetType().GetProperties())
                {
                    string typeName = prop.PropertyType.Name;
                    dr[prop.Name] = prop.GetValue(model, null);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 获取分页代码
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="numberButtonCount"></param>
        /// <returns></returns>     
        public static string GetPagerHtml(int pageSize, int pageIndex, int recordCount, int numberButtonCount)
        {
            StringBuilder sb = new StringBuilder();
            int count = recordCount / pageSize;
            if (recordCount % pageSize > 0)
            {
                count = count + 1;
            }

            sb.Append("共<span>" + count + "</span>页，<span>" + recordCount + "</span>条数据 ");

            sb.Append("<a href=\"" + GetPagerCode(1) + "\">首页</a> ");

            if (pageIndex > 1)
            {
                sb.Append("<a href=\"" + GetPagerCode(pageIndex - 1) + "\">上一页</a> ");
            }

            //当总页数小于数字按钮的总数
            if (count <= numberButtonCount)
            {
                for (int i = 1; i <= count; i++)
                {
                    sb.Append("<a href=\"" + GetPagerCode(i) + "\">" + i + "</a> ");
                }
            }
            else
            {
                //当前页码+按钮总<总页数
                if (pageIndex + numberButtonCount < count)
                {
                    for (int i = 1; i <= numberButtonCount; i++)
                    {
                        int thisIndex = pageIndex + i;
                        sb.Append("<a href=\"" + GetPagerCode(thisIndex) + "\">" + thisIndex + "</a> ");
                    }
                }
                else
                {
                    //当前页码+按钮总数-总页数
                    for (int i = 1; i <= pageIndex + numberButtonCount - count; i++)
                    {
                        int thisIndex = pageIndex - (pageIndex + numberButtonCount - count - i);
                       
                        sb.Append("<a href=\"" + GetPagerCode(thisIndex) + "\">" + thisIndex + "</a> ");
                    }

                    for (int i = 1; i <= count - pageIndex ; i++)
                    {
                        int thisIndex = pageIndex + i;
                        sb.Append("<a href=\"" + GetPagerCode(thisIndex) + "\">" + thisIndex + "</a> ");
                    }
                }
            }

            if (pageIndex < count)
            {
                sb.Append("<a href=\"" + GetPagerCode(pageIndex + 1) + "\">下一页</a> ");
            }

            sb.Append("<a href=\"" + GetPagerCode(count) + "\">末页</a> ");

            //地址
            string url=HttpContext.Current.Request.Url.ToStr();

            sb.Append("<select class=\"pager_select\" onchange=\"window.location='" + SetUrlParas(url , "page", "") + "'+this.value\"> ");

            //下拉显示所有页码
            for (int i = 0; i < count; i++)
            {
                if (i + 1 == pageIndex)
                {
                    sb.Append("<option value=\"" + (i + 1) + "\" selected=\"selected\">" + (i + 1) + "</option>");
                }
                else
                {
                    sb.Append("<option value=\"" + (i + 1) + "\">" + (i + 1) + "</option>");
                }
            }
            sb.Append("</select>");
            sb.Append("<input type=\"text\" class=\"pager_input\" id=\"pager_input\" value=\""+ pageIndex +"\" /> ");

            sb.Append("<input type=\"button\" class=\"pager_ok\" value=\" 确定 \" onclick=\"window.location='"
                + SetUrlParas(url, "page", "") + "'+document.getElementById('pager_input').value\"/> ");
            return sb.ToString();
        }

        /// <summary>
        /// 获取脚本代码
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        private static string GetPagerCode(int pageIndex)
        {
            string url = HttpContext.Current.Request.Url.ToStr();
            return SetUrlParas(url, "page", pageIndex);
        }

        /// <summary>
        /// 获取Ajax脚本代码
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="showId"></param>
        /// <returns></returns>
        private static string GetPagerAjaxJavascriptCode(string url,int pageIndex, string showId)
        { 
            return "javascript:yk.get('" + SetUrlParas(url, "page", pageIndex) + "','" + showId + "')";
        }
        /// <summary>
        /// 获取ajax分页代码
        /// </summary>
        /// <param name="url">获取数据的地址</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="numberButtonCount"></param>
        /// <param name="showId"></param>
        /// <returns></returns>     
        public static string GetPagerAjaxHtml(string url,int pageSize, int pageIndex, int recordCount, int numberButtonCount,string showId)
        {
            StringBuilder sb = new StringBuilder();
            int count = recordCount / pageSize;
            if (recordCount % pageSize > 0)
            {
                count = count + 1;
            }

            sb.Append("共<span>" + count + "</span>页，<span>" + recordCount + "</span>条数据 ");

            sb.Append("<a href=\"" + GetPagerAjaxJavascriptCode(url,1, showId) + "\">首页</a> ");

            if (pageIndex != 1)
            {
                sb.Append("<a href=\"" + GetPagerAjaxJavascriptCode(url, pageIndex - 1, showId) + "\">上一页</a> ");
            }

            for (int i = 1; i <= numberButtonCount; i++)
            {
                int thisIndex = pageIndex + i;
                if (thisIndex <= count)
                {
                    sb.Append("<a href=\"" + GetPagerAjaxJavascriptCode(url, thisIndex, showId) + "\">" + thisIndex + "</a> ");                  
                }
            }

            if (pageIndex < count)
            {
                sb.Append("<a href=\"" + GetPagerAjaxJavascriptCode(url, pageIndex + 1, showId) + "\">下一页</a> ");                
            }

            sb.Append("<a href=\"" + GetPagerAjaxJavascriptCode(url, count, showId) + "\">末页</a> ");

            sb.Append("<select onchange=\"yk.get('" + SetUrlParas(url, "page", "") + "'+this.value,'" + showId + "')\"> ");

            //下拉显示所有页码
            for (int i = 0; i < count; i++)
            {
                if (i + 1 == pageIndex)
                {
                    sb.Append("<option value=\"" + (i + 1) + "\" selected=\"selected\">" + (i + 1) + "</option>");
                }
                else
                {
                    sb.Append("<option value=\"" + (i + 1) + "\">" + (i + 1) + "</option>");
                }
            }
            sb.Append("</select>");

            sb.Append("<input type=\"text\" class=\"pager_input\" id=\"pager_input\" value=\"" + pageIndex + "\" /> ");
            sb.Append("<input type=\"button\" class=\"pager_ok\" value=\" 确定 \" onclick=\"yk.get('"
                + SetUrlParas(url, "page", "") + "'+document.getElementById('pager_input').value,'"+showId+"')\"/> ");

            return sb.ToString();
        }
   }

    /// <summary>
    /// 导出Excel
    /// </summary>
    public static partial class CommonClass
    {
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="modelID">导出模块编号</param>
        /// <param name="DataTable">数据表，为空时导出所有数据</param>
        /// <param name="Page">页面</param>
        public static void OutputExcel(int modelID, System.Web.UI.Page Page)
        {
            TB_Excel_Model model = YK.Core.Core<TB_Excel_Model>.CoreTemplate.Get(modelID);

            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("ModelID", "=", modelID.ToStr()));

            List<TB_Excel_Fields> list = YK.Core.Core<TB_Excel_Fields>.CoreTemplate.Search(expression).Where(f => f.Type.Contains("0")).ToList();

            //字段
            string fields = "";
            //头部名称
            string[] headerNames = new string[list.Count];
            //内容字段
            string[] contentFields = new string[list.Count];

            int i = 0;
            foreach (TB_Excel_Fields f in list)
            {
                fields += f.FieldName + ",";
                headerNames[i] = f.ChineseName;
                contentFields[i] = f.FieldName;
            }
            fields = fields.TrimEnd(',');

            string cmdText = "select " + fields + " from " + model.TableName;
            DataTable dt = new SqlHelper().GetDataSet(cmdText).Tables[0];

            ExcelHelper.OutputExcel(dt, headerNames, contentFields , Page);
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="str">提示内容</param>
        /// <returns></returns>
        private static void OutputExcel(DataTable dt, string[] headerNames, string[] fields, System.Web.UI.Page Page)
        {
            ExcelHelper.OutputExcel(dt, headerNames, fields, Page);
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="str">提示内容</param>
        /// <returns></returns>
        private static void OutputExcel1(DataTable dt, string[] headerNames, string[] fields, System.Web.UI.Page Page)
        {
            StringBuilder strb = new StringBuilder();
            #region 头部分拼接
            strb.Append(" <html xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            strb.Append("xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
            strb.Append("xmlns=\"http://www.w3.org/TR/REC-html40\"");
            strb.Append(" <head> <meta http-equiv='Content-Type' content='text/html; charset=gb2312'>");
            strb.Append(" <style>");
            strb.Append(".xl26");
            strb.Append(" {mso-style-parent:style0;");
            strb.Append(" font-family:\"Times New Roman\", serif;");
            strb.Append(" mso-font-charset:0;");
            strb.Append(" mso-number-format:\"@\";}");
            strb.Append(" </style>");
            strb.Append(" <xml>");
            strb.Append(" <x:ExcelWorkbook>");
            strb.Append(" <x:ExcelWorksheets>");
            strb.Append(" <x:ExcelWorksheet>");
            strb.Append(" <x:Name>Sheet1 </x:Name>");
            strb.Append(" <x:WorksheetOptions>");
            strb.Append(" <x:DefaultRowHeight>285 </x:DefaultRowHeight>");
            strb.Append(" <x:Selected/>");
            strb.Append(" <x:Panes>");
            strb.Append(" <x:Pane>");
            strb.Append(" <x:Number>3 </x:Number>");
            strb.Append(" <x:ActiveCol>1 </x:ActiveCol>");
            strb.Append(" </x:Pane>");
            strb.Append(" </x:Panes>");
            strb.Append(" <x:ProtectContents>False </x:ProtectContents>");
            strb.Append(" <x:ProtectObjects>False </x:ProtectObjects>");
            strb.Append(" <x:ProtectScenarios>False </x:ProtectScenarios>");
            strb.Append(" </x:WorksheetOptions>");
            strb.Append(" </x:ExcelWorksheet>");
            strb.Append(" <x:WindowHeight>6750 </x:WindowHeight>");
            strb.Append(" <x:WindowWidth>10620 </x:WindowWidth>");
            strb.Append(" <x:WindowTopX>480 </x:WindowTopX>");
            strb.Append(" <x:WindowTopY>75 </x:WindowTopY>");
            strb.Append(" <x:ProtectStructure>False </x:ProtectStructure>");
            strb.Append(" <x:ProtectWindows>False </x:ProtectWindows>");
            strb.Append(" </x:ExcelWorkbook>");
            strb.Append(" </xml>");
            #endregion
            strb.Append("</head>");
            strb.Append("<body>");
            strb.Append("<table align=\"center\" style='border-collapse:collapse;table-layout:fixed'>");
            strb.Append("<tr>");
            foreach (string name in headerNames)
            {
                strb.Append("<td>" + name + "</td>");
            }
            strb.Append("</tr>");
            int i = 0;
            //插入数据
            #region
            foreach (DataRow dr in dt.Rows)
            {
                strb.Append("<tr>");
                foreach (string field in fields)
                {
                    strb.Append("<td>" + dr[field].ToStr() + "</td>");
                }
                strb.Append("</tr>");
            }
            #endregion
            strb.Append("</table>");
            strb.Append("</body></html>");

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;

            HttpContext.Current.Response.Charset = "GB2312";
            string fileName = "Excel.xls";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName));

            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

            HttpContext.Current.Response.ContentType = "application/ms-excel";

            Page.EnableViewState = false;

            HttpContext.Current.Response.Write(strb);

            HttpContext.Current.Response.End();
        }
    }
}
