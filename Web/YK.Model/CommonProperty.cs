using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
 
namespace YK.Model
{
    /// <summary> 
    ///公共属性
    /// </summary>
    public class CommonProperty
    {
        /// <summary> 
        ///创建人
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///创建日期
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary> 
        ///修改人
        /// </summary>
        public string Modifier { get; set; }
        /// <summary> 
        ///修改日期
        /// </summary>
        public DateTime? ModifyOn { get; set; }
    }
}
