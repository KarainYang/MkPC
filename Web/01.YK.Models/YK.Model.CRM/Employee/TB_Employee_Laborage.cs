using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///工资
    /// </summary>
    public class TB_Employee_Laborage
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
        ///基本工资
        /// </summary>
        public decimal Laborage { get; set; }
        /// <summary> 
        ///提成工资
        /// </summary>
        public decimal Commission { get; set; }
        /// <summary> 
        ///绩效工资
        /// </summary>
        public decimal Performance { get; set; }
        /// <summary> 
        ///考勤工资
        /// </summary>
        public decimal Attendance { get; set; }
        /// <summary> 
        ///餐补
        /// </summary>
        public decimal SubsidizedMeals { get; set; }
        /// <summary> 
        ///扣费
        /// </summary>
        public decimal Charged { get; set; }
        /// <summary> 
        ///扣社保
        /// </summary>
        public decimal Social { get; set; }
        /// <summary> 
        ///扣个税
        /// </summary>
        public decimal IncomeTax { get; set; }
        /// <summary> 
        ///工资合计
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary> 
        ///工资月份
        /// </summary>
        public DateTime LaborageMonth { get; set; }
        /// <summary> 
        ///工资发放日期
        /// </summary>
        public DateTime PayDate { get; set; }
        /// <summary> 
        ///备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
