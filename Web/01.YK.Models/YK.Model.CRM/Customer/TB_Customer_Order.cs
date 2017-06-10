using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///客户下单
    /// </summary>
    public class TB_Customer_Order
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
        ///客户编号
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary> 
        ///业务项目编号
        /// </summary>
        public int BusProjectID { get; set; }
        /// <summary> 
        ///空间大小
        /// </summary>
        public string SpaceSize { get; set; }
        /// <summary> 
        ///网站域名
        /// </summary>
        public string SiteDomain { get; set; }
        /// <summary> 
        ///参考网站
        /// </summary>
        public string ReferenceSite { get; set; }
        /// <summary> 
        ///颜色要求
        /// </summary>
        public string ColorRequirements { get; set; }
        /// <summary> 
        ///主要栏目
        /// </summary>
        public string MainColumns { get; set; }
        /// <summary> 
        ///制作要求
        /// </summary>
        public string DesignRequirement { get; set; }
        /// <summary> 
        ///项目资料
        /// </summary>
        public string ProjectData { get; set; }
        /// <summary> 
        ///关键字
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary> 
        ///
        /// </summary>
        public string Explain { get; set; }
        /// <summary> 
        ///说明
        /// </summary>
        public decimal ProjectAmount { get; set; }
        /// <summary> 
        ///项目金额
        /// </summary>
        public string BusinessAgent { get; set; }
        /// <summary> 
        ///业务代表
        /// </summary>
        public decimal ReceivedAmount { get; set; }
        /// <summary> 
        ///已收金额
        /// </summary>
        public decimal UnpaidAmount { get; set; }
        /// <summary> 
        ///签单日期
        /// </summary>
        public DateTime SignDate { get; set; }
        /// <summary> 
        ///结束日期
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary> 
        ///制作周期（天）
        /// </summary>
        public int ProductionCycle { get; set; }
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
