using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using DAL;
using System.Threading;

namespace BL
{
    public class ClientesBLL
    {
        private static object _sync = new object();

        public static DataSet GetClientes(sbyte frm)
        {
            DataSet dt = DAL.ClientesDAL.GetClientes(frm);
            return dt;
        }

        public static void GrabarDB(DataTable tbl, ref int? codigoError)
        {
            try
            {
                DAL.ClientesDAL.GrabarDB(tbl);
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1042) //no se pudo abrir la conexion por falta de internet
                {
                    tbl.RejectChanges(); ;
                    codigoError = 1042;
                }
                else
                {
                    tbl.RejectChanges();
                    codigoError = ex.Number;
                }
            }
        }

    }
}
