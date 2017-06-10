using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YK.Interface;
using System.Reflection;

namespace YK.Service
{
    /// <summary>
    /// 公共操作类
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    public static class FactoryCommon<TEntity> where TEntity : new()
    {
        public static ICommon<TEntity> Common
        {
            get { return Assembly.Load("YK.BLL").CreateInstance("YK.BLL.BasePageBLL<" + new TEntity().GetType().Name + ">") as ICommon<TEntity>; }
        }

        public static object RunMethod(string className,string methodName,object[] paras)
        {
            object obj = Assembly.Load("YK.BLL").CreateInstance("YK.BLL.BasePageBLL<" + className + ">");
            Type[] types=new Type[paras.Length];
            for(int i=0;i<paras.Length;i++)
            {
                types[i]=paras[i].GetType();
            }
            MethodInfo methodInfo = obj.GetType().GetMethod(methodName, types);
            return methodInfo.Invoke(obj, paras);

            Type type = obj.GetType();
            return type.InvokeMember(methodName, BindingFlags.InvokeMethod, null, obj, paras);
        }

        /// <summary>
        /// 通用接口
        /// </summary>
        //public static ICommon<TEntity> Common
        //{
        //    get
        //    {
        //        return new Common<TEntity>();
        //    }
        //}       
    }
}
