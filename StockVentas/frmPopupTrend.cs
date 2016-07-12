using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace StockVentas
{
    public partial class frmPopupTrend : Form
    {
        public frmPopupTrend()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       System.Drawing.ColorTranslator.FromHtml("#111317"),
                                                                       System.Drawing.ColorTranslator.FromHtml("#07090A"),
                                                                       90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void frmPopupTrend_Load(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(workingRectangle.Width - 305, workingRectangle.Height - 295);
            pictureBox3.Image = Properties.Resources.btn_cerrar;
            this.Opacity = 0.35;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Properties.Resources.btn_cerrar_down;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Properties.Resources.btn_cerrar;
        }

    }
}




