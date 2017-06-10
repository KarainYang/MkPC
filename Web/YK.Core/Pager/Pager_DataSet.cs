using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace YK.Core
{
    /// <summary>
    /// 分页
    /// </summary>
    public class Pager_DataSet
    {
        /// <summary>
        /// 传递参数分别是：表名，主键，页面大小，分页码，条件，查询总数,参数
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="PrimaryKey"></param>
        /// <param name="selectValue"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="Where"></param>
        /// <param name="OrderBy"></param>
        /// <param name="recordCount"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public DataSet GetPagerInfo(string TableName, string PrimaryKey, string selectValue, int PageSize, int PageIndex, string Where, string OrderBy, ref int recordCount, List<SqlParameter> spr)
        {

            Where = string.IsNullOrEmpty(Where) ? "1=1" : Where;
            OrderBy = string.IsNullOrEmpty(OrderBy) ? "" : (" Order By " + OrderBy);

            string cmdText = "select count(" + PrimaryKey + ") from " + TableName + " where " + Where;
            recordCount = new SqlConvertHelper().ExecuteScalar(cmdText, spr).ToInt();

            //当页码为1，或小于1时
            if (PageIndex <= 1)
            {
                cmdText = "select top " + PageSize + " " + selectValue + " from " + TableName + " where " + Where + " " + OrderBy;
            }
            else
            {
                cmdText = "select top " + PageSize + " " + selectValue + " from " + TableName + " where " + Where + " and " + PrimaryKey 
                    + " not in (select top " + PageSize * (PageIndex - 1) + " " + PrimaryKey + " from " + TableName + " where " + Where + " " + OrderBy + ") " + OrderBy;
            }
            return new SqlConvertHelper().GetDataSet(cmdText, spr);
        }

        /// <summary>
        /// 传递参数分别是：表名，主键，页面大小，分页码，条件，查询总数，参数
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="PrimaryKey"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="Where"></param>
        /// <param name="OrderBy"></param>
        /// <param name="recordCount"></param>
        /// <param name="spr"></param>
        /// <returns></returns>
        public DataSet GetPagerInfo(string TableName, string PrimaryKey, int PageSize, int PageIndex, string Where, string OrderBy, ref int recordCount, List<SqlParameter> spr)
        {
            return GetPagerInfo(TableName, PrimaryKey, "*", PageSize, PageIndex, Where,OrderBy, ref recordCount, spr);
        }

        /// <summary>
        /// 传递参数分别是：表名，主键，页面大小，分页码，条件，查询总数
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="PrimaryKey"></param>
        /// <param name="selectValue"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="Where"></param>
        /// <param name="OrderBy"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataSet GetPagerInfo(string TableName, string PrimaryKey, string selectValue, int PageSize, int PageIndex, string Where, string OrderBy, ref int recordCount)
        {
            return GetPagerInfo(TableName, PrimaryKey, selectValue, PageSize, PageIndex, Where, OrderBy, ref recordCount, null);
        }

        /// <summary>
        /// 传递参数分别是：表名，主键，页面大小，分页码，条件，查询总数
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="PrimaryKey"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="Where"></param>
        /// <param name="OrderBy"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataSet GetPagerInfo(string TableName, string PrimaryKey, int PageSize, int PageIndex, string Where, string OrderBy, ref int recordCount)
        {
            return GetPagerInfo(TableName, PrimaryKey, "*", PageSize, PageIndex, Where, OrderBy, ref recordCount);
        }

    }
}
