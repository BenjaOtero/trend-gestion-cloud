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
            SqlSelectCommand1 = new MySqlCommand("Exportar_Fondo_Caja_Listar", SqlConnection1);
            SqlDataAdapter1.SelectCommand = SqlSelectCommand1;
            SqlSelectCommand1.CommandType = CommandType.StoredProcedure;
            DataTable tbl = new DataTable();
            SqlDataAdapter1.Fill(tbl);
            SqlConnection1.Close();
            DateTime fecha = Convert.ToDateTime(tbl.Rows[0][0].ToString());
            string strFecha = fecha.ToString("yyyy-MM-dd");
            return strFecha;
        }

        public static void BorrarMovimientos(string fecha)
        {
            MySqlConnection SqlConnection1 = DALBase.GetConnection();
            SqlConnection1.Open();
            MySqlCommand SqlSelectCommand1 = new MySqlCommand("Exportar_Borrar_Movimientos", SqlConnection1);
            SqlSelectCommand1.Parameters.AddWithValue("p_fecha", fecha);
            SqlSelectCommand1.CommandType = CommandType.StoredProcedure;
            SqlSelectCommand1.ExecuteNonQuery();
            SqlConnection1.Close();
        }

        public static void InsertarMovimientos()
        {
            MySqlConnection SqlConnection1 = DALBase.GetConnection();
            SqlConnection1.Open();
            MySqlCommand SqlSelectCommand1 = new MySqlCommand("Exportar_Insertar_Movimientos", SqlConnection1);
            SqlSelectCommand1.CommandType = CommandType.StoredProcedure;
            SqlSelectCommand1.ExecuteNonQuery();
            SqlConnection1.Close();
        }

    }
}
