using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;
using System.Configuration;
using BL;

namespace StockVentas
{

    public partial class frmInicio : Form
    {
        BackgroundWorker bckIniciarComponetes;
        BackgroundWorker bckServicioBckp;
        bool existeServicio;
        Label label1;
        public static DataSet ds;
        public static DataTable tblArticulos;
        public static DataTable tblArticulosCons;

        public frmInicio()
        {
            InitializeComponent();
            System.Drawing.Icon ico = Properties.Resources.icono_app;
            this.Icon = ico;
            Configuration cm = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection cs = cm.GetSection("connectionStrings");
            if (cs != null)
            {
                if (!cs.SectionInformation.IsProtected)
                {
                    cs.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                    cs.SectionInformation.ForceSave = true;
                    cm.Save(ConfigurationSaveMode.Full);
                }
            }
        }

        private void frmInicio_Shown(object sender, EventArgs e)
        {
            this.Visible = false;
            Control.CheckForIllegalCrossThreadCalls = false; // permite asignar un valor a label1.text en un subproceso diferente al principal
            label1 = new Label();            
            label1.Location = new System.Drawing.Point(28, 190);
            label1.AutoSize = true;
            Controls.Add(label1);
            string cs = ConnectionStringManager.GetFirstConnectionString();
          //  string db = ConnectionStringManager.GetDatabaseName();
            if (cs == "nuevo_cliente")
            {
                label1.Text = "Iniciando Trend Gestión por primera vez. . .";
                frmGetDatosCliente frmDatos = new frmGetDatosCliente();
                frmDatos.ShowDialog();
            }
            else
            {
                this.Visible = true;
                label1.Text = "Comprobando conexión de red. . .";
                bckIniciarComponetes = new BackgroundWorker();
                bckIniciarComponetes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckIniciarComponetes_DoWork);
                bckIniciarComponetes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckIniciarComponetes_RunWorkerCompleted);
                bckIniciarComponetes.RunWorkerAsync();
            }
        }

        private void bckIniciarComponetes_DoWork(object sender, DoWorkEventArgs e)
        {
            if (BL.Utilitarios.HayInternet())
            {
                label1.Text = "Obteniendo datos del servidor . . .";
                try
                {
                    ds = BL.GetDataBLL.GetData();
                }
                catch (MySqlException ex)
                {
                    int codigoError = ex.Number;
                    if (codigoError == 1042) //Unable to connect to any of the specified MySQL hosts.
                    {
                        this.Invoke((Action)delegate
                        {
                            this.Visible = false;
                            MessageBox.Show("No se pudo establecer la conexión con el servidor (verifique la conexión a internet).","Trend Gestión",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        });
                    }
                    if (codigoError == 0) // Procedure or function cannot be found in database 
                    {
                        this.Invoke((Action)delegate
                        {
                            this.Visible = false;
                            MessageBox.Show("Ocurrió un error al ejecutar la consulta MySQL (consulte al administrador del sistema).", "Trend Gestión",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        });
                    }
                }
                catch (System.TimeoutException)
                {
                    this.Invoke((Action)delegate
                    {
                        this.Visible = false;
                        MessageBox.Show("El tiempo de conexión con el servidor ha expirado. Intente nuevamente.", "Trend Gestión",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    });
                }
                catch(Exception)
                {
                    this.Invoke((Action)delegate
                    {
                        this.Visible = false;
                        MessageBox.Show("Se produjo un error inesperado. Consulte al administrador del sistema.", "Trend Gestión",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    });
                }
                Mantenimiento();
            }
            else
            {
                if (this.InvokeRequired) //si da true es porque estoy en un subproceso distinto al hilo principal
                {
                    string mensaje = "No se puede iniciar la aplicación sin internet.";
                    //invoca al hilo principal através de un delegado
                    this.Invoke((Action)delegate
                    {
                        MessageBox.Show(this, mensaje, "Trend Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    });
                }
            }
        }

        private void bckIniciarComponetes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Visible = false;
            frmPrincipal principal = new frmPrincipal();
            principal.Show();
            bckServicioBckp = new BackgroundWorker();
            bckServicioBckp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckServicioBckp_DoWork);
        //    bckServicioBckp.RunWorkerAsync();
        }

        private void bckServicioBckp_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!BL.Utilitarios.ExisteServicio("AVGzh"))
            {
                string path = Application.StartupPath;
                System.IO.StreamWriter sw = System.IO.File.CreateText(path + @"\Backup\servicio.bat"); // creo el archivo .bat
                sw.Close();
                StringBuilder sb = new StringBuilder();
                string unidad = path.Substring(0, 2);
                sb.AppendLine(unidad);
                sb.AppendLine(@"cd " + path + @"\Backup");
                sb.AppendLine("InstallUtil.exe Backup.exe");
             //   sb.AppendLine("PAUSE");
                using (StreamWriter outfile = new StreamWriter(path + @"\Backup\servicio.bat", true)) // escribo el archivo .bat
                {
                    outfile.Write(sb.ToString());
                }
                Process process = new Process();
                process.StartInfo.FileName = path + @"\Backup\servicio.bat";
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.EnableRaisingEvents = true;  // permite disparar el evento process_Exited
                process.Exited += new EventHandler(process_Exited);
                process.Start();
            }
        }

        private void process_Exited(object sender, System.EventArgs e)
        {
            if (File.Exists("c:\\Windows\\Temp\\backup.bat"))
            {
                File.Delete("c:\\Windows\\Temp\\backup.bat");
            }
        }

        private bool ExisteBD()
        {
            existeServicio = false;
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(ConnectionStringManager.GetFirstConnectionString());
            return existeServicio;
        }

        private void Mantenimiento()
        {
            try
            {
                BL.MantenimientoBLL.Mantenimiento();
                BL.VentasBLL.VentasHistoricasMantener();
            }
            catch (Exception)
            { 
            }
        }

        private void frmInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  BL.Utilitarios.StartService("AVGzh");
        }

        private bool ExisteServicioMySQL()
        {
            existeServicio = false;
            ServiceController[] scServices;
            scServices = ServiceController.GetServices();
            foreach (ServiceController scTemp in scServices)
            {
                if (scTemp.ServiceName == "MySQL")
                {
                    existeServicio = true;
                    continue;
                }
            }
            return existeServicio;
        }

        private void ConfigurarMySQL()
        {
            System.IO.StreamWriter sw = System.IO.File.CreateText("c:\\Windows\\Temp\\config_mysql.bat"); // creo el archivo .bat
            sw.Close();
            string programFiles = "C:\\Program files";
            if (Directory.Exists(programFiles))
            {
                programFiles = programFiles.Substring(3, programFiles.Length - 3);
            }
            else
            {
                programFiles = "Archivos de programa";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("C:");
            string configMysql = "cd " + "\"C:\\" + programFiles + "\\MySQL\\MySQL Server 5.5\\bin\"";
            sb.AppendLine(configMysql);
            configMysql = "mysqlinstanceconfig.exe -i -q ServiceName=MySQL root Password=8953#AFjn ServerType=DEVELOPER DatabaseType=INODB Port=myport Charset=utf8";
            sb.AppendLine(configMysql);
            string rutaDB = Application.StartupPath.ToString() + @"\MySql\ncsoftwa_re.sql";
            string restaurarDB = "mysql.exe -u root < \"" + rutaDB + "\"";
            sb.AppendLine(restaurarDB);
            string usuario = "mysql.exe -u root -e \"GRANT ALL ON *.* TO 'ncsoftwa_re'@'%' IDENTIFIED BY '8953#AFjn' WITH GRANT OPTION; FLUSH PRIVILEGES;\"";
            sb.AppendLine(usuario);
            using (StreamWriter outfile = new StreamWriter("c:\\Windows\\Temp\\config_mysql.bat", true)) // escribo en el archivo .bat
            {
                outfile.Write(sb.ToString());
            }
            Process process = new Process();
            process.StartInfo.FileName = "c:\\Windows\\Temp\\config_mysql.bat";
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.EnableRaisingEvents = true;
            process.WaitForExit();
            StringBuilder sb_myIni = new StringBuilder();
            sb_myIni.AppendLine("");
            sb_myIni.AppendLine("[mysqld]");
            sb_myIni.AppendLine("lower_case_table_names = 0");
            using (StreamWriter file = new StreamWriter("C:\\" + programFiles + "\\MySQL\\MySQL Server 5.5\\my.ini", true))
            {
                file.Write(sb_myIni.ToString());
            }
        }

    }

}
