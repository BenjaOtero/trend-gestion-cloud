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
using MySql.Data;
using MySql.Data.MySqlClient;
using DAL;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace StockVentas
{
    public partial class frmActualizarStock : Form
    {
        string strFilePath;

        public frmActualizarStock()
        {
            InitializeComponent();
        }

        public static DataSet CrearDataset()
        {
            OleDbDataAdapter da = AdaptadorSELECT();
            DataSet dt = new DataSet();
            da.Fill(dt, "VentasHistoricas");
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

        public static MySqlConnection GetConnection()
        {
            string connectionString;
            MySqlConnection objCon;
            connectionString = ConfigurationManager.ConnectionStrings["DBMain"].ConnectionString;
            //   connectionString = ConfigurationManager.ConnectionStrings["DBMainLocal"].ConnectionString;
            objCon = new MySqlConnection(connectionString);
            return objCon;
        }

        private static OleDbDataAdapter AdaptadorSELECT()
        {
            OleDbConnection Connection1 = GetConnectionAccess();
            OleDbDataAdapter OleDbDataAdapter1 = new OleDbDataAdapter();
            OleDbCommand OleDbSelectCommand1 = new OleDbCommand("SELECT * FROM VentasHistoricas", Connection1);
            OleDbDataAdapter1.SelectCommand = OleDbSelectCommand1;
            OleDbSelectCommand1.CommandType = CommandType.Text;
            return OleDbDataAdapter1;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataSet dt = new DataSet();
            strFilePath = Application.StartupPath + "\\Datasets_xml\\";
            if (File.Exists(strFilePath + "VentasHistoricas.xml"))
            {
                dt.ReadXml(strFilePath + "VentasHistoricas.xml");
                DAL.VentasDAL.GrabarHistoricas(dt);
            }
            Cursor.Current = Cursors.Arrow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TcpListener server = null;
            try
            {
                int port = 13000;
                server = new TcpListener(IPAddress.Any, port);
                server.AllowNatTraversal(true);
                server.Start();
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Socket exception message: {0}", ex.Message);
                Console.WriteLine("Socket Error Code: {0}", ex.SocketErrorCode.ToString());
            }
            finally
            {
                server.Stop();
            }
            Console.WriteLine("\nHit enter to continue...");
            Console.ReadKey();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "SQL (*.sql)|*.sql";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(fichero.FileName);
            }
            System.IO.StreamWriter sw = System.IO.File.CreateText("n:\\backup.bat"); // creo el archivo .bat
            sw.Close();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("N:");
            sb.AppendLine("cd N:\\wamp\\bin\\mysql\\mysql5.5.8\\bin");
            sb.AppendLine("cls");
            sb.AppendLine("mysqldump -u ncsoftwa_re -p8953#AFjn -h dns26.cyberneticos.com ncsoftwa_re > " + fichero.FileName);
            using (StreamWriter outfile = new StreamWriter("n:\\backup.bat", true)) // escribo el archivo .bat
            {
                outfile.Write(sb.ToString());
            }
            Process process = new Process();
            process.StartInfo.FileName = "n:\\backup.bat";
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.EnableRaisingEvents = true;
            process.Exited += new EventHandler(processBackupExited);           
        }

        private void processBackupExited(object sender, System.EventArgs e)
        {
            MessageBox.Show("Backup terminado");
            File.Delete("n:\\backup.bat");
        }
    }
}
