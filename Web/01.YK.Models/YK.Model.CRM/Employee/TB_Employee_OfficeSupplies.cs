using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///办公用品申请
    /// </summary>
    public class TB_Employee_OfficeSupplies
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
        ///办公用品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///审批人
        /// </summary>
        public int Approver { get; set; }
        /// <summary> 
        ///申请状态，0为未审核，1为通过，2为不通过，3已领取，4未领取
        /// </summary>
        public int State { get; set; }
        /// <summary> 
        ///不通过原因
        /// </summary>
        public string Reason { get; set; }
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
