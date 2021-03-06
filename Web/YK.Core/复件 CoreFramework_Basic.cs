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
using System.Data.Linq.Mapping;

namespace YK.Core
{
    /// <summary>
    /// 公共实体
    /// </summary>
    internal class CoreFrameworkEntity
    {
        /// <summary>
        /// 参数列表
        /// </summary>
        public List<SqlParameter> paraList { get; set; }
        /// <summary>
        /// 条件字符串
        /// </summary>
        public string where { get; set; }
    }

    /// <summary>
    /// 获取实体的属性的Column特性
    /// </summary>
    public class EntityPropColumnAttributes
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        public string propName { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string fieldName { get; set; }
        /// <summary>
        /// 是否主键
        /// </summary>
        public bool isPrimaryKey { get; set; }
        /// <summary>
        /// 是否自动增长
        /// </summary>
        public bool isIdentity { get; set; }
        /// <summary>
        /// 属性的类型名称
        /// </summary>
        public string typeName { get; set; }
    }

    /// <summary>
    /// 公共操作类
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    internal partial class CoreFramework<TEntity> 
    {
        /// <summary>
        /// 主键
        /// </summary>
        private string primaryKey
        {
            get { return GetPrimaryKey(); }
        }
        /// <summary>
        /// 表名
        /// </summary>
        public string tableName {
            get { return AttributeHelper.GetEntityTableAtrributes<TEntity>(); }
        }

        /// <summary>
        /// 获取主键
        /// </summary>
        /// <returns></returns>
        public string GetPrimaryKey()
        {
            var list = AttributeHelper.GetEntityColumnAtrributes<TEntity>();
            foreach(var model in list)
            {
                if (model.isPrimaryKey)
                {
                    return model.fieldName;
                }
            }
            return "";
        }

        /// <summary>
        /// 获取表达式列表对应的参数列表和条件
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public CoreFrameworkEntity GetParaListAndWhere(List<Expression> express)
        {
            //获取实体列的特性
            List<EntityPropColumnAttributes> columnAttrList = AttributeHelper.GetEntityColumnAtrributes<TEntity>();
            #region 获取参数和条件
            //参数列表
            List<SqlParameter> listPara = new List<SqlParameter>();
            //条件
            string where = "";
            if (express != null)
            {
                if (express.Count == 0)
                {
                    where = "1=1";
                }
                int i = 0;//运行的位置，从下标0开始
                foreach (Expression exp in express)
                {
                    string fieldName = columnAttrList.Where(w => w.propName.ToLower() == exp.FieldName.ToLower()).Count() > 0
                        ? columnAttrList.Where(w => w.propName.ToLower() == exp.FieldName.ToLower()).First().fieldName : exp.FieldName;
                    //连接符号
                    if (string.IsNullOrEmpty(exp.Join))
                    {
                        //判断个数是为了防止参数名相同
                        int fieldCount = express.Where(e => e.FieldName == exp.FieldName).Count();
                        string paraName = fieldCount == 1 ? exp.FieldName : exp.FieldName + "_p" + i.ToStr();

                        //当两个条件没有使用连接符时，则默认用and拼接,从第一个参数后试用
                        if (i > 0)
                        {
                            //如果上一个参数不是连接符时，默认每个参数是以and的形式拼接
                            if (string.IsNullOrEmpty(express[i - 1].Join))
                                where += " and ";
                        }

                        #region 条件语句
                        switch (exp.Condition.Trim())
                        {
                            case "like":
                                listPara.Add(new SqlParameter("@" + paraName, "%" + exp.Value + "%"));
                                where += " " + fieldName + " like @" + paraName;
                                break;
                            case "in":
                                where += " " + fieldName + " in (" + exp.Value + ")";
                                break;
                            default:
                                listPara.Add(new SqlParameter("@" + paraName, exp.Value));
                                where += " " + fieldName + " " + exp.Condition + " @" + paraName;
                                break;
                        }
                        #endregion
                    }
                    else
                    {
                        where += " " + exp.Join + " ";
                    }
                    i++;
                }
            }
            else
            {
                where = "1=1";
            }
            #endregion

            CoreFrameworkEntity entity = new CoreFrameworkEntity();
            entity.paraList = listPara;
            entity.where = where;
            return entity;
        }

        /// <summary>
        /// 将数据表转换为实体列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<TEntity> DataTableToEntityList(DataTable dt)
        {
            if(dt==null)
            {
                return new List<TEntity>();
            }
            var list = AttributeHelper.GetEntityColumnAtrributes<TEntity>();
            DataTable dtTwo = new DataTable(tableName);
            foreach (var model in list)
            {
                if (dt.Columns.Contains(model.fieldName))
                {
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = model.propName;
                    dc.DataType = dt.Columns[model.fieldName].DataType;
                    dtTwo.Columns.Add(dc);
                }
            }
            foreach (DataRow dr in dt.Rows)
            {
                DataRow drTwo = dtTwo.NewRow();
                foreach (var model in list)
                {
                    if (dt.Columns.Contains(model.fieldName))
                    {
                        drTwo[model.propName] = dr[model.fieldName];
                    }
                }
                dtTwo.Rows.Add(drTwo);
            }
            return ConvertEntityByEmit.GetList<TEntity>(dtTwo);

            //List<TEntity> entityList = new List<TEntity>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    //实体
            //    TEntity entity = new TEntity();
            //    //循环属性
            //    foreach (PropertyInfo prop in entity.GetType().GetProperties())
            //    {
            //        //判断数据表中是否存在该列
            //        if (dt.Columns.Contains(prop.Name))
            //        {
            //            if (!string.IsNullOrEmpty(dr[prop.Name].ToStr()))
            //            {
            //                //Convert.ChangeType将对象转换为指定类型
            //                prop.SetValue(entity, Convert.ChangeType(dr[prop.Name], prop.PropertyType), null);
            //            }
            //        }

            //    }
            //    entityList.Add(entity);
            //}
            //return entityList;
        }

        /// <summary>
        /// 将阅读器数据转换为实体列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<TEntity> DataTableToEntityList(SqlDataReader sdr)
        {        
            //将阅读器数据转换成DataTable
            var list = AttributeHelper.GetEntityColumnAtrributes<TEntity>();
            DataTable dtTwo = new DataTable(tableName);
            foreach (var model in list)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = model.propName;
                dc.DataType =  Type.GetType(model.typeName);
                dtTwo.Columns.Add(dc);
            }
            while(sdr.Read())
            {
                DataRow drTwo = dtTwo.NewRow();
                foreach (var model in list)
                {
                    try
                    {
                        if (sdr[model.fieldName] != null)
                        {
                            drTwo[model.propName] = sdr[model.fieldName];
                        }
                    }catch{ }
                }
                dtTwo.Rows.Add(drTwo);
            }
            return ConvertEntityByEmit.GetList<TEntity>(dtTwo);
        }

