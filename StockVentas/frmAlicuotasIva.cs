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
    public partial class frmAlicuotasIva : Form
    {
        private DataTable tblAlicuotasIva;
        string oldId = string.Empty;
        bool editar = false;

        public enum FormState
        {
            inicial,
            edicion,
            insercion,
            eliminacion
        }

        public frmAlicuotasIva()
        {
            InitializeComponent();
            tblAlicuotasIva = BL.GetDataBLL.AlicuotasIva();
            BL.Utilitarios.AddEventosABM(grpCampos, ref btnGrabar, ref tblAlicuotasIva);
            bindingSource1.BindingComplete += new BindingCompleteEventHandler(bindingSource1_BindingComplete);
            txtIdAlicuotaALI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(BL.Utilitarios.SoloNumeros);
            txtPorcentajeALI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(BL.Utilitarios.SoloNumerosConComa);            
        }

        private void frmAlicuotasIva_Load(object sender, EventArgs e)
        {
            System.Drawing.Icon ico = Properties.Resources.icono_app;
            this.Icon = ico;
            this.ControlBox = true;
            this.MaximizeBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            bindingSource1.DataSource = tblAlicuotasIva;
            bindingNavigator1.BindingSource = bindingSource1;
            BL.Utilitarios.DataBindingsAdd(bindingSource1, grpCampos);
            gvwDatos.DataSource = bindingSource1;
            gvwDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvwDatos.Columns["IdAlicuotaALI"].HeaderText = "ID";
            gvwDatos.Columns["PorcentajeALI"].HeaderText = "Porcentaje";
            bindingSource1.Sort = "IdAlicuotaALI";
            tblAlicuotasIva.ColumnChanged += new DataColumnChangeEventHandler(Column_Changed);
            SetStateForm(FormState.inicial);   
        }        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string parametros = txtParametros.Text;
            bindingSource1.Filter = "PorcentajeALI LIKE '" + parametros + "*'";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bindingSource1.AddNew();
            bindingSource1.Position = bindingSource1.Count - 1;
            SetStateForm(FormState.insercion);   
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count == 0) return;
            editar = true;
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
            if (tblAlicuotasIva.GetChanges() != null)
            {
                string idAlicuota;
                if (editar)
                {
                    if (string.IsNullOrEmpty(oldId)) oldId = txtIdAlicuotaALI.Text;
                    idAlicuota = txtIdAlicuotaALI.Text;
                }
                else
                {
                    oldId = txtIdAlicuotaALI.Text;
                    idAlicuota = txtIdAlicuotaALI.Text;
                }
                frmProgress progreso = new frmProgress(tblAlicuotasIva, "frmAlicuotasIva", "grabar", idAlicuota, oldId);
                progreso.ShowDialog();
            }
            bindingSource1.RemoveFilter();
            bindingSource1.Sort = "IdAlicuotaALI";
            editar = false;
            SetStateForm(FormState.inicial);
            }
            catch (ConstraintException ex)
            {
                bool b;
                if (b = ex.Message.ToString().Contains("IdAlicuotaALI"))
                {
                    string mensaje = "No se puede agregar el ID '" + txtIdAlicuotaALI.Text.ToUpper() + "' porque ya existe";
                    MessageBox.Show(mensaje, "Trend", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIdAlicuotaALI.Focus();
                }
                else
                {
                    string mensaje = "No se puede agregar el porcentaje '" + txtPorcentajeALI.Text.ToUpper() + "' porque ya existe";
                    MessageBox.Show(mensaje, "Trend", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPorcentajeALI.Focus();
                }                

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

        private void frmAlicuotasIva_FormClosing(object sender, FormClosingEventArgs e)
        {
            bindingSource1.EndEdit();
            if (tblAlicuotasIva.GetChanges() != null)
            {
                DataTable tbl = tblAlicuotasIva.GetChanges();
                frmProgress progreso = new frmProgress(tblAlicuotasIva, "frmAlicuotasIva", "grabar");
                progreso.ShowDialog();
            }
            bindingSource1.RemoveFilter();
        }

        private void bindingSource1_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            // Check if the data source has been updated, and that no error has occured.
            if (e.BindingCompleteContext ==
                BindingCompleteContext.DataSourceUpdate && e.Exception == null)

                // If not, end the current edit.
                e.Binding.BindingManagerBase.EndCurrentEdit();
        }

        private void Column_Changed(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                oldId = e.Row["IdAlicuotaALI", DataRowVersion.Original].ToString();
            }
            catch (VersionNotFoundException)
            {
                return;
            }
            
        }

        private void ValidarCampos(object sender, CancelEventArgs e)
        {
            if ((sender == (object)txtIdAlicuotaALI))
            {
                if (string.IsNullOrEmpty(txtIdAlicuotaALI.Text))
                {
                    this.errorProvider1.SetError(txtIdAlicuotaALI, "Debe escribir una alícuota.");
                    e.Cancel = true;
                }
            }
            if ((sender == (object)txtPorcentajeALI))
            {
                if (string.IsNullOrEmpty(txtPorcentajeALI.Text))
                {
                    this.errorProvider1.SetError(txtPorcentajeALI, "Debe escribir un porcentaje.");
                    e.Cancel = true;
                }
            }
        }

        private void CamposValidado(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void AddEventosValidacion()
        {
            foreach (Control ctl in grpCampos.Controls)
            {
                if (ctl is TextBox || ctl is MaskedTextBox || ctl is ComboBox)
                {
                    ctl.Validating += new System.ComponentModel.CancelEventHandler(this.ValidarCampos);
                    ctl.Validated += new System.EventHandler(this.CamposValidado);
                }
            }
        }

        private void DelEventosValidacion()
        {
            foreach (Control ctl in grpCampos.Controls)
            {
                if (ctl is TextBox || ctl is MaskedTextBox || ctl is ComboBox)
                {
                    ctl.Validating -= new System.ComponentModel.CancelEventHandler(this.ValidarCampos);
                    ctl.Validated -= new System.EventHandler(this.CamposValidado);
                }
            }
            this.errorProvider1.Clear();
        }

        public void SetStateForm(FormState state)
        {

            if (state == FormState.inicial)
            {
                gvwDatos.Enabled = true;
                txtPorcentajeALI.ReadOnly = true;
                txtPorcentajeALI.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                btnBuscar.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnBorrar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                btnSalir.Enabled = true;
                DelEventosValidacion();
                txtParametros.Focus();
            }

            if (state == FormState.insercion)
            {
                gvwDatos.Enabled = false;
                txtIdAlicuotaALI.ReadOnly = false;
                txtPorcentajeALI.ReadOnly = false;
                txtPorcentajeALI.Clear();
                txtIdAlicuotaALI.Focus();
                btnBuscar.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnBorrar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnSalir.Enabled = false;
                AddEventosValidacion();
            }

            if (state == FormState.edicion)
            {
                gvwDatos.Enabled = false;
                txtIdAlicuotaALI.ReadOnly = false;
                txtPorcentajeALI.ReadOnly = false;
                txtIdAlicuotaALI.Focus();
                btnBuscar.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnBorrar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnSalir.Enabled = false;
                AddEventosValidacion();
            }
        }

    }
}
