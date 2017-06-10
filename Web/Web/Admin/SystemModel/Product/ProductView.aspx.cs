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
using YK.Interface;
using YK.Service;
using YK.Common;

public partial class Admin_SystemModel_Product_ProductView : BasePage
{
    /// <summary>
    /// 子商品
    /// </summary>
    public List<TB_Product_Products> childList = new List<TB_Product_Products>();

    /// <summary>
    /// 子商品下标
    /// </summary>
    public int index = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //int ID = CommonClass.ReturnRequestInt("id", 0);    
        //if (ID > 0)
        //{
        //    childList = GetChildProducts(ID);
        //}

        if (!IsPostBack)
        {
            BindCategory();            
            LoadDataBind();
        }
    }

    //加载
    public void LoadDataBind()
    {
        int ID = CommonClass.ReturnRequestInt("id", 0);
        if (ID > 0)
        {
            TB_Product_Products model = ProductService.ProductsService.Get(ID);
            if (model.ID.ToInt() > 0)
            {
                ViewState["id"] = model.ID;

                TB_Product_Categorys category = ProductService.CategoryService.Get(model.CategoryID);
                DDLOneLevel.SelectedValue = ProductService.CategoryService.Get(category.ParentID).ParentID.ToStr();

                GetTwoCategory();
                DDLTwoLevel.SelectedValue = category.ParentID.ToStr();

                GetThreeCategory();
                DDLThreeLevel.SelectedValue = model.CategoryID.ToStr();

                BindProperties();
                BindBrand(model.CategoryID);

                TbProductName.Text = model.ProName;
                TbProNumber.Text = model.ProNumber;
                TbIntroduction.Text = model.Introduction;
                DDLBrand.SelectedValue = model.BrandID.ToStr();
                ProPic.Url = model.PicUrl;
                ProImg.Url = model.ImgUrl;
                TbPurchasPrice.Text = model.PurchasPrice.ToStr();
                TbMarketPrice.Text = model.MarketPrice.ToStr();
                TbSalesPrice.Text = model.SalesPrice.ToStr();
                TbColor.Text = model.Color;
                FckDesc.Value = model.ProDesc;
                FckPakingList.Value = model.PakingList;
                FckSalesService.Value = model.CustomerService;
                TbOrderBy.Text = model.OrderBy.ToStr();
                TbKeyWord.Text = model.KeyWord;
                TbClickCount.Text = model.ClickCount.ToStr();
                CheckBoxIsHidden.Checked = model.IsHidden;
                DDLVouchType.SelectedValue = model.VouchType.ToStr();
                TbDate.Text = model.AddDate.ToString();

                foreach (ListItem li in CheckBoxListMark.Items)
                {
                    if (model.Mark.Contains(li.Value))
                    {
                        li.Selected = true;
                    }
                }

                //绑定子商品
                RepChildList.DataSource = GetChildProducts(model.ID);
                RepChildList.DataBind();
            }
        }
    }

    /// <summary>
    /// 绑定类别
    /// </summary>
    public void BindCategory()
    {
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("ParentId","=","0"));
        DDLOneLevel.DataSource= ProductService.CategoryService.Search(expression).OrderBy(c=>c.OrderBy);
        DDLOneLevel.DataTextField = "CategoryName";
        DDLOneLevel.DataValueField = "ID";
        DDLOneLevel.DataBind();

        ListItem li = new ListItem();
        li.Text = "==请选择==";
        li.Value = "";
        DDLOneLevel.Items.Insert(0,li);        
    }

    /// <summary>
    /// 绑定属性
    /// </summary>
    public void BindProperties()
    {
        int cid = DDLThreeLevel.SelectedValue.ToInt();
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("ProCategoryId", "=", cid));
        RepProperties.DataSource = ProductService.PropertiesService.Search(expression).OrderBy(c => c.OrderBy);
        RepProperties.DataBind();
    }

    /// <summary>
    /// 属性绑定事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void RepProperties_ItemDataBind(object sender, RepeaterItemEventArgs e)
    {
            int propertieId = ((HiddenField)e.Item.FindControl("HiddenFieldID")).Value.ToInt();
            TextBox TbValue = (TextBox)e.Item.FindControl("TbValue");
            DropDownList DDLValue = (DropDownList)e.Item.FindControl("DDLValue");
            CheckBoxList CkValue = (CheckBoxList)e.Item.FindControl("CkValue");
            RadioButtonList RadioValue = (RadioButtonList)e.Item.FindControl("RadioValue");

            var properties = ProductService.PropertiesService.Get(propertieId);
            string[] arr = properties.PropValue.Split(',');

            TbValue.Visible = false;
            DDLValue.Visible = false;
            CkValue.Visible = false;
            RadioValue.Visible = false;

            switch (properties.PropType)
            { 
                case 0:
                    TbValue.Visible = true;
                    break;
                case 1:
                    DDLValue.Visible = true;                    
                    foreach(string str in arr)
                    {
                        ListItem li = new ListItem();
                        li.Text = str;
                        li.Value = str;
                        DDLValue.Items.Add(li);
                    }
                    break;
                case 2:
                    CkValue.Visible = true;
                    foreach (string str in arr)
                    {
                        ListItem li = new ListItem();
                        li.Text = str;
                        li.Value = str;
                        CkValue.Items.Add(li);
                    }
                    break;
                case 3:
                    RadioValue.Visible = true;
                    foreach (string str in arr)
                    {
                        ListItem li = new ListItem();
                        li.Text = str;
                        li.Value = str;
                        RadioValue.Items.Add(li);
                    }
                    break;
            }

            int proId=ViewState["id"].ToInt();
            if(proId>0)
            {
                List<Expression> expression = new List<Expression>();
                expression.Add(new Expression("ProId", "=", proId));
                expression.Add(new Expression("PropertieId", "=", propertieId));
                var entity = ProductService.ProductPropertiesService.Get(expression);       

                switch (properties.PropType)
                {
                    case 0:
                        TbValue.Text = entity.Value;
                        break;
                    case 1:
                        DDLValue.SelectedValue = entity.Value;
                        break;
                    case 2:
                        CkValue.SelectedValue = entity.Value;
                        break;
                    case 3:
                        RadioValue.SelectedValue = entity.Value;
                        break;
                }
            }
    }

    protected void DDLOneLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetTwoCategory();
    }

    protected void DDLTwoLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetThreeCategory();
    }

    protected void DDLThreeLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindProperties();
        BindBrand(DDLThreeLevel.SelectedValue.ToInt());
    }
    
    /// <summary>
    /// 获取二级类别
    /// </summary>
    public void GetTwoCategory()
    {
        DDLTwoLevel.Items.Clear();

        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("ParentId", "=", DDLOneLevel.SelectedValue));
        DDLTwoLevel.DataSource = ProductService.CategoryService.Search(expression).OrderBy(c => c.OrderBy);
        DDLTwoLevel.DataTextField = "CategoryName";
        DDLTwoLevel.DataValueField = "ID";
        DDLTwoLevel.DataBind();

        ListItem li = new ListItem();
        li.Text = "==请选择==";
        li.Value = "";
        DDLTwoLevel.Items.Insert(0, li);

        GetThreeCategory();
    }

    /// <summary>
    /// 获取三级类别
    /// </summary>
    public void GetThreeCategory()
    {
        DDLThreeLevel.Items.Clear();

        if (DDLTwoLevel.SelectedValue != "")
        {
            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("ParentId", "=", DDLTwoLevel.SelectedValue));
            DDLThreeLevel.DataSource = ProductService.CategoryService.Search(expression).OrderBy(c => c.OrderBy);
            DDLThreeLevel.DataTextField = "CategoryName";
            DDLThreeLevel.DataValueField = "ID";
            DDLThreeLevel.DataBind();            
        }

        ListItem li = new ListItem();
        li.Text = "==请选择==";
        li.Value = "";
        DDLThreeLevel.Items.Insert(0, li);
    }

    //绑定品牌
    public void BindBrand(int categoryId)
    {
        DDLBrand.Items.Clear();

        DDLBrand.DataSource = ProductService.BrandsService.GetCategoryBrands(categoryId);
        DDLBrand.DataTextField = "BrandName";
        DDLBrand.DataValueField = "ID";
        DDLBrand.DataBind();

        ListItem li = new ListItem();
        li.Text = "==请选择==";
        li.Value = "";
        DDLBrand.Items.Insert(0, li);
    }
    
    /// <summary>
    /// 获取子商品
    /// </summary>
    /// <param name="pid">商品编号</param>
    public List<TB_Product_Products> GetChildProducts(int pid)
    {
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("ParentId","=",pid));
        return ProductService.ProductsService.Search(expression);
    }

    //添加子商品
    protected void BtnAddChild_Click(object sender, EventArgs e)
    {
        List<TB_Product_Products> list = new List<TB_Product_Products>();

        TB_Product_Products entity2 = new TB_Product_Products();
        list.Add(entity2);

        foreach (RepeaterItem item in RepChildList.Items)
        {
            TB_Product_Products entity = new TB_Product_Products();
            entity.ID = ((HiddenField)item.FindControl("ID")).Value.ToInt();
            entity.ProName = ((TextBox)item.FindControl("ProName")).Text;
            entity.ProNumber = ((TextBox)item.FindControl("ProNumber")).Text;
            entity.Color = ((TextBox)item.FindControl("Color")).Text;
            entity.PurchasPrice = ((TextBox)item.FindControl("PurchasPrice")).Text.ToDecimal();
            entity.MarketPrice = ((TextBox)item.FindControl("MarketPrice")).Text.ToDecimal();
            entity.SalesPrice = ((TextBox)item.FindControl("SalesPrice")).Text.ToDecimal();

            list.Add(entity);
        }

        RepChildList.DataSource = list;
        RepChildList.DataBind();
        
    }
    
    protected void RepChildList_DataBind(object sender, RepeaterItemEventArgs e)
    {
        index++;
    }
    
    protected void RepChildList_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        string commandName = e.CommandName;
        string value = e.CommandArgument.ToStr();
        if (commandName == "delete")
        {
            List<TB_Product_Products> list = new List<TB_Product_Products>();
            foreach (RepeaterItem item in RepChildList.Items)
            {
                string thisIndex = ((HiddenField)item.FindControl("Index")).Value;

                if (value != thisIndex)
                {
                    TB_Product_Products entity = new TB_Product_Products();
                    entity.ProName = ((TextBox)item.FindControl("ProName")).Text;
                    entity.ProNumber = ((TextBox)item.FindControl("ProNumber")).Text;
                    entity.Color = ((TextBox)item.FindControl("Color")).Text;
                    entity.PurchasPrice = ((TextBox)item.FindControl("PurchasPrice")).Text.ToDecimal();
                    entity.MarketPrice = ((TextBox)item.FindControl("MarketPrice")).Text.ToDecimal();
                    entity.SalesPrice = ((TextBox)item.FindControl("SalesPrice")).Text.ToDecimal();

                    list.Add(entity);
                }
                
            }
            RepChildList.DataSource = list;
            RepChildList.DataBind();
        }
    }

    /// <summary>
    ///保存商品属性
    /// </summary>
    /// <param name="pid"></param>
    protected void SaveProperties(int pid)
    {
        foreach (RepeaterItem item in RepProperties.Items)
        {
            int propertieId = ((HiddenField)item.FindControl("HiddenFieldID")).Value.ToInt();
            string value = "";

            TextBox TbValue = (TextBox)item.FindControl("TbValue");
            DropDownList DDLValue = (DropDownList)item.FindControl("DDLValue");
            CheckBoxList CkValue = (CheckBoxList)item.FindControl("CkValue");
            RadioButtonList RadioValue = (RadioButtonList)item.FindControl("RadioValue");

            var properties = ProductService.PropertiesService.Get(propertieId);
            switch (properties.PropType)
            {
                case 0:
                    value = TbValue.Text;
                    break;
                case 1:
                    value = DDLValue.SelectedValue;
                    break;
                case 2:
                    value = CkValue.SelectedValue;
                    break;
                case 3:
                    value = RadioValue.SelectedValue;
                    break;
            }

            TB_Product_ProductProperties entity = new TB_Product_ProductProperties();
            entity.ProId = pid;
            entity.PropertieId = propertieId;
            entity.Value = value;

            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("ProId", "=", pid));
            expression.Add(new Expression("PropertieId", "=", propertieId));
            if (ProductService.ProductPropertiesService.Search(expression).Count > 0)
            {
                ProductService.ProductPropertiesService.Update(entity, expression);
            }
            else
            {
                ProductService.ProductPropertiesService.Insert(entity);
            }
        }
    }

    /// <summary>
    /// 保存子商品
    /// </summary>
    /// <param name="pid"></param>
    protected void SaveChildProduct(TB_Product_Products entity)
    {
        //旧数据
        List<int> ids = GetChildProducts(entity.ID).Select(p => p.ID).ToList();
        //新数据
        List<int> thisIds = new List<int>();

        foreach (RepeaterItem item in RepChildList.Items)
        {
            int id = ((HiddenField)item.FindControl("ID")).Value.ToInt();
            entity.ProName = ((TextBox)item.FindControl("ProName")).Text;
            entity.ProNumber = ((TextBox)item.FindControl("ProNumber")).Text;
            entity.Color = ((TextBox)item.FindControl("Color")).Text;
            entity.PurchasPrice = ((TextBox)item.FindControl("PurchasPrice")).Text.ToDecimal();
            entity.MarketPrice = ((TextBox)item.FindControl("MarketPrice")).Text.ToDecimal();
            entity.SalesPrice = ((TextBox)item.FindControl("SalesPrice")).Text.ToDecimal();
            entity.ParentId = entity.ID;
            entity.AddDate = DateTime.Now;

            if (id == 0)
            {
                ProductService.ProductsService.Insert(entity);
            }
            else
            {
                entity.ID = id;                
                ProductService.ProductsService.Update(entity);

                thisIds.Add(id);
            }
        }
        
        foreach(int id in ids)
        {
            //如果当前id存在说明为删除，不存在说明删除
            if (!thisIds.Contains(id))
            {
                //删除
                ProductService.ProductsService.Delete(id);
            }
        }
    }

    /// <summary>
    /// 保存子商品,js形式
    /// </summary>
    /// <param name="pid"></param>
    protected void SaveChildProduct2(TB_Product_Products entity)
    {
       string[] ids = Request["pid"].ToStr().Split(',');
       string[] names = Request["name"].ToStr().Split(',');
       string[] proNumbers = Request["proNumber"].ToStr().Split(',');
       string[] colors = Request["color"].ToStr().Split(',');
       string[] purchasPrices = Request["purchasPrice"].ToStr().Split(',');
       string[] marketPrices = Request["marketPrice"].ToStr().Split(',');
       string[] salesPrices = Request["salesPrice"].ToStr().Split(',');

       for (int i = 0; i < names.Length;i++ )
       {
           entity.ProName=names[i];
           entity.ProNumber = proNumbers[i];
           entity.Color = colors[i];
           entity.PurchasPrice=purchasPrices[i].ToDecimal();
           entity.MarketPrice = marketPrices[i].ToDecimal();
           entity.SalesPrice = salesPrices[i].ToDecimal();
           entity.ParentId = entity.ID;
           entity.AddDate = DateTime.Now;

           if (ids[0].ToInt() == 0)
           {
               ProductService.ProductsService.Insert(entity);
           }
           else
           {
               entity.ID = ids[0].ToInt();

               ProductService.ProductsService.Update(entity);
           }
       }       
    }

    object obj = new object();

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        lock (obj)
        {
            TB_Product_Products model = new TB_Product_Products();
            if (ViewState["id"] != null)
            {
                model = ProductService.ProductsService.Get(ViewState["id"]);
            }
            model.CategoryID = DDLThreeLevel.SelectedValue.ToInt();
            model.CategoryName = DDLThreeLevel.SelectedItem.Text;
            model.ProName = TbProductName.Text;
            model.ProNumber = TbProNumber.Text;
            model.Introduction = TbIntroduction.Text;
            model.BrandID = DDLBrand.SelectedValue.ToInt();
            model.PicUrl = ProPic.Url;
            model.ImgUrl = ProImg.Url;
            model.PurchasPrice = TbPurchasPrice.Text.ToDecimal();
            model.MarketPrice = TbMarketPrice.Text.ToDecimal();
            model.SalesPrice = TbSalesPrice.Text.ToDecimal();
            model.Color = TbColor.Text;
            model.ProDesc = FckDesc.Value;
            model.PakingList = FckPakingList.Value;
            model.CustomerService = FckSalesService.Value;
            model.OrderBy = TbOrderBy.Text.ToInt();
            model.KeyWord = TbKeyWord.Text;
            model.ClickCount = TbClickCount.Text.ToInt();
            model.IsHidden = CheckBoxIsHidden.Checked;
            model.VouchType = DDLVouchType.SelectedValue.ToInt();
            model.Creater = AdminUserName;
            model.AddDate = Convert.ToDateTime(TbDate.Text);
            foreach (ListItem li in CheckBoxListMark.Items)
            {
                if (li.Selected == true)
                {
                    model.Mark += li.Value + ",";
                }
            }

            if (ViewState["id"] == null)
            {
                if (ProductService.ProductsService.Insert(model) == 1)
                {
                    model = ProductService.ProductsService.Search(1, new List<Expression>(), "id desc").First();
                    //保存商品属性
                    SaveProperties(model.ID);
                    //保存子商品
                    SaveChildProduct(model);

                    MessageDiv.InnerHtml = CommonClass.Reload("数据添加成功");
                }
                else
                {
                    MessageDiv.InnerHtml = CommonClass.Alert("数据添加失败");
                }
            }
            else
            {
                if (ProductService.ProductsService.Update(model) == 1)
                {
                    //保存商品属性
                    SaveProperties(model.ID);
                    //保存子商品
                    SaveChildProduct(model);

                    MessageDiv.InnerHtml = CommonClass.Reload("数据修改成功");
                }
                else
                {
                    MessageDiv.InnerHtml = CommonClass.Alert("数据修改失败");
                }
            }
        }
    }
    
}