        /// <summary>
        /// 将实体列表转换为数据表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable EntityListToDataTable(List<TEntity> list)
        {
            //实体
            TEntity entity = new TEntity();
            //数据表
            DataTable dt = new DataTable(entity.GetType().Name);
            //创建列
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = prop.Name;
                dc.DataType = typeof(string);
                dt.Columns.Add(dc);
            }
            //填充行
            foreach (TEntity model in list)
            {
                DataRow dr = dt.NewRow();
                //循环属性
                foreach (PropertyInfo prop in model.GetType().GetProperties())
                {
                    string typeName = prop.PropertyType.Name;
                    dr[prop.Name] = prop.GetValue(model, null);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }

    /// <summary>
    /// 公共操作类，增（Insert）、删（Delete）、改（Update）、查（Get）功能
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    internal partial class CoreFramework<TEntity>
    {
        /// <summary>
        /// 插入（添加）
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Insert(TEntity entity)
        {
            //参数列表
            List<SqlParameter> listPara = new List<SqlParameter>();
            string insertStr = "";//插入字段
            string paraStr = "";//参数
            string nowPrimaryKey = primaryKey;
            //获取实体列的特性
            List<EntityPropColumnAttributes> columnAttrList = AttributeHelper.GetEntityColumnAtrributes<TEntity>();
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                EntityPropColumnAttributes columnAttribute=columnAttrList.Where(w => w.propName == prop.Name).First();
                //当不为自动增长时
                if (columnAttribute.isIdentity == false)
                {
                    object val = prop.GetValue(entity, null);
                    if (val != null)
                    {
                        insertStr += columnAttribute.fieldName + ",";//字符拼接
                        paraStr += "@" + columnAttribute.fieldName + ",";//字符拼接                    
                        listPara.Add(new SqlParameter("@" + columnAttribute.fieldName, val));//参数添加
                    }
                }
            }
            //去掉最后的逗号
            insertStr = insertStr.TrimEnd(',');
            paraStr = paraStr.TrimEnd(',');
            //拼接SQL语句
            string cmdText = "insert into " + tableName + "(" + insertStr + ") values(" + paraStr + ")";
            return SqlHelper.ExecuteNonQuery(cmdText, listPara);
        }

        /// <summary>
        /// 大数据量插入
        /// </summary>
        /// <param name="entityList">实体列表</param>
        /// <param name="isPkIdentity">是否保留标志源</param>
        /// <returns></returns>
        public bool Insert(List<TEntity> entityList, bool isPkIdentity)
        {
            //转换为DataTable
            DataTable dt = EntityListToDataTable(entityList);
            return SqlHelper.BatchCopyInsert(dt.TableName, dt, isPkIdentity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        public int Update(TEntity entity)
        {
            List<Expression> express = new List<Expression>();
            object value = null;
            //获取实体列的特性
            List<EntityPropColumnAttributes> columnAttrList = AttributeHelper.GetEntityColumnAtrributes<TEntity>(); 
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                EntityPropColumnAttributes columnAttribute = columnAttrList.Where(w => w.propName == prop.Name).First();
                if (columnAttribute.isPrimaryKey)
                {
                    value = prop.GetValue(entity, null);
                    express.Add(new Expression(columnAttribute.fieldName, "=", value));
                }
            }  
            return Update(entity, express);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public int Update(TEntity entity, List<Expression> express)
        {
            //参数列表
            List<SqlParameter> listPara = new List<SqlParameter>();
            string setStr = "";//set修改字段和参数
            string where = "";//条件
            //获取实体列的特性
            List<EntityPropColumnAttributes> columnAttrList = AttributeHelper.GetEntityColumnAtrributes<TEntity>();
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                EntityPropColumnAttributes columnAttribute = columnAttrList.Where(w => w.propName == prop.Name).First();
                object val = prop.GetValue(entity, null);
                //当值不为空的时候进行拼接并且当不为主键时
                if (val != null && columnAttribute.isIdentity == false && columnAttribute.isPrimaryKey == false)
                {
                    setStr += columnAttribute.fieldName + "=@" + columnAttribute.fieldName + ",";//字符拼接
                    listPara.Add(new SqlParameter("@" + columnAttribute.fieldName, val));//参数添加
                }
            }
            setStr = setStr.TrimEnd(',');

            CoreFrameworkEntity careEntity = GetParaListAndWhere(express);
            listPara.AddRange(careEntity.paraList);
            where = careEntity.where;

            //拼接SQL语句
            string cmdText = "update " + tableName + " set " + setStr + " where " + where;
            return SqlHelper.ExecuteNonQuery(cmdText, listPara);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public int Update(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, bool>> express)
        {
            //参数列表
            List<SqlParameter> listPara = new List<SqlParameter>();
            string setStr = "";//set修改字段和参数
            string where = "";//条件
            //获取实体列的特性
            List<EntityPropColumnAttributes> columnAttrList = AttributeHelper.GetEntityColumnAtrributes<TEntity>();
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                EntityPropColumnAttributes columnAttribute = columnAttrList.Where(w => w.propName == prop.Name).First();
                object val = prop.GetValue(entity, null);
                //当值不为空的时候进行拼接并且当不为主键时
                if (val != null && columnAttribute.isIdentity == false && columnAttribute.isPrimaryKey == false)
                {
                    setStr += columnAttribute.fieldName + "=@" + columnAttribute.fieldName + ",";//字符拼接
                    listPara.Add(new SqlParameter("@" + columnAttribute.fieldName, val));//参数添加
                }
            }
            setStr = setStr.TrimEnd(',');

            CoreFrameworkEntity lamdaEntity = GetLambdaEntity<TEntity>(express);
            listPara.AddRange(lamdaEntity.paraList);
            where=lamdaEntity.where;

            //表名,即实体名称
            string tableName = entity.GetType().Name;
            //拼接SQL语句
            string cmdText = "update " + tableName + " set " + setStr + " where " + where;
            return SqlHelper.ExecuteNonQuery(cmdText, listPara);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        public int Delete(object id)
        {
            List<Expression> express = new List<Expression>();
            express.Add(new Expression(primaryKey, "=", id.ToStr()));
            return Delete(express);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public int Delete(List<Expression> express)
        {
            //获取参数和条件
            CoreFrameworkEntity CoreFrameworkEntity = GetParaListAndWhere(express);
            //条件
            string where = CoreFrameworkEntity.where;
            //参数列表
            List<SqlParameter> listPara = CoreFrameworkEntity.paraList;
            //拼接SQL语句
            string cmdText = "delete from " + tableName + " where " + where;
            return SqlHelper.ExecuteNonQuery(cmdText, listPara);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public int Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> express)
        {
            //参数列表
            List<SqlParameter> listPara = new List<SqlParameter>();
            CoreFrameworkEntity lamdaEntity = GetLambdaEntity<TEntity>(express);
            listPara.AddRange(lamdaEntity.paraList);
            //拼接SQL语句
            string cmdText = "delete from " + tableName + " where " + lamdaEntity.where;
            return SqlHelper.ExecuteNonQuery(cmdText, listPara);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public TEntity Get(List<Expression> express)
        {
            //获取参数和条件
            CoreFrameworkEntity CoreFrameworkEntity = GetParaListAndWhere(express);
            //条件
            string where = CoreFrameworkEntity.where;
            //参数列表
            List<SqlParameter> listPara = CoreFrameworkEntity.paraList;

            //拼接SQL语句
            string cmdText = "select * from " + tableName + " where " + where;
            SqlDataReader dr = SqlHelper.ExecuteReader(cmdText, listPara);
            List<TEntity> list =DataTableToEntityList(dr);

            return list.Count > 0 ? list.First() : new TEntity();   
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns></returns>
        public TEntity Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> express)
        {
            //参数列表
            List<SqlParameter> listPara = new List<SqlParameter>();
            string where = "";//条件            

            CoreFrameworkEntity lamdaEntity = GetLambdaEntity<TEntity>(express);
            listPara.AddRange(lamdaEntity.paraList);
            where = lamdaEntity.where;

            //拼接SQL语句
            string cmdText = "select * from " + tableName + " where " + where;
            SqlDataReader dr = SqlHelper.ExecuteReader(cmdText, listPara);
            List<TEntity> list = DataTableToEntityList(dr);

            return list.Count > 0 ? list.First() : new TEntity();     
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        public TEntity Get(object id)
        {
            TEntity entity = new TEntity();
            //主键是否存在
            if (!string.IsNullOrEmpty(primaryKey))
            {
                //获取实体
                List<Expression> express = new List<Expression>();
                express.Add(new Expression(primaryKey, "=", id.ToStr()));
                entity = Get(express);
            }
            return entity;
        }

    }

}
