using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YK.Model;
using System.Data.SqlClient;

namespace YK.Interface.Common
{
    /// <summary>
    /// 公共接口，提供通用的方法，供子接口继承
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial interface IBase<TEntity>
    {

        /// <summary>
        /// 插入（添加）
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        int Insert(TEntity entity);

        /// <summary>
        /// 插入（添加）
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isBackId">是否返回主键</param>
        /// <returns></returns>
        object Insert(TEntity entity, bool isBackId);

        /// <summary>
        /// 大数据量插入
        /// </summary>
        /// <param name="entityList">实体列表</param>
        /// <param name="isPkIdentity">是否保留标志源</param>
        /// <returns></returns>
        bool Insert(List<TEntity> entityList, bool isPkIdentity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        int Update(TEntity entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        int Update(TEntity entity, List<Expression> express);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        int Update(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, bool>> express);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        int Delete(object id);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        int Delete(List<Expression> express);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        int Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> express);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        TEntity Get(object id);


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        TEntity Get(List<Expression> express);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        TEntity Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> express);

    }
    /// <summary>
    /// Search
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial interface IBase<TEntity>
    {
        ////////////////////////////////////////////////////////////////////////------Search-------/////////////////////////////////////////////////////////////////

        /// <summary>
        /// 分页查询，参数：页面大小，页码，表达式，排序，数据总条数
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        List<TEntity> Search(int pageSize, int pageIndex, List<Expression> express, string orderBy, ref int recordCount);


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="express">表达式</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        List<TEntity> Search(int pageSize, int pageIndex, List<Expression> express, ref int recordCount);

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序,为空则不排序</param>
        /// <returns></returns>
        List<TEntity> Search(int count, List<Expression> express, string orderBy);

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        List<TEntity> Search(int count, List<Expression> express);

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <returns></returns>
        List<TEntity> Search(int count);

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序,为空则不排序</param>
        /// <returns></returns>
        List<TEntity> Search(List<Expression> express, string orderBy);

        /// <summary>
        /// 不分页查询,通过表达式查询所有数据
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        List<TEntity> Search(List<Expression> express);

        /// <summary>
        /// 不分页查询，不带任何条件
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        List<TEntity> Search();
    }

    /// <summary>
    /// 搜索模块（Lambda Search）
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial interface IBase<TEntity>
    {

        //////////////////////////////////////////////////////////////////////搜索模块（Lambda Search）///////////////////////////////////////////////////////////////

        /// <summary>
        /// 分页查询，参数：页面大小，页码，表达式，排序，数据总条数
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        List<TEntity> Search(int pageSize, int pageIndex, System.Linq.Expressions.Expression<Func<TEntity, bool>> express, string orderBy, ref int recordCount);



        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="express">表达式</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        List<TEntity> Search(int pageSize, int pageIndex, System.Linq.Expressions.Expression<Func<TEntity, bool>> express, ref int recordCount);


        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序,为空则不排序</param>
        /// <returns></returns>
        List<TEntity> Search(int count, System.Linq.Expressions.Expression<Func<TEntity, bool>> express, string orderBy);


        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        List<TEntity> Search(int count, System.Linq.Expressions.Expression<Func<TEntity, bool>> express);


        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序,为空则不排序</param>
        /// <returns></returns>
        List<TEntity> Search(System.Linq.Expressions.Expression<Func<TEntity, bool>> express, string orderBy);


        /// <summary>
        /// 不分页查询,通过表达式查询所有数据
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        List<TEntity> Search(System.Linq.Expressions.Expression<Func<TEntity, bool>> express);

    }

    /// <summary>
    /// 搜索模块（SQL Search）
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial interface IBase<TEntity>
    {

        ////////////////////////////////////////////////////////////////////////------SQL-------/////////////////////////////////////////////////////////////////

        /// <summary>
        /// SQL命令语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        List<TEntity> SQLSearch(string cmdText);

        /// <summary>
        /// SQL命令语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        List<TEntity> SQLSearch(string cmdText, List<SqlParameter> listPara);

        /// <summary>
        /// SQL命令语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        DataSet SQLGetDataSet(string cmdText, List<SqlParameter> listPara);

        /// <summary>
        /// SQL命令语句，返回所影响的行数
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        int SQLExecuteNonQuery(string cmdText, List<SqlParameter> listPara);

        /// <summary>
        /// SQL命令语句，返回数据阅读器
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        IDataReader SQLExecuteReader(string cmdText, List<SqlParameter> listPara);

        /// <summary>
        /// SQL命令语句，返回第一行第一列的值
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        string SQLExecuteScalar(string cmdText, List<SqlParameter> listPara);
    }
}
