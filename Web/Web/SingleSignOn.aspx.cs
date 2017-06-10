using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;

public partial class SingleSignOn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 作为唯一标识的str_Key，应该是唯一的，这可根据需要自己设定规则。            
        // 做为测试，这里用用户名和密码的组合来做标识；也不进行其它的错误检查。             
        // 生成str_Key            
        string str_Key = "yankun";
        // 得到Cache中的给定str_Key的值   
        string str_User = Convert.ToString(Cache[str_Key]);
        // Cache中没有该str_Key的项目，表名用户没有登录，或者已经登录超时            
        if (str_User == String.Empty)
        {
            // TimeSpan构造函数，用来重载版本的方法，进行判断是否登录。                
            TimeSpan SessTimeOut = new TimeSpan(0, 0, HttpContext.Current.Session.Timeout, 0, 0);
            HttpContext.Current.Cache.Insert(str_Key, str_Key, null, DateTime.MaxValue, SessTimeOut, CacheItemPriority.NotRemovable, null);
            // 首次登录成功                
            Response.Write("<h2 style='color:red'>你好，登录成功！");
        }
        else
        {
            // 在 Cache 中存在该用户的记录，表名已经登录过，禁止再次登录                
            Response.Write("<h2 style='color:red'>抱歉，您好像已经登录了！");
            return;
        } 
    }

    protected void btnLogin_Click(object sender, EventArgs e)   
    {        
        // 作为唯一标识的str_Key，应该是唯一的，这可根据需要自己设定规则。            
        // 做为测试，这里用用户名和密码的组合来做标识；也不进行其它的错误检查。             
        // 生成str_Key            
        string str_Key = "yankun";            
        // 得到Cache中的给定str_Key的值   
        string str_User = Convert.ToString(Cache[str_Key]);
        // Cache中没有该str_Key的项目，表名用户没有登录，或者已经登录超时            
        if (str_User == String.Empty)
        {
            // TimeSpan构造函数，用来重载版本的方法，进行判断是否登录。                
            TimeSpan SessTimeOut = new TimeSpan(0, 0, HttpContext.Current.Session.Timeout, 0, 0);
            HttpContext.Current.Cache.Insert(str_Key, str_Key, null, DateTime.MaxValue, SessTimeOut, CacheItemPriority.NotRemovable, null);
            Session["User"] = str_Key;
            // 首次登录成功                
            Response.Write("<h2 style='color:red'>你好，登录成功！");
        }
        else
        {
            // 在 Cache 中存在该用户的记录，表名已经登录过，禁止再次登录                
            Response.Write("<h2 style='color:red'>抱歉，您好像已经登录了！");
            return;
        } 
    }
}