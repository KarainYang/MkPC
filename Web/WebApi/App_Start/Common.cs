using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

using YK.Service;
using YK.Model;
using System.Web.Mvc;
using YK.Cache;

namespace CRMMvc
{
    /// <summary>
    ///Common 的摘要说明
    /// </summary>
    public class Common
    {
        /// <summary>
        /// 获取数据字典列表，绑定下拉框
        /// </summary>
        /// <param name="code">类别标识</param>
        /// <param name="dropDownList">下拉框ID</param>
        public static List<SelectListItem> GetDictionarys(string code)
        {
            return GetDictionarys(code, "==请选择==");
        }

        /// <summary>
        /// 获取数据字典列表，绑定下拉框
        /// </summary>
        /// <param name="code">类别标识</param>
        /// <param name="dropDownList">下拉框ID</param>
        public static List<SelectListItem> GetDictionarys(string code, string defaultTxt)
        {
            var list = DataToCacheHelper.GetAllDictionaries().Where(d => d.TypeCode == code).OrderBy(d => d.OrderBy).ToList();

            List<SelectListItem> selectList = new List<SelectListItem>(); 
            SelectListItem li0 = new SelectListItem();
            li0.Text = defaultTxt;
            li0.Value = "";
            selectList.Add(li0);

            foreach (var item in list)
            {
                SelectListItem li = new SelectListItem();
                li.Text = item.Name;
                li.Value = item.Code;
                selectList.Add(li);
            }

            return selectList;
        }

        /// <summary>
        /// 获取数据字典实体
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static TB_System_Dictionary GetDictionary(string code)
        {
            var list = DataToCacheHelper.GetAllDictionaries().Where(d => d.Code == code);
            if (list.Count() > 0)
            {
                return list.First();
            }
            else
            {
                return new TB_System_Dictionary();
            }
        }
    }    
}