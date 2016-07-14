namespace StockVentas
{
    partial class frmPopupTrend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxBoton = new System.Windows.Forms.PictureBox();
            this.pictureBoxPromo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPromo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBoton
            // 
            this.pictureBoxBoton.Location = new System.Drawing.Point(372, 12);
            this.pictureBoxBoton.Name = "pictureBoxBoton";
            this.pictureBoxBoton.Size = new System.Drawing.Size(16, 14);
            this.pictureBoxBoton.TabIndex = 3;
            this.pictureBoxBoton.TabStop = false;
            this.pictureBoxBoton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBoton_MouseDown);
            this.pictureBoxBoton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBoton_MouseUp);
            // 
            // pictureBoxPromo
            // 
            this.pictureBoxPromo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPromo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPromo.Name = "pictureBoxPromo";
            this.pictureBoxPromo.Size = new System.Drawing.Size(400, 200);
            this.pictureBoxPromo.TabIndex = 4;
            this.pictureBoxPromo.TabStop = false;
            this.pictureBoxPromo.Click += new System.EventHandler(this.pictureBoxPromo_Click);
            // 
            // frmPopupTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxBoton);
            this.Controls.Add(this.pictureBoxPromo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPopupTrend";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmPopupTrend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPromo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBoton;
        private System.Windows.Forms.PictureBox pictureBoxPromo;
    }
}