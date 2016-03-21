using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
using System.Data.Objects.DataClasses;

namespace StockVentas
{
    public partial class frmColores : Form
    {
        private DataTable tblColores;

        public enum FormState
        {
            inicial,
            edicion,
            insercion,
            eliminacion
        }

        public frmColores()
        {
            InitializeComponent();
            tblColores = BL.GetDataBLL.Colores();
            BL.Utilitarios.AddEventosABM(grpCampos, ref btnGrabar, ref tblColores);
        }

        private void BindingSource_Load(object sender, EventArgs e)
        {
            System.Drawing.Icon ico = Properties.Resources.icono_app;
            this.Icon = ico;
            this.ControlBox = true;
            this.MaximizeBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            bindingSource1.DataSource = tblColores;
            bindingNavigator1.BindingSource = bindingSource1;
            BL.Utilitarios.DataBindingsAdd(bindingSource1, grpCampos);
            gvwDatos.DataSource = bindingSource1;
            gvwDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvwDatos.Columns["HexCOL"].Visible = false;
            gvwDatos.Columns["IdColorCOL"].HeaderText = "Nº color";
            gvwDatos.Columns["DescripcionCOL"].HeaderText = "Descripción";
            bindingSource1.Sort = "DescripcionCOL";
            SetStateForm(FormState.inicial);   
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string parametros = txtParametros.Text;
            bindingSource1.Filter = "DescripcionCOL LIKE '" + parametros + "*'";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bindingSource1.AddNew();
            DataTable tmp = tblColores.Copy();
            tmp.AcceptChanges();
            // utilizo tmp porque si hay filas borradas en tblColores el select max da error
            var maxValue = tmp.Rows.OfType<DataRow>().Select(row => row["IdColorCOL"]).Max();
            int clave = Convert.ToInt32(maxValue) + 1;
            bindingSource1.Position = bindingSource1.Count - 1;
            txtIdColorCOL.ReadOnly = false;
            txtIdColorCOL.Text = clave.ToString();
            txtIdColorCOL.ReadOnly = true;
            txtDescripcionCOL.Focus();
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
            SetStateForm(FormState.inicial); 
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource1.EndEdit();
                bindingSource1.Position = 0;
                bindingSource1.Sort = "DescripcionCOL";
                SetStateForm(FormState.inicial);
                bindingSource1.RemoveFilter();
            }
            catch (ConstraintException)
            {
                string mensaje = "No se puede agregar el color '" + txtDescripcionCOL.Text.ToUpper() + "' porque ya existe";
                MessageBox.Show(mensaje, "Trend", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcionCOL.Focus();
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

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                string color = System.Drawing.ColorTranslator.ToHtml(MyDialog.Color);
                txtHexCOL.Text = color;
            }
        }

        private void frmBindingSource_FormClosing(object sender, FormClosingEventArgs e)
        {
            bindingSource1.EndEdit();
            if (tblColores.GetChanges() != null)
            {
                frmProgress progreso = new frmProgress(tblColores, "frmColores", "grabar");
                progreso.ShowDialog();
            }
            bindingSource1.RemoveFilter();
        }

        public void SetStateForm(FormState state)
        {
            if (state == FormState.inicial)
            {
                gvwDatos.Enabled = true;
                txtIdColorCOL.ReadOnly = true;
                txtIdColorCOL.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtDescripcionCOL.ReadOnly = true;
                txtDescripcionCOL.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtHexCOL.ReadOnly = true;
                txtHexCOL.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                btnBuscar.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnBorrar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                btnColor.Enabled = false;
                btnSalir.Enabled = true;
                txtParametros.Focus();
            }
            if (state == FormState.insercion)
            {              
                txtDescripcionCOL.ReadOnly = false;
                txtHexCOL.ReadOnly = false;
                txtDescripcionCOL.Clear();
                txtDescripcionCOL.Focus();
                txtHexCOL.Clear();
                btnBuscar.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnBorrar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnColor.Enabled = true;
                btnSalir.Enabled = false;
            }
            if (state == FormState.edicion)
            {
                gvwDatos.Enabled = false;
                txtDescripcionCOL.ReadOnly = false;
                txtHexCOL.ReadOnly = false;
                txtDescripcionCOL.Focus();
                btnBuscar.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnBorrar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnColor.Enabled = true;
                btnSalir.Enabled = false;
            }
        }

    }
}
