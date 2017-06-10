using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using YK.Common;

public partial class CodeTools : System.Web.UI.Page
{
    public string AppPath = HttpContext.Current.Server.MapPath("~/");

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    //连接
    protected void BtnLink_Click(object sender, EventArgs e)
    {
        if (TbIpAdd.Text.Trim() == string.Empty)
        {
            LbTooltip.Text="请输入服务器地址！";
            return;
        }
        if (TbUser.Text.Trim() == string.Empty)
        {
            LbTooltip.Text="请输入用户名！";
            return;
        }
        if (TbPwd.Text.Trim() == string.Empty)
        {
            LbTooltip.Text="请输入密码！";
            return;
        }
        SqlConnection conn = CodeToolsHelper.OpenCn();
        try
        {
            GetDataBase();
            LbTooltip.Text = "连接成功";
        }
        catch (Exception ex)
        {
            LbTooltip.Text="连接失败";
        }
    }
    
    /// <summary>
    /// 获取数据库名称
    /// </summary>
    public void GetDataBase()
    {
        CodeToolsHelper.ConnStr = "server=" + TbIpAdd.Text.Trim() + ";user id=" + TbUser.Text.Trim() + ";pwd=" + TbPwd.Text.Trim() + ";";
        string cmdText = "select name from master..sysdatabases";
        DDLDataBase.DataTextField = "name";
        DDLDataBase.DataValueField = "name";
        DDLDataBase.DataSource = CodeToolsHelper.GetDataSet(cmdText).Tables[0];
        DDLDataBase.DataBind();

        GetDataTable();

        DataBindColumns();
    }

    /// <summary>
    /// 获取数据库对应的表
    /// </summary>
    public void GetDataTable()
    {
        CodeToolsHelper.ConnStr = "server=" + TbIpAdd.Text.Trim() + ";user id=" + TbUser.Text.Trim() + ";pwd=" + TbPwd.Text.Trim() + ";database=" + DDLDataBase.SelectedValue;
        string cmdText = "select name from sysObjects where xtype='u' order by name";
        DataTable ds=CodeToolsHelper.GetDataSet(cmdText).Tables[0];
        DDLDataTable.DataTextField = "name";
        DDLDataTable.DataValueField = "name";
        DDLDataTable.DataSource = ds;
        DDLDataTable.DataBind();

        RepDataTable.DataSource = ds;
        RepDataTable.DataBind();

        RepTables.DataSource = ds;
        RepTables.DataBind();
        

        DataBindColumns();
    }

    /// <summary>
    /// //获取数据表中字段的信息
    /// </summary>
    /// <param name="tableName">表名</param>
    /// <returns></returns>
    public DataTable GetColumnsToTable(string tableName)
    {
        //获取数据表中字段的信息
        //string cmdText = "SELECT SysObjects.Name as TableName,SysColumns.Name as ColumnsName, "
        //    + "SysTypes.Name as ColumnsType,SysColumns.Length as ColumnsLength "
        //    + "FROM SysObjects,SysTypes,SysColumns WHERE (Sysobjects.Xtype='u' OR Sysobjects.Xtype ='v') "
        //    + "AND Sysobjects.Id = Syscolumns.Id AND SysTypes.XType = Syscolumns.XType "
        //    + "AND SysTypes.Name  <> 'sysname'  AND SysObjects.name = '" + tableName + "' ";

        CodeToolsHelper.ConnStr = "server=" + TbIpAdd.Text.Trim() + ";user id=" + TbUser.Text.Trim() + ";pwd=" + TbPwd.Text.Trim() + ";database=" + DDLDataBase.SelectedValue;
        
        string cmdText = "SELECT ColumnsName=C.name,ColumnDesc=ISNULL(PFD.[value],N''),ColumnsType=T.name "
            + "FROM sys.columns C    INNER JOIN sys.objects O ON C.[object_id]=O.[object_id] "
            + "AND O.type='U' AND O.is_ms_shipped=0 INNER JOIN sys.types T ON C.user_type_id=T.user_type_id   "
            + "LEFT JOIN sys.extended_properties PFD ON PFD.class=1 AND C.[object_id]=PFD.major_id AND C.column_id=PFD.minor_id "
            + "WHERE O.name=N'" + tableName + "' "
            + "ORDER BY O.name,C.column_id ";
        return CodeToolsHelper.GetDataSet(cmdText).Tables[0];
    }

