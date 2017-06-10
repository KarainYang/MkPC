using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///客户信息
    /// </summary>
    public class TB_Customer_Customers
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
        ///客户名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary> 
        ///公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary> 
        ///行业
        /// </summary>
        public string Industry { get; set; }
        /// <summary> 
        ///规模
        /// </summary>
        public string Scale { get; set; }
        /// <summary> 
        ///来源
        /// </summary>
        public string Source { get; set; }
        /// <summary> 
        ///手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary> 
        ///QQ
        /// </summary>
        public string QQ { get; set; }

        /// <summary> 
        ///网址
        /// </summary>
        public string WebSite { get; set; }
        /// <summary> 
        ///电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary> 
        ///传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary> 
        ///邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary> 
        ///地址
        /// </summary>
        public string Address { get; set; }
        /// <summary> 
        ///备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary> 
        ///状态，0为初级客户，1为意向客户，2为签单客户
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 是否共享
        /// </summary>
        public bool IsSharing { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
