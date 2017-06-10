using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YK.Core
{
    /// <summary>
    /// 核心
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Core<TEntity> where TEntity : new() 
    {
        /// <summary>
        /// 核心
        /// </summary>
        public static ICoreFramework<TEntity> CoreTemplate 
        {
            get { return new CoreFramework<TEntity>(); }
        }
    }
}
