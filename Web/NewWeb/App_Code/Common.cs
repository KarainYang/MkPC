using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YK.Model;
using System.Web.UI.WebControls;

/// <summary>
///Common 的摘要说明
/// </summary>
public class Common
{
	public Common()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 获取数据字典列表，绑定下拉框
    /// </summary>
    /// <param name="code">类别标识</param>
    /// <param name="dropDownList">下拉框ID</param>
    public static List<TB_System_Dictionary> GetDictionarys(string code, DropDownList dropDownList)
    {
        var list = DataToCacheHelper.GetAllDictionaries().Where(d => d.TypeCode == code).OrderBy(d => d.OrderBy).ToList();

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

/// <summary>
/// 任务公共模块
/// </summary>
public class TaskCommon
{
    /// <summary>
    /// 获取状态值
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    public static string GetStateStr(int state)
    {
        string stateStr = "";
        switch (state)
        {
            case 0:
                stateStr = "未处理";
                break;
            case 1:
                stateStr = "<span style=\"color:blue;\">处理中</span>";
                break;
            case 2:
                stateStr = "<span style=\"color:green;\">已处理</span>";
                break;
            case 3:
                stateStr = "<span style=\"color:purple;\">拒绝</span>";
                break;
        }
        return stateStr;
    }
}