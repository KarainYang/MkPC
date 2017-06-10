using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

using YK.Model;
using YK.Interface;
using YK.Common;

namespace YK.BLL
{
    /// <summary>
    /// 数据字典业务
    /// </summary>
    public class System_Dictionary_BLL : BasePageBLL<TB_System_Dictionary>,ISystem_Dictionary
    {
        /// <summary>
        /// 获取数据字典列表，绑定下拉框
        /// </summary>
        /// <param name="code">类别标识</param>
        /// <param name="dropDownList">下拉框ID</param>
        public List<TB_System_Dictionary> GetDictionarys(string code,DropDownList dropDownList)
        {
            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("TypeCode", "=", code));
            var list = Search(expression);
            if (dropDownList != null)
            {
                ListItem li0 = new ListItem();
                li0.Text = "==请选择==";
                li0.Value = "";
                dropDownList.Items.Add(li0);

                foreach (var item in list)
                {
                    ListItem li = new ListItem();
                    li.Text = item.Name;
                    li.Value = item.Code;
                    dropDownList.Items.Add(li);
                }
            }

            return list;
        }
    }
}
