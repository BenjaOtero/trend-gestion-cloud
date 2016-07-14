using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Timers;
using System.Diagnostics;

namespace StockVentas
{
    public partial class frmPopupTrend : Form
    {
        private System.Timers.Timer timerUp;
        private System.Timers.Timer timerDown;
        double porcentajeDown = 1;
        double porcentajeUp = 0.5;
        byte[] imgBytes;
        string url;

        public frmPopupTrend(byte[] imgBytes, string url)
        {
            InitializeComponent();
            this.imgBytes = imgBytes;
            this.url = url;
        }

        private void frmPopupTrend_Load(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(workingRectangle.Width - 405, workingRectangle.Height - 205);
            pictureBoxBoton.Image = Properties.Resources.btn_cerrar;
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            Bitmap MyBitmap = (Bitmap)tc.ConvertFrom(imgBytes);
            pictureBoxPromo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxPromo.Image = MyBitmap;
            this.BackColor = System.Drawing.Color.White;

            timerUp = new System.Timers.Timer(1);
            timerUp.Elapsed += new ElapsedEventHandler(OpacityUp);
            timerUp.Enabled = false;

            timerDown = new System.Timers.Timer(10000);
            timerDown.Elapsed += new ElapsedEventHandler(OpacityDown);
            timerDown.Enabled = true;
        }

        private void pictureBoxBoton_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxBoton.Image = Properties.Resources.btn_cerrar_down;
        }

        private void pictureBoxBoton_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxBoton.Image = Properties.Resources.btn_cerrar;
            this.Close();
        }

        private void OpacityUp(object source, ElapsedEventArgs e)
        {
            if (porcentajeUp == 1)
            {
                timerUp.Enabled = false;
                this.Close();
            }
            porcentajeUp = porcentajeUp + 0.01;
            this.Opacity = porcentajeUp;
            timerUp.Interval = 100;
        }

        private void OpacityDown(object source, ElapsedEventArgs e)
        {
            if (porcentajeDown == 0.10)
            {
                timerDown.Enabled = false;
                this.Close();
            }
            porcentajeDown = porcentajeDown - 0.01;
            this.Opacity = porcentajeDown;
            timerDown.Interval = 50;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(url);
        }

    }
}