    /// <summary>
    /// 获取表中的列
    /// </summary>
    public void DataBindColumns()
    {
        DataTable dt = GetColumnsToTable(DDLDataTable.SelectedValue.ToString());
        //绑定
        RepColumns.DataSource = dt;
        RepColumns.DataBind();
    }

    /// <summary>
    /// 获取表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DDLDataBase_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDataTable();
    }

    //选择数据表
    protected void DDLDataTable_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataBindColumns();
    }

    //生成实体文件
    protected void BtnRealse_Click(object sender, EventArgs e)
    {
        if (DDLDataTable.SelectedValue == null)
        {
            LbTooltip.Text="请先连接数据获取数据表";
            return;
        }
        if (DDLGenerationFile.Text == "全部")
        {
            if (TbModelName.Text.Trim() == string.Empty)
            {
                LbTooltip.Text="请输入描述";
                return;
            }

            //生成实体文件
            GenerationModel(DDLDataTable.SelectedValue.ToString(), TbModelName.Text);
            // 生成接口文件
            GenerationInterface(DDLDataTable.SelectedValue.ToString(), TbModelName.Text);
            //生成BLL文件
            GenerationBLL(DDLDataTable.SelectedValue.ToString(), TbModelName.Text);
        }
        else
        {
            if (TbModelName.Text.Trim() == string.Empty && DDLGenerationFile.Text == "实体文件")
            {
                LbTooltip.Text = "请输入描述";
                return;
            }

            if (DDLGenerationFile.Text == "实体文件")
            {                
                //生成实体文件
                GenerationModel(DDLDataTable.SelectedValue.ToString(),TbModelName.Text);
            }
            if (DDLGenerationFile.Text == "接口文件")
            {
                // 生成接口文件
                GenerationInterface(DDLDataTable.SelectedValue.ToString(), TbModelName.Text);
            }

            if (DDLGenerationFile.Text == "业务文件")
            {
                // 生成接口文件
                GenerationBLL(DDLDataTable.SelectedValue.ToString(), TbModelName.Text);
            }
        }
        LbTooltip.Text="生成成功";
    }

    /// <summary>
    /// 生成实体文件
    /// </summary>
    /// <param name="tableName">实体表名</param>
    /// <param name="desc">描述</param>   
    public void GenerationModel(string tableName, string desc)
    {
        DataTable dt = GetColumnsToTable(tableName);
        //拼接字符
        StringBuilder sb = new StringBuilder();
        sb.Append("using System;\r\n");
        sb.Append("using System.Text;\r\n");
        sb.Append("using System.Collections.Generic;\r\n");
        sb.Append("namespace YK.Model \r\n");
        sb.Append("{ \r\n");
        //实体描述
        sb.Append("/// <summary> \r\n");
        sb.Append("///" + desc + "\r\n");
        sb.Append("/// </summary>\r\n");
        sb.Append("public class  " + tableName + "{ \r\n");
        //字段
        foreach (DataRow dr in dt.Rows)
        {
            sb.Append("/// <summary> \r\n");
            sb.Append("///" + dr["ColumnDesc"].ToString() + "\r\n");
            sb.Append("/// </summary>\r\n");
            sb.Append("public " + GetColumnType(dr["ColumnsType"].ToString()) + " " + dr["ColumnsName"].ToString() + " {get;set;} \r\n");
        }
        sb.Append("} \r\n");
        sb.Append("} \r\n");

        string[] arr = tableName.Split('_');
        //文件路径
        string directory = AppPath + "CodeFile/Model/" + (arr.Length == 3 ? arr[1] + "/" : "");
        string fileUrl = directory + tableName + ".cs";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        //创建文件
        FileStream fs = File.Create(fileUrl);
        StreamWriter sw = new StreamWriter(fs,
            System.Text.Encoding.GetEncoding("utf-8"));
        sw.Write(sb.ToString());
        sw.Close();
    }

    /// <summary>
    /// 生成接口文件
    /// </summary>
    /// <param name="tableName">实体表名</param>
    /// <param name="desc">描述</param>   
    public void GenerationInterface(string tableName, string desc)
    {
        string templateUrl = AppPath + "Template/IModel.cs";
        string text = "";
        StreamReader sr = new StreamReader(templateUrl);
        text = sr.ReadToEnd();
        sr.Close();
        text = text.Replace("#接口名称#", desc + "接口").Replace("#实体名称#", tableName).
            Replace("#接口#", "I" + tableName.Replace("TB_", ""));
     
        string[] arr = tableName.Split('_');
        //文件路径
        string directory = AppPath + "CodeFile/Interface/" + (arr.Length == 3 ? arr[1] + "/" : "");
        string fileUrl = directory + "I" + tableName.Replace("tb_", "").Replace("tB_", "").Replace("Tb_", "").Replace("TB_", "") + ".cs";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        //创建文件
        FileStream fs = File.Create(fileUrl);
        StreamWriter sw = new StreamWriter(fs,
            System.Text.Encoding.GetEncoding("utf-8"));
        sw.Write(text);
        sw.Close();
    }

    /// <summary>
    /// 生成数据访问层
    /// </summary>
    /// <param name="tableName">实体表名</param>
    /// <param name="desc">描述</param>    
    public void GenerationBLL(string tableName,string desc)
    {
        string templateUrl = AppPath + "Template/Model_BLL.cs";
        string text = "";
        StreamReader sr = new StreamReader(templateUrl);
        text = sr.ReadToEnd();
        sr.Close();

        text = text.Replace("#业务描述#", desc + "业务").
            Replace("#实体#", tableName).
            Replace("#接口#", "I" + tableName.Replace("tb_", "").Replace("tB_", "").Replace("Tb_", "").Replace("TB_", "")).
            Replace("#业务#", tableName.Replace("tb_", "").Replace("tB_", "").Replace("Tb_", "").Replace("TB_", "") + "_BLL"); ;

        string[] arr = tableName.Split('_');
        //文件路径
        string directory = AppPath + "CodeFile/BLL/" + (arr.Length == 3 ? arr[1] + "/" : "");
        string fileUrl = directory + tableName.Replace("tb_", "").Replace("tB_", "").Replace("Tb_", "").Replace("TB_", "") + "_BLL.cs";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        //创建文件
        FileStream fs = File.Create(fileUrl);
        StreamWriter sw = new StreamWriter(fs,
            System.Text.Encoding.GetEncoding("utf-8"));
        sw.Write(text);
        sw.Close();
    }

    /// <summary>
    /// 获取字段类型对应的程序类型
    /// </summary>
    /// <param name="typeName">类型名称</param>
    /// <returns></returns>
    protected string GetColumnType(string typeName)
    {
        string type = "";
        switch (typeName.ToLower())
        {
            case "int":
                type = "int";
                break;
            case "smallint":
                type = "int";
                break;
            case "varchar":
                type = "string";
                break;
            case "bit":
                type = "bool";
                break;
            case "nvarchar":
                type = "string";
                break;
            case "nchar":
                type = "string";
                break;
            case "ntext":
                type = "string";
                break;
            case "text":
                type = "string";
                break;
            case "money":
                type = "decimal";
                break;
            case "decimal":
                type = "decimal";
                break;
            case "float":
                type = "float";
                break;
            case "datetime":
                type = "DateTime";
                break;
        }
        return type;
    }

    protected void BtnGenerationCheckTable_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in RepTables.Items)
        {
            CheckBox check = (CheckBox)item.FindControl("ChkTable");
            string tableName = ((HiddenField)item.FindControl("HiddenName")).Value;
            string desc = ((TextBox)item.FindControl("TbDesc")).Text;
            if (check.Checked)
            {
                //生成实体文件
                GenerationModel(tableName, desc);
                // 生成接口文件
                GenerationInterface(tableName, desc);
                //生成BLL文件
                GenerationBLL(tableName, desc);
            }
        }
    }
}
