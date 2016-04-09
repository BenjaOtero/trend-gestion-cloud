using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;

namespace StockVentas
{
    public partial class frmMarketingEmail : Form
    {
        string strFileName;

        public frmMarketingEmail()
        {
            InitializeComponent();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFilDlg = new OpenFileDialog();
            opFilDlg.Filter = "JPG (*.jpg)|*.jpg";
            if (opFilDlg.ShowDialog() == DialogResult.OK)
            {
                strFileName = opFilDlg.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = Image.FromFile(strFileName);

            }
        }

        private void EmbedImages(string mailTo)
        {
            MailAddress to = new MailAddress(mailTo);
            MailAddress from = new MailAddress("info@trendsistemas.com", "Karminna");
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = txtTitulo.Text;
            AlternateView plainView = AlternateView.CreateAlternateViewFromString("This is my plain text content, viewable by those clients that don't support html", null, "text/plain");

            //then we create the Html part
            //to embed images, we need to use the prefix 'cid' in the img src value
            //the cid value will map to the Content-Id of a Linked resource.
            //thus <img src='cid:companylogo'> will map to a LinkedResource with a ContentId of 'companylogo'
            string html = "Hacé click en la imágen y participá del sorteo.";
            html += "<a href='http://promo.st/1XfFOGn'>";
            html += "<img src=cid:companylogo>";
            html += "</a>";

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, null, "text/html");

            //create the LinkedResource (embedded image)
            LinkedResource logo = new LinkedResource(strFileName);
            logo.ContentId = "companylogo";
            //add the LinkedResource to the appropriate view
            htmlView.LinkedResources.Add(logo);

            //add the views
            mail.AlternateViews.Add(plainView);
            mail.AlternateViews.Add(htmlView);


            //send the message
          //  SmtpClient smtp = new SmtpClient("127.0.0.1"); //specify the mail server address
            SmtpClient client = new SmtpClient("mail.trendsistemas.com", 587);
            client.Credentials = new System.Net.NetworkCredential("info@trendsistemas.com", "8953#AFjn");
            client.Send(mail);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
