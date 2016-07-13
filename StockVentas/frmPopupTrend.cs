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

namespace StockVentas
{
    public partial class frmPopupTrend : Form
    {
        private System.Timers.Timer aTimer;
        double porcentaje = 1;

        public frmPopupTrend()
        {
            InitializeComponent();
        }

        private void frmPopupTrend_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(workingRectangle.Width - 405, workingRectangle.Height - 205);
            pictureBox3.Image = Properties.Resources.btn_cerrar;
       //     this.Opacity = 0.35;
            this.BackColor = System.Drawing.Color.White;
            aTimer = new System.Timers.Timer(10000);
            aTimer.Elapsed += new ElapsedEventHandler(OpacityDown);
            aTimer.Enabled = true;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Properties.Resources.btn_cerrar_down;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Properties.Resources.btn_cerrar;
        }

        private void OpacityDown(object source, ElapsedEventArgs e)
        {
            if (porcentaje == 0.10)
            {
                aTimer.Enabled = false;
                this.Close();
            }
            porcentaje = porcentaje - 0.01;
            this.Opacity = porcentaje;
            aTimer.Interval = 150;
        }

    }
}




