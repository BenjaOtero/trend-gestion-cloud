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
    public partial class frmArticulosItems : Form
    { 
        private DataTable tblArticulosItems;
        int clave;

        public enum FormState
        {
            inicial,
            edicion,
            insercion,
            eliminacion
        }

        public frmArticulosItems()
        {
            InitializeComponent();
            tblArticulosItems = BL.GetDataBLL.ArticulosItems();
            tblArticulosItems.PrimaryKey = new DataColumn[] { tblArticulosItems.Columns["IdItemITE"] };
            BL.Utilitarios.AddEventosABM(grpCampos, ref btnGrabar, ref tblArticulosItems);
        }

        private void frmArticulosItems_Load(object sender, EventArgs e)
        {
            this.Location = new Point(50, 50);
            System.Drawing.Icon ico = Properties.Resources.icono_app;
            this.Icon = ico;
            this.ControlBox = true;
            this.MaximizeBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            bindingSource1.DataSource = tblArticulosItems;
            bindingNavigator1.BindingSource = bindingSource1;
            BL.Utilitarios.DataBindingsAdd(bindingSource1, grpCampos);
            Binding bind = new Binding("Checked", bindingSource1, "ActivoWebITE", false, DataSourceUpdateMode.OnPropertyChanged);
            bind.Format += new ConvertEventHandler(binding_Format);
            bind.Parse += new ConvertEventHandler(binding_Parse);
            chkActivoWebITE.DataBindings.Add(bind);
            gvwDatos.DataSource = bindingSource1;
            gvwDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvwDatos.Columns["IdItemITE"].HeaderText = "Nº Item";
            gvwDatos.Columns["DescripcionITE"].HeaderText = "Descripción";
            gvwDatos.Columns["DescripcionWebITE"].Visible = false;
            gvwDatos.Columns["ActivoWebITE"].Visible = false;
            bindingSource1.Sort = "DescripcionITE";
            grpBotones.CausesValidation = false;
            btnCancelar.CausesValidation = false;
            SetStateForm(FormState.inicial);            
        }

        private void txtParametros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) btnBuscar.PerformClick();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string parametros = txtParametros.Text;
            bindingSource1.Filter = "DescripcionITE LIKE '" + parametros + "*'";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bindingSource1.AddNew();
            // tildo el checkbox para disparar el evento parse del objeto bind
            chkActivoWebITE.CheckState = CheckState.Checked;
            Random rand = new Random();
            clave = rand.Next(1, 999);
            bool existe = true;
            while (existe == true)
            {
              //  DataRow foundRow = tblArticulosItems.Rows.Find(clave);
                DataRow[] foundRow2 = tblArticulosItems.Select("IdItemITE =" + clave);
                if (foundRow2.Count() == 0)
                {
                    existe = false;
                }
                else
                {
                    clave = rand.Next(1, 999);
                }
            }
            bindingSource1.Position = bindingSource1.Count - 1;
            txtIdItemITE.ReadOnly = false;
            txtIdItemITE.Text = clave.ToString();            
            txtIdItemITE.ReadOnly = true;
            txtDescripcionITE.Focus();
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
            if (MessageBox.Show("¿Desea borrar este registro?", "Trend Gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                bindingSource1.Sort = "DescripcionITE";
                SetStateForm(FormState.inicial);
                bindingSource1.RemoveFilter(); 
            }
            catch (ConstraintException)
            {
                string mensaje = "No se puede agregar el ítem " + txtDescripcionITE.Text.ToUpper() + " porque ya existe.";
                MessageBox.Show(mensaje, "Trend", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcionITE.Focus();
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

        private void frmArticulosItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            bindingSource1.EndEdit();
            if (tblArticulosItems.GetChanges() != null)
            {
                frmProgress progreso = new frmProgress(tblArticulosItems, "frmArticulosItems", "grabar");
                progreso.ShowDialog();
            }
            bindingSource1.RemoveFilter();
        }        

        private void binding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "True")  e.Value = true;
            else e.Value = false;
        }

        private void binding_Parse(object sender, ConvertEventArgs e)
        {
           if ((bool)e.Value) e.Value = 1;
            else e.Value = 0;
        }

        private void ValidarCampos(object sender, CancelEventArgs e)
        {
            if ((sender == (object)txtDescripcionITE))
            {
                if (string.IsNullOrEmpty(txtDescripcionITE.Text))
                {
                    this.errorProvider1.SetError(txtDescripcionITE, "Debe escribir una descripcion.");
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
                txtIdItemITE.ReadOnly = true;
                txtDescripcionITE.ReadOnly = true;
                txtDescripcionWebITE.ReadOnly = true;
                chkActivoWebITE.Enabled = false;
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
                txtDescripcionITE.ReadOnly = false;
                txtDescripcionWebITE.ReadOnly = false;
                txtDescripcionWebITE.Clear();
                chkActivoWebITE.Enabled = true;
                txtDescripcionITE.Clear();
                txtDescripcionITE.Focus();
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
                txtDescripcionITE.ReadOnly = false;
                txtDescripcionWebITE.ReadOnly = false;
                chkActivoWebITE.Enabled = true;
                txtDescripcionITE.Focus();
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

        private void btnProbar_Click(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();

            Random rand = new Random();
            clave = rand.Next(1, 1000000000);
            txtDescripcionITE.Text = clave.ToString();
            btnGrabar.PerformClick();
        }

    }
}
