using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class EditFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnGet_Click(object sender, EventArgs e)
    {
        StreamReader sr = new StreamReader(Server.MapPath(TbAddress.Text));
        TbTxt.Text = sr.ReadToEnd();
        sr.Close();
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        StreamWriter sw = new StreamWriter(Server.MapPath(TbAddress.Text));
        sw.Write(TbTxt.Text);
        sw.Close();
    }
}