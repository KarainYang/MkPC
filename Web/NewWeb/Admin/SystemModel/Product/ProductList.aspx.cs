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
using YK.Model;
using YK.Common;
using YK.Service;

public partial class Admin_SystemModel_Product_ProductList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ButtonDelete.Attributes.Add("onclick", "return confirm('确认删除这条信息吗？')");
        if (!IsPostBack)
        {
            ViewState["PageIndex"] = 1;
            ViewState["search"] = "";
            LoadDataBind();
        }
    }

    //加载所有信息
    public void LoadDataBind()
    {
        int pageSize = AspNetPager1.PageSize;
        int recordCount = 0;
        int pageIndex = ViewState["PageIndex"].ToInt();

        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("ProName","like",TbKey.Text.Trim()));
        if (DDLMark.SelectedValue != "")
        { 
            expression.Add(new Expression("Mark", "like", DDLMark.SelectedValue));
        }
        if (CategoryId.CategoryID != 0)
        {
            expression.Add(new Expression("CategoryID", "=", CategoryId.CategoryID.ToStr()));
        }
        if(TbStartDate.Text.Trim()!=string.Empty)
        {
            expression.Add(new Expression("AddDate", ">=", TbStartDate.Text));
        }
        if (TbStopDate.Text.Trim() != string.Empty)
        {
            DateTime stopDate = Convert.ToDateTime(TbStopDate.Text).AddDays(1);
            expression.Add(new Expression("AddDate", "<", stopDate.ToShortDateString()));
        }
        List<TB_Product_Products> list = ProductService.ProductsService.Search(pageSize, pageIndex, expression, " Id desc,AddDate desc", ref recordCount);
        RepList.DataSource = list;
        RepList.DataBind();
        AspNetPager1.RecordCount = recordCount;
    }

    //删除
    protected void ButtonDelete_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem ri in RepList.Items)
        {
            CheckBox cb = ((CheckBox)ri.FindControl("CheckBoxChoose"));
            int ID = Convert.ToInt32(((HiddenField)ri.FindControl("HiddenFieldID")).Value);
            if (cb.Checked == true)
            {
                ProductService.ProductsService.Delete(ID);
            }
        }
        //重新加载
        LoadDataBind();
    }

    //推荐设置
    protected void ButtonVouchSet_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem ri in RepList.Items)
        {
            CheckBox cb = ((CheckBox)ri.FindControl("CheckBoxChoose"));
            int ID = Convert.ToInt32(((HiddenField)ri.FindControl("HiddenFieldID")).Value);
            if (cb.Checked == true)
            {
                TB_Product_Products model = ProductService.ProductsService.Get(ID);
                model.Mark = "";
                foreach (ListItem li in CheckBoxListMark.Items)
                {
                    if (li.Selected == true)
                    {
                        model.Mark += li.Value + ",";
                    }
                }
                ProductService.ProductsService.Update(model);
            }
        }
        //重新加载
        LoadDataBind();
    }

    //分页
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ViewState["PageIndex"] = e.NewPageIndex;
        LoadDataBind();
    }

    //搜索
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        ViewState["PageIndex"] = 1;
        AspNetPager1.CurrentPageIndex = 1;
        LoadDataBind(); //重新加载

    }

    protected void BtnExcel_Click(object sender, EventArgs e)
    {
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("ProName", "like", TbKey.Text.Trim()));
        if (DDLMark.SelectedValue != "")
        {
            expression.Add(new Expression("Mark", "like", DDLMark.SelectedValue));
        }
        if (CategoryId.CategoryID != 0)
        {
            expression.Add(new Expression("CategoryID", "=", CategoryId.CategoryID.ToStr()));
        }
        if (TbStartDate.Text.Trim() != string.Empty)
        {
            expression.Add(new Expression("AddDate", ">=", TbStartDate.Text));
        }
        if (TbStopDate.Text.Trim() != string.Empty)
        {
            DateTime stopDate = Convert.ToDateTime(TbStopDate.Text).AddDays(1);
            expression.Add(new Expression("AddDate", "<", stopDate.ToShortDateString()));
        }

        List<TB_Product_Products> list = ProductService.ProductsService.Search(TbCount.Text.ToInt(), expression);
        YK.Common.ExcelHelper.OutputExcel<TB_Product_Products>(list,new string[]{"类别","商品名称","采购价","市场价","销售价","添加时间"},new string[]{"CategoryName","ProName","PurchasPrice","MarketPrice","SalesPrice","AddDate"},this.Page);
    }
}
