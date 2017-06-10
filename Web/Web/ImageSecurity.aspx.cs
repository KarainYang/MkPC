using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public partial class ImageSecurity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] str = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] strS = new string[5];
        string strStr = "";
        Random rand = new Random();
        for (int i = 0; i < 5; i++)
        {
            int j = rand.Next(0, str.Length - 1);
            strS[i] = str[j];
            strStr += str[j];
        }
        Session["Security"] = strStr;
        Bitmap bit = new Bitmap(160, 40);
        Graphics graphics = Graphics.FromImage(bit);
        graphics.DrawString(strS[0], new Font("宋体", 35, FontStyle.Bold), new SolidBrush(Color.Red), new PointF(10, 0));
        graphics.DrawString(strS[1], new Font("宋体", 25, FontStyle.Bold), new SolidBrush(Color.Wheat), new PointF(50, 5));
        graphics.DrawString(strS[2], new Font("宋体", 20, FontStyle.Bold), new SolidBrush(Color.Green), new PointF(80, 2));
        graphics.DrawString(strS[3], new Font("宋体", 28, FontStyle.Bold), new SolidBrush(Color.Yellow), new PointF(100, 6));
        graphics.DrawString(strS[4], new Font("宋体", 30, FontStyle.Bold), new SolidBrush(Color.Gold), new PointF(130, 5));
        graphics.DrawLine(new Pen(new SolidBrush(Color.Red)), new Point(0, 0), new Point(160, 40));
        graphics.DrawLine(new Pen(new SolidBrush(Color.Red)), new Point(0, 40), new Point(160, 0));
        graphics.DrawRectangle(new Pen(new SolidBrush(Color.Red)), 10, 10, 160, 20);
        graphics.Save();

        MemoryStream MS = new MemoryStream();
        bit.Save(MS, ImageFormat.Gif);
        Response.ClearContent();
        Response.ContentType = "image/Png";
        Response.BinaryWrite(MS.ToArray());
    }
}
