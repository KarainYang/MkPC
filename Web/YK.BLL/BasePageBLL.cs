using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using YK.Model;
using YK.Interface;
using YK.Common;
using System.Reflection;
using YK.Core;

namespace YK.BLL
{

    /// <summary>
    /// 业务
    /// </summary>
    public partial class BasePageBLL<TEntity> where TEntity : new()
    {
        /// <summary>
        /// 插入（添加）
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Insert(TEntity entity)
        {
            return Core<TEntity>.CoreTemplate.Insert(entity);
        }

        /// <summary>
        /// 插入（添加）
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isBackId">是否返回主键</param>
        /// <returns></returns>
        public object Insert(TEntity entity, bool isBackId)
        {
            return Core<TEntity>.CoreTemplate.Insert(entity, isBackId);
        }

        /// <summary>
        /// 批量插入（添加）
        /// </summary>
        /// <param name="entityList">实体列表</param>
        /// <returns></returns>
        public object BatchInsert(List<TEntity> entityList)
        {
            return Core<TEntity>.CoreTemplate.BatchInsert(entityList);
        }

        /// <summary>
        /// 大数据量插入
        /// </summary>
        /// <param name="entityList">实体列表</param>
        /// <param name="isPkIdentity">是否保留标志源</param>
        /// <returns></returns>
        public bool Insert(List<TEntity> entityList, bool isPkIdentity)
        {
            return Core<TEntity>.CoreTemplate.Insert(entityList, isPkIdentity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        public int Update(TEntity entity)
        {
            return Core<TEntity>.CoreTemplate.Update(entity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public int Update(TEntity entity, List<Expression> express)
        { 
            return Core<TEntity>.CoreTemplate.Update(entity,express);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public int Update(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, bool>> express)
        { 
            return Core<TEntity>.CoreTemplate.Update(entity,express);
        }        

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        public int Delete(object id)
        {
            return Core<TEntity>.CoreTemplate.Delete(id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public int Delete(List<Expression> express)
        {
            return Core<TEntity>.CoreTemplate.Delete(express);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public int Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> express)
        {
            return Core<TEntity>.CoreTemplate.Delete(express);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        public TEntity Get(object id)
        {
            return Core<TEntity>.CoreTemplate.Get(id);
        }


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public TEntity Get(List<Expression> express)
        {
            return Core<TEntity>.CoreTemplate.Get(express);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public TEntity Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> express)
        {
            return Core<TEntity>.CoreTemplate.Get(express);
        }


        ////////////////////////////////////////////////////////////////////////------Search-------/////////////////////////////////////////////////////////////////

        #region Search

        
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        public List<TEntity> Search(int pageSize, int pageIndex, List<Expression> express, string orderBy, ref int recordCount)
        {
            return Core<TEntity>.CoreTemplate.Search(pageSize, pageIndex,express,orderBy, ref recordCount);
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="express">表达式</param>
        /// <param name="recordCount">数据总条数</param>        
        /// <returns></returns>
        public List<TEntity> Search(int pageSize, int pageIndex, List<Expression> express, ref int recordCount)
        {
            return Core<TEntity>.CoreTemplate.Search(pageSize, pageIndex,express, ref recordCount);
        }

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序,为空则不排序</param>
        /// <returns></returns>
        public List<TEntity> Search(int count, List<Expression> express, string orderBy)
        {
            return Core<TEntity>.CoreTemplate.Search(count,express, orderBy);
        }

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public List<TEntity> Search(int count, List<Expression> express)
        {
            return Search(count, express, "");
        }

        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <returns></returns>
        public List<TEntity> Search(int count)
        {
            List<Expression> express = new List<Expression>();
            return Search(count, express);
        }
        
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序,为空则不排序</param>
        /// <returns></returns>
        public List<TEntity> Search(List<Expression> express, string orderBy)
        {
            return Core<TEntity>.CoreTemplate.Search(express, orderBy);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public List<TEntity> Search(List<Expression> express)
        {
            return Core<TEntity>.CoreTemplate.Search(express);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public List<TEntity> Search()
        {
            return Core<TEntity>.CoreTemplate.Search();
        }

        #endregion

        
    }

    /// <summary>
    /// 搜索模块（Lambda Search）
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial class BasePageBLL<TEntity>
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
        public List<TEntity> Search(int pageSize, int pageIndex, System.Linq.Expressions.Expression<Func<TEntity, bool>> express, string orderBy, ref int recordCount)
        {
            return Core<TEntity>.CoreTemplate.Search(pageSize, pageIndex, express, orderBy, ref recordCount);
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
            return Core<TEntity>.CoreTemplate.Search(pageSize, pageIndex, express, ref recordCount);
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
            return Core<TEntity>.CoreTemplate.Search(count, express, orderBy);
        }


        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="count">显示总数</param>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public List<TEntity> Search(int count, System.Linq.Expressions.Expression<Func<TEntity, bool>> express)
        {
            return Core<TEntity>.CoreTemplate.Search(count, express);
        }


        /// <summary>
        /// 不分页查询，通过表达式和排序查询数据
        /// </summary>
        /// <param name="express">表达式</param>
        /// <param name="orderBy">排序,为空则不排序</param>
        /// <returns></returns>
        public List<TEntity> Search(System.Linq.Expressions.Expression<Func<TEntity, bool>> express, string orderBy)
        {
            return Core<TEntity>.CoreTemplate.Search(express,orderBy);
        }


        /// <summary>
        /// 不分页查询,通过表达式查询所有数据
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public List<TEntity> Search(System.Linq.Expressions.Expression<Func<TEntity, bool>> express)
        {
            return Core<TEntity>.CoreTemplate.Search(express);
        }

    }

    /// <summary>
    /// 搜索模块（SQL Search）
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial class BasePageBLL<TEntity>
    {
        ////////////////////////////////////////////////////////////////////////------SQL-------/////////////////////////////////////////////////////////////////

        /// <summary>
        /// SQL命令语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public List<TEntity> SQLSearch(string cmdText)
        {
            return Core<TEntity>.CoreTemplate.SQLSearch(cmdText);
        }

        /// <summary>
        /// SQL命令语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public List<TEntity> SQLSearch(string cmdText, List<SqlParameter> listPara)
        {
            return Core<TEntity>.CoreTemplate.SQLSearch(cmdText, listPara);
        }

        /// <summary>
        /// SQL命令语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public DataSet SQLGetDataSet(string cmdText, List<SqlParameter> listPara)
        {
            return Core<TEntity>.CoreTemplate.SQLGetDataSet(cmdText, listPara);
        }

        /// <summary>
        /// SQL命令语句，返回所影响的行数
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public int SQLExecuteNonQuery(string cmdText, List<SqlParameter> listPara)
        {
            return Core<TEntity>.CoreTemplate.SQLExecuteNonQuery(cmdText, listPara);
        }

        /// <summary>
        /// SQL命令语句，返回数据阅读器
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public IDataReader SQLExecuteReader(string cmdText, List<SqlParameter> listPara)
        {
            return Core<TEntity>.CoreTemplate.SQLExecuteReader(cmdText, listPara);
        }

        /// <summary>
        /// SQL命令语句，返回第一行第一列的值
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public string SQLExecuteScalar(string cmdText, List<SqlParameter> listPara)
        {
            return Core<TEntity>.CoreTemplate.SQLExecuteScalar(cmdText, listPara);
        }
    }
}
