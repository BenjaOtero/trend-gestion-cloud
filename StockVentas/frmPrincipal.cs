using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using BL;
using System.Net;
using System.Xml;


namespace StockVentas
{
    public partial class frmPrincipal : Form
    {
        public frmProgress progreso;
        string origen, accion;
        string idRazonSocial;

        public frmPrincipal()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    client.BackColor = this.BackColor;
                    break;
                }
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            System.Drawing.Icon ico = Properties.Resources.icono_app;
            this.Icon = ico;
         //   alícuotasIVAToolStripMenuItem.Visible = false;
            //   condiciónIVAToolStripMenuItem.Visible = false;
            //   empleadosToolStripMenuItem.Visible = false;
            //  movimientosDeEmpleadosToolStripMenuItem.Visible = false;
            //    empleadosToolStripMenuItem2.Visible = false;
            //    actualizarServidorToolStripMenuItem.Visible = false;
            //     pruebasToolStripMenuItem.Visible = false;
            //     exportarDatosToolStripMenuItem.Visible = false;
            //     borradoMasivoArtículosToolStripMenuItem.Visible = false;                                    
        }

        private void alícuotasIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlicuotasIva newMDIChild = new frmAlicuotasIva();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            origen = "frmArticulos";
            accion = "cargar";
            frmArticulos newMDIChild = new frmArticulos();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void artículosItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosItems newMDIChild = new frmArticulosItems();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes newMDIChild = new frmClientes();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void coloresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmColores newMDIChild = new frmColores();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void condiciónIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCondicionIva newMDIChild = new frmCondicionIva();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void datosComercialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRazonSocial newMDIChild = new frmRazonSocial();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEmpleados newMDIChild = new frmEmpleados();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void tipoMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleadosMovTipo newMDIChild = new frmEmpleadosMovTipo();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void formasDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormasPago newMDIChild = new frmFormasPago();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void génerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGeneros newMDIChild = new frmGeneros();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void localesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocales newMDIChild = new frmLocales();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores newMDIChild = new frmProveedores();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockMov newMDIChild = new frmStockMov();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void StockEntradas_Click(object sender, EventArgs e)
        {
            frmStockEntradas newMDIChild = new frmStockEntradas();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void StockCompensaciones_Click(object sender, EventArgs e)
        {
            frmStockComp newMDIChild = new frmStockComp();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentas newMDIChild = new frmVentas();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void movimientosDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleadosMov newMDIChild = new frmEmpleadosMov();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void movimientosDeTesoreríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmTesoreriaMov
            //frmTesoreriaBinding
            frmTesoreriaMov newMDIChild = new frmTesoreriaMov();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void movimientosEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleadosMovConsInter newMDIChild = new frmEmpleadosMovConsInter();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void liquidaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            HaberesRpt newMDIChild = new HaberesRpt();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void fondoDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFondoCaja newMDIChild = new frmFondoCaja();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void stockDeArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockInter newMDIChild = new frmStockInter();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void movimientosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStockMovInter newMDIChild = new frmStockMovInter();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void compensacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStockCompInter newMDIChild = new frmStockCompInter();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void arqueoDeCajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmArqueoInter newMDIChild = new frmArqueoInter();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void ventasEnPesos_Click(object sender, EventArgs e)
        {
            frmVentasPesosInter newMDIChild = new frmVentasPesosInter();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void ventasDetalle_Click(object sender, EventArgs e)
        {
           frmVentasDetalleInter newMDIChild = new frmVentasDetalleInter();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void ventasHistoricas_Click(object sender, EventArgs e)
        {
            frmVentasHistoricasInter newMDIChild = new frmVentasHistoricasInter();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void fondosDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            origen = "frmFondoCajaCons";
            accion = "cargar";
            frmProgress newMDIChild = new frmProgress(origen, accion);
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void pedidos_Click(object sender, EventArgs e)
        {
            frmPedido newMDIChild = new frmPedido();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void actualizarServidorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        /*   frmActualizarStock newMDIChild = new frmActualizarStock();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();*/
        }

        private void backup_Click(object sender, EventArgs e)
        {
            Backup();
        }

        private void processBackupExited(object sender, System.EventArgs e)
        {
            if (File.Exists("c:\\Windows\\Temp\\backup.bat"))
            {
                File.Delete("c:\\Windows\\Temp\\backup.bat");
            }            
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("¿Realiza copia de seguridad de los datos?", "Trend", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Backup();
            Application.Exit();
        }

        private void pruebasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPruebas newMDIChild = new frmPruebas();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void Backup()
        {            
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "SQL (*.sql)|*.sql";
            fichero.FileName = "Backup";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                System.IO.StreamWriter sw = System.IO.File.CreateText("c:\\Windows\\Temp\\backup.bat"); // creo el archivo .bat
                sw.Close();
                StringBuilder sb = new StringBuilder();
                string path = Application.StartupPath;
                string unidad = path.Substring(0, 2);
                sb.AppendLine(unidad);
                sb.AppendLine(@"cd " + path + @"\Backup");
                //  sb.AppendLine(@"mysqldump --skip-comments -u ncsoftwa_re -p8953#AFjn -h ns21a.cyberneticos.com --opt ncsoftwa_re > " + fichero.FileName);
                sb.AppendLine(@"mysqldump --skip-comments -u benja -p8953#AFjn -h localhost --routines --opt ncsoftwa_re > " + fichero.FileName);              
                //mysqldump -u... -p... mydb t1 t2 t3 > mydb_tables.sql
                using (StreamWriter outfile = new StreamWriter("c:\\Windows\\Temp\\backup.bat", true)) // escribo el archivo .bat
                {
                    outfile.Write(sb.ToString());
                }
                Process process = new Process();
                process.StartInfo.FileName = "c:\\Windows\\Temp\\backup.bat";
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.EnableRaisingEvents = true;  // permite disparar el evento process_Exited
                process.Exited += new EventHandler(process_Exited);
                process.Start();
                process.WaitForExit();

            }
        }

        private void process_Exited(object sender, System.EventArgs e)
        {
            if (File.Exists("c:\\Windows\\Temp\\backup.bat")) File.Delete("c:\\Windows\\Temp\\backup.bat");
            Cursor = Cursors.Arrow;
        }

        private void exportarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DataTable tbl = BL.GetDataBLL.RazonSocial();
            idRazonSocial = tbl.Rows[0][0].ToString() + "_datos.sql.gz";
            ExportarDatos(idRazonSocial);
            Cursor = Cursors.Arrow;
        }

        private void ExportarDatos(string idRazonSocial)
        {
                Cursor = Cursors.WaitCursor;
                System.IO.StreamWriter sw = System.IO.File.CreateText("c:\\Windows\\Temp\\backup.bat"); // creo el archivo .bat
                sw.Close();
                StringBuilder sb = new StringBuilder();
                string path = Application.StartupPath;
                string unidad = path.Substring(0, 2);
                sb.AppendLine(unidad);
                sb.AppendLine(@"cd " + path + @"\Backup");
                sb.AppendLine(@"mysqldump --skip-comments -u ncsoftwa_re -p8953#AFjn -h localhost --opt ncsoftwa_re articulos clientes formaspago generos alicuotasiva razonsocial | gzip > c:\windows\temp\" + idRazonSocial);
                using (StreamWriter outfile = new StreamWriter("c:\\Windows\\Temp\\backup.bat", true)) // escribo el archivo .bat
                {
                    outfile.Write(sb.ToString());
                }
                Process process = new Process();
                process.StartInfo.FileName = "c:\\Windows\\Temp\\backup.bat";
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.EnableRaisingEvents = true;  // permite disparar el evento process_Exited
                process.Exited += new EventHandler(ExportarDatos_Exited);
                process.Start();
                process.WaitForExit();
        }

        private void ExportarDatos_Exited(object sender, System.EventArgs e)
        {
            UploadDatosPos(@"c:\windows\temp\" + idRazonSocial, idRazonSocial);
            if (File.Exists("c:\\Windows\\Temp\\backup.bat")) File.Delete("c:\\Windows\\Temp\\backup.bat");
            Cursor = Cursors.Arrow;
        }

        public static void UploadDatosPos(string nombreLocal, string nombreServidor)
        {
            string ftpServerIP;
            string ftpUserID;
            string ftpPassword;

            /*  ftpServerIP = "trendsistemas.com/datos";
              ftpUserID = "benja@trendsistemas.com";
              ftpPassword = "8953#AFjn";*/

            // FTP local
            ftpServerIP = "127.0.0.1:22";
            ftpUserID = "Benja";
            ftpPassword = "8953#AFjn";

            FileInfo fileInf = new FileInfo(nombreLocal);
            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + nombreServidor));

            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

            // By default KeepAlive is true, where the control connection is not closed
            // after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
            }
        }

        private void borradoMasivoArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosBorradoMasivo newMDIChild = new frmArticulosBorradoMasivo();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void empleadosToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void importarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BL.Utilitarios.HayInternet())
            {
                string ftpServerIP;
                string ftpUserID;
                string ftpPassword;

                /*  ftpServerIP = "trendsistemas.com/datos";
                  ftpUserID = "benja@trendsistemas.com";
                  ftpPassword = "8953#AFjn";*/

                // FTP local
                ftpServerIP = "127.0.0.1:22";
                ftpUserID = "Benja";
                ftpPassword = "8953#AFjn";

                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + ftpServerIP);
                ftpRequest.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                List<string> directories = new List<string>();

                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    directories.Add(line);
                    line = streamReader.ReadLine();
                }
                streamReader.Close();

                if (directories.Count() > 0)
                {
                    if (Directory.Exists(@"c:\windows\temp\datos")) Directory.Delete(@"c:\windows\temp\datos", true);
                    Directory.CreateDirectory(@"c:\windows\temp\datos");
                    DataTable tbl = BL.GetDataBLL.RazonSocial();
                    idRazonSocial = tbl.Rows[0][0].ToString() + "_";
                    using (WebClient ftpClient = new WebClient())
                    {
                        ftpClient.Credentials = new System.Net.NetworkCredential(ftpUserID, ftpPassword);

                        for (int i = 0; i <= directories.Count - 1; i++)
                        {
                            if (directories[i].Contains(idRazonSocial))
                            {
                                string path = "ftp://" + ftpServerIP + "/" + directories[i].ToString();
                                string trnsfrpth = @"c:\windows\temp\datos\" + directories[i].ToString();
                                ftpClient.DownloadFile(path, trnsfrpth);
                            }
                        }
                    }
                    string[] dirs = Directory.GetFiles(@"c:\windows\temp\datos", idRazonSocial + "*");
                }
                
            }
            else
                MessageBox.Show("Verifique la conexión a internet. No se importaron datos.", "Trend", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
