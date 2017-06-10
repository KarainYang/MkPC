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
using YK.Common;
using YK.Model;

public partial class member_MyPoints : MemberBasePage
{
    protected List<TB_Member_Intergral> list = new List<TB_Member_Intergral>();
    protected TB_Member_Members member = new TB_Member_Members();
    protected void Page_Load(object sender, EventArgs e)
    {
        member = MemberService.MembersService.Get(MemberID);

        if(!IsPostBack)
        {
            LoadDataBind(1);
        }
    }

    public void LoadDataBind(int pageIndex)
    {
        int recordCount = 0;
        List<Expression> expression=new List<Expression>();
        expression.Add(new Expression("MemberID","=",MemberID.ToStr()));
        if (TbStartDate.Text != string.Empty && TbStartDate.Text != "请输入时间")
        {
            expression.Add(new Expression("AddDate", ">=", TbStartDate.Text));
        }
        if (TbStopDate.Text != string.Empty && TbStopDate.Text != "请输入时间")
        {
            expression.Add(new Expression("AddDate", "<=", TbStopDate.Text));
        }

        list = MemberService.IntergralService.Search(AspNetPager1.PageSize, pageIndex, expression, " addDate desc", ref recordCount);
        AspNetPager1.RecordCount = recordCount;
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        LoadDataBind(e.NewPageIndex);
    }
}
