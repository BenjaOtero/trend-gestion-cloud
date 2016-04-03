using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;

namespace StockVentas
{
    public partial class frmProveedores : Form
    {
        private DataTable tblProveedores;

        public enum FormState
        {
            inicial,
            edicion,
            insercion,
            eliminacion
        }

        public frmProveedores()
        {
            InitializeComponent();
            tblProveedores = BL.GetDataBLL.Proveedores();
            DataColumn[] primaryKey;
            primaryKey = new DataColumn[1];
            DataColumn razonSocial = tblProveedores.Columns["RazonSocialPRO"];
            primaryKey[0] = razonSocial;
            tblProveedores.PrimaryKey = primaryKey;
            BL.Utilitarios.AddEventosABM(grpCampos, ref btnGrabar, ref tblProveedores);
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            System.Drawing.Icon ico = Properties.Resources.icono_app;
            this.Icon = ico;
            this.ControlBox = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            bindingSource1.DataSource = tblProveedores;
            bindingNavigator1.BindingSource = bindingSource1;
            BL.Utilitarios.DataBindingsAdd(bindingSource1, grpCampos);
            gvwDatos.DataSource = bindingSource1;
            gvwDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvwDatos.Columns["IdProveedorPRO"].HeaderText = "Nº prov.";
            gvwDatos.Columns["RazonSocialPRO"].HeaderText = "Razon social";
            gvwDatos.Columns["DireccionPRO"].Visible = false;
            gvwDatos.Columns["CodigoPostalPRO"].Visible = false;
            gvwDatos.Columns["TelefonoPRO"].Visible = false;
            gvwDatos.Columns["ContactoPRO"].Visible = false;
            bindingSource1.Sort = "RazonSocialPRO";
            SetStateForm(FormState.inicial);  
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string parametros = txtParametros.Text;
            bindingSource1.Filter = "RazonSocialPRO LIKE '" + parametros + "*'";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bindingSource1.AddNew();
            DataTable tmp = tblProveedores.Copy();
            tmp.AcceptChanges();
            // utilizo tmp porque si hay filas borradas en tblColores el select max da error
            var maxValue = tmp.Rows.OfType<DataRow>().Select(row => row["IdProveedorPRO"]).Max();
            int clave = Convert.ToInt32(maxValue) + 1;
            bindingSource1.Position = bindingSource1.Count - 1;
            txtIdProveedorPRO.ReadOnly = false;
            txtIdProveedorPRO.Text = clave.ToString();
            txtIdProveedorPRO.ReadOnly = true;
            txtRazonSocialPRO.Focus();
            SetStateForm(FormState.insercion);  
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count == 0) return;
            SetStateForm(FormState.edicion);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count == 0) return;
            if (MessageBox.Show("¿Desea borrar este registro?", "Buscar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingSource1.RemoveCurrent();
                bindingSource1.EndEdit();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource1.EndEdit();
                bindingSource1.Position = 0;
                bindingSource1.Sort = "RazonSocialPRO";
                SetStateForm(FormState.inicial);
                bindingSource1.RemoveFilter();
            }
            catch (ConstraintException)
            {
                string mensaje = "No se puede agregar el proveedor '" + txtRazonSocialPRO.Text.ToUpper() + "' porque ya existe";
                MessageBox.Show(mensaje, "Trend", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRazonSocialPRO.Focus();
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

        private void frmProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            bindingSource1.EndEdit();
            if (tblProveedores.GetChanges() != null)
            {
                frmProgress progreso = new frmProgress(tblProveedores, "frmProveedores", "grabar");
                progreso.ShowDialog();
            }
            bindingSource1.RemoveFilter();
        }

        public void SetStateForm(FormState state)
        {

            if (state == FormState.inicial)
            {
                gvwDatos.Enabled = true;
                txtIdProveedorPRO.ReadOnly = true;
                txtIdProveedorPRO.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtRazonSocialPRO.ReadOnly = true;
                txtRazonSocialPRO.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtDireccionPRO.ReadOnly = true;
                txtDireccionPRO.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtCodigoPostalPRO.ReadOnly = true;
                txtCodigoPostalPRO.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtTelefonoPRO.ReadOnly = true;
                txtTelefonoPRO.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtContactoPRO.ReadOnly = true;
                txtContactoPRO.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
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
                txtRazonSocialPRO.ReadOnly = false;
                txtDireccionPRO.ReadOnly = false;
                txtCodigoPostalPRO.ReadOnly = false;
                txtTelefonoPRO.ReadOnly = false;
                txtContactoPRO.ReadOnly = false;
                txtRazonSocialPRO.Clear();
                txtDireccionPRO.Clear();
                txtCodigoPostalPRO.Clear();
                txtTelefonoPRO.Clear();
                txtContactoPRO.Clear();
                txtRazonSocialPRO.Focus();
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
                txtRazonSocialPRO.ReadOnly = false;
                txtDireccionPRO.ReadOnly = false;
                txtCodigoPostalPRO.ReadOnly = false;
                txtTelefonoPRO.ReadOnly = false;
                txtContactoPRO.ReadOnly = false;
                txtRazonSocialPRO.Focus();
                btnBuscar.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnBorrar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnSalir.Enabled = false;
            }
        }

        private void gvwDatos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

    }
}
