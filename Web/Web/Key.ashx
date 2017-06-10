<%@ WebHandler Language="C#" Class="Key" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using YK.Model;

public class Key : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.ContentType = "text/plain";
        //关键字
        string key = System.Web.HttpContext.Current.Request["key"];
        //表名
        string tableName = System.Web.HttpContext.Current.Request["tableName"];
        //字段名
        string fieldName = System.Web.HttpContext.Current.Request["fieldName"];
        fieldName = string.IsNullOrEmpty(fieldName) ? "*" : fieldName;
        string[] fields = fieldName.Split(',');

        List<SqlParameter> expression = new List<SqlParameter>();
        expression.Add(new SqlParameter("@key", "%" + key + "%"));

        string cmdText = "select " + fieldName + " from " + tableName + " where " + (fields.Length > 1 ? fields[1] : fields[0]) + " like @key";
        DataTable dt = YK.Core.SqlHelper.GetDataSet(cmdText, expression).Tables[0];
        string json = "[";
        foreach (DataRow dr in dt.Rows)
        {
            json += "{value" + ":" + (fields.Length > 1 ? dr[fields[0]] : 0) + ",name:\"" + dr[(fields.Length > 1 ? fields[1] : fields[0])] + "\"},";
        }
        json = json.TrimEnd(',') + "]";
        System.Web.HttpContext.Current.Response.Write(json.TrimEnd(','));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}