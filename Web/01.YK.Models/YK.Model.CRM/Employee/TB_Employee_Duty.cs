using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///职位
    /// </summary>
    public class TB_Employee_Duty
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///部门编号
        /// </summary>
        public int DepartmentID { get; set; }
        /// <summary> 
        ///父级编号
        /// </summary>
        public int ParentID { get; set; }
        /// <summary> 
        ///职位名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///排序
        /// </summary>
        public int OrderBy { get; set; }
        /// <summary> 
        ///是否隐藏,0为显示，1为隐藏
        /// </summary>
        public bool IsHidden { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime AddDate { get; set; }
    }
}
