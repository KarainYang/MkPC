using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///考勤
    /// </summary>
    public class TB_Employee_Attendance
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
        ///考勤签到时间
        /// </summary>
        public DateTime OnDutyDate { get; set; }
        /// <summary> 
        ///考勤退签时间
        /// </summary>
        public DateTime OffDutyDate { get; set; }
        /// <summary> 
        ///迟到原因
        /// </summary>
        public string LateRemark { get; set; }
        /// <summary> 
        ///早退原因
        /// </summary>
        public string LeaveEarRemark { get; set; }
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
