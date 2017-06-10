using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

using YK.Service;
using YK.Model;
using YK.Common;

public partial class Index : System.Web.UI.Page
{
    /// <summary>
    /// 底部图片切换序号
    /// </summary>
    public int num = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(YK.Core.Core<TB_Admin_User>.CoreTemplate.Search().Count);

        //ActivityHelper.GetActivity();

        //EmailHelper.SendEmail("xxxxxxxxx","xxxxxxxx","871339677@qq.com","");

        if (!IsPostBack)
        {
            int i = 0;
            foreach (List<TB_Product_Products> list in DataToCacheHelper.GetIndexVouchProducts())
            {
                i++;
                switch (i)
                {
                    case 1:
                        RepVouchList.DataSource = list;
                        RepVouchList.DataBind();
                        break;
                    case 2:
                        RepVouchList2.DataSource = list;
                        RepVouchList2.DataBind();
                        break;
                    case 3:
                        RepVouchList3.DataSource = list;
                        RepVouchList3.DataBind();
                        break;
                    case 4:
                        RepVouchList4.DataSource = list;
                        RepVouchList4.DataBind();
                        break;
                }
            }

            List<Expression> SpecialsOne = new List<Expression>();
            SpecialsOne.Add(new Expression("Mark", "like", "3"));

            RepSpecialsOne.DataSource = ProductService.ProductsService.Search(6, SpecialsOne, "OrderBy asc,addDate desc");
            RepSpecialsOne.DataBind();

            //底部推荐的一级类别
            List<Expression> vouchCategory = new List<Expression>() { 
                new Expression("ParentID","=","0"),
                new Expression("VouchType","=","1")
            };

            //System.Linq.Expressions.Expression<Func<TB_Product_Categorys, bool>> fun = null;
            //fun=c=>c.ID<10;

            //var lambda = System.Linq.Expressions.Expression.Lambda<Func<TB_Product_Categorys, bool>>(fun.Body, fun.Parameters);

            //Expression<Func<Package, bool>> expr = new Expression<Func<Package,bool>>();

            Func<TB_Product_Categorys, bool> fun = new Func<TB_Product_Categorys,bool>(c=>c.ID<10);
            //fun = c => c.ID > 6;

            RepVouchCategory.DataSource = ProductService.CategoryService.Search(vouchCategory).OrderBy(c => c.OrderBy);
            RepVouchCategory.DataBind();
        }
    }

    protected void RepVouchCategory_DataBind(object sender, RepeaterItemEventArgs e)
    {
        int cid = ((HiddenField)e.Item.FindControl("HiddenFieldCategoryId")).Value.ToInt();
        Repeater rep = (Repeater)e.Item.FindControl("RepProList");
        List<Expression> expression = new List<Expression>() { 
            new Expression("CategoryId"," in ", ProductService.CategoryService.GetCategoryList(cid)),
            new Expression("IsDelete", "=", "0")
        };
        rep.DataSource = ProductService.ProductsService.Search(5, expression, "OrderBy asc,addDate desc");
        rep.DataBind();
    }
}
