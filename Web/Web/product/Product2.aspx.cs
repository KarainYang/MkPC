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

public partial class product_Product2 : System.Web.UI.Page
{
    public TB_Product_Products Product { get; set; }

    int id = 0;
    protected string memberName;
    protected int memberID=0;
    //图片列表
    protected List<TB_Product_Picture> picList;

    protected void Page_Load(object sender, EventArgs e)
    {
        id = CommonClass.ReturnRequestInt("id",0);
        if (id > 0)
        {
            //Response.Redirect("product_"+ id.ToStr() + ".html");

            Product = ProductService.ProductsService.Get(id);

            if (Product.ID == 0)
            {
                Response.Redirect(CommonClass.AppPath);
            }
        }
        else
        {
            Response.Redirect("Products.aspx");
        }

        //获取会员信息
        if (Request.Cookies["MemberInfo"]!=null)
        {
            memberName = Request.Cookies["MemberInfo"].Values["MemberName"].ToStr();
            memberID = Request.Cookies["MemberInfo"].Values["ID"].ToInt();

            //添加浏览记录
            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("MemberId", "=", memberID.ToStr()));
            expression.Add(new Expression("ProId", "=", id.ToStr()));
            TB_Product_BrowerRecord entity = ProductService.BrowerRecordService.Get(expression);
            //判断是否已经浏览过此商品
            if (entity.MemberId > 0)
            {
                entity.BrowerDate = DateTime.Now;
                ProductService.BrowerRecordService.Update(entity, expression);
            }
            else
            {
                entity.MemberId = memberID;
                entity.ProId = id;
                entity.BrowerDate = DateTime.Now;
                ProductService.BrowerRecordService.Insert(entity);
            }
        }

        //获取图片列表
        picList = ProductService.PictureService.Search(new List<Expression>(), " OrderBy asc");

        if (!IsPostBack)
        {
            //相关产品
            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("CategoryId", "=", Product.CategoryID.ToStr()));
            RepList.DataSource = ProductService.ProductsService.Search(20, expression);
            RepList.DataBind();

            //绑定评论
            BindComments(1);

            //绑定提问
            BindQuestions(1);
        }
    }

    protected void BtnCollection_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["MemberInfo"] == null)
        {
            Response.Redirect("../member/Login.aspx");
        }

        List<Expression> express = new List<Expression>();
        express.Add(new Expression("ProductID","=",id.ToStr()));
        express.Add(new Expression("MemberID", "=", memberID.ToStr()));

        if (ProductService.CollectionService.Search(express).Count == 0)
        {
            TB_Product_Collection entity = new TB_Product_Collection();
            entity.ProductID = id;
            entity.MemberID = memberID;
            entity.Url = Request.Url.ToStr();
            entity.AddDate = DateTime.Now;
            ProductService.CollectionService.Insert(entity);

            MsgBox.InnerHtml = CommonClass.Alert("商品收藏成功");
        }
        else
        {
            MsgBox.InnerHtml = CommonClass.Alert("您已经将该产品加入收藏，不能重复收藏");
        }
    }

    //加入购物车
    protected void BtnCart_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["MemberInfo"] == null)
        {
            Response.Redirect("../member/Login.aspx");
        }

        Cart.AddCart(id,1);
        Response.Redirect("../order/ShoppingCart.aspx");
    }

    //绑定评论
    protected void BindComments(int page)
    { 
        int recordCount=0;
        RepComments.DataSource = ProductService.CommentsService.Search(AspNetPagerComments.PageSize, page, new List<Expression>(), "AddDate desc", ref recordCount);
        RepComments.DataBind();
        AspNetPagerComments.RecordCount = recordCount;
    }

    //绑定评论
    protected void BindQuestions(int page)
    {
        int recordCount = 0;
        RepQuestions.DataSource = ProductService.QuestionsService.Search(AspNetPagerComments.PageSize, page, new List<Expression>(), "AddDate desc", ref recordCount);
        RepQuestions.DataBind();
        AspNetPagerQuestions.RecordCount = recordCount;
    }

    protected void BtnComments_Click(object sender, EventArgs e)
    {
        if (TbComContent.Text.TrimEnd() == "")
        {
            LbComments.Text = "请输入内容";
            return;
        }

        TB_Product_Comments model = new TB_Product_Comments();
        model.MemberID = memberID;
        model.ProductID = Product.ID;
        model.ComType = RadioBtnCommentType.SelectedValue.ToInt();
        model.ComContent = TbComContent.Text;
        model.AddDate = DateTime.Now;
        ProductService.CommentsService.Insert(model);

        TbComContent.Text = "";
        LbComments.Text = "";

        BindComments(1);
    }

    //分页
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        BindComments(e.NewPageIndex);
    }

    //咨询
    protected void BtnQeustion_Click(object sender, EventArgs e)
    {
        if (TbQuestionContent.Text.TrimEnd()=="")
        {
            LbQuestion.Text = "请输入内容";
            return;
        }
        TB_Product_Questions model = new TB_Product_Questions();
        model.MemberID = memberID;
        model.ProductID = Product.ID;
        model.ComContent = TbQuestionContent.Text;
        model.AddDate = DateTime.Now;
        ProductService.QuestionsService.Insert(model);

        TbQuestionContent.Text = "";
        LbQuestion.Text = "";

        BindQuestions(1);
    }

    //咨询分页
    protected void AspNetPagerQuestions_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        BindQuestions(e.NewPageIndex);
    }

    //绑定事件
    protected void RepQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rep = (Repeater)e.Item.FindControl("RepReply");
        string QuestionID = ((HiddenField)e.Item.FindControl("HiddenFieldID")).Value;

        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("QuestionID", "=", QuestionID));

        rep.DataSource = ProductService.ReplyService.Search(expression);
        rep.DataBind();
    }
}
