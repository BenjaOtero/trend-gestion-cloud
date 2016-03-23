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

namespace BL
{
    public class ImportDataBLL
    {

        public static string GetFechaImport()
        {
            string fecha = DAL.ImportDataDAL.GetFechaImport();
            return fecha;
        }

        public static void BorrarMovimientos(string fecha)
        {
            DAL.ImportDataDAL.BorrarMovimientos(fecha);
        }

        public static void InsertarMovimientos()
        {
            DAL.ImportDataDAL.InsertarMovimientos();
        }

    }
}