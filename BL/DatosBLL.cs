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

        public static void GetDataPOS()
        {
            List<string> directories = Utilitarios.GetDirectoriesFTP();
            if (directories.Count() > 0)
            {
                if (Directory.Exists(@"c:\windows\temp\datos")) Directory.Delete(@"c:\windows\temp\datos", true);
                Directory.CreateDirectory(@"c:\windows\temp\datos");
                DataTable tbl = BL.GetDataBLL.RazonSocial();
                string idRazonSocial = tbl.Rows[0][0].ToString() + "_";
                WebClient webClient = Utilitarios.ClienteWeb();
                foreach (string archivo in directories)
                {
                    if (archivo.Contains(idRazonSocial))
                    {
                        if (!archivo.Contains("datos") && !archivo.Contains("locales") && !archivo.Contains("pcs"))
                        {
                            string ftpPath = "ftp://" + ftpServerIP + "/" + archivo;
                            string localPath = @"c:\windows\temp\datos\" + archivo;
                            webClient.DownloadFile(ftpPath, localPath);
                        }
                    }
                }

                string[] dirs = Directory.GetFiles(@"c:\windows\temp\datos", idRazonSocial + "*");
                foreach (string archivo in dirs)
                {
                 //   RestaurarDatos(archivo);
                 //   BL.DatosBLL.InsertarMovimientos();
                }
               /* foreach (string archivo in directories)
                {
                    if (archivo.Contains(idRazonSocial))
                    {
                        if (!archivo.Contains("datos") || !archivo.Contains("locales") || !archivo.Contains("pcs"))
                        {
                            string ftpPath = "ftp://" + ftpServerIP + "/" + archivo;
                            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
                            request.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                            request.Method = WebRequestMethods.Ftp.DeleteFile;
                            FtpWebResponse respuesta = (FtpWebResponse)request.GetResponse();
                        }
                    }
                }*/
            }  
        }

    }
}