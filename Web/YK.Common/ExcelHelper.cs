using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Text;

namespace YK.Common
{

    /// <summary>
    ///ImportExcel 的摘要说明
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// 开始行号
        /// </summary>
        public int StartRowIndex { get; set; }
        /// <summary>
        /// 开始列号
        /// </summary>
        public int StartColumnIndex { get; set; }

        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="filePath">文件路径</param>
        /// <param name="fieldNames">字段名</param>
        /// <returns></returns>
        public List<T> GetEntityList<T>(string filePath, List<string> fieldNames)
        {
            List<T> list = new List<T>();

            DataTable dt = ExcelDs(filePath).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //判断第一列是否为空
                if (!string.IsNullOrEmpty(dt.Rows[i][StartColumnIndex - 1].ToString()))
                {
                    if (i + 1 >= StartRowIndex)
                    {
                        T entity = System.Activator.CreateInstance<T>();
                        //循环属性
                        foreach (PropertyInfo prop in entity.GetType().GetProperties())
                        {
                            //循环字段
                            for (int j = 0; j < fieldNames.Count; j++)
                            {
                                if (fieldNames[j].ToLower() == prop.Name.ToLower())
                                {
                                    //获取值
                                    string value = dt.Rows[i][StartColumnIndex - 1 + j].ToString();
                                    if (!string.IsNullOrEmpty(value))
                                    {
                                        prop.SetValue(entity, Convert.ChangeType(value, prop.PropertyType), null);
                                    }
                                    break;
                                }
                            }

                        }
                        list.Add(entity);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获取实体列表,不需要设置开始列
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public List<T> GetEntityList<T>(string filePath)
        {
            List<T> list = new List<T>();

            DataTable dt = ExcelDs(filePath).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //判断第一列是否为空
                if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString()))
                {
                    if (i + 1 >= StartRowIndex)
                    {
                        T entity = System.Activator.CreateInstance<T>();
                        int j = 0;
                        //循环属性
                        foreach (PropertyInfo prop in entity.GetType().GetProperties())
                        {
                            //获取值
                            string value = dt.Rows[i][j].ToString();
                            if (!string.IsNullOrEmpty(value))
                            {
                                prop.SetValue(entity, Convert.ChangeType(value, prop.PropertyType), null);
                            }
                            j++;
                        }
                        list.Add(entity);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获取Excel数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public DataSet ExcelDs(string filePath)
        {
            string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + filePath + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);
            OleDbDataAdapter odda = new OleDbDataAdapter("select * from [Sheet1$]", conn);
            DataSet ds = new DataSet();
            odda.Fill(ds);
            return ds;
        }



        /// <summary>
        /// 写Excel头
        /// </summary>
        /// <param name="OutFileContent"></param>
        /// <returns></returns>
        private static StringBuilder AddHeadFile()
        {
            StringBuilder OutFileContent = new StringBuilder();

            OutFileContent.Append("<?xml version=\"1.0\"?>\r\n");
            OutFileContent.Append("<?mso-application progid=\"Excel.Sheet\"?>\r\n");
            OutFileContent.Append("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n");
            OutFileContent.Append(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n");
            OutFileContent.Append(" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"\r\n");
            OutFileContent.Append(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n");
            OutFileContent.Append(" xmlns:html=\"http://www.w3.org/TR/REC-html40\">\r\n");
            OutFileContent.Append(" <DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">\r\n");
            OutFileContent.Append("  <Author>panss</Author>\r\n");
            OutFileContent.Append("  <LastAuthor>Оґ¶ЁТе</LastAuthor>\r\n");
            OutFileContent.Append("  <Created>2004-12-31T03:40:31Z</Created>\r\n");
            OutFileContent.Append("  <Company>Prcedu</Company>\r\n");
            OutFileContent.Append("  <Version>12.00</Version>\r\n");
            OutFileContent.Append(" </DocumentProperties>\r\n");
            OutFileContent.Append(" <OfficeDocumentSettings xmlns=\"urn:schemas-microsoft-com:office:office\">\r\n");
            OutFileContent.Append("  <DownloadComponents/>\r\n");
            OutFileContent.Append("  <LocationOfComponents HRef=\"file:///F:\\Tools\\OfficeXP\\OfficeXP\\\"/>\r\n");
            OutFileContent.Append(" </OfficeDocumentSettings>\r\n");
            OutFileContent.Append(" <ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">\r\n");
            OutFileContent.Append("  <WindowHeight>9000</WindowHeight>\r\n");
            OutFileContent.Append("  <WindowWidth>10620</WindowWidth>\r\n");
            OutFileContent.Append("  <WindowTopX>480</WindowTopX>\r\n");
            OutFileContent.Append("  <WindowTopY>45</WindowTopY>\r\n");
            OutFileContent.Append("  <ProtectStructure>False</ProtectStructure>\r\n");
            OutFileContent.Append("  <ProtectWindows>False</ProtectWindows>\r\n");
            OutFileContent.Append(" </ExcelWorkbook>\r\n");
            OutFileContent.Append(" <Styles>\r\n");
            OutFileContent.Append("  <Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n");
            OutFileContent.Append("   <Alignment ss:Vertical=\"Center\" />\r\n");
            OutFileContent.Append("   <Borders/>\r\n");
            OutFileContent.Append("   <Font ss:FontName=\"ЛОМе\" x:CharSet=\"134\" ss:Size=\"12\"/>\r\n");
            OutFileContent.Append("   <Interior/>\r\n");
            OutFileContent.Append("   <NumberFormat/>\r\n");
            OutFileContent.Append("   <Protection/>\r\n");
            OutFileContent.Append("  </Style>\r\n");
            OutFileContent.Append("  <Style ss:ID=\"s62\">\r\n");
            OutFileContent.Append("   <Alignment ss:Vertical=\"Center\" ss:Horizontal=\"Center\" ss:WrapText=\"1\"/>\r\n");
            OutFileContent.Append("   <Font ss:FontName=\"ЛОМе\" x:CharSet=\"134\" ss:Size=\"9\"/>\r\n");
            OutFileContent.Append("  </Style>\r\n");
            OutFileContent.Append("  <Style ss:ID=\"s74\">\r\n");
            OutFileContent.Append("   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\"/>\r\n");
            OutFileContent.Append("   <Borders>\r\n");
            OutFileContent.Append("  <Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>\r\n");
            OutFileContent.Append("  <Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>\r\n");
            OutFileContent.Append("  <Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>\r\n");
            OutFileContent.Append("  <Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>\r\n");
            OutFileContent.Append("  </Borders>\r\n");
            OutFileContent.Append("   <Font ss:FontName=\"ЛОМе\" x:CharSet=\"134\" ss:Size=\"12\" ss:Bold=\"1\"/>\r\n");
            OutFileContent.Append("   <Interior ss:Color=\"#BFBFBF\" ss:Pattern=\"Solid\"/>\r\n");
            OutFileContent.Append("  </Style>\r\n");
            OutFileContent.Append(" </Styles>\r\n");
            OutFileContent.Append(" <Worksheet ss:Name=\"Sheet1\">\r\n");
            OutFileContent.Append("  <Table ss:ExpandedColumnCount=\"255\" x:FullColumns=\"1\" \r\n");
            OutFileContent.Append("x:FullRows=\"1\" ss:StyleID=\"s62\" ss:DefaultColumnWidth=\"75\" ss:DefaultRowHeight=\"20.25\">\r\n");
            OutFileContent.Append("<Column ss:StyleID=\"s62\" ss:AutoFitWidth=\"0\" ss:Width=\"112.5\"/>\r\n");
            return OutFileContent;
        }

        /// <summary>
        /// 写Excel尾
        /// </summary>
        /// <param name="OutFileContent"></param>
        /// <returns></returns>
        private static StringBuilder AddEndFile()
        {
            StringBuilder OutFileContent = new StringBuilder();

            OutFileContent.Append("</Table>\r\n");
            OutFileContent.Append("<WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">\r\n");
            OutFileContent.Append("<Unsynced/>\r\n");
            OutFileContent.Append("<Print>\r\n");
            OutFileContent.Append("    <ValidPrinterInfo/>\r\n");
            OutFileContent.Append("    <PaperSizeIndex>9</PaperSizeIndex>\r\n");
            OutFileContent.Append("    <HorizontalResolution>600</HorizontalResolution>\r\n");
            OutFileContent.Append("    <VerticalResolution>0</VerticalResolution>\r\n");
            OutFileContent.Append("</Print>\r\n");
            OutFileContent.Append("<Selected/>\r\n");
            OutFileContent.Append("<Panes>\r\n");
            OutFileContent.Append("    <Pane>\r\n");
            OutFileContent.Append("    <Number>3</Number>\r\n");
            OutFileContent.Append("    <RangeSelection>R1:R65536</RangeSelection>\r\n");
            OutFileContent.Append("    </Pane>\r\n");
            OutFileContent.Append("</Panes>\r\n");
            OutFileContent.Append("<ProtectObjects>False</ProtectObjects>\r\n");
            OutFileContent.Append("<ProtectScenarios>False</ProtectScenarios>\r\n");
            OutFileContent.Append("</WorksheetOptions>\r\n");
            OutFileContent.Append("</Worksheet>\r\n");
            OutFileContent.Append("<Worksheet ss:Name=\"Sheet2\">\r\n");
            OutFileContent.Append("<Table ss:ExpandedColumnCount=\"1\" ss:ExpandedRowCount=\"1\" x:FullColumns=\"1\"\r\n");
            OutFileContent.Append("x:FullRows=\"1\" ss:DefaultColumnWidth=\"54\" ss:DefaultRowHeight=\"14.25\">\r\n");
            OutFileContent.Append("<Row ss:AutoFitHeight=\"0\"/>\r\n");
            OutFileContent.Append("</Table>\r\n");
            OutFileContent.Append("<WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">\r\n");
            OutFileContent.Append("<Unsynced/>\r\n");
            OutFileContent.Append("<ProtectObjects>False</ProtectObjects>\r\n");
            OutFileContent.Append("<ProtectScenarios>False</ProtectScenarios>\r\n");
            OutFileContent.Append("</WorksheetOptions>\r\n");
            OutFileContent.Append("</Worksheet>\r\n");
            OutFileContent.Append("<Worksheet ss:Name=\"Sheet3\">\r\n");
            OutFileContent.Append("<Table ss:ExpandedColumnCount=\"1\" ss:ExpandedRowCount=\"1\" x:FullColumns=\"1\"\r\n");
            OutFileContent.Append("x:FullRows=\"1\" ss:DefaultColumnWidth=\"54\" ss:DefaultRowHeight=\"14.25\">\r\n");
            OutFileContent.Append("<Row ss:AutoFitHeight=\"0\"/>\r\n");
            OutFileContent.Append("</Table>\r\n");
            OutFileContent.Append("<WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">\r\n");
            OutFileContent.Append("<Unsynced/>\r\n");
            OutFileContent.Append("<ProtectObjects>False</ProtectObjects>\r\n");
            OutFileContent.Append("<ProtectScenarios>False</ProtectScenarios>\r\n");
            OutFileContent.Append("</WorksheetOptions>\r\n");
            OutFileContent.Append("</Worksheet>\r\n");
            OutFileContent.Append("</Workbook>\r\n");
            return OutFileContent;
        }

        /// <summary>
        /// 写数据内容
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="headerNames"></param>
        /// <param name="fields"></param>
        /// <returns></returns> 
        private static StringBuilder AddContentFile(DataTable dt, string[] headerNames, string[] fields)
        {
            StringBuilder OutFileContent = new StringBuilder();
            //写列头
            OutFileContent.Append("<Row ss:AutoFitHeight=\"0\">");
            foreach (string name in headerNames)
            {
                OutFileContent.Append("<Cell><Data ss:Type=\"String\">" + name + "</Data></Cell>");
            }
            OutFileContent.Append("</Row>");

            //插入数据
            #region
            foreach (DataRow dr in dt.Rows)
            {
                OutFileContent.Append("<Row ss:AutoFitHeight=\"0\">");
                foreach (string field in fields)
                {
                    OutFileContent.Append("<Cell><Data ss:Type=\"String\">" + dr[field].ToString() + "</Data></Cell>");
                }
                OutFileContent.Append("</Row>");
            }
            #endregion

            return OutFileContent;
        }


        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="headerNames">头部分</param>
        /// <param name="fields">字段</param>
        /// <param name="Page">当前页面</param>
        public static void OutputExcel(DataTable dt, string[] headerNames, string[] fields, System.Web.UI.Page Page)
        {
            StringBuilder OutFileContent = new StringBuilder();//容器
            //写头文件
            OutFileContent.Append(AddHeadFile());
            //写内容
            OutFileContent.Append(AddContentFile(dt, headerNames, fields));
            //写尾文件
            OutFileContent.Append(AddEndFile());

            byte[] btArray = new byte[OutFileContent.Length];
            btArray = Encoding.UTF8.GetBytes(OutFileContent.ToString());

            Page.Response.Charset = "UTF-8";
            Page.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            Page.Response.ContentType = "application/vnd.ms-excel";

            Page.Response.AddHeader("Content-Disposition", "attachment; filename=" + Page.Server.UrlEncode("Excel.xls"));
            Page.Response.BinaryWrite(btArray);
            Page.Response.Flush();
            Page.Response.End();
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="dt">实体列表</param>
        /// <param name="headerNames">头部分</param>
        /// <param name="fields">字段</param>
        /// <param name="Page">当前页面</param>
        public static void OutputExcel<T>(List<T> entityList, string[] headerNames, string[] fields, System.Web.UI.Page Page) where T : new()
        {
            DataTable dt= YK.Common.CommonClass.EntityListToDataTable<T>(entityList);
            OutputExcel(dt, headerNames, fields, Page);
        }
    }
}