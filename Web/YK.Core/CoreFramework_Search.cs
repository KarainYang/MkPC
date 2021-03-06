using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.IO;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using YK.Model;

namespace YK.Core
{
    /// <summary>
    /// 公共操作类，搜索模块（Search）
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    internal partial class CoreFramework<TEntity> : ICoreFramework<TEntity> where TEntity : new() 
    {
        /// <summary>
        /// 分页查询，基础方法，参数：页面大小，页码，主键，查询字段，表达式，排序，数据总条数
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="primaryKey">主键</param>
        /// <param name="selectFields">查询字段</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        private List<TEntity> Search(int pageSize, int pageIndex, string primaryKey, string selectFields, List<Expression> express, string orderBy, ref int recordCount)
        {
            //获取参数和条件
            CoreFrameworkEntity CoreFrameworkEntity = GetParaListAndWhere(express);
            //条件
            string where = CoreFrameworkEntity.where;
            //参数列表
            List<SqlParameter> listPara = CoreFrameworkEntity.paraList;

            selectFields = selectFields == "" ? "*" : selectFields;//查询字段

            Pager page = new Pager();
            IDataReader sdr = page.GetPagerInfo(tableName, primaryKey, selectFields, pageSize, pageIndex, where, orderBy, ref recordCount, listPara);

            return DynamicBuilder<TEntity>.GetList(sdr, columnAttrList);

        }

        /// <summary>
        /// 分页查询，参数：页面大小，页码，查询字段，表达式，排序，数据总条数
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="selectFields">查询字段</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        private List<TEntity> Search(int pageSize, int pageIndex, string selectFields, List<Expression> express, string orderBy, ref int recordCount)
        {
            return Search(pageSize, pageIndex, primaryKey, selectFields, express, orderBy, ref recordCount);
        }

        /// <summary>
        /// 分页查询，参数：页面大小，页码，查询字段，表达式，数据总条数
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="selectFields">查询字段</param>
        /// <param name="express">表达式</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        private List<TEntity> Search(int pageSize, int pageIndex, string selectFields, List<Expression> express, ref int recordCount)
        {
            return Search(pageSize, pageIndex, selectFields, express, "", ref recordCount);
        }

        /// <summary>
        /// 分页查询，参数：页面大小，页码，表达式，排序，数据总条数
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        public List<TEntity> Search(int pageSize, int pageIndex, List<Expression> express, string orderBy, ref int recordCount)
        {
            return Search(pageSize, pageIndex, "*", express, orderBy, ref recordCount);
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="express">表达式</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        public List<TEntity> Search(int pageSize, int pageIndex, List<Expression> express, ref int recordCount)
        {
            return Search(pageSize, pageIndex, express, "", ref recordCount);
        }

        /// <summary>
        /// 不分页查询,基础方法
        /// </summary>
        /// <param name="count">显示总数，空则全部显示</param>
        /// <param name="selectFields">查询字段</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序,为空则不排序</param>
        /// <returns></returns>
        private List<TEntity> Search(int? count, string selectFields, List<Expression> express, string orderBy)
        {
            //获取参数和条件
            CoreFrameworkEntity CoreFrameworkEntity = GetParaListAndWhere(express);
            //条件
            string where = CoreFrameworkEntity.where;
            //参数列表
            List<SqlParameter> listPara = CoreFrameworkEntity.paraList;

            selectFields = selectFields == "" ? "*" : selectFields;//查询字段
            orderBy = orderBy == "" ? "" : "order by " + orderBy;//排序

            string topStr = count.HasValue == false ? "" : " top " + count + " ";
            string cmdText = "select " + topStr + selectFields + " from " + tableName + " where " + where + " " + orderBy;
            IDataReader sdr = new SqlConvertHelper().ExecuteReader(cmdText, listPara);
            return DynamicBuilder<TEntity>.GetList(sdr, columnAttrList);
        }

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序,为空则不排序</param>
        /// <returns></returns>
        public List<TEntity> Search(int count,List<Expression> express, string orderBy)
        {
            return Search(count,"*", express, orderBy);
        }

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public List<TEntity> Search(int count, List<Expression> express)
        {
            return Search(count, "*", express, "");
        }

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <returns></returns>
        public List<TEntity> Search(int count)
        {
            List<Expression> express = new List<Expression>();

            return Search(count, "*", express, "");
        }

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序,为空则不排序</param>
        /// <returns></returns>
        public List<TEntity> Search(List<Expression> express, string orderBy)
        {
            return Search(null,"*", express, orderBy);
        }

        /// <summary>
        /// 不分页查询,通过表达式查询所有数据
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public List<TEntity> Search(List<Expression> express)
        {
            return Search(express, "");
        }

        /// <summary>
        /// 不分页查询，不带任何条件
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public List<TEntity> Search()
        {
            List<Expression> express = new List<Expression>();
            return Search(express);
        }
    }

    /// <summary>
    /// 公共操作类，搜索模块（Lambda Search）
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    internal partial class CoreFramework<TEntity> 
    {
        /// <summary>
        /// 分页查询，基础方法，参数：页面大小，页码，主键，查询字段，表达式，排序，数据总条数
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="primaryKey">主键</param>
        /// <param name="selectFields">查询字段</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        private List<TEntity> Search(int pageSize, int pageIndex, string primaryKey, string selectFields, System.Linq.Expressions.Expression<Func<TEntity, bool>> express, string orderBy, ref int recordCount)
        {
            //获取参数和条件
            CoreFrameworkEntity lambdaEntity = GetLambdaEntity(express);
            //条件
            string where = lambdaEntity.where;
            //参数列表
            List<SqlParameter> listPara = lambdaEntity.paraList;

            selectFields = selectFields == "" ? "*" : selectFields;//查询字段

            Pager page = new Pager();
            IDataReader sdr = page.GetPagerInfo(tableName, primaryKey, selectFields, pageSize, pageIndex, where, orderBy, ref recordCount, listPara);

            return DynamicBuilder<TEntity>.GetList(sdr, columnAttrList);

        }

        /// <summary>
        /// 分页查询，参数：页面大小，页码，查询字段，表达式，排序，数据总条数
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="selectFields">查询字段</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        private List<TEntity> Search(int pageSize, int pageIndex, string selectFields, System.Linq.Expressions.Expression<Func<TEntity, bool>> express, string orderBy, ref int recordCount)
        {
            return Search(pageSize, pageIndex, primaryKey, selectFields, express, orderBy, ref recordCount);
        }

        /// <summary>
        /// 分页查询，参数：页面大小，页码，查询字段，表达式，数据总条数
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="selectFields">查询字段</param>
        /// <param name="express">表达式</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        private List<TEntity> Search(int pageSize, int pageIndex, string selectFields, System.Linq.Expressions.Expression<Func<TEntity, bool>> express, ref int recordCount)
        {
            return Search(pageSize, pageIndex, selectFields, express, "", ref recordCount);
        }

        /// <summary>
        /// 分页查询，参数：页面大小，页码，表达式，排序，数据总条数
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        public List<TEntity> Search(int pageSize, int pageIndex, System.Linq.Expressions.Expression<Func<TEntity, bool>> express, string orderBy, ref int recordCount)
        {
            return Search(pageSize, pageIndex, "*", express, orderBy, ref recordCount);
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="express">表达式</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        public List<TEntity> Search(int pageSize, int pageIndex, System.Linq.Expressions.Expression<Func<TEntity, bool>> express, ref int recordCount)
        {
            return Search(pageSize, pageIndex, express, "", ref recordCount);
        }

        /// <summary>
        /// 不分页查询,基础方法
        /// </summary>
        /// <param name="count">显示总数，空则全部显示</param>
        /// <param name="selectFields">查询字段</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序,为空则不排序</param>
        /// <returns></returns>
        private List<TEntity> Search(int? count, string selectFields, System.Linq.Expressions.Expression<Func<TEntity, bool>> express, string orderBy)
        {
            //获取参数和条件
            CoreFrameworkEntity lambdaEntity = GetLambdaEntity(express);
            //条件
            string where = lambdaEntity.where;
            //参数列表
            List<SqlParameter> listPara = lambdaEntity.paraList;

            selectFields = selectFields == "" ? "*" : selectFields;//查询字段
            orderBy = orderBy == "" ? "" : "order by " + orderBy;//排序

            string topStr = count.HasValue == false ? "" : " top " + count + " ";
            string cmdText = "select " + topStr + selectFields + " from " + tableName + " where " + where + " " + orderBy;
            IDataReader sdr = new SqlConvertHelper().ExecuteReader(cmdText, listPara);
            return DynamicBuilder<TEntity>.GetList(sdr, columnAttrList);
        }

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序,为空则不排序</param>
        /// <returns></returns>
        public List<TEntity> Search(int count, System.Linq.Expressions.Expression<Func<TEntity, bool>> express, string orderBy)
        {
            return Search(count, "*", express, orderBy);
        }

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public List<TEntity> Search(int count, System.Linq.Expressions.Expression<Func<TEntity, bool>> express)
        {
            return Search(count, "*", express, "");
        }

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序,为空则不排序</param>
        /// <returns></returns>
        public List<TEntity> Search(System.Linq.Expressions.Expression<Func<TEntity, bool>> express, string orderBy)
        {
            return Search(null, "*", express, orderBy);
        }

        /// <summary>
        /// 不分页查询,通过表达式查询所有数据
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public List<TEntity> Search(System.Linq.Expressions.Expression<Func<TEntity, bool>> express)
        {
            return Search(express, "");
        }
    }

    /// <summary>
    /// 公共操作类，SQL命令语句模块（SQL）
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    internal partial class CoreFramework<TEntity>
    {
        /// <summary>
        /// SQL命令语句,获取数据
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public List<TEntity> SQLSearch(string cmdText)
        {
            return SQLSearch(cmdText,null);
        }

        /// <summary>
        /// SQL命令语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public List<TEntity> SQLSearch(string cmdText,List<SqlParameter> listPara)
        {
            IDataReader sdr = new SqlConvertHelper().ExecuteReader(cmdText, listPara);
            return DynamicBuilder<TEntity>.GetList(sdr, columnAttrList);
        }

        /// <summary>
        /// SQL命令语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public DataSet SQLGetDataSet(string cmdText, List<SqlParameter> listPara)
        {
            return new SqlConvertHelper().GetDataSet(cmdText, listPara);
        }

        /// <summary>
        /// SQL命令语句，返回所影响的行数
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public int SQLExecuteNonQuery(string cmdText, List<SqlParameter> listPara)
        {
            return new SqlConvertHelper().ExecuteNonQuery(cmdText, listPara);
        }

        /// <summary>
        /// SQL命令语句，返回数据阅读器
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public IDataReader SQLExecuteReader(string cmdText, List<SqlParameter> listPara)
        {
            return new SqlConvertHelper().ExecuteReader(cmdText, listPara);
        }

        /// <summary>
        /// SQL命令语句，返回第一行第一列的值
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public string SQLExecuteScalar(string cmdText, List<SqlParameter> listPara)
        {
            return new SqlConvertHelper().ExecuteScalar(cmdText, listPara);
        }
    }
}
