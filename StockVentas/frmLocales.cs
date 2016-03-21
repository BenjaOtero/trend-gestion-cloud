using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockVentas
{
    public partial class frmLocales : Form
    {
        private DataTable tblLocales;

        public enum FormState
        {
            inicial,
            edicion,
            insercion,
            eliminacion
        }

        public frmLocales()
        {
            InitializeComponent();
            tblLocales = BL.GetDataBLL.Locales();
        //    BL.Utilitarios.AddEventosABM(grpCampos, ref btnGrabar, ref tblLocales);
            BL.Utilitarios.AddEventosABM(grpCampos, ref btnGrabar, ref chkActivoWebLOC, ref tblLocales);
        }

        private void BindingSource_Load(object sender, EventArgs e)
        {
            System.Drawing.Icon ico = Properties.Resources.icono_app;
            this.Icon = ico;
            this.ControlBox = true;
            this.MaximizeBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            bindingSource1.DataSource = tblLocales;
            bindingNavigator1.BindingSource = bindingSource1;
            BL.Utilitarios.DataBindingsAdd(bindingSource1, grpCampos);
            Binding bind = new Binding("Checked", bindingSource1, "ActivoWebLOC", false, DataSourceUpdateMode.OnPropertyChanged);
            bind.Format += new ConvertEventHandler(binding_Format);
            bind.Parse += new ConvertEventHandler(binding_Parse);
            chkActivoWebLOC.DataBindings.Add(bind);
            gvwDatos.DataSource = bindingSource1;
            gvwDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvwDatos.Columns["DireccionLOC"].Visible = false;
            gvwDatos.Columns["TelefonoLOC"].Visible = false;
            gvwDatos.Columns["ActivoWebLOC"].Visible = false;
            gvwDatos.Columns["IdLocalLOC"].HeaderText = "Nº local";
            gvwDatos.Columns["NombreLOC"].HeaderText = "Nombre";
            bindingSource1.Sort = "NombreLOC";
            SetStateForm(FormState.inicial);   
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string parametros = txtParametros.Text;
            bindingSource1.Filter = "NombreLOC LIKE '" + parametros + "*'";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bindingSource1.AddNew();
            // tildo el checkbox para disparar el evento parse del objeto bind
            chkActivoWebLOC.CheckState = CheckState.Checked;
            DataTable tmp = tblLocales.Copy();
            tmp.AcceptChanges();
            // utilizo tmp porque si hay filas borradas en tblLocales el select max da error
            var maxValue = tmp.Rows.OfType<DataRow>().Select(row => row["IdLocalLOC"]).Max();
            int clave = Convert.ToInt32(maxValue) + 1;
            bindingSource1.Position = bindingSource1.Count - 1;
            txtIdLocalLOC.ReadOnly = false;
            txtIdLocalLOC.Text = clave.ToString();
            txtIdLocalLOC.ReadOnly = true;
            txtNombreLOC.Focus();
            SetStateForm(FormState.insercion);                   
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            SetStateForm(FormState.edicion);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea borrar este registro?", "Buscar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingSource1.RemoveCurrent();
                bindingSource1.EndEdit();
            }
            SetStateForm(FormState.inicial); 
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource1.EndEdit();
                bindingSource1.Position = 0;
                bindingSource1.Sort = "NombreLOC";
                SetStateForm(FormState.inicial);
                bindingSource1.RemoveFilter();
            }
            catch (ConstraintException)
            {
                string mensaje = "No se puede agregar el local " + txtNombreLOC.Text.ToUpper() + " porque ya existe.";
                MessageBox.Show(mensaje, "Trend", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreLOC.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bindingSource1.CancelEdit();
            SetStateForm(FormState.inicial);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBindingSource_FormClosing(object sender, FormClosingEventArgs e)
        {
            bindingSource1.EndEdit();
            if (tblLocales.GetChanges() != null)
            {
                frmProgress progreso = new frmProgress(tblLocales, "frmLocales", "grabar");
                progreso.ShowDialog();
            }
            bindingSource1.RemoveFilter();
        }

        public void SetStateForm(FormState state)
        {

            if (state == FormState.inicial)
            {
                gvwDatos.Enabled = true;
                txtIdLocalLOC.ReadOnly = true;
                txtIdLocalLOC.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtNombreLOC.ReadOnly = true;
                txtNombreLOC.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtDireccionLOC.ReadOnly = true;
                txtDireccionLOC.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtTelefonoLOC.ReadOnly = true;
                txtTelefonoLOC.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                chkActivoWebLOC.Enabled = false;
                btnBuscar.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnBorrar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                btnSalir.Enabled = true;
            }

            if (state == FormState.insercion)
            {
                gvwDatos.Enabled = false;                
                txtNombreLOC.ReadOnly = false;
                txtDireccionLOC.ReadOnly = false;
                txtTelefonoLOC.ReadOnly = false;
                chkActivoWebLOC.Enabled = true;
                txtNombreLOC.Clear();
                txtNombreLOC.Focus();
                txtDireccionLOC.Clear();
                txtTelefonoLOC.Clear();
                btnBuscar.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnBorrar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnSalir.Enabled = false;
            }

            if (state == FormState.edicion)
            {
                gvwDatos.Enabled = false;
                txtNombreLOC.ReadOnly = false;
                txtDireccionLOC.ReadOnly = false;
                txtTelefonoLOC.ReadOnly = false;
                chkActivoWebLOC.Enabled = true;
                txtNombreLOC.Focus();
                btnBuscar.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnBorrar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnSalir.Enabled = false;
            }
        }

        void binding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "True") e.Value = true;
            else e.Value = false;
        }

        void binding_Parse(object sender, ConvertEventArgs e)
        {
            if ((bool)e.Value) e.Value = 1;
            else e.Value = 0;
        }
    }
}
