using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using YK.Model;
public partial class AssemblyPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //YK.Common.IAssembly asse = Assembly.Load("YK.Common").CreateInstance("YK.Common.MyAssembly") as YK.Common.IAssembly;
        //asse.go();
        
        if(!IsPostBack)
        {
            loadDataBind();
        }
    }

    public void loadDataBind()
    {
        int i = 0;
        GridView1.DataSource = YK.Service.FactoryCommon<TB_Admin_User>.Common.Search(100, 1, new List<Expression>(), "ID asc", ref i);
        GridView1.DataBind();

        List<Expression> express = new List<Expression>();
        express.Add(new Expression("ID", "=", "15"));

        TB_Admin_User model = YK.Service.FactoryCommon<TB_Admin_User>.Common.Get(express);
        TbUserName.Text = model.UserName;
        TbPwd.Text = model.UserPwd;

        express.Clear();
        express.Add(new Expression("ID", "=", "9"));
        YK.Service.FactoryCommon<TB_Admin_User>.Common.Delete(express);

    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        TB_Admin_User model = new TB_Admin_User();
        model.UserName = TbUserName.Text;
        model.UserPwd = TbPwd.Text;
        model.UserState = 0;
        model.LastLoginTime = DateTime.Now;
        YK.Service.FactoryCommon<TB_Admin_User>.Common.Insert(model);
        loadDataBind();
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        TB_Admin_User model = new TB_Admin_User();
        model.UserName = TbUserName.Text;
        model.UserPwd = TbPwd.Text;
        model.UserState = 0;
        model.LastLoginTime = DateTime.Now;
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("ID","=","14"));
        YK.Service.FactoryCommon<TB_Admin_User>.Common.Update(model,express);
        loadDataBind();
    }
}
