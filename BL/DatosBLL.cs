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
            List<string> directories = GetDirectoriesFTP();
            if (directories.Count() > 0)
            {
                DataTable tbl = BL.GetDataBLL.RazonSocial();
                string idRazonSocial = tbl.Rows[0][0].ToString() + "_";
                DescargarArchivos(directories, idRazonSocial);
                string[] archivos = Directory.GetFiles(@"c:\windows\temp\data_import", idRazonSocial + "*");
                foreach (string archivo in archivos)
                {
                    RestaurarDatos(archivo);
                    BL.DatosBLL.InsertarMovimientos();
                }
                // borro archivos en el servidor ftp
                FtpWebRequest ftpRequest;
                foreach (string archivo in archivos)
                {
                    Char delimitador = '\\';
                    String[] cadena = archivo.Split(delimitador);
                    string borrar = cadena[4];
                    ftpRequest = Utilitarios.FtpRequest(@"/datos/" + borrar);
                    ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                    FtpWebResponse respuesta = (FtpWebResponse)ftpRequest.GetResponse();
                }
            }  
        }

        public static List<string> GetDirectoriesFTP()
        {
            FtpWebRequest ftpRequest = Utilitarios.FtpRequest("/datos");
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
            return directories;
        }

        private static void DescargarArchivos(List<string> directories, string idRazonSocial)
        {
            if (Directory.Exists(@"c:\windows\temp\data_import")) Directory.Delete(@"c:\windows\temp\data_import", true);
            Directory.CreateDirectory(@"c:\windows\temp\data_import");
            //string connectionString = ConfigurationManager.ConnectionStrings["FtpLocal"].ConnectionString;
            string connectionString = ConfigurationManager.ConnectionStrings["Ftp"].ConnectionString;
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
                        if (!archivo.Contains("datos") && !archivo.Contains("locales") && !archivo.Contains("pcs") && !archivo.Contains("bck"))
                        {
                            string ftpPath = "ftp://" + ftpServerIP + "/" + archivo;
                            string localPath = @"c:\windows\temp\data_import\" + archivo;
                            ftpClient.DownloadFile(ftpPath, localPath);
                        }
                    }
                }
            }
        }

        private static void RestaurarDatos(string archivo)
        {
            System.IO.StreamWriter sw = System.IO.File.CreateText("c:\\Windows\\Temp\\data_import\\restore.bat"); // creo el archivo .bat
            sw.Close();
            StringBuilder sb = new StringBuilder();
            string path = Application.StartupPath;
            string unidad = path.Substring(0, 2);
            sb.AppendLine(unidad);
            sb.AppendLine(@"cd " + path + @"\Mysql");
            sb.AppendLine(@"gzip -d " + archivo);
            archivo = archivo.Substring(0, archivo.Length - 3);
            sb.AppendLine(@"mysql -u ncsoftwa_re -p8953#AFjn ncsoftwa_re < " + archivo);
            using (StreamWriter outfile = new StreamWriter("c:\\Windows\\Temp\\data_import\\restore.bat", true)) // escribo el archivo .bat
            {
                outfile.Write(sb.ToString());
            }
            Process process = new Process();
            process.StartInfo.FileName = "c:\\Windows\\Temp\\data_import\\restore.bat";
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.EnableRaisingEvents = true;  // permite disparar el evento process_Exited
            process.Exited += new EventHandler(RestaurarDatos_Exited);
            process.Start();
            process.WaitForExit();
        }

        private static void RestaurarDatos_Exited(object sender, System.EventArgs e)
        {
            if (File.Exists("c:\\Windows\\Temp\\data_import\\restore.bat")) File.Delete("c:\\Windows\\Temp\\data_import\\restore.bat");
            if (File.Exists("c:\\Windows\\Temp\\datos.sql")) File.Delete("c:\\Windows\\Temp\\datos.sql");
            if (File.Exists("c:\\Windows\\Temp\\datos.sql.gz")) File.Delete("c:\\Windows\\Temp\\datos.sql.gz");
        }

        // END GET DATOS POS

    }
}