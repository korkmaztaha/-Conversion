using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Drawing;
using Spire.Pdf;
using Spire.Doc;
using Spire.Presentation;
using Spire.License;
using System.Drawing.Imaging;
using Spire.Doc.Documents;
using Spire.Pdf.Graphics;
using Ionic.Zip;
using System.Net.Mail;

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
                case "PdfToTiff":
                    PdfToTiff(context);
                    break;
                case "PdfToJpg":
                    PdfToJpg(context);
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
                case "WordToXml":
                    WordToXml(context);
                    break;
                case "WordToPdf":
                    WordToPdf(context);
                    break;
                case "WordToTxt":
                    WordToTxt(context);
                    break;
                case "WordToHtml":
                    WordToHtml(context);
                    break;
                case "WordToRtf":
                    WordToRtf(context);
                    break;
                case "WordToEpub":
                    WordToEpub(context);
                    break;
                case "WordToXps":
                    WordToXps(context);
                    break;
                //case "PowerPointoPng":
                //    PowerPointoPng(context);
                //    break;
                case "SendMail":
                    SendEmail(context);
                    break;
                default:
                    break;
            }
        }
        private void SendEmail(HttpContext context)
        {
            System.Net.Mail.SmtpClient smmail = new System.Net.Mail.SmtpClient();
            System.Net.Mail.MailMessage mailObj = new System.Net.Mail.MailMessage();

            mailObj.To.Add("korkmaztaha@hotmail.com");        
            mailObj.Subject = "Conversion";
            mailObj.BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            mailObj.IsBodyHtml = true;

            AlternateView htmlview = AlternateView.CreateAlternateViewFromString("User Name:" + context.Request.QueryString["uName"] + " Mail Adress: " + context.Request.QueryString["uMail"] + " Message: " +context.Request.QueryString["uMessage"], null, "text/html");
            mailObj.AlternateViews.Add(htmlview);

            smmail.Send(mailObj);



            //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com.", 465);

            //smtpClient.Credentials = new System.Net.NetworkCredential("turktarihotagi@gmail.com", "12Enver21");
            //smtpClient.UseDefaultCredentials = true;
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.EnableSsl = true;
            //MailMessage mail = new MailMessage();

            ////Setting From , To and CC
            //mail.From = new MailAddress("turktarihotagi@gmail.com", "smtp.gmail.com");
            //mail.To.Add(new MailAddress("enver@mitrabilisim.com.tr"));
            //mail.CC.Add(new MailAddress("korkmaztaha95@gmail.com"));

            //smtpClient.Send(mail);

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


            #region jpeg Çevirme
            string jpegNumber = "";
            jpegNumber = Guid.NewGuid().ToString();
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(path);

            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                for (int i = 0; i < doc.Pages.Count; i++)
                {
                    Image bmp = doc.SaveAsImage(i);
                    bmp.Save(HttpContext.Current.Server.MapPath("~/Documents/Images") + "\\" + jpegNumber + i + ".jpeg", ImageFormat.Jpeg);
                    zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Images") + "\\" + jpegNumber + i + ".jpeg", "images");
                }
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");

            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }

        private void PdfToJpg(HttpContext context)
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
                    bmp.Save(HttpContext.Current.Server.MapPath("~/Documents/Images") + "\\" + jpgNumber + i + ".jpg", ImageFormat.Jpeg);
                    zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Images") + "\\" + jpgNumber + i + ".jpg", "images");
                }
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");

            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }
        private void PdfToTiff(HttpContext context)
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


            #region tiff Çevirme
            string tiffNumber = "";
            tiffNumber = Guid.NewGuid().ToString();
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(path);

            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                for (int i = 0; i < doc.Pages.Count; i++)
                {
                    Image bmp = doc.SaveAsImage(i);
                    bmp.Save(HttpContext.Current.Server.MapPath("~/Documents/Images") + "\\" + tiffNumber + i + ".tiff", ImageFormat.Tiff);
                    zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Images") + "\\" + tiffNumber + i + ".tiff", "images");
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
                    doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Xps") + "\\" + XpsNumber + i + ".xps", Spire.Pdf.FileFormat.XPS);
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
                doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + DocNumber + ".doc", Spire.Pdf.FileFormat.DOC);
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
                doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Html") + "\\" + HtmlNumber + ".html", Spire.Pdf.FileFormat.HTML);
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

                    doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Svg") + "\\" + SvgNumber + i + ".svg", i, i, Spire.Pdf.FileFormat.SVG);
                    zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Svg") + "\\" + SvgNumber + i + ".svg", Spire.Pdf.FileFormat.SVG.ToString());

                }
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");

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


                doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + DocxNumber + ".docx", Spire.Pdf.FileFormat.DOCX);
                zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + DocxNumber + ".docx", "doc");


                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");

            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }

        private void WordToXml(HttpContext context)
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
                    path = HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + fileNumber + ".doc";
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

            #region xml Çevirme

            string XmlNumber = "";
            XmlNumber = Guid.NewGuid().ToString();
            Document doc = new Document();
            doc.LoadFromFile(path);
            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                //for (int i = 0; i < doc.Pages.Count - 1; i++)
                //{
                doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Xml") + "\\" + XmlNumber + ".xml");
                zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Xml") + "\\" + XmlNumber + ".xml", "xml");
                //}
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");
            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }

        private void WordToPdf(HttpContext context)
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
                    path = HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + fileNumber + ".doc";
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

            #region PDF Çevirme

            string PdfNumber = "";
            PdfNumber = Guid.NewGuid().ToString();
            Document doc = new Document();
            doc.LoadFromFile(path);
            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                //for (int i = 0; i < doc.Pages.Count - 1; i++)
                //{
                doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Pdf") + "\\" + PdfNumber + ".pdf",Spire.Doc.FileFormat.PDF);
                zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Pdf") + "\\" + PdfNumber + ".pdf", "pdf");
                //}
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");
            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }
        private void WordToTxt(HttpContext context)
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
                    path = HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + fileNumber + ".doc";
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

            #region Txt Çevirme

            string TxtNumber = "";
            TxtNumber = Guid.NewGuid().ToString();
            Document doc = new Document();
            doc.LoadFromFile(path);
            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                //for (int i = 0; i < doc.Pages.Count - 1; i++)
                //{
                doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Txt") + "\\" + TxtNumber + ".txt", Spire.Doc.FileFormat.Txt);
                zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Txt") + "\\" + TxtNumber + ".txt", "txt");
                //}
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");
            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }
        private void WordToHtml(HttpContext context)
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
                    path = HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + fileNumber + ".doc";
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
            Document doc = new Document();
            doc.LoadFromFile(path);
            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                //for (int i = 0; i < doc.Pages.Count - 1; i++)
                //{
                doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Html") + "\\" + HtmlNumber + ".html", Spire.Doc.FileFormat.Html);
                
                zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Html") + "\\" + HtmlNumber + ".html", "html");
                //}
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");
            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }
        private void WordToRtf(HttpContext context)
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
                    path = HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + fileNumber + ".doc";
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

            #region Rtf Çevirme

            string RtfNumber = "";
            RtfNumber = Guid.NewGuid().ToString();
            Document doc = new Document();
            doc.LoadFromFile(path);
            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                //for (int i = 0; i < doc.Pages.Count - 1; i++)
                //{
                doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Rtf") + "\\" + RtfNumber + ".rtf", Spire.Doc.FileFormat.Rtf);

                zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Rtf") + "\\" + RtfNumber + ".rtf", "rtf");
                //}
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");
            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }
        private void WordToEpub(HttpContext context)
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
                    path = HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + fileNumber + ".doc";
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

            #region Epub Çevirme

            string EpubNumber = "";
            EpubNumber = Guid.NewGuid().ToString();
            Document doc = new Document();
            doc.LoadFromFile(path);
            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                //for (int i = 0; i < doc.Pages.Count - 1; i++)
                //{
                doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Epub") + "\\" + EpubNumber + ".epub", Spire.Doc.FileFormat.EPub);

                zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Epub") + "\\" + EpubNumber + ".epub", "epub");
                //}
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");
            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }

        private void WordToXps(HttpContext context)
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
                    path = HttpContext.Current.Server.MapPath("~/Documents/Doc") + "\\" + fileNumber + ".doc";
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

            #region Xps Çevirme

            string XpsNumber = "";
            XpsNumber = Guid.NewGuid().ToString();
            Document doc = new Document();
            doc.LoadFromFile(path);
            string ZipNumber = "";
            ZipNumber = Guid.NewGuid().ToString();
            using (ZipFile zip = new ZipFile())
            {

                //for (int i = 0; i < doc.Pages.Count - 1; i++)
                //{
                doc.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Xps") + "\\" + XpsNumber + ".xps", Spire.Doc.FileFormat.XPS);

                zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Xps") + "\\" + XpsNumber + ".xps", "xps");
                //}
                zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");
            }
            context.Response.ContentType = "text";
            context.Response.Clear();
            context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

            #endregion



        }

        //private void PowerPointoPng(HttpContext context)
        //{
        //    string fileNumber = "";
        //    string path = "";
        //    string fExt = "";
        //    int fLen = 0;
        //    string fileName = "";
        //    string fname = "";
        //    string rslt = "{\"fileid\":\"\",\"filepath\":\"\"}";
        //    fileNumber = Guid.NewGuid().ToString();
        //    string spath = "";
        //    if (context.Request.Files.Count > 0)
        //    {
        //        string virgul = "";
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("{\"files\": [");

        //        HttpFileCollection files = context.Request.Files;

        //        for (int i = 0; i < files.Count; i++)
        //        {

        //            HttpPostedFile file = files[i];
        //            var stream = file.InputStream;
        //            fileName = file.FileName;
        //            var aaa = context.Request.QueryString["ftype"];
        //            fname = Path.GetFileNameWithoutExtension(fileName);
        //            fExt = Path.GetExtension(fileName);
        //            fLen = file.ContentLength;
        //            path = HttpContext.Current.Server.MapPath("~/Documents/PowerPoint") + "\\" + fileNumber + ".pptx";
        //            using (var fileStream = System.IO.File.Create(path))
        //            {
        //                stream.CopyTo(fileStream);
        //            }

        //            sb.Append(virgul);
        //            sb.Append("{");
        //            sb.AppendFormat("\"name\":\"{0}\",\"size\":\"{1}\",\"url\":\"{2}\",\"thumbnailUrl\":\"{3}\",\"deleteUrl\":\"{4}\",\"deleteType\":\"DELETE\"", fileName, fLen, spath, "", "#");

        //            sb.Append("}");
        //            virgul = ",";
        //        }
        //        sb.Append("]}");


        //    }

        //    context.Response.ContentType = "text/json";
        //    context.Response.Clear();
        //    context.Response.Write(rslt);

        //    #region png Çevirme

        //    string pngNumber = "";
        //    pngNumber = Guid.NewGuid().ToString();



        //    Presentation presentation = new Presentation();
        //    Image image = presentation.Slides[i].SaveAsImage();

        //    presentation.LoadFromFile(path);
        //    string ZipNumber = "";
        //    ZipNumber = Guid.NewGuid().ToString();
        //    using (ZipFile zip = new ZipFile())
        //    {

        //        //for (int i = 0; i < doc.Pages.Count - 1; i++)
        //        //{
        //        presentation.SaveToFile(HttpContext.Current.Server.MapPath("~/Documents/Png") + "\\" + pngNumber + ".png");

        //        zip.AddFile(HttpContext.Current.Server.MapPath("~/Documents/Png") + "\\" + pngNumber + ".png", "png");
        //        //}
        //        zip.Save(HttpContext.Current.Server.MapPath("~/Documents/Zip") + "\\" + ZipNumber + ".zip");
        //    }
        //    context.Response.ContentType = "text";
        //    context.Response.Clear();
        //    context.Response.Write("../Documents/Zip/" + ZipNumber + ".zip");

        //    #endregion



        //}


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}