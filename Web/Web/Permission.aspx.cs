using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YK.Model;

public partial class Permission : YK.Common.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("1","=","1"));
        YK.Service.AdminService.RoleInResourcesService.Delete(expression);

       var all = YK.Service.AdminService.ResourcesService.Search();
       foreach (var item in all)
       {
           YK.Service.AdminService.ResourcesService.Delete(item.ID);
       }

        CommonHelpers helper = new CommonHelpers();
        var list = helper.Permission();
        foreach(var item in list)
        {
            YK.Model.TB_Admin_Resources resources = new YK.Model.TB_Admin_Resources();
            resources.ResourceName = item.ResourceName;
            resources.ParentID = 0;
            resources.OrderBy = item.OrderBy;
            resources.Url = item.Url;
            resources.IsShow = item.IsShow;
            resources.Creater = AdminUserName;
            resources.AddDate = DateTime.Now;

            YK.Service.AdminService.ResourcesService.Insert(resources);

            var entityList = YK.Service.AdminService.ResourcesService.Search(1, new List<Expression>(), "id desc");

            var entity = entityList.Count>0?entityList.First():new YK.Model.TB_Admin_Resources();

            foreach(var child in item.ChildTree)
            {
                YK.Model.TB_Admin_Resources resources2 = new YK.Model.TB_Admin_Resources();
                resources2.ResourceName = child.ResourceName;
                resources2.ParentID = entity.ID;
                resources2.OrderBy = child.OrderBy;
                resources2.Url = child.Url;
                resources2.IsShow = child.IsShow;
                resources2.Creater = AdminUserName;
                resources2.AddDate = DateTime.Now;

                YK.Service.AdminService.ResourcesService.Insert(resources2);
            }
        }
    }
}