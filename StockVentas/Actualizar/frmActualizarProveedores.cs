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
    public partial class frmActualizarProveedores : Form
    {
        public frmActualizarProveedores()
        {
            InitializeComponent();
        }

        public static DataSet CrearDataset()
        {
            OleDbDataAdapter da = AdaptadorSELECT();
            DataSet dt = new DataSet();
            da.Fill(dt, "Proveedores");
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
            OleDbCommand OleDbSelectCommand1 = new OleDbCommand("SELECT * FROM Proveedores", Connection1);
            OleDbDataAdapter1.SelectCommand = OleDbSelectCommand1;
            OleDbSelectCommand1.CommandType = CommandType.Text;
            return OleDbDataAdapter1;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataSet dt = new DataSet();
            string strFilePath = Application.StartupPath + "\\Datasets_xml\\";
            if (File.Exists(strFilePath + "Proveedores.xml"))
            {
                dt.ReadXml(strFilePath + "Proveedores.xml");
                dt.AcceptChanges();
            }

            DataView viewServer = new DataView(dt.Tables[0]);

            DataSet dtAccess = CrearDataset();
            DataView viewAccess = new DataView(dtAccess.Tables[0]);
            foreach (DataRowView rowAccess in viewAccess)
            {
                DataRowView rowServer = viewServer.AddNew();
                rowServer["IdProveedorPRO"] = rowAccess[0];
                rowServer["RazonSocialPRO"] = rowAccess[1];
                rowServer["DireccionPRO"] = rowAccess[2];
                rowServer["CodigoPostalPRO"] = rowAccess[3];
                rowServer["TelefonoPRO"] = rowAccess[4];
                rowServer["ContactoPRO"] = rowAccess[5];
                rowServer.EndEdit();
            }
         //   BL.ProveedoresBLL.GrabarDB(dt);
            Cursor.Current = Cursors.Arrow;
        }
    }
}
