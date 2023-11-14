using System;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class CD_Connection
    {
        static string server = "MSI\\SQLEXPRESS";
        private SqlConnection conexion = new SqlConnection("Server=" + server + "; Database=POE_DB; Integrated Security=true");

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            
            return conexion;
        }
        
    }
}