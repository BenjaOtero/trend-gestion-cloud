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
    public partial class frmActualizarArticulosItems : Form
    {
        public frmActualizarArticulosItems()
        {
            InitializeComponent();
        }

        public static DataSet CrearDataset()
        {
            OleDbDataAdapter da = AdaptadorSELECT();
            DataSet dt = new DataSet();
            da.Fill(dt, "ArticulosItems");
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
            OleDbCommand OleDbSelectCommand1 = new OleDbCommand("SELECT * FROM ArticulosItems", Connection1);
            OleDbDataAdapter1.SelectCommand = OleDbSelectCommand1;
            OleDbSelectCommand1.CommandType = CommandType.Text;
            return OleDbDataAdapter1;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataSet dt = new DataSet();
            string strFilePath = Application.StartupPath + "\\Datasets_xml\\";
            if (File.Exists(strFilePath + "ArticulosItems.xml"))
            {
                dt.ReadXml(strFilePath + "ArticulosItems.xml");
                dt.AcceptChanges();
            }

            DataView viewServer = new DataView(dt.Tables[0]);

            DataSet dtAccess = CrearDataset();
            DataView viewAccess = new DataView(dtAccess.Tables[0]);
            foreach (DataRowView rowAccess in viewAccess)
            {
                DataRowView rowServer = viewServer.AddNew();
                rowServer["IdItemITE"] = rowAccess[0];
                rowServer["DescripcionITE"] = rowAccess[1];
                rowServer["DescripcionWebITE"] = string.Empty;
                rowServer["ActivoWebITE"] = 0;
                rowServer.EndEdit();
            }

            string formularioOrigen = "frmArticulosItems";
            string accionProgress = "grabar";
            frmProgress progreso = new frmProgress(dt, formularioOrigen, accionProgress);
            progreso.ShowDialog();

      //      BL.ArticulosBLL.GrabarDB(dt);
            Cursor.Current = Cursors.Arrow;
        }
    }
}
