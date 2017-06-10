using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

using YK.Model;
using System.Data;

namespace YK.Interface
{
    /// <summary>
    /// 数据字典接口
    /// </summary>
    public interface ISystem_Dictionary: ICommon<TB_System_Dictionary>
    {
       /// <summary>
        /// 获取数据字典列表，绑定下拉框
        /// </summary>
        /// <param name="code">类别标识</param>
        /// <param name="dropDownList">下拉框ID</param>
        List<TB_System_Dictionary> GetDictionarys(string code, DropDownList dropDownList);
    }
}
