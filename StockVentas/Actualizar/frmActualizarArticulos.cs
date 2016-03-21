﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.IO;
using BL;

namespace StockVentas
{
    public partial class frmActualizarArticulos : Form
    {
        public frmActualizarArticulos()
        {
            InitializeComponent();
        }

        public static DataSet CrearDataset()
        {
            OleDbDataAdapter da = AdaptadorSELECT();
            DataSet dt = new DataSet();
            da.Fill(dt, "Articulos");
            return dt;
        }

        public static OleDbConnection GetConnectionAccess()
        {
            string connectionString;
            OleDbConnection objCon;
            connectionString = ConfigurationManager.ConnectionStrings["DBAccess"].ConnectionString;
            objCon = new OleDbConnection(connectionString);
            return objCon;
        }

        private static OleDbDataAdapter AdaptadorSELECT()
        {
            OleDbConnection Connection1 = GetConnectionAccess();
            OleDbDataAdapter OleDbDataAdapter1 = new OleDbDataAdapter();
            OleDbCommand OleDbSelectCommand1 = new OleDbCommand("SELECT * FROM Articulos", Connection1);
            OleDbDataAdapter1.SelectCommand = OleDbSelectCommand1;
            OleDbSelectCommand1.CommandType = CommandType.Text;
            return OleDbDataAdapter1;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataSet dt = new DataSet();
            string strFilePath = Application.StartupPath + "\\Datasets_xml\\";
            if (File.Exists(strFilePath + "Articulos.xml"))
            {
                dt.ReadXml(strFilePath + "Articulos.xml");
                dt.AcceptChanges();
            }

            DataView viewServer = new DataView(dt.Tables[0]);

            DataSet dtAccess = CrearDataset();
            DataView viewAccess = new DataView(dtAccess.Tables[0]);
            foreach (DataRowView rowAccess in viewAccess)
            {
                DataRowView rowServer = viewServer.AddNew();
                rowServer["IdArticuloART"] = rowAccess[0];
                rowServer["IdItemART"] = rowAccess[1];
                rowServer["IdColorART"] = rowAccess[2];
                rowServer["TalleART"] = rowAccess[3];
                rowServer["IdProveedorART"] = rowAccess[4];
                rowServer["DescripcionART"] = rowAccess[5];
                rowServer["DescripcionWebART"] = rowAccess[6];
                rowServer["PrecioCostoART"] = rowAccess[7];
                rowServer["PrecioPublicoART"] = rowAccess[8];
                rowServer["PrecioMayorART"] = rowAccess[9];
                rowServer["FechaART"] = rowAccess[10];
                rowServer["ImagenART"] = rowAccess[11];
                rowServer.EndEdit();
            }

            string formularioOrigen = "frmArticulos";
            string accionProgress = "grabar";
            frmProgress progreso = new frmProgress(dt, formularioOrigen, accionProgress);
            progreso.ShowDialog();

      //      BL.ArticulosBLL.GrabarDB(dt);
            Cursor.Current = Cursors.Arrow;
        }
    }
}
