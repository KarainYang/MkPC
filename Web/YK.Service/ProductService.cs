using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YK.Interface;
using System.Reflection;
using YK.BLL;

namespace YK.Service
{
    /// <summary>
    /// 商品模块操作类
    /// </summary>
    public static class ProductService
    {
        /// <summary>
        /// 商品类别服务
        /// </summary>
        public static IProduct_Categorys CategoryService
        {
            get
            {
                return new Product_Categorys_BLL();
            }
        }

        /// <summary>
        /// 商品服务
        /// </summary>
        public static IProduct_Products ProductsService
        {
            get
            {
                return new Product_Products_BLL();
            }
        }

        /// <summary>
        /// 商品属性服务
        /// </summary>
        public static IProduct_Properties PropertiesService
        {
            get
            {
                return new Product_Properties_BLL();
            }
        }

        /// <summary>
        /// 团购商品服务
        /// </summary>
        public static IProduct_Group GroupService
        {
            get
            {
                return new Product_Group_BLL();
            }
        }

        /// <summary>
        /// 商品品牌服务
        /// </summary>
        public static IProduct_Brands BrandsService
        {
            get
            {
                return new Product_Brands_BLL();
            }
        }

        /// <summary>
        /// 类别品牌服务
        /// </summary>
        public static IProduct_CategoryBrand CategoryBrandsService
        {
            get { return new Product_CategoryBrand_BLL(); }
        }


        /// <summary>
        /// 商品属性值服务
        /// </summary>
        public static IProduct_ProductProperties ProductPropertiesService
        {
            get { return new Product_ProductProperties_BLL(); }
        }

        /// <summary>
        /// 商品购物车服务
        /// </summary>
        public static IProduct_Cart CartService
        {
            get
            {
                return new Product_Cart_BLL();
            }
        }

        /// <summary>
        /// 组合商品服务
        /// </summary>
        public static IProduct_Combination CombinationService
        {
            get
            {
                return new Product_Combination_BLL();
            }
        }

        /// <summary>
        /// 商品收藏服务
        /// </summary>
        public static IProduct_Collection CollectionService
        {
            get
            {
                return new Product_Collection_BLL();
            }
        }

        /// <summary>
        /// 商品评论服务
        /// </summary>
        public static IProduct_Comments CommentsService
        {
            get
            {
                return new Product_Comments_BLL();
            }
        }

        /// <summary>
        /// 提问服务
        /// </summary>
        public static IProduct_Questions QuestionsService
        {
            get
            {
                return new Product_Questions_BLL();
            }
        }

        /// <summary>
        /// 回复服务
        /// </summary>
        public static IProduct_Reply ReplyService
        {
            get
            {
                return new Product_Reply_BLL();
            }
        }

        /// <summary>
        /// 商品图片服务
        /// </summary>
        public static IProduct_Picture PictureService
        {
            get
            {
                return new Product_Picture_BLL();
            }
        }

        /// <summary>
        /// 浏览记录
        /// </summary>
        public static IProduct_BrowerRecord BrowerRecordService
        {
            get
            {
                return new Product_BrowerRecord_BLL();
            }
        }
    }
}
