using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Conversion.Users
{
    public partial class WebService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod()]
        public static string xxSendEmailxx(string uName, string uMail, string uMessage)
        {
            //System.Net.Mail.SmtpClient smmail = new System.Net.Mail.SmtpClient();
            //System.Net.Mail.MailMessage mailObj = new System.Net.Mail.MailMessage();

            //mailObj.To.Add("korkmaztaha@hotmail.com");
            //mailObj.Subject = "Conversion";
            //mailObj.BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            //mailObj.IsBodyHtml = true;

            //AlternateView htmlview = AlternateView.CreateAlternateViewFromString("User Name:" + uName + " Mail Adress: " + uMail + " Message: " + uMessage, null, "text/html");
            //mailObj.AlternateViews.Add(htmlview);

            //smmail.Send(mailObj);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com.", 465);

            smtpClient.Credentials = new System.Net.NetworkCredential("turktarihotagi@gmail.com", "12Enver21");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress("turktarihotagi@gmail.com", "smtp.gmail.com");
            mail.To.Add(new MailAddress("enver@mitrabilisim.com.tr"));
            mail.CC.Add(new MailAddress("korkmaztaha95@gmail.com"));

            //smtpClient.Send(mail);
            return "";
        }

    }
}