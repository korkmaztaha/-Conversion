using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Drawing;
using Spire.Pdf;
using System.Drawing.Imaging;
using Spire.Doc.Documents;
using Spire.Pdf.Graphics;
using Ionic.Zip;

namespace Conversion.Users
{
    /// <summary>
    /// Summary description for Handler
    /// </summary>
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            switch (context.Request.QueryString["Step"].ToString())
            {

                case "FormAttachAny":
                    AnyUpload(context);
                    break;
                case "PdfToXps":
                    PdfToXps(context);
                    break;
                case "PdfToDoc":
                    PdfToDoc(context);
                    break;
                case "PdfToHtml":
                    PdfToHtml(context);
                    break;
                case "PdfToSvg":
                    PdfToSvg(context);
                    break;
                case "PdfToDocx":
                    PdfToDocx(context);
                    break;
                default:
                    break;
            }
        }

        private void AnyUpload(HttpContext context)
        {
            string fileNumber = "";
            string path = "";
            string fExt = "";
            int fLen = 0;
            string fileName = "";
            string fname = "";
            string rslt = "{\"fileid\":\"\",\"filepath\":\"\"}";
            fileNumber = Guid.NewGuid().ToString();
            string spath = "";
            if (context.Request.Files.Count > 0)
            {
                string virgul = "";
                StringBuilder sb = new StringBuilder();
                sb.Append("{\"files\": [");

                HttpFileCollection files = context.Request.Files;

                for (int i = 0; i < files.Count; i++)
                {

                    HttpPostedFile file = files[i];
                    var stream = file.InputStream;
                    fileName = file.FileName;
                    var aaa = context.Request.QueryString["ftype"];
                    fname = Path.GetFileNameWithoutExtension(fileName);
                    fExt = Path.GetExtension(fileName);
                    fLen = file.ContentLength;
                    path = HttpContext.Current.Server.MapPath("~/Documents/Pdf") + "\\" + fileNumber + ".pdf";
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }

                    sb.Append(virgul);
                    sb.Append("{");
                    sb.AppendFormat("\"name\":\"{0}\",\"size\":\"{1}\",\"url\":\"{2}\",\"thumbnailUrl\":\"{3}\",\"deleteUrl\":\"{4}\",\"deleteType\":\"DELETE\"", fileName, fLen, spath, "", "#");

                    sb.Append("}");
                    virgul = ",";
                }
                sb.Append("]}");


            }


            #region jpg Çevirme
            string jpgNumber = "";
            jpgNumber = Guid.NewGuid().ToString();
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(path);

            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                for (int i = 0; i < doc.Pages.Count; i++)
                {
                    Image bmp = doc.SaveAsImage(i);
                    bmp.Save(HttpContext.Current.Server.MapPath("~/Documents/Images") + "\\" + jpgNumber + i + ".jpeg", ImageFormat.Jpeg);
                    zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Images") + "\\" + jpgNumber + i + ".jpeg", "images");
                }
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");
                
            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");
            
            #endregion



        }
       private void PdfToXps(HttpContext context)
        {
            #region pdfAlma
            string fileNumber = "";
            string path = "";
            string fExt = "";
            int fLen = 0;
            string fileName = "";
            string fname = "";
            string rslt = "{\"fileid\":\"\",\"filepath\":\"\"}";
            fileNumber = Guid.NewGuid().ToString();
            string spath = "";
            if (context.Request.Files.Count > 0)
            {
                string virgul = "";
                StringBuilder sb = new StringBuilder();
                sb.Append("{\"files\": [");

                HttpFileCollection files = context.Request.Files;

                for (int i = 0; i < files.Count; i++)
                {

                    HttpPostedFile file = files[i];
                    var stream = file.InputStream;
                    fileName = file.FileName;
                    var aaa = context.Request.QueryString["ftype"];
                    fname = Path.GetFileNameWithoutExtension(fileName);
                    fExt = Path.GetExtension(fileName);
                    fLen = file.ContentLength;
                    path = HttpContext.Current.Server.MapPath("~/Documents/Pdf") + "\\" + fileNumber + ".pdf";
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }

                    sb.Append(virgul);
                    sb.Append("{");
                    sb.AppendFormat("\"name\":\"{0}\",\"size\":\"{1}\",\"url\":\"{2}\",\"thumbnailUrl\":\"{3}\",\"deleteUrl\":\"{4}\",\"deleteType\":\"DELETE\"", fileName, fLen, spath, "", "#");

                    sb.Append("}");
                    virgul = ",";
                }
                sb.Append("]}");


            }

            context.Response.ContentType = "text/json";
            context.Response.Clear();
            context.Response.Write(rslt);
            #endregion

            #region Xps Çevirme        
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(path);

            string ZipNumber = "";
            string XpsNumber = "";
            XpsNumber = Guid.NewGuid().ToString();
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                for (int i = 0; i < doc.Pages.Count - 1; i++)
                {
                    doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Xps") + "\\" + XpsNumber + i + ".xps", FileFormat.XPS);
                    doc.Close();

                    zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Xps") + "\\" + XpsNumber + i + ".xps", "Xps");
                }
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");
            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }
        private void PdfToDoc(HttpContext context)
        {
            string fileNumber = "";
            string path = "";
            string fExt = "";
            int fLen = 0;
            string fileName = "";
            string fname = "";
            string rslt = "{\"fileid\":\"\",\"filepath\":\"\"}";
            fileNumber = Guid.NewGuid().ToString();
            string spath = "";
            if (context.Request.Files.Count > 0)
            {
                string virgul = "";
                StringBuilder sb = new StringBuilder();
                sb.Append("{\"files\": [");

                HttpFileCollection files = context.Request.Files;

                for (int i = 0; i < files.Count; i++)
                {

                    HttpPostedFile file = files[i];
                    var stream = file.InputStream;
                    fileName = file.FileName;
                    var aaa = context.Request.QueryString["ftype"];
                    fname = Path.GetFileNameWithoutExtension(fileName);
                    fExt = Path.GetExtension(fileName);
                    fLen = file.ContentLength;
                    path = HttpContext.Current.Server.MapPath("~/Documents/Pdf") + "\\" + fileNumber + ".pdf";
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }

                    sb.Append(virgul);
                    sb.Append("{");
                    sb.AppendFormat("\"name\":\"{0}\",\"size\":\"{1}\",\"url\":\"{2}\",\"thumbnailUrl\":\"{3}\",\"deleteUrl\":\"{4}\",\"deleteType\":\"DELETE\"", fileName, fLen, spath, "", "#");

                    sb.Append("}");
                    virgul = ",";
                }
                sb.Append("]}");


            }

            context.Response.ContentType = "text/json";
            context.Response.Clear();
            context.Response.Write(rslt);

            #region Doc Çevirme
            string DocNumber = "";
            DocNumber = Guid.NewGuid().ToString();
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(path);
            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                //for (int i = 0; i < doc.Pages.Count - 1; i++)
                //{
                doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + DocNumber + ".doc", FileFormat.DOC);
                zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + DocNumber + ".doc", "Doc");
                //}
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");
            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }
        private void PdfToHtml(HttpContext context)
        {
            string fileNumber = "";
            string path = "";
            string fExt = "";
            int fLen = 0;
            string fileName = "";
            string fname = "";
            string rslt = "{\"fileid\":\"\",\"filepath\":\"\"}";
            fileNumber = Guid.NewGuid().ToString();
            string spath = "";
            if (context.Request.Files.Count > 0)
            {
                string virgul = "";
                StringBuilder sb = new StringBuilder();
                sb.Append("{\"files\": [");

                HttpFileCollection files = context.Request.Files;

                for (int i = 0; i < files.Count; i++)
                {

                    HttpPostedFile file = files[i];
                    var stream = file.InputStream;
                    fileName = file.FileName;
                    var aaa = context.Request.QueryString["ftype"];
                    fname = Path.GetFileNameWithoutExtension(fileName);
                    fExt = Path.GetExtension(fileName);
                    fLen = file.ContentLength;
                    path = HttpContext.Current.Server.MapPath("~/Documents/Pdf") + "\\" + fileNumber + ".pdf";
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }

                    sb.Append(virgul);
                    sb.Append("{");
                    sb.AppendFormat("\"name\":\"{0}\",\"size\":\"{1}\",\"url\":\"{2}\",\"thumbnailUrl\":\"{3}\",\"deleteUrl\":\"{4}\",\"deleteType\":\"DELETE\"", fileName, fLen, spath, "", "#");

                    sb.Append("}");
                    virgul = ",";
                }
                sb.Append("]}");


            }

            context.Response.ContentType = "text/json";
            context.Response.Clear();
            context.Response.Write(rslt);

            #region Html Çevirme

            string HtmlNumber = "";
            HtmlNumber = Guid.NewGuid().ToString();
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(path);
            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                //for (int i = 0; i < doc.Pages.Count - 1; i++)
                //{
                doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Html") + "\\" + HtmlNumber + ".html", FileFormat.HTML);
                zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Html") + "\\" + HtmlNumber + ".html", "Html");
                //}
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");
            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }
        private void PdfToSvg(HttpContext context)
        {
            string fileNumber = "";
            string path = "";
            string fExt = "";
            int fLen = 0;
            string fileName = "";
            string fname = "";
            string rslt = "{\"fileid\":\"\",\"filepath\":\"\"}";
            fileNumber = Guid.NewGuid().ToString();
            string spath = "";
            if (context.Request.Files.Count > 0)
            {
                string virgul = "";
                StringBuilder sb = new StringBuilder();
                sb.Append("{\"files\": [");

                HttpFileCollection files = context.Request.Files;

                for (int i = 0; i < files.Count; i++)
                {

                    HttpPostedFile file = files[i];
                    var stream = file.InputStream;
                    fileName = file.FileName;
                    var aaa = context.Request.QueryString["ftype"];
                    fname = Path.GetFileNameWithoutExtension(fileName);
                    fExt = Path.GetExtension(fileName);
                    fLen = file.ContentLength;
                    path = HttpContext.Current.Server.MapPath("~/Documents/Pdf") + "\\" + fileNumber + ".pdf";
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }

                    sb.Append(virgul);
                    sb.Append("{");
                    sb.AppendFormat("\"name\":\"{0}\",\"size\":\"{1}\",\"url\":\"{2}\",\"thumbnailUrl\":\"{3}\",\"deleteUrl\":\"{4}\",\"deleteType\":\"DELETE\"", fileName, fLen, spath, "", "#");

                    sb.Append("}");
                    virgul = ",";
                }
                sb.Append("]}");


            }

            context.Response.ContentType = "text/json";
            context.Response.Clear();
            context.Response.Write(rslt);

            #region Svg Çevirme
            string SvgNumber = "";
            SvgNumber = Guid.NewGuid().ToString();
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(path);
            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                for (int i = 0; i < doc.Pages.Count; i++)
                {
                   
                    doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Svg") + "\\" + SvgNumber +i+ ".svg", i, i, FileFormat.SVG);
                    zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Svg") + "\\" + SvgNumber +i+ ".svg", FileFormat.SVG.ToString());

                }
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber+ ".zip");

            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }
        private void PdfToDocx(HttpContext context)
        {
            string fileNumber = "";
            string path = "";
            string fExt = "";
            int fLen = 0;
            string fileName = "";
            string fname = "";
            string rslt = "{\"fileid\":\"\",\"filepath\":\"\"}";
            fileNumber = Guid.NewGuid().ToString();
            string spath = "";
            if (context.Request.Files.Count > 0)
            {
                string virgul = "";
                StringBuilder sb = new StringBuilder();
                sb.Append("{\"files\": [");

                HttpFileCollection files = context.Request.Files;

                for (int i = 0; i < files.Count; i++)
                {

                    HttpPostedFile file = files[i];
                    var stream = file.InputStream;
                    fileName = file.FileName;
                    var aaa = context.Request.QueryString["ftype"];
                    fname = Path.GetFileNameWithoutExtension(fileName);
                    fExt = Path.GetExtension(fileName);
                    fLen = file.ContentLength;
                    path = HttpContext.Current.Server.MapPath("~/Documents/Pdf") + "\\" + fileNumber + ".pdf";
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }

                    sb.Append(virgul);
                    sb.Append("{");
                    sb.AppendFormat("\"name\":\"{0}\",\"size\":\"{1}\",\"url\":\"{2}\",\"thumbnailUrl\":\"{3}\",\"deleteUrl\":\"{4}\",\"deleteType\":\"DELETE\"", fileName, fLen, spath, "", "#");

                    sb.Append("}");
                    virgul = ",";
                }
                sb.Append("]}");
            }

            context.Response.ContentType = "text/json";
            context.Response.Clear();
            context.Response.Write(rslt);

            #region Docx Çevirme
            string DocxNumber = "";
            DocxNumber = Guid.NewGuid().ToString();
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(path);
            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {


                doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + DocxNumber + ".docx", FileFormat.DOCX);
                zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + DocxNumber + ".docx", "doc");


                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");

            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}