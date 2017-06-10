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
    /// SQL转换
    /// </summary>
    public class SqlConvertHelper
    {
        private List<SqlParameter> sqlserverParamList;
        private List<MySqlParameter> mysqlParamList;
        private List<OracleParameter> oraclParamList;


        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="spr"></param>
        public void GetParameters(List<SqlParameter> spr)
        {
            sqlserverParamList = new List<SqlParameter>();
            mysqlParamList = new List<MySqlParameter>();
            oraclParamList = new List<OracleParameter>();

            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
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
        public int ExecuteNonQuery(CommandType commandType, string cmdText, List<SqlParameter> spr)
        {
            GetParameters(spr);
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteNonQuery(commandType, cmdText, sqlserverParamList);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteNonQuery(commandType, cmdText, mysqlParamList);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteNonQuery(commandType, cmdText, oraclParamList);
                    break;
            }
            return 0;
        }

        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public int ExecuteNonQueryPro(string cmdText, List<SqlParameter> spr)
        {
            GetParameters(spr);
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteNonQueryPro(cmdText, sqlserverParamList);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteNonQueryPro(cmdText, mysqlParamList);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteNonQueryPro(cmdText, oraclParamList);
                    break;
            }
            return 0;
        }

        /// <summary>
        /// 不带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public int ExecuteNonQueryPro(string cmdText)
        {
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteNonQueryPro(cmdText);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteNonQueryPro(cmdText);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteNonQueryPro(cmdText);
                    break;
            }
            return 0;
        }

        /// <summary>
        /// 带参数的操作语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText, List<SqlParameter> spr)
        {
            GetParameters(spr);
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteNonQuery(cmdText, sqlserverParamList);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteNonQuery(cmdText, mysqlParamList);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteNonQuery(cmdText, oraclParamList);
                    break;
            }
            return 0;
        }

        /// <summary>
        /// 不带参数的操作语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText)
        {
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteNonQuery(cmdText);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteNonQuery(cmdText);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteNonQuery(cmdText);
                    break;
            }
            return 0;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public DataSet GetDataSet(CommandType cmdType, string cmdText, List<SqlParameter> spr)
        {
            GetParameters(spr);
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.GetDataSet(cmdType,cmdText, sqlserverParamList);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.GetDataSet(cmdType, cmdText, mysqlParamList);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.GetDataSet(cmdType, cmdText, oraclParamList);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public DataSet GetDataSetPro(string cmdText, List<SqlParameter> spr)
        {
            GetParameters(spr);
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.GetDataSetPro(cmdText, sqlserverParamList);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.GetDataSetPro(cmdText, mysqlParamList);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.GetDataSetPro(cmdText, oraclParamList);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 不带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public DataSet GetDataSetPro(string cmdText)
        {
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.GetDataSetPro(cmdText);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.GetDataSetPro(cmdText);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.GetDataSetPro(cmdText);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 带参数的文本查询
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string cmdText, List<SqlParameter> spr)
        {
            GetParameters(spr);
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.GetDataSet(cmdText, sqlserverParamList);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.GetDataSet(cmdText, mysqlParamList);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.GetDataSet(cmdText, oraclParamList);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 不带参数的文本查询
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string cmdText)
        {
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.GetDataSet(cmdText);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.GetDataSet(cmdText);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.GetDataSet(cmdText);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 数据阅读器
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(CommandType cmdType, string cmdText, List<SqlParameter> spr)
        {
            GetParameters(spr);
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteReader(cmdType, cmdText, sqlserverParamList);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteReader(cmdType, cmdText, mysqlParamList);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteReader(cmdType, cmdText, oraclParamList);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public IDataReader ExecuteReaderPro(string cmdText, List<SqlParameter> spr)
        {
            GetParameters(spr);
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteReaderPro(cmdText, sqlserverParamList);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteReaderPro(cmdText, mysqlParamList);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteReaderPro(cmdText, oraclParamList);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 不带带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public IDataReader ExecuteReaderPro(string cmdText)
        {
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteReaderPro(cmdText);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteReaderPro(cmdText);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteReaderPro(cmdText);
                    break;
            }
            return null;
        }


        /// <summary>
        /// 带参数的文本
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string cmdText, List<SqlParameter> spr)
        {
            GetParameters(spr);
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteReader(cmdText, sqlserverParamList);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteReader(cmdText, mysqlParamList);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteReader(cmdText, oraclParamList);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 不带参数的文本
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string cmdText)
        {
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteReader(cmdText);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteReader(cmdText);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteReader(cmdText);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 返回第一行第一列的值
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public string ExecuteScalar(CommandType cmdType, string cmdText, List<SqlParameter> spr)
        {
            GetParameters(spr);
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteScalar(cmdType, cmdText, sqlserverParamList);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteScalar(cmdType, cmdText, mysqlParamList);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteScalar(cmdType, cmdText, oraclParamList);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public string ExecuteScalarPro(string cmdText, List<SqlParameter> spr)
        {
            GetParameters(spr);
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteScalarPro(cmdText, sqlserverParamList);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteScalarPro(cmdText, mysqlParamList);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteScalarPro(cmdText, oraclParamList);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 不带参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public string ExecuteScalarPro(string cmdText)
        {
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteScalarPro(cmdText);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteScalarPro(cmdText);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteScalarPro(cmdText);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 带参数的文本
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public string ExecuteScalar(string cmdText, List<SqlParameter> spr)
        {
            GetParameters(spr);
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteScalar(cmdText, sqlserverParamList);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteScalar(cmdText, mysqlParamList);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteScalar(cmdText, oraclParamList);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 不带参数的文本
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public string ExecuteScalar(string cmdText)
        {
            var connDic = new ConnectionHelper().GetConnectionDic();
            switch (connDic["provider"])
            {
                case "System.Data.SqlClient":
                    var sqlHelper = new SqlHelper();
                    sqlHelper.ConnectionString = connDic["connectionstring"];
                    return sqlHelper.ExecuteScalar(cmdText);
                    break;
                case "MySql.Data.MySqlClient":
                    var mySqlHelper = new MySqlHelper();
                    mySqlHelper.ConnectionString = connDic["connectionstring"];
                    return mySqlHelper.ExecuteScalar(cmdText);
                    break;
                case "System.Data.OracleClient":
                    var oraclHelper = new OracleHelper();
                    oraclHelper.ConnectionString = connDic["connectionstring"];
                    return oraclHelper.ExecuteScalar(cmdText);
                    break;
            }
            return null;
        }

        /// <summary>
        /// 大批量数据插入
        /// </summary>
        /// <param name="tableNamelist">表名数组</param>
        /// <param name="dtlist">数据表数组</param>
        /// <param name="isPkIdentitylist">是否保留标志源</param>
        public bool BatchCopyInsert(string tableName, DataTable dt, bool isPkIdentity)
        {
            return new SqlHelper().BatchCopyInsert(tableName,dt,isPkIdentity);
        }
        /// <summary>
        /// 大批量数据插入
        /// </summary>
        /// <param name="tableNamelist">表名数组</param>
        /// <param name="dtlist">数据表数组</param>
        /// <param name="isPkIdentitylist">是否保留标志源</param>
        public bool BatchCopyInsert(List<string> tableNameList, List<DataTable> dtList, List<bool> isPkIdentitylist)
        {
            return new SqlHelper().BatchCopyInsert(tableNameList, dtList, isPkIdentitylist);
        }
    }
}
