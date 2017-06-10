using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.ComponentModel;

using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

using System.Collections;


    /// <summary>
    /// Excel导入导出工具,导出的数据必须先准备好对象,导入导出的对象属性须与excel表格的列一一对应
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// 数据起始行
        /// </summary>
        public int DataRowStart { get; set; }

        /// <summary>
        /// 数据起始列
        /// </summary>
        public int DataColumnStart { get; set; }

        /// <summary>
        /// 工作表名称
        /// </summary>
        public string SheetName { get; set; }

        /// <summary>
        /// 模板文件名
        /// </summary>
        public string TemplateFileName { get; set; }

        /// <summary>
        /// 模板数据单元格样式
        /// </summary>
        ICellStyle[] cellStyles;

        public ExcelHelper()
        {
            this.DataRowStart = 1;
            this.DataColumnStart = 0;
            this.SheetName = "Sheet1";
        }

        public ExcelHelper(int rowStart) : this()
        {
            this.DataRowStart = rowStart;
        }

        public ExcelHelper(int rowStart, int columnStart, string templateName)
        {
            this.DataRowStart = rowStart;
            this.DataColumnStart = columnStart;
            this.TemplateFileName = templateName;
        }

        public IEnumerable<T> Import<T>(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return Import<T>(fs);
            }
        }

        public IEnumerable<T> Import<T>(Stream input)
        {
            List<T> objs = new List<T>();
            HSSFWorkbook workbook = new HSSFWorkbook(input);
            ISheet sheet = workbook.GetSheetAt(0);
            var rows = sheet.GetRowEnumerator();

            int index = 0;
            while (index++ < this.DataRowStart) //移动到数据起始行
            {
                if (!rows.MoveNext())
                    return objs;
            }

            while (rows.MoveNext())
            {
                var row = (IRow)rows.Current;
                T obj = Activator.CreateInstance<T>();
                int i = 0;

                //当遇到第一列为空的行时退出
                if (row.Cells[0] == null || string.IsNullOrEmpty(row.Cells[0].ToString()))
                {
                    break;
                }

                var properties = obj.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var cell = row.GetCell(i++);
                    if (cell != null)
                    {
                        //时间字段不能使用ToString()获取
                        object value = null;
                        try
                        {
                            switch (property.PropertyType.Name)
                            {
                                case "DateTime":
                                    {
                                        if(cell.CellType != CellType.BLANK)
                                            value = cell.DateCellValue; 
                                        break;
                                    }
                                case "Int32":
                                    {
                                        value = cell.NumericCellValue; break;
                                    }
                                default:
                                    {
                                        value = cell.ToString(); break;
                                    }
                            }
                            property.SetValue(obj, Convert.ChangeType(value, property.PropertyType), null);
                        }
                        catch { }
                    }
                }
                objs.Add(obj);
            }

            return objs;
        }

        public HSSFWorkbook Import(Stream input)
        {
            return new HSSFWorkbook(input);
        }

        public void Export(IEnumerable data, string[] headers, string saveFileName)
        {
            var workbook = CreateExcel(data, headers);
            using (FileStream fs = new FileStream(saveFileName, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }
        }

        public void Export(IEnumerable data, string templateFileName, string saveFileName)
        {
            var workbook = CreateExcel(data, templateFileName);
            using (FileStream fs = new FileStream(saveFileName, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }
        }

        public HSSFWorkbook CreateExcel(IEnumerable data)
        {
            return CreateExcel(data, this.TemplateFileName);
        }

        public HSSFWorkbook CreateExcel(IEnumerable data, string[] headers)
        {
            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet(this.SheetName);
            var row = sheet.CreateRow(0);
            int i = 0;
            
            //写表头
            for (int j = 0; j < headers.Length; j++)
            {
                row.CreateCell(i++).SetCellValue(headers[j]);
            }

            //写数据
            WriteData(sheet, data);

            return workbook;
        }

        public HSSFWorkbook CreateExcel(IEnumerable data, string templateFileName)
        {
            HSSFWorkbook workbook;
            using (FileStream fs = new FileStream(templateFileName, FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(fs);
            }

            ISheet sheet = workbook.GetSheet(SheetName);
            if (sheet == null)
            {
                sheet = workbook.GetSheetAt(0);
            }

            //保留模板第一数据行的样式,最大支持100列
            cellStyles = new ICellStyle[100];
            for (int i = DataColumnStart; i < 100; i++)
            {
                cellStyles[i] = workbook.CreateCellStyle();
                cellStyles[i].CloneStyleFrom(sheet.GetRow(DataRowStart).Cells[i].CellStyle);
            }

            WriteData(sheet, data);

            return workbook;
        }

        void WriteData(ISheet sheet, IEnumerable data)
        {
            int rowIndex = DataRowStart;

            foreach (var obj in data)
            {
                IRow row = sheet.CreateRow(rowIndex++);
                var properties = obj.GetType().GetProperties();
                int colIndex = DataColumnStart;

                foreach (var property in properties)
                {
                    var value = property.GetValue(obj, null) ?? "";
                    var cell = row.CreateCell(colIndex);

                    cell.SetCellValue(value.ToString());
                    cell.CellStyle = cellStyles[colIndex];

                    colIndex++;
                }
            }
        }
    }