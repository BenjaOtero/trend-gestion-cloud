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

        public static void GrabarDB(DataSet dt, ref int? codigoError)
        {
            try
            {
                DAL.ClientesDAL.GrabarDB(dt);
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1042) //no se pudo abrir la conexion por falta de internet
                {
                    dt.RejectChanges(); ;
                    codigoError = 1042;
                }
                else
                {
                    dt.RejectChanges();
                    codigoError = ex.Number;
                }
            }
        }

    }
}
