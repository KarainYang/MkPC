using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace YK.Model.CRM
{
    /// <summary> 
    ///工作流主表
    /// </summary>
    public class TB_WorkFlow_Main
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        /// <summary> 
        ///编码
        /// </summary>
        public string Code { get; set; }
        /// <summary> 
        ///名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 审批页面地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 明细页面地址
        /// </summary>
        public string DetailUrl { get; set; }
        /// <summary>
        /// 返回通知页面
        /// </summary>
        public string NotifyUrl { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///添加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
