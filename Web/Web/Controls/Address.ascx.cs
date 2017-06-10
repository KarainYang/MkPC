using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using YK.Common;

public partial class Controls_Address : System.Web.UI.UserControl
{
    public string Text
    {
        get
        {
            return TbText.Value;
        }
        set
        {
            TbText.Value = value;
        }
    }

    public string Value
    {
        get
        {
            return TbValue.Value;
        }
        set
        {
            TbValue.Value = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (TbValue.Value != string.Empty)
        {
            string[] codes = TbValue.Value.Split(',');
            province.SelectedValue=codes[0];
            city.SelectedValue = codes[1];
            area.SelectedValue=codes[2];

            string[] names = AddressHelper.GetNames(Value);
            Text = names[0] + "," + names[1] + "," + names[2];
        }
    }
}