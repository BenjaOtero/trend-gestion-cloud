using System;
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
    public partial class frmActualizarVentasDetalle : Form
    {
        public frmActualizarVentasDetalle()
        {
            InitializeComponent();
        }

        public static DataSet CrearDataset()
        {
            OleDbDataAdapter da = AdaptadorSELECT();
            DataSet dt = new DataSet();
            da.Fill(dt, "VentasDetalle");
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
            OleDbCommand OleDbSelectCommand1 = new OleDbCommand("SELECT * FROM VentasDetalle", Connection1);
            OleDbDataAdapter1.SelectCommand = OleDbSelectCommand1;
            OleDbSelectCommand1.CommandType = CommandType.Text;
            return OleDbDataAdapter1;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DAL.VentasDetalleActualizarSrvDAL.CrearDataset();
            DataSet dt = new DataSet();
            string strFilePath = Application.StartupPath + "\\Datasets_xml\\";
            if (File.Exists(strFilePath + "VentasDetalle.xml"))
            {
                dt.ReadXml(strFilePath + "VentasDetalle.xml");
                dt.AcceptChanges();
            }

            DataView viewServer = new DataView(dt.Tables[0]);

            DataSet dtAccess = CrearDataset();
            DataView viewAccess = new DataView(dtAccess.Tables[0]);
            foreach (DataRowView rowAccess in viewAccess)
            {
                DataRowView rowServer = viewServer.AddNew();
                rowServer["IdDVEN"] = rowAccess[0];
                rowServer["IdVentaDVEN"] = rowAccess[1];
                rowServer["IdArticuloDVEN"] = rowAccess[2];
                rowServer["DescripcionDVEN"] = rowAccess[3];
                rowServer["CantidadDVEN"] = rowAccess[4];
                rowServer["PrecioPublicoDVEN"] = rowAccess[5];
                rowServer["PrecioCostoDVEN"] = rowAccess[6];
                rowServer["PrecioMayorDVEN"] = rowAccess[7];
                rowServer["IdFormaPagoDVEN"] = rowAccess[8];
                rowServer["NroCuponDVEN"] = rowAccess[9];
                rowServer["NroFacturaDVEN"] = rowAccess[10];
                rowServer["IdEmpleadoDVEN"] = rowAccess[11];
                rowServer["LiquidadoDVEN"] = rowAccess[12];
                rowServer["EsperaDVEN"] = rowAccess[13];
                rowServer["DevolucionDVEN"] = rowAccess[14];
                rowServer.EndEdit();
            }

            string formularioOrigen = "frmActualizarVentasDetalle";
            string accionProgress = "grabar";
            frmProgress progreso = new frmProgress(dt, formularioOrigen, accionProgress);
            progreso.ShowDialog();

      //      BL.ArticulosBLL.GrabarDB(dt);
            Cursor.Current = Cursors.Arrow;
        }
    }
}
