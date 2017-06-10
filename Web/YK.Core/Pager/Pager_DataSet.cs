using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace YK.Core
{
    /// <summary>
    /// ��ҳ
    /// </summary>
    public class Pager_DataSet
    {
        /// <summary>
        /// ���ݲ����ֱ��ǣ�������������ҳ���С����ҳ�룬��������ѯ����,����
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

            //��ҳ��Ϊ1����С��1ʱ
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
        /// ���ݲ����ֱ��ǣ�������������ҳ���С����ҳ�룬��������ѯ����������
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
        /// ���ݲ����ֱ��ǣ�������������ҳ���С����ҳ�룬��������ѯ����
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
        /// ���ݲ����ֱ��ǣ�������������ҳ���С����ҳ�룬��������ѯ����
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
