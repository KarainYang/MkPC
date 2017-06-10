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
    /// 信息资讯操作类
    /// </summary>
    public static class InfoService
    {       
        /// <summary>
        /// 新闻类别服务
        /// </summary>
        public static IInfo_NewsCategory NewsCategoryService
        {
            get
            {
                return new Info_NewsCategory_BLL();
            }
        }

        /// <summary>
        /// 新闻服务
        /// </summary>
        public static IInfo_News NewsService
        {
            get
            {
                return new Info_News_BLL();
            }
        }

        /// <summary>
        /// 帮助中心类别服务
        /// </summary>
        public static IInfo_HelpCategory HelpCategoryService
        {
            get
            {
                return new Info_HelpCategory_BLL();
            }
        }

        /// <summary>
        /// 帮助中心服务
        /// </summary>
        public static IInfo_Help HelpService
        {
            get
            {
                return new Info_Help_BLL();
            }
        }

        /// <summary>
        /// 单篇页服务
        /// </summary>
        public static IInfo_Page PageService
        {
            get
            {
                return new Info_Page_BLL();
            }
        }

        /// <summary>
        /// 友情连接服务
        /// </summary>
        public static IInfo_Links LinksService
        {
            get
            {
                return new Info_Links_BLL();
            }
        }

        /// <summary>
        /// 热门搜索服务
        /// </summary>
        public static IInfo_HotSearch HotSearchService
        {
            get
            {
                return new Info_HotSearch_BLL();
            }
        }   
    }
}
