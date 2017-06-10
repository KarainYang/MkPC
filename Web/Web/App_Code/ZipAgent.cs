using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;

using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System.Collections;
using System.Collections.Generic;

    /// <summary>
    ///ZipAgent 的摘要说明
    /// </summary>
    public class ZipAgent
    {

        // 所有文件缓存
        List<string> files = new List<string>();


        // 所有空目录缓存
        List<string> paths = new List<string>();

        public void funcZipFile(string FileToZip, string ZipedFile, int CompressionLevel, int BlockSize)
        {
            //如果文件没有找到，则报错 
            if (!System.IO.File.Exists(FileToZip))
            {
                throw new System.IO.FileNotFoundException("The specified file " + FileToZip + " could not be found. Zipping aborderd");
            }

            FileStream StreamToZip = new FileStream(FileToZip, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            FileStream ZipFile = File.Open(ZipedFile, FileMode.OpenOrCreate);

            ZipOutputStream ZipStream = new ZipOutputStream(ZipFile);
            ZipEntry ZipEntry = new ZipEntry(Path.GetFileName(FileToZip));
            ZipStream.PutNextEntry(ZipEntry);
            ZipStream.SetLevel(CompressionLevel);
            byte[] buffer = new byte[BlockSize];
            System.Int32 size = StreamToZip.Read(buffer, 0, buffer.Length);
            ZipStream.Write(buffer, 0, size);
            try
            {
                while (size < StreamToZip.Length)
                {
                    int sizeRead = StreamToZip.Read(buffer, 0, buffer.Length);
                    ZipStream.Write(buffer, 0, sizeRead);
                    size += sizeRead;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                ZipStream.Finish();
                ZipStream.Close();
                StreamToZip.Close();
            }
        }
        /// <summary>
        /// 压缩目录（包括子目录及所有文件）
        /// </summary>
        /// <param name="rootPath">要压缩的根目录</param>
        /// <param name="destinationPath">保存路径</param>
        /// <param name="compressLevel">压缩程度，范围0-9，数值越大，压缩程序越高</param>
        public void funcZipFile(string rootPath, string destinationPath, int compressLevel)
        {

            GetAllDirectories(rootPath);

            while (rootPath.LastIndexOf("\\") + 1 == rootPath.Length)//检查路径是否以"\"结尾
            {
                rootPath = rootPath.Substring(0, rootPath.Length - 1);//如果是则去掉末尾的"\"
            }
            string rootMark = rootPath; //得到当前路径的位置，以备压缩时将所压缩内容转变成相对路径。
            Crc32 crc = new Crc32();
            ZipOutputStream outPutStream = new ZipOutputStream(File.Create(destinationPath));
            outPutStream.SetLevel(compressLevel); // 0 - store only to 9 - means best compression

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                FileStream fileStream = File.OpenRead(file);//打开压缩文件
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                string path = file.Replace(rootMark, string.Empty);
                if (path.Substring(0, 1) == "\\")
                {
                    path = path.Substring(1);
                }
                ZipEntry entry = new ZipEntry(path);
                entry.DateTime = fi.LastWriteTime;
                entry.Size = fileStream.Length;
                fileStream.Close();
                crc.Reset();
                crc.Update(buffer);
                entry.Crc = crc.Value;
                outPutStream.PutNextEntry(entry);
                outPutStream.Write(buffer, 0, buffer.Length);
            }
            this.files.Clear();
            foreach (string emptyPath in paths)
            {
                string path = emptyPath.Replace(rootMark, string.Empty);
                if (path.Substring(0, 1) == "\\")
                {
                    path = path.Substring(1);
                }
                if (path.LastIndexOf("\\") + 1 != path.Length)
                {
                    path = path + "\\";
                }

                ZipEntry entry = new ZipEntry(path);
                outPutStream.PutNextEntry(entry);
            }
            this.paths.Clear();
            outPutStream.Finish();
            outPutStream.Close();
        }
        /// <summary>
        /// 取得目录下所有文件及文件夹，分别存入files及paths
        /// </summary>
        /// <param name="rootPath">根目录</param>
        private void GetAllDirectories(string rootPath)
        {
            string[] subPaths = Directory.GetDirectories(rootPath);//得到所有子目录
            foreach (string path in subPaths)
            {
                GetAllDirectories(path);//对每一个字目录做与根目录相同的操作：即找到子目录并将当前目录的文件名存入List
            }
            string[] files = Directory.GetFiles(rootPath);
            foreach (string file in files)
            {
                this.files.Add(file);//将当前目录中的所有文件全名存入文件List
            }
            if (subPaths.Length == files.Length && files.Length == 0)//如果是空目录
            {
                this.paths.Add(rootPath);//记录空目录
            }
        }

        public void funcZipFiles(string[] filenames, string ZipedFile, int CompressionLevel)
        {
            //string[] filenames = Directory.GetFiles(args[0]);

            Crc32 crc = new Crc32();
            ZipOutputStream s = new ZipOutputStream(File.Create(ZipedFile));

            s.SetLevel(CompressionLevel);
            foreach (string file in filenames)
            {
                //打开压缩文件
                FileInfo fi = new FileInfo(file.StartsWith("/") ? HttpContext.Current.Server.MapPath(file) : file);
                FileStream fs = File.OpenRead(fi.FullName);

                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                ZipEntry entry = new ZipEntry(Path.GetFileName(file));

                entry.DateTime = fi.LastWriteTime;
                entry.Size = fs.Length;
                fs.Close();

                crc.Reset();
                crc.Update(buffer);

                entry.Crc = crc.Value;

                s.PutNextEntry(entry);

                s.Write(buffer, 0, buffer.Length);

            }

            s.Finish();
            s.Close();

        }

        public ArrayList funcUnZip(string zipFile, string saveDirectory)
        {
            if (!Directory.Exists(saveDirectory)) Directory.CreateDirectory(saveDirectory);
            if (!saveDirectory.EndsWith("\\")) saveDirectory += "\\";

            ArrayList list = new ArrayList();
            ZipInputStream s = new ZipInputStream(File.OpenRead(zipFile));
            try
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string fileName = Path.GetFileName(theEntry.Name);
                    list.Add(fileName);
                    FileInfo file = new FileInfo(saveDirectory + fileName);
                    FileStream fs = file.Create();
                    int size = 2048;
                    byte[] data = new byte[2048];
                    size = s.Read(data, 0, data.Length);
                    while (size > 0)
                    {
                        fs.Write(data, 0, size);
                        size = s.Read(data, 0, data.Length);
                    }

                    fs.Close();
                    //修改文件时间为实际时间
                    file.CreationTime = file.LastAccessTime = file.LastWriteTime = theEntry.DateTime;
                }
            }
            catch (Exception eu)
            {
                throw eu;
            }
            finally
            {
                s.Close();
            }

            return list;
        }
    }