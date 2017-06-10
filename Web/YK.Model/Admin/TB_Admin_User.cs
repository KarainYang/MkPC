using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace YK.Model
{
    /// <summary> 
    ///管理员实体
    /// </summary>
    [Table(Name = "TB_Admin_User")]
    [Description("首页推荐")]
    public class TB_Admin_User
    {
        /// <summary> 
        ///管理员编号
        /// </summary> 
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        [Description("管理员编号")]
        public int ID { get; set; }
        /// <summary> 
        ///管理员名称
        /// </summary>
        [Column(Name = "UserName")]
        [Description("管理员名称")]
        public string UserName { get; set; }
        /// <summary> 
        ///管理员密码
        /// </summary>
        [Column(Name = "UserPwd")]
        [Description("管理员密码")]
        public string UserPwd { get; set; }
        /// <summary> 
        ///状态，0为开通，1为冻结
        /// </summary>
        [Column(Name = "UserState")]
        [Description("状态，0为开通，1为冻结")]
        public int UserState { get; set; }
        /// <summary> 
        ///最后登录时间
        /// </summary>
        [Column(Name = "LastLoginTime")]
        [Description("最后登录时间")]
        public DateTime? LastLoginTime { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        [Column(Name = "Creater")]
        [Description("创建者")]
        public string Creater { get; set; }
        /// <summary> 
        ///是否删除
        /// </summary>
        [Column(Name = "IsDelete")]
        [Description("是否删除")]
        public bool IsDelete { get; set; }
        /// <summary> 
        ///添加时间
        /// </summary>
        [Column(Name = "AddDate")]
        [Description("添加时间")]
        public DateTime? AddDate { get; set; }

    }
}


