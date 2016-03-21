﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ClientesDAL
    {

        public static DataSet GetClientes(sbyte frm)
        {
            MySqlConnection SqlConnection1 = DALBase.GetConnection();
            MySqlDataAdapter SqlDataAdapter1 = new MySqlDataAdapter();
            MySqlCommand SqlSelectCommand1 = new MySqlCommand("Clientes_Listar", SqlConnection1);
            SqlSelectCommand1.Parameters.AddWithValue("p_frm", frm);
            SqlDataAdapter1.SelectCommand = SqlSelectCommand1;
            SqlSelectCommand1.CommandType = CommandType.StoredProcedure;
            DataSet dt = new DataSet();
            SqlDataAdapter1.Fill(dt, "Clientes");
            if (!dt.Tables[0].Constraints.Contains("correoConstraint"))
            {
                UniqueConstraint uniqueConstraint = new UniqueConstraint("correoConstraint", dt.Tables[0].Columns["CorreoCLI"]);
                //   dt.Tables[0].Constraints.Add(uniqueConstraint);
            }
            SqlConnection1.Close();
            return dt;
        }

        public static void GrabarDB(DataSet dt)
        {
            MySqlConnection SqlConnection1;
            SqlConnection1 = DALBase.GetConnection();
            MySqlDataAdapter da = AdaptadorABM(SqlConnection1);
            da.Update(dt, "Clientes");
            SqlConnection1.Close();
        }

        private static MySqlDataAdapter AdaptadorABM(MySqlConnection SqlConnection1)
        {
            MySqlCommand SqlInsertCommand1;
            MySqlCommand SqlUpdateCommand1;
            MySqlCommand SqlDeleteCommand1;
            MySqlDataAdapter SqlDataAdapter1 = new MySqlDataAdapter();
            SqlInsertCommand1 = new MySqlCommand("Clientes_Insertar", SqlConnection1);
            SqlUpdateCommand1 = new MySqlCommand("Clientes_Actualizar", SqlConnection1);
            SqlDeleteCommand1 = new MySqlCommand("Clientes_Borrar", SqlConnection1);
            SqlDataAdapter1.DeleteCommand = SqlDeleteCommand1;
            SqlDataAdapter1.InsertCommand = SqlInsertCommand1;
            SqlDataAdapter1.UpdateCommand = SqlUpdateCommand1;


            // IMPLEMENTACIÓN DE LA ORDEN UPDATE
            SqlUpdateCommand1.Parameters.Add("p_id", MySqlDbType.Int32, 11, "IdClienteCLI");
            SqlUpdateCommand1.Parameters.Add("p_razon", MySqlDbType.VarChar, 50, "RazonSocialCLI");
            SqlUpdateCommand1.Parameters.Add("p_nombre", MySqlDbType.VarChar, 50, "NombreCLI");
            SqlUpdateCommand1.Parameters.Add("p_apellido", MySqlDbType.VarChar, 50, "ApellidoCLI");
            SqlUpdateCommand1.Parameters.Add("p_cuit", MySqlDbType.VarChar, 50, "CUIT");
            SqlUpdateCommand1.Parameters.Add("p_condicion", MySqlDbType.VarChar, 50, "CondicionIvaCLI");
            SqlUpdateCommand1.Parameters.Add("p_direccion", MySqlDbType.VarChar, 50, "DireccionCLI");
            SqlUpdateCommand1.Parameters.Add("p_localidad", MySqlDbType.VarChar, 50, "LocalidadCLI");
            SqlUpdateCommand1.Parameters.Add("p_provincia", MySqlDbType.VarChar, 50, "ProvinciaCLI");
            SqlUpdateCommand1.Parameters.Add("p_transporte", MySqlDbType.VarChar, 50, "TransporteCLI");
            SqlUpdateCommand1.Parameters.Add("p_contacto", MySqlDbType.VarChar, 50, "ContactoCLI");
            SqlUpdateCommand1.Parameters.Add("p_telefono", MySqlDbType.VarChar, 50, "TelefonoCLI");
            SqlUpdateCommand1.Parameters.Add("p_movil", MySqlDbType.VarChar, 50, "MovilCLI");
            SqlUpdateCommand1.Parameters.Add("p_correo", MySqlDbType.VarChar, 50, "CorreoCLI");
            SqlUpdateCommand1.Parameters.Add("p_fecha", MySqlDbType.Date, 50, "FechaNacCLI");
            SqlUpdateCommand1.CommandType = CommandType.StoredProcedure;

            // IMPLEMENTACIÓN DE LA ORDEN INSERT
            SqlInsertCommand1.Parameters.Add("p_id", MySqlDbType.Int32, 11, "IdClienteCLI");
            SqlInsertCommand1.Parameters.Add("p_razon", MySqlDbType.VarChar, 50, "RazonSocialCLI");
            SqlInsertCommand1.Parameters.Add("p_nombre", MySqlDbType.VarChar, 50, "NombreCLI");
            SqlInsertCommand1.Parameters.Add("p_apellido", MySqlDbType.VarChar, 50, "ApellidoCLI");
            SqlInsertCommand1.Parameters.Add("p_cuit", MySqlDbType.VarChar, 50, "CUIT");
            SqlInsertCommand1.Parameters.Add("p_condicion", MySqlDbType.VarChar, 50, "CondicionIvaCLI");
            SqlInsertCommand1.Parameters.Add("p_direccion", MySqlDbType.VarChar, 50, "DireccionCLI");
            SqlInsertCommand1.Parameters.Add("p_localidad", MySqlDbType.VarChar, 50, "LocalidadCLI");
            SqlInsertCommand1.Parameters.Add("p_provincia", MySqlDbType.VarChar, 50, "ProvinciaCLI");
            SqlInsertCommand1.Parameters.Add("p_transporte", MySqlDbType.VarChar, 50, "TransporteCLI");
            SqlInsertCommand1.Parameters.Add("p_contacto", MySqlDbType.VarChar, 50, "ContactoCLI");
            SqlInsertCommand1.Parameters.Add("p_telefono", MySqlDbType.VarChar, 50, "TelefonoCLI");
            SqlInsertCommand1.Parameters.Add("p_movil", MySqlDbType.VarChar, 50, "MovilCLI");
            SqlInsertCommand1.Parameters.Add("p_correo", MySqlDbType.VarChar, 50, "CorreoCLI");
            SqlInsertCommand1.Parameters.Add("p_fecha", MySqlDbType.Date, 50, "FechaNacCLI");
            SqlInsertCommand1.CommandType = CommandType.StoredProcedure;

            // IMPLEMENTACIÓN DE LA ORDEN DELETE
            SqlDeleteCommand1.Parameters.Add("p_id", MySqlDbType.Int32, 11, "IdClienteCLI");
            SqlDeleteCommand1.CommandType = CommandType.StoredProcedure;
            return SqlDataAdapter1;
        }

    }

}
