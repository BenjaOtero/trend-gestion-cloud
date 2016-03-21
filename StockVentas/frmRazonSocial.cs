﻿using System;
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
    public partial class frmRazonSocial : Form
    {
        private DataTable tblRazonSocial;

        public enum FormState
        {
            inicial,
            edicion,
            insercion,
            eliminacion
        }

        public frmRazonSocial()
        {
            InitializeComponent();
            tblRazonSocial = BL.GetDataBLL.RazonSocial();
            BL.Utilitarios.AddEventosABM(grpCampos, ref btnGrabar, ref tblRazonSocial);
            bindingSource1.BindingComplete += new BindingCompleteEventHandler(bindingSource1_BindingComplete);
        }

        private void frmRazonSocial_Load(object sender, EventArgs e)
        {
            System.Drawing.Icon ico = Properties.Resources.icono_app;
            this.Icon = ico;
            this.ControlBox = true;
            this.MaximizeBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            bindingSource1.DataSource = tblRazonSocial;
            DataTable tblCondicionIva = BL.GetDataBLL.CondicionIva();
            cmbIdCondicionIvaRAZ.ValueMember = "IdCondicionIvaCIVA";
            cmbIdCondicionIvaRAZ.DisplayMember = "DescripcionCIVA";
            cmbIdCondicionIvaRAZ.DropDownStyle = ComboBoxStyle.DropDown;
            cmbIdCondicionIvaRAZ.DataSource = tblCondicionIva;
            BL.Utilitarios.DataBindingsAdd(bindingSource1, grpCampos);
            cmbIdCondicionIvaRAZ.KeyDown += new System.Windows.Forms.KeyEventHandler(BL.Utilitarios.EnterTab);            
            SetStateForm(FormState.inicial);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count == 0) return;
            SetStateForm(FormState.edicion);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource1.EndEdit();
                SetStateForm(FormState.inicial);
                //  bindingSource1.RemoveFilter();
            }
            catch (ConstraintException)
            {

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

        private void frmRazonSocial_FormClosing(object sender, FormClosingEventArgs e)
        {
            bindingSource1.EndEdit();
            if (tblRazonSocial.GetChanges() != null)
            {
                frmProgress progreso = new frmProgress(tblRazonSocial, "frmRazonSocial", "grabar");
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

        public void SetStateForm(FormState state)
        {

            if (state == FormState.inicial)
            {

                txtIdRazonSocialRAZ.Enabled = false;
                txtRazonSocialRAZ.Enabled = false;
                txtNombreFantasiaRAZ.Enabled = false;
                txtDomicilioRAZ.Enabled = false;
                txtLocalidadRAZ.Enabled = false;
                txtProvinciaRAZ.Enabled = false;
                cmbIdCondicionIvaRAZ.Enabled = false;
                txtCuitRAZ.Enabled = false;
                txtIngresosBrutosRAZ.Enabled = false;
                txtInicioActividadRAZ.Enabled = false;

                txtIdRazonSocialRAZ.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtRazonSocialRAZ.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtNombreFantasiaRAZ.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtDomicilioRAZ.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtLocalidadRAZ.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtProvinciaRAZ.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                cmbIdCondicionIvaRAZ.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtCuitRAZ.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtIngresosBrutosRAZ.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                txtInicioActividadRAZ.BackColor = System.Drawing.SystemColors.ActiveCaptionText;

                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                btnSalir.Enabled = true;
            }

            if (state == FormState.edicion)
            {
                txtIdRazonSocialRAZ.Enabled = false;
                txtRazonSocialRAZ.Enabled = true;
                txtNombreFantasiaRAZ.Enabled = true;
                txtDomicilioRAZ.Enabled = true;
                txtLocalidadRAZ.Enabled = true;
                txtProvinciaRAZ.Enabled = true;
                cmbIdCondicionIvaRAZ.Enabled = true;
                txtCuitRAZ.Enabled = true;
                txtIngresosBrutosRAZ.Enabled = true;
                txtInicioActividadRAZ.Enabled = true;
                btnEditar.Enabled = false;
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
