using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using DAL;
using Entities;
using System.Net;
using System.Configuration;
using System.Diagnostics;

namespace BL
{
    public class DatosBLL
    {

        public static string GetFechaImport()
        {
            string fecha = DAL.DatosDAL.GetFechaImport();
            return fecha;
        }

        public static void BorrarMovimientos(string fecha)
        {
            DAL.DatosDAL.BorrarMovimientos(fecha);
        }

        public static void InsertarMovimientos()
        {
            DAL.DatosDAL.InsertarMovimientos();
        }

        // GET DATOS POS

        public static void GetDataPOS()
        {
            List<string> directories = Utilitarios.GetDirectoriesFTP();
            if (directories.Count() > 0)
            {
                DataTable tbl = BL.GetDataBLL.RazonSocial();
                string idRazonSocial = tbl.Rows[0][0].ToString() + "_";
                DescargarArchivos(directories, idRazonSocial);
                string[] dirs = Directory.GetFiles(@"c:\windows\temp\datos", idRazonSocial + "*");
                foreach (string archivo in dirs)
                {
                    RestaurarDatos(archivo);
                    BL.DatosBLL.InsertarMovimientos();
                }
                BorrarArchivos(dirs);
            }  
        }

        public static void DescargarArchivos(List<string> directories, string idRazonSocial)
        {
            if (Directory.Exists(@"c:\windows\temp\datos")) Directory.Delete(@"c:\windows\temp\datos", true);
            Directory.CreateDirectory(@"c:\windows\temp\datos");
            string connectionString = ConfigurationManager.ConnectionStrings["FtpLocal"].ConnectionString;
            //   string connectionString = ConfigurationManager.ConnectionStrings["Ftp"].ConnectionString;
            Char delimiter = ';';
            String[] substrings = connectionString.Split(delimiter);
            string ftpServerIP = substrings[0] + "/datos";
            string ftpUserID = substrings[1];
            string ftpPassword = substrings[2];
            WebClient ftpClient = new WebClient();
            ftpClient.Credentials = new System.Net.NetworkCredential(ftpUserID, ftpPassword);
            using (ftpClient)
            {
                foreach (string archivo in directories)
                {
                    if (archivo.Contains(idRazonSocial))
                    {
                        if (!archivo.Contains("datos") && !archivo.Contains("locales") && !archivo.Contains("pcs"))
                        {
                            string ftpPath = "ftp://" + ftpServerIP + "/" + archivo;
                            string localPath = @"c:\windows\temp\datos\" + archivo;
                            ftpClient.DownloadFile(ftpPath, localPath);
                            ftpClient.DownloadFile(ftpPath, localPath);
                        }
                    }
                }
            }
        }

        private static void RestaurarDatos(string archivo)
        {
            System.IO.StreamWriter sw = System.IO.File.CreateText("c:\\Windows\\Temp\\datos\\restore.bat"); // creo el archivo .bat
            sw.Close();
            StringBuilder sb = new StringBuilder();
            string path = Application.StartupPath;
            string unidad = path.Substring(0, 2);
            sb.AppendLine(unidad);
            sb.AppendLine(@"cd " + path + @"\Mysql");
            sb.AppendLine(@"gzip -d " + archivo);
            archivo = archivo.Substring(0, archivo.Length - 3);
            sb.AppendLine(@"mysql -u ncsoftwa_re -p8953#AFjn ncsoftwa_re < " + archivo);
            using (StreamWriter outfile = new StreamWriter("c:\\Windows\\Temp\\datos\\restore.bat", true)) // escribo el archivo .bat
            {
                outfile.Write(sb.ToString());
            }
            Process process = new Process();
            process.StartInfo.FileName = "c:\\Windows\\Temp\\datos\\restore.bat";
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.EnableRaisingEvents = true;  // permite disparar el evento process_Exited
            process.Exited += new EventHandler(RestaurarDatos_Exited);
            process.Start();
            process.WaitForExit();
        }

        private static void RestaurarDatos_Exited(object sender, System.EventArgs e)
        {
            if (File.Exists("c:\\Windows\\Temp\\datos\\restore.bat")) File.Delete("c:\\Windows\\Temp\\datos\\restore.bat");
            if (File.Exists("c:\\Windows\\Temp\\datos.sql")) File.Delete("c:\\Windows\\Temp\\datos.sql");
            if (File.Exists("c:\\Windows\\Temp\\datos.sql.gz")) File.Delete("c:\\Windows\\Temp\\datos.sql.gz");
        }

        public static void BorrarArchivos(string[] dirs)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FtpLocal"].ConnectionString;
            //   string connectionString = ConfigurationManager.ConnectionStrings["Ftp"].ConnectionString;
            Char delimiter = ';';
            String[] substrings = connectionString.Split(delimiter);
            string ftpServerIP = substrings[0] + "/datos/";
            string ftpUserID = substrings[1];
            string ftpPassword = substrings[2];
            FtpWebRequest ftpRequest;            
            foreach (string archivo in dirs)
            {
                Char delimitador = '\\';
                String[] cadena = archivo.Split(delimitador);
                string borrar = cadena[4];
                ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + ftpServerIP + borrar);
                ftpRequest.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse respuesta = (FtpWebResponse)ftpRequest.GetResponse();
            }
        }

        // END GET DATOS POS

    }
}