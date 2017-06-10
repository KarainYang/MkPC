﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///缺陷管理
    /// </summary>
    public class TB_Project_Bug
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///员工编号
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary> 
        ///任务编号
        /// </summary>
        public int TaskID { get; set; }
        /// <summary> 
        ///缺陷名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary> 
        ///处理人
        /// </summary>
        public int Handler { get; set; }
        /// <summary> 
        ///处理状态，0为未处理，1为已处理，2为拒绝，三为重现
        /// </summary>
        public int State { get; set; }
        /// <summary> 
        ///拒绝原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
