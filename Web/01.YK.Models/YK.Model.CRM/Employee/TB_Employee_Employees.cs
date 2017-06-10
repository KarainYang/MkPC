using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///员工
    /// </summary>
    public class TB_Employee_Employees
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///员工编号
        /// </summary>
        public string EmployeeNo { get; set; }
        /// <summary> 
        ///员工名称
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary> 
        ///账号
        /// </summary>
        public string Account { get; set; }
        /// <summary> 
        ///密码
        /// </summary>
        public string Password { get; set; }
        /// <summary> 
        ///部门编号
        /// </summary>
        public int DepartmentID { get; set; }
        /// <summary> 
        ///职位编号
        /// </summary>
        public int DutyID { get; set; }
        /// <summary> 
        ///性别,0代表男，1代表女
        /// </summary>
        public int Sex { get; set; }
        /// <summary> 
        ///年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary> 
        ///婚姻状况，0代表未婚，1代表已婚
        /// </summary>
        public int Marriage { get; set; }
        /// <summary> 
        ///电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary> 
        ///生日
        /// </summary>
        public string Birthday { get; set; }
        /// <summary> 
        ///相片路径
        /// </summary>
        public string PhotoUrl { get; set; }
        /// <summary> 
        ///入职时间
        /// </summary>
        public string EntryTime { get; set; }
        /// <summary> 
        ///转正时间
        /// </summary>
        public string PermanentTime { get; set; }
        /// <summary> 
        ///离职时间
        /// </summary>
        public string LeftTime { get; set; }
        /// <summary> 
        ///试用期薪水
        /// </summary>
        public decimal ProbationScalary { get; set; }
        /// <summary> 
        ///薪水
        /// </summary>
        public decimal Scalary { get; set; }
        /// <summary> 
        ///传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary> 
        ///邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary> 
        ///邮编
        /// </summary>
        public string PostedCode { get; set; }
        /// <summary> 
        ///城市
        /// </summary>
        public string City { get; set; }
        /// <summary> 
        ///地址
        /// </summary>
        public string Address { get; set; }
        /// <summary> 
        ///备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary> 
        ///状态,0为在职，1为离职
        /// </summary>
        public int State { get; set; }
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
