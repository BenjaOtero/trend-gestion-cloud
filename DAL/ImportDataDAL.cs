using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public static class ImportDataDAL
    {

        public static string GetFechaImport()
        {
            MySqlConnection SqlConnection1;
            MySqlDataAdapter SqlDataAdapter1;
            MySqlCommand SqlSelectCommand1;
            SqlConnection1 = DALBase.GetConnection();
            SqlDataAdapter1 = new MySqlDataAdapter();
            SqlSelectCommand1 = new MySqlCommand("exportar_fondo_caja_Listar", SqlConnection1);
            SqlDataAdapter1.SelectCommand = SqlSelectCommand1;
            SqlSelectCommand1.CommandType = CommandType.StoredProcedure;
            DataTable tbl = new DataTable();
            SqlDataAdapter1.Fill(tbl);
            SqlConnection1.Close();
            string fecha = tbl.Rows[0][0].ToString();
            return fecha;
        }

        public static void BorrarMovimientos(string accion)
        {
            MySqlConnection SqlConnection1 = DALBase.GetConnection();
            SqlConnection1.Open();
            MySqlCommand SqlSelectCommand1 = new MySqlCommand("ClientesFallidas_BorrarByAccion", SqlConnection1);
            SqlSelectCommand1.Parameters.AddWithValue("p_accion", accion);
            SqlSelectCommand1.CommandType = CommandType.StoredProcedure;
            SqlSelectCommand1.ExecuteNonQuery();
            SqlConnection1.Close();
        }

        public static void InsertarMovimientos(string accion)
        {
            MySqlConnection SqlConnection1 = DALBase.GetConnection();
            SqlConnection1.Open();
            MySqlCommand SqlSelectCommand1 = new MySqlCommand("ClientesFallidas_BorrarByAccion", SqlConnection1);
            SqlSelectCommand1.Parameters.AddWithValue("p_accion", accion);
            SqlSelectCommand1.CommandType = CommandType.StoredProcedure;
            SqlSelectCommand1.ExecuteNonQuery();
            SqlConnection1.Close();
        }

    }
}
