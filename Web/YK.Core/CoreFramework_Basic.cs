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
        /// 是否数据库生成
        /// </summary>
        public bool isDbGenerated { get; set; }
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
        public string tableName
        {
            get { return AttributeHelper.GetEntityTableAtrributes<TEntity>(); }
        }
        /// <summary>
        /// 获取主键
        /// </summary>
        /// <returns></returns>
        public string GetPrimaryKey()
        {
            var list = AttributeHelper.GetEntityColumnAtrributes<TEntity>();
            foreach (var model in list)
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
                    //连接符号
                    if (string.IsNullOrEmpty(exp.Join))
                    {
                        if (string.IsNullOrEmpty(exp.FieldName) || string.IsNullOrEmpty(exp.Value))
                        {
                            continue;
                        }
                        string fieldName = columnAttrList.Where(w => w.propName.ToLower() == exp.FieldName.ToLower()).Count() > 0
                        ? columnAttrList.Where(w => w.propName.ToLower() == exp.FieldName.ToLower()).First().fieldName : exp.FieldName;

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
                            case "not like":
                                listPara.Add(new SqlParameter("@" + paraName, "%" + exp.Value + "%"));
                                where += " " + fieldName + " not like @" + paraName;
                                break;
                            case "in":
                                where += " " + fieldName + " in (" + exp.Value + ")";
                                break;
                            case "not in":
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
        /// <summary>
        /// 将实体列表转换为数据表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<TEntity> EntityListByDataTable(DataTable dt)
        {
            List<TEntity> list = new List<TEntity>();
            foreach (DataRow dr in dt.Rows)
            {
                //实体
                TEntity entity = new TEntity();
                //创建列
                foreach (PropertyInfo prop in entity.GetType().GetProperties())
                {
                    if (dt.Columns.Contains(prop.Name))
                    {
                        prop.SetValue(entity, dr[prop.Name], null);
                    }
                }
                list.Add(entity);
            }
            return list;
        }
    }
        

    /// <summary>
    /// 公共操作类，增（Insert）、删（Delete）、改（Update）、查（Get）功能
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    internal partial class CoreFramework<TEntity>
    {
        //获取实体列的特性
        List<EntityPropColumnAttributes> columnAttrList = new List<EntityPropColumnAttributes>();
        public CoreFramework()
        {
            columnAttrList = AttributeHelper.GetEntityColumnAtrributes<TEntity>();
        }

        /// <summary>
        /// 插入（添加）
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isBackId">是否返回主键</param>
        /// <returns></returns>
        public int Insert(TEntity entity)
        {
            return Insert(entity, false).ToInt();
        }
        #region 备份
        ///// <summary>
        ///// 插入（添加）
        ///// </summary>
        ///// <param name="entity">实体</param>
        ///// <param name="isBackId">是否返回主键</param>
        ///// <returns></returns>
        //public object Insert(TEntity entity, bool isBackId)
        //{
        //    //参数列表
        //    List<SqlParameter> listPara = new List<SqlParameter>();
        //    string insertStr = "";//插入字段
        //    string paraStr = "";//参数
        //    //获取实体列的特性
        //    List<EntityPropColumnAttributes> columnAttrList = AttributeHelper.GetEntityColumnAtrributes<TEntity>();
        //    foreach (PropertyInfo prop in entity.GetType().GetProperties())
        //    {
        //        EntityPropColumnAttributes columnAttribute = columnAttrList.Where(w => w.propName.ToLower() == prop.Name.ToLower()).First();
        //        //当不为自动增长时
        //        if (columnAttribute.isDbGenerated == false)
        //        {
        //            object val = prop.GetValue(entity, null);
        //            if (val != null)
        //            {
        //                insertStr += columnAttribute.fieldName + ",";//字符拼接
        //                paraStr += "@" + columnAttribute.fieldName + ",";//字符拼接                    
        //                listPara.Add(new SqlParameter("@" + columnAttribute.fieldName, val));//参数添加
        //            }
        //        }
        //    }
        //    //去掉最后的逗号
        //    insertStr = insertStr.TrimEnd(',');
        //    paraStr = paraStr.TrimEnd(',');
        //    //拼接SQL语句
        //    string cmdText = "insert into " + tableName + "(" + insertStr + ") values(" + paraStr + ");";
        //    if (isBackId)
        //    {
        //        cmdText += "SELECT @@IDENTITY AS ID;";
        //        return SqlConvertHelper.ExecuteScalar(cmdText, listPara);
        //    }
        //    else
        //    {
        //        return SqlConvertHelper.ExecuteNonQuery(cmdText, listPara);
        //    }
        //}
        #endregion

        /// <summary>
        /// 插入（添加）
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isBackId">是否返回主键</param>
        /// <returns></returns>
        public object Insert(TEntity entity, bool isBackId)
        {
            var entityList = new List<TEntity>() { entity };
            var dics = GetInsertInfo(entityList);
            string cmdText = dics["sql"].ToStr();
            var listPara = dics["params"] as List<SqlParameter>;
            if (isBackId)
            {
                cmdText += "SELECT @@IDENTITY AS ID;";
                return new SqlConvertHelper().ExecuteScalar(cmdText, listPara);
            }
            else
            {
                return new SqlConvertHelper().ExecuteNonQuery(cmdText, listPara);
            }
        }

        /// <summary>
        /// 批量插入（添加）
        /// </summary>
        /// <param name="entityList">实体列表</param>
        /// <returns></returns>
        public object BatchInsert(List<TEntity> entityList)
        {
            int pageSize = 100;
            int pageCount = entityList.Count / pageSize;
            for (int i = 0; i < pageCount; i++)
            {
                var dics = GetInsertInfo(entityList.Skip(i * pageSize).Take(pageSize).ToList());
                string cmdText = dics["sql"].ToStr();
                var listPara = dics["params"] as List<SqlParameter>;
                new SqlConvertHelper().ExecuteNonQuery(cmdText, listPara);
            }
            return true;
        }

        /// <summary>
        /// 获取插入数据的相关信息
        /// </summary>
        /// <param name="entityList">实体列表</param>
        /// <returns></returns>
        private Dictionary<string, object> GetInsertInfo(List<TEntity> entityList)
        {
            string cmdText = "";
            int num = 0;
            //参数列表
            List<SqlParameter> listPara = new List<SqlParameter>();
            foreach (var entity in entityList)
            {
                num++;
                string insertStr = "";//插入字段
                string paraStr = "";//参数
                //获取实体列的特性
                List<EntityPropColumnAttributes> columnAttrList = AttributeHelper.GetEntityColumnAtrributes<TEntity>();
                foreach (PropertyInfo prop in entity.GetType().GetProperties())
                {
                    num++;
                    EntityPropColumnAttributes columnAttribute = columnAttrList.Where(w => w.propName.ToLower() == prop.Name.ToLower()).First();
                    //当不为自动增长时
                    if (columnAttribute.isDbGenerated == false)
                    {
                        object val = prop.GetValue(entity, null);
                        if (val != null)
                        {
                            insertStr += columnAttribute.fieldName + ",";//字符拼接
                            paraStr += "@param" + num + ",";//字符拼接                    
                            listPara.Add(new SqlParameter("@param" + num, val));//参数添加
                        }
                    }
                }
                //去掉最后的逗号
                insertStr = insertStr.TrimEnd(',');
                paraStr = paraStr.TrimEnd(',');
                //拼接SQL语句
                cmdText += "insert into " + tableName + "(" + insertStr + ") values(" + paraStr + ");";
            }
            return new Dictionary<string, object>(){
                {"sql",cmdText},
                {"params",listPara}
            };
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
            return new SqlConvertHelper().BatchCopyInsert(dt.TableName, dt, isPkIdentity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        public int Update(TEntity entity)
        {                     
            EntityPropColumnAttributes columnAttribute = columnAttrList.Where(w => w.fieldName.ToLower() == primaryKey.ToLower()).First();
            PropertyInfo prop = typeof(TEntity).GetProperty(columnAttribute.propName);
            object value = prop.GetValue(entity, null);
            List<Expression> express = new List<Expression>();   
            express.Add(new Expression(columnAttribute.propName, "=", value)); 
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
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                EntityPropColumnAttributes columnAttribute = columnAttrList.Where(w => w.propName.ToLower() == prop.Name.ToLower()).First();
                object val = prop.GetValue(entity, null);
                //当值不为空的时候进行拼接并且当不为主键时
                if (val != null && columnAttribute.isDbGenerated == false && columnAttribute.isPrimaryKey == false)
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
            return new SqlConvertHelper().ExecuteNonQuery(cmdText, listPara);
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
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                EntityPropColumnAttributes columnAttribute = columnAttrList.Where(w => w.propName.ToLower() == prop.Name.ToLower()).First();
                object val = prop.GetValue(entity, null);
                //当值不为空的时候进行拼接并且当不为主键时
                if (val != null && columnAttribute.isDbGenerated == false && columnAttribute.isPrimaryKey == false)
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
            return new SqlConvertHelper().ExecuteNonQuery(cmdText, listPara);
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
            return new SqlConvertHelper().ExecuteNonQuery(cmdText, listPara);
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
            return new SqlConvertHelper().ExecuteNonQuery(cmdText, listPara);
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
            IDataReader sdr = new SqlConvertHelper().ExecuteReader(cmdText, listPara);
            List<TEntity> list = DynamicBuilder<TEntity>.GetList(sdr, columnAttrList);

            return list.Count > 0 ? list.First() : default(TEntity);     
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
            IDataReader sdr = new SqlConvertHelper().ExecuteReader(cmdText, listPara);
            List<TEntity> list = DynamicBuilder<TEntity>.GetList(sdr, columnAttrList);
            return list.Count > 0 ? list.First() : default(TEntity);     
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        public TEntity Get(object id)
        {
            //主键是否存在
            if (!string.IsNullOrEmpty(primaryKey))
            {
                //获取实体
                List<Expression> express = new List<Expression>();
                express.Add(new Expression(primaryKey, "=", id.ToStr()));
                return Get(express);
            }
            return default(TEntity); ;
        }

    }

}
