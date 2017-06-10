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
    /// 系统操作类
    /// </summary>
    public static class SystemService
    {       
        /// <summary>
        /// Excel模块服务
        /// </summary>
        public static IExcel_Model ExcelModelService
        {
            get
            {
                return new Excel_Model_BLL();
            }
        }

        /// <summary>
        /// Excel字段服务
        /// </summary>
        public static IExcel_Fields ExcelFieldsService
        {
            get
            {
                return new Excel_Fields_BLL();
            }
        }

        /// <summary>
        /// 数据字典类型服务
        /// </summary>
        public static ISystem_DictionaryType DictionaryTypeService
        {
            get
            {
                return new System_DictionaryType_BLL();
            }
        }  

        /// <summary>
        /// 数据字典服务
        /// </summary>
        public static ISystem_Dictionary DictionaryService
        {
            get
            {
                return new System_Dictionary_BLL();
            }
        }

        /// <summary>
        /// 广告类别服务
        /// </summary>
        public static ISystem_AdverCategory AdverCategoryService
        {
            get
            {
                return new System_AdverCategory_BLL();
            }
        }

        /// <summary>
        /// 广告服务
        /// </summary>
        public static ISystem_Adver AdverService
        {
            get
            {
                return new System_Adver_BLL();
            }
        }

        /// <summary>
        /// 广告图片服务
        /// </summary>
        public static ISystem_AdverPic AdverPicService
        {
            get
            {
                return new System_AdverPic_BLL();
            }
        }
    }
}
