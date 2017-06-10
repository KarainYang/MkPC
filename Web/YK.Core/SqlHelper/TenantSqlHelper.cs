using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using Oracle.DataAccess.Client;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace YK.Core
{
    /// <summary>
    /// 租户SQL执行
    /// </summary>
    public static class TenantSqlHelper
    {
        private static List<SqlParameter> sqlserverParamList;
        private static List<MySqlParameter> mysqlParamList;
        private static List<OracleParameter> oraclParamList;

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="spr"></param>
        public static void GetParameters(Dictionary<string, string> dic,List<SqlParameter> spr)
        {
            sqlserverParamList = new List<SqlParameter>();
            mysqlParamList = new List<MySqlParameter>();
            oraclParamList = new List<OracleParameter>();

            switch (dic["provider"])
            {
                case "System.Data.SqlClient":
                    sqlserverParamList = spr;
                    break;
                case "MySql.Data.MySqlClient":
                    foreach (var item in spr)
                    {
                        mysqlParamList.Add(new MySqlParameter(item.ParameterName, item.Value));
                    }
                    break;
                case "System.Data.OracleClient":
                    foreach (var item in spr)
                    {
                        oraclParamList.Add(new OracleParameter(item.ParameterName, item.Value));
                    }
                    break;
            }
        }

        /// <summary>
        /// 返回影响的行数
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteNonQuery(CommandType commandType, string cmdText, List<SqlParameter> spr)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string,object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                GetParameters(dic,spr);
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteNonQuery(commandType, cmdText, sqlserverParamList);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteNonQuery(commandType, cmdText, mysqlParamList);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteNonQuery(commandType, cmdText, oraclParamList);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteNonQueryPro(string cmdText, List<SqlParameter> spr)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                GetParameters(dic,spr);
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteNonQueryPro(cmdText, sqlserverParamList);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteNonQueryPro(cmdText, mysqlParamList);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteNonQueryPro(cmdText, oraclParamList);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 不带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteNonQueryPro(string cmdText)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteNonQueryPro(cmdText);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteNonQueryPro(cmdText);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteNonQueryPro(cmdText);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 带参数的操作语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteNonQuery(string cmdText, List<SqlParameter> spr)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                GetParameters(dic,spr);
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteNonQuery(cmdText, sqlserverParamList);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteNonQuery(cmdText, mysqlParamList);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteNonQuery(cmdText, oraclParamList);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 不带参数的操作语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteNonQuery(string cmdText)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteNonQuery(cmdText);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteNonQuery(cmdText);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteNonQuery(cmdText);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> GetDataSet(CommandType cmdType, string cmdText, List<SqlParameter> spr)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                GetParameters(dic,spr);
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.GetDataSet(cmdType, cmdText, sqlserverParamList);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.GetDataSet(cmdType, cmdText, mysqlParamList);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.GetDataSet(cmdType, cmdText, oraclParamList);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> GetDataSetPro(string cmdText, List<SqlParameter> spr)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                GetParameters(dic,spr);
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.GetDataSetPro(cmdText, sqlserverParamList);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.GetDataSetPro(cmdText, mysqlParamList);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.GetDataSetPro(cmdText, oraclParamList);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 不带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> GetDataSetPro(string cmdText)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.GetDataSetPro(cmdText);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.GetDataSetPro(cmdText);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.GetDataSetPro(cmdText);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 带参数的文本查询
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> GetDataSet(string cmdText, List<SqlParameter> spr)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                GetParameters(dic,spr);
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.GetDataSet(cmdText, sqlserverParamList);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.GetDataSet(cmdText, mysqlParamList);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.GetDataSet(cmdText, oraclParamList);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 不带参数的文本查询
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> GetDataSet(string cmdText)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.GetDataSet(cmdText);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.GetDataSet(cmdText);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.GetDataSet(cmdText);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 数据阅读器
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteReader(CommandType cmdType, string cmdText, List<SqlParameter> spr)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                GetParameters(dic,spr);
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteReader(cmdType, cmdText, sqlserverParamList);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteReader(cmdType, cmdText, mysqlParamList);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteReader(cmdType, cmdText, oraclParamList);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteReaderPro(string cmdText, List<SqlParameter> spr)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                GetParameters(dic,spr);
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteReaderPro(cmdText, sqlserverParamList);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteReaderPro(cmdText, mysqlParamList);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteReaderPro(cmdText, oraclParamList);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 不带带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteReaderPro(string cmdText)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteReaderPro(cmdText);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteReaderPro(cmdText);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteReaderPro(cmdText);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }


        /// <summary>
        /// 带参数的文本
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteReader(string cmdText, List<SqlParameter> spr)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                GetParameters(dic,spr);
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteReader(cmdText, sqlserverParamList);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteReader(cmdText, mysqlParamList);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteReader(cmdText, oraclParamList);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 不带参数的文本
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteReader(string cmdText)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteReader(cmdText);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteReader(cmdText);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteReader(cmdText);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 返回第一行第一列的值
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteScalar(CommandType cmdType, string cmdText, List<SqlParameter> spr)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                GetParameters(dic,spr);
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteScalar(cmdType, cmdText, sqlserverParamList);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteScalar(cmdType, cmdText, mysqlParamList);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteScalar(cmdType, cmdText, oraclParamList);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteScalarPro(string cmdText, List<SqlParameter> spr)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                GetParameters(dic,spr);
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteScalarPro(cmdText, sqlserverParamList);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteScalarPro(cmdText, mysqlParamList);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteScalarPro(cmdText, oraclParamList);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 不带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteScalarPro(string cmdText)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteScalarPro(cmdText);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteScalarPro(cmdText);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteScalarPro(cmdText);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 带参数的文本
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteScalar(string cmdText, List<SqlParameter> spr)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                GetParameters(dic,spr);
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteScalar(cmdText, sqlserverParamList);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteScalar(cmdText, mysqlParamList);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteScalar(cmdText, oraclParamList);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 不带参数的文本
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, object>> ExecuteScalar(string cmdText)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];

                
                switch (dic["provider"])
                {
                    case "System.Data.SqlClient":
                        var sqlHelper = new SqlHelper();
                        sqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = sqlHelper.ExecuteScalar(cmdText);
                        break;
                    case "MySql.Data.MySqlClient":
                        var mySqlHelper = new MySqlHelper();
                        mySqlHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = mySqlHelper.ExecuteScalar(cmdText);
                        break;
                    case "System.Data.OracleClient":
                        var oraclHelper = new OracleHelper();
                        oraclHelper.ConnectionString = dic["connectionstring"];
                        resDic["data"] = oraclHelper.ExecuteScalar(cmdText);
                        break;
                }
                resDics.Add(resDic);
            }
            return resDics;
        }

        /// <summary>
        /// 大批量数据插入
        /// </summary>
        /// <param name="tableNamelist">表名数组</param>
        /// <param name="dtlist">数据表数组</param>
        /// <param name="isPkIdentitylist">是否保留标志源</param>
        public static List<Dictionary<string, object>> BatchCopyInsert(string tableName, DataTable dt, bool isPkIdentity)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics  = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                var sqlHelper = new SqlHelper();
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];
                resDic["data"] = sqlHelper.BatchCopyInsert(tableName,dt,isPkIdentity);
                resDics.Add(resDic);
            }
            return resDics;
        }
        /// <summary>
        /// 大批量数据插入
        /// </summary>
        /// <param name="tableNamelist">表名数组</param>
        /// <param name="dtlist">数据表数组</param>
        /// <param name="isPkIdentitylist">是否保留标志源</param>
        public static List<Dictionary<string, object>> BatchCopyInsert(List<string> tableNameList, List<DataTable> dtList, List<bool> isPkIdentitylist)
        {
            List<Dictionary<string, object>> resDics = new List<Dictionary<string, object>>();
            var connDics = new ConnectionHelper().GetOrgConnDic();
            foreach (var dic in connDics)
            {
                var sqlHelper = new SqlHelper();
                Dictionary<string, object> resDic = new Dictionary<string, object>();
                resDic["code"] = dic["code"];
                resDic["name"] = dic["name"];
                resDic["data"] = sqlHelper.BatchCopyInsert(tableNameList, dtList, isPkIdentitylist);
                resDics.Add(resDic);
            }
            return resDics;
        }
    }
}
