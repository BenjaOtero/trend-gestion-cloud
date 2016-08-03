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
    public static class DatosDAL
    {
        public static void InsertarMovimientos()
        {
            MySqlConnection SqlConnection1 = DALBase.GetConnection();
            SqlConnection1.Open();
            MySqlCommand SqlSelectCommand1 = new MySqlCommand("Exportar_Insertar_Movimientos", SqlConnection1);
            SqlSelectCommand1.CommandType = CommandType.StoredProcedure;
            SqlSelectCommand1.ExecuteNonQuery();
            SqlConnection1.Close();
        }

        public static int RegistroRestaurado(string fecha, int pc)
        {
            int registroRestaurado = 0;
            MySqlConnection SqlConnection1 = DALBase.GetConnection();
            MySqlDataAdapter SqlDataAdapter1 = new MySqlDataAdapter();
            MySqlCommand SqlSelectCommand1 = new MySqlCommand("Exportar_Controlar_Restore", SqlConnection1);
            SqlSelectCommand1.Parameters.AddWithValue("p_fecha", fecha);
            SqlSelectCommand1.Parameters.AddWithValue("p_pc", pc);
            SqlDataAdapter1.SelectCommand = SqlSelectCommand1;
            SqlSelectCommand1.CommandType = CommandType.StoredProcedure;
            DataTable tbl = new DataTable();
            SqlDataAdapter1.Fill(tbl);
            SqlConnection1.Close();
            registroRestaurado = Convert.ToInt32(tbl.Rows[0][0].ToString());
            return registroRestaurado;
        }

    }
}
