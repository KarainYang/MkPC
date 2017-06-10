using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///商品实体
    /// </summary>
    public class TB_Product_Products
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///类别编号
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary> 
        ///类别名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary> 
        ///商品名称
        /// </summary>
        public string ProName { get; set; }
        /// <summary> 
        ///商品编号
        /// </summary>
        public string ProNumber { get; set; }
        /// <summary> 
        ///品牌编号
        /// </summary>
        public int BrandID { get; set; }
        /// <summary> 
        ///小图片路径
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary> 
        ///大图片路径
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary> 
        ///采购价
        /// </summary>
        public decimal PurchasPrice { get; set; }
        /// <summary> 
        ///市场价
        /// </summary>
        public decimal MarketPrice { get; set; }
        /// <summary> 
        ///销售价
        /// </summary>
        public decimal SalesPrice { get; set; }
        /// <summary> 
        ///会员价
        /// </summary>
        public decimal MemberPrice { get; set; }
        /// <summary> 
        ///颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 商品简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary> 
        ///描述
        /// </summary>
        public string ProDesc { get; set; }
        /// <summary> 
        ///包装清单
        /// </summary>
        public string PakingList { get; set; }
        /// <summary> 
        ///售后服务
        /// </summary>
        public string CustomerService { get; set; }
        /// <summary> 
        ///关键字
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary> 
        ///点击总数
        /// </summary>
        public int ClickCount { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///排序
        /// </summary>
        public int OrderBy { get; set; }
        /// <summary> 
        ///是否隐藏
        /// </summary>
        public bool IsHidden { get; set; }
        /// <summary> 
        ///是否推荐
        /// </summary>
        public int VouchType { get; set; }
        /// <summary> 
        ///是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
        /// <summary> 
        ///语言
        /// </summary>
        public string Langs { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public int ParentId { get; set; }
    }
}
