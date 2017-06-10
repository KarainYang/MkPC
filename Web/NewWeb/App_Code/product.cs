using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using YK.Service;

/// <summary>
///product 的摘要说明
/// </summary>
public class product:System.Web.UI.Page
{
    public List<int> list = new List<int>();
    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater rep = this.FindControl("RepList") as Repeater;
        rep.DataSource = ProductService.ProductsService.Search(1000);
        rep.DataBind();
    }
	public product()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
        
	}
    //删除
    protected void ButtonDelete_Click(object sender, EventArgs e)
    {
        Response.Write("xxxxxx");
    }
}