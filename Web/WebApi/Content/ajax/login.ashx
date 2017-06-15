<%@ WebHandler Language="C#" Class="login" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

using YK.Model;
using YK.Service;
using YK.Common;

public class login : IHttpHandler,IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string orgCode = context.Request["orgCode"].TrimEnd();
        string userName=context.Request["userName"].TrimEnd();
        string userPwd = context.Request["userPwd"].ToEncryptStr(); 
        string verCode = context.Request["verCode"];

        if (context.Session["VerifyCode"] == null)
        {
            context.Response.Write("验证失效，请点击重新获取！");
            return;
        }
        if (context.Session["VerifyCode"].ToStr() != verCode)
        {
            context.Response.Write("验证码错误，请重新输入！");
            return;
        }

        HttpCookie cookie = new HttpCookie("AdminInfo");
        cookie.Values["OrgCode"] = orgCode;
        cookie.Expires = DateTime.Now.AddDays(1);
        context.Response.Cookies.Add(cookie);

        List<Expression> express = new List<Expression>();
        express.Add(new Expression("Account", "=", userName));
        express.Add(new Expression("Password", "=", userPwd));
        express.Add(new Expression("State", "=", 0));

        var employee = EmployeeService.EmployeesService.Get(express);
        if (employee.ID > 0)
        {
            cookie.Values["ID"] = employee.ID.ToStr();
            cookie.Values["Account"] = employee.Account;
            cookie.Values["Password"] = employee.Password;
            cookie.Values["EmployeeName"] = context.Server.UrlEncode(employee.EmployeeName);
            cookie.Expires = DateTime.Now.AddDays(1);
            context.Response.Cookies.Add(cookie);

            //操作日志
            AdminService.LogService.Insert(OperationType.用户操作, employee.ID, "用户" + employee.EmployeeName + "后台登录", employee.EmployeeName);

            context.Response.Write("1");
            return;
        }
        else
        {
            context.Response.Write("用户名或密码错误！");
            return;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}