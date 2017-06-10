using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using YK.Common;

public partial class WaterMark_ : System.Web.UI.Page
{
    //http://www.cnblogs.com/sikaodelang/archive/2010/08/10/1796781.html 参考地址


    protected void Page_Load(object sender, EventArgs e)
    {
        //PicWaterMark(Horizontal.left, Vertical.top);
        //TxtWaterMark(Horizontal.center,Vertical.top);

        string path = Server.MapPath("~/test.jpg");
        string waterFile = Server.MapPath("~/logo.jpg");
        WaterMarkHelper1.PicWaterMark(path, waterFile, YK.Common.Horizontal.center, YK.Common.Vertical.bottom);
    }
    void Fun1()
    {
        string path = Server.MapPath("~/test.jpg");
        string text = "梦科网络";

        System.Drawing.Image image = System.Drawing.Image.FromFile(path);
        Bitmap bitmap = new Bitmap(image, image.Width, image.Height);
        Graphics g = Graphics.FromImage(bitmap);

        float fontSize = 12.0f;    //字体大小   
        float textWidth = text.Length * fontSize;  //文本的长度   
        //下面定义一个矩形区域，以后在这个矩形里画上白底黑字   
        float rectX = 0;
        float rectY = 0;
        float rectWidth = text.Length * (fontSize + 8);
        float rectHeight = fontSize + 8;
        //声明矩形域   
        RectangleF textArea = new RectangleF(rectX, rectY, rectWidth, rectHeight);

        Font font = new Font("宋体", fontSize);   //定义字体   
        Brush whiteBrush = new SolidBrush(Color.Red);   //白笔刷，画文字用   
        Brush blackBrush = new SolidBrush(Color.White);   //黑笔刷，画背景用   

        g.FillRectangle(blackBrush, rectX, rectY, rectWidth, rectHeight);

        g.DrawString(text, font, whiteBrush, textArea);
        MemoryStream ms = new MemoryStream();
        //保存为Jpg类型   
        bitmap.Save(ms, ImageFormat.Jpeg);

        #region 保存加水印的图片

        string testPath = Server.MapPath("~/test2.jpg");
        byte[] imgData = ms.ToArray();
        if (File.Exists(testPath))
        { 
            File.Delete(testPath);
        }        
        FileStream fs = new FileStream(testPath, FileMode.Create, FileAccess.Write);
        if (fs != null)
        {
            fs.Write(imgData, 0, imgData.Length);
            fs.Close();
        }

        #endregion

        //HttpFileCollection img = Request.Files;
        //Stream stream = img[0].InputStream;

        //FileStream fs = new FileStream(testPath, FileMode.Open);
        //Stream stream = fs;
        //BinaryReader br = new BinaryReader(stream);
        //byte[] fileByte = br.ReadBytes((int)stream.Length);

        //string baseFileString = Convert.ToBase64String(fileByte);
        //byte[] byt = Convert.FromBase64String(baseFileString);

        //输出处理后的图像，这里为了演示方便，我将图片显示在页面中了   
        Response.Clear();
        Response.ContentType = "image/jpeg";
        Response.BinaryWrite(ms.ToArray());

        g.Dispose();
        bitmap.Dispose();
        image.Dispose();   
    }

    public enum Horizontal { left,center,right }
    public enum Vertical { top, middle, bottom }

    public void TxtWaterMark(Horizontal horizontal, Vertical vertical)
    {

        Color[] color = { Color.Black, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.DarkBlue };
        string[] font = { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" };
        int fontSize = 14;
        string txt = "梦科网络科技有限公司";
        Random rnd = new Random();

        string path=Server.MapPath("~/test.jpg");
        System.Drawing.Image image = System.Drawing.Image.FromFile(path);
        int width=image.Width;
        int height=image.Height;
        
        Bitmap bmp = new Bitmap(image,width ,height );
        Graphics g = Graphics.FromImage(bmp);
        //g.Clear(Color.White);

        //坐标值
        int x = 0, y = 0;

        switch (horizontal)
        { 
            case Horizontal.left:
                x = 0;
                break;
            case Horizontal.center:
                x = (width - 20 * (txt.Length)) / 2;
                break;
            case Horizontal.right:
                x = width - 20 * (txt.Length) - 10;
                break;
        }

        switch (vertical)
        {
            case Vertical.top:
                y = 0 + 10; //向下移动10像素好看些
                break;
            case Vertical.middle:
                y = height / 2 - fontSize ;
                break;
            case Vertical.bottom:
                y = height - 14;
                break;
        }

        // 画验证码
        for (int i = 0; i < txt.Length; i++)
        {
            string fnt = font[rnd.Next(font.Length)];
            Font ft = new Font(fnt, fontSize, FontStyle.Bold);
            Color clr = color[rnd.Next(color.Length)];
            g.DrawString(txt[i].ToString(), ft, new SolidBrush(clr), (float)i * 20 + x, y);
        }

        MemoryStream ms = new MemoryStream();       
        bmp.Save(ms, ImageFormat.Png);

        #region 保存加水印的图片

        string testPath = Server.MapPath("~/test2.jpg");
        byte[] imgData = ms.ToArray();
        if (File.Exists(testPath))
        {
            File.Delete(testPath);
        }
        FileStream fs = new FileStream(testPath, FileMode.Create, FileAccess.Write);
        if (fs != null)
        {
            fs.Write(imgData, 0, imgData.Length);
            fs.Close();
        }

        #endregion

        Response.ClearContent();
        Response.ContentType = "image/jpeg";
        Response.BinaryWrite(ms.ToArray());
        
        g.Dispose();
        bmp.Dispose();
        image.Dispose();   
    }

    /// <summary>    
    /// 给图片上水印    
    /// </summary>    
    /// <param name="filePath">原图片地址</param>    
    /// <param name="waterFile">水印图片地址</param>    
    public void PicWaterMark(Horizontal horizontal, Vertical vertical)
    {
        string filePath = Server.MapPath("~/test.jpg");
        string waterFile = Server.MapPath("~/logo.jpg");

        string ModifyImagePath = filePath;//修改的图像路径    
        int lucencyPercent = 25;//透明度
        Image modifyImage = null;
        Image drawedImage = null;
        Graphics g = null;
        try
        {
            //建立图形对象    
            modifyImage = Image.FromFile(ModifyImagePath, true);
            drawedImage = Image.FromFile(waterFile, true);
            g = Graphics.FromImage(modifyImage);            
            //设置颜色矩阵    
            float[][] matrixItems ={    
            new float[] {1, 0, 0, 0, 0},    
            new float[] {0, 1, 0, 0, 0},    
            new float[] {0, 0, 1, 0, 0},    
            new float[] {0, 0, 0, (float)lucencyPercent/100f, 0},    
            new float[] {0, 0, 0, 0, 1}};

            //获取要绘制图形坐标    
            int x = 0;
            int y = 0;
            //水印图片的宽和高
            int width = drawedImage.Width;
            int height = drawedImage.Height;
            switch (horizontal)
            {
                case Horizontal.left:
                    x = 0;
                    break;
                case Horizontal.center:
                    x = (modifyImage.Width-width)/2 ;
                    break;
                case Horizontal.right:
                    x = modifyImage.Width - width ;
                    break;
            }

            switch (vertical)
            {
                case Vertical.top:
                    y = 0 ; //向下移动10像素好看些
                    break;
                case Vertical.middle:
                    y = (modifyImage.Height-height)/2;
                    break;
                case Vertical.bottom:
                    y = modifyImage.Height - height;
                    break;
            }

            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
            ImageAttributes imgAttr = new ImageAttributes();
            imgAttr.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            //绘制阴影图像    
            g.DrawImage(drawedImage, 
                new Rectangle(x, y, drawedImage.Width, drawedImage.Height), 
                0, 0, //水印图片的坐标值开始，如0,0就是从水印图片的0,0坐标开始画图
                drawedImage.Width, 
                drawedImage.Height, 
                GraphicsUnit.Pixel, 
                imgAttr);
            //保存文件    
            string[] allowImageType = { ".jpg", ".gif", ".png", ".bmp", ".tiff", ".wmf", ".ico" };
            FileInfo fi = new FileInfo(ModifyImagePath);
            ImageFormat imageType = ImageFormat.Gif;
            switch (fi.Extension.ToLower())
            {
                case ".jpg": imageType = ImageFormat.Jpeg; break;
                case ".gif": imageType = ImageFormat.Gif; break;
                case ".png": imageType = ImageFormat.Png; break;
                case ".bmp": imageType = ImageFormat.Bmp; break;
                case ".tif": imageType = ImageFormat.Tiff; break;
                case ".wmf": imageType = ImageFormat.Wmf; break;
                case ".ico": imageType = ImageFormat.Icon; break;
                default: break;
            }
            MemoryStream ms = new MemoryStream();
            modifyImage.Save(ms, imageType);
            byte[] imgData = ms.ToArray();
            modifyImage.Dispose();
            drawedImage.Dispose();
            g.Dispose();


            //FileStream fs = null;
            //File.Delete(ModifyImagePath);
            //fs = new FileStream(ModifyImagePath, FileMode.Create, FileAccess.Write);
            //if (fs != null)
            //{
            //    fs.Write(imgData, 0, imgData.Length);
            //    fs.Close();
            //}


            Response.ClearContent();
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(ms.ToArray());
        }
        finally
        {
            try
            {
                drawedImage.Dispose();
                modifyImage.Dispose();
                g.Dispose();
            }
            catch
            {
            }
        }
    }    

}