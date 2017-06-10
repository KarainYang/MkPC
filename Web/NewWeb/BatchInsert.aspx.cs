using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YK.Model;

public partial class BatchInsert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //性能测试结果：10000条数据3469毫秒，1000条数据350毫秒
        YK.Common.PerformanceHelper performanceHelper = new YK.Common.PerformanceHelper();
        performanceHelper.Start("开始");
        var list = new List<TB_Admin_User>();
        for (int i = 0; i < 10000; i++)
        {
            YK.Model.TB_Admin_User user = new TB_Admin_User();
            user.UserName = "admin" + i;
            user.UserPwd = i.ToString();
            list.Add(user);
        }        
        YK.Service.AdminService.UserService.BatchInsert(list);
        performanceHelper.Stop();
    }
}