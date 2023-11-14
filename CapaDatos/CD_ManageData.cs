using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_ManageData
    {
        private CD_Connection conn = new CD_Connection();

        public DataTable getDataAlummo()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter;
            // abro conexion
            cmd.Connection = conn.AbrirConexion();
            // establezco la sentencia SQL a ejecutar
            cmd.CommandText = "SELECT * FROM TB_ALUMNO";
            // ejecuto y asigno al adaptador
            adapter = new SqlDataAdapter(cmd);
            // asignar los resultados al datatable
            adapter.Fill(dt);
            return dt;

        }

        public DataTable getListaProvincias()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter;
            // abro conexion
            cmd.Connection = conn.AbrirConexion();
            // establezco la sentencia SQL a ejecutar
            cmd.CommandText = "SELECT * FROM TB_PROVINCIA";
            // ejecuto y asigno al adaptador
            adapter = new SqlDataAdapter(cmd);
            // asignar los resultados al datatable
            adapter.Fill(dt);
            return dt;
        }

        public bool InsertarProvincia(string nombre_provincia, int poblacion, int extension)
        {
            string v_sql = "insert into TB_PROVINCIA (nombre_provincia, extension, poblacion, estado) values('" + nombre_provincia + "', " + extension + ", " + poblacion + ", 'A')";
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= conn.AbrirConexion();
            cmd.CommandText = v_sql;
            cmd.ExecuteNonQuery();
            conn.CerrarConexion();
            
            return true;
        }

        public bool ActualizarProvincia(int id_provincia, string nombre_provincia, int poblacion, int extension)
        {
            string v_sql = "update TB_PROVINCIA set nombre_provincia ='" + nombre_provincia + "', poblacion = " + poblacion + " , extension = " + extension + " where id_provincia = " + id_provincia + ";";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn.AbrirConexion();
            cmd.CommandText = v_sql;
            cmd.ExecuteNonQuery();
            conn.CerrarConexion();

            return true;
        }

        public bool EliminarProvincia(int id_provincia)
        {
            string v_sql = "update TB_PROVINCIA set estado = 'I' where id_provincia = " + id_provincia + ";";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn.AbrirConexion();
            cmd.CommandText = v_sql;
            cmd.ExecuteNonQuery();
            conn.CerrarConexion();

            return true;
        }
        
        //Trabaja con Store Procedure
        public DataTable ObtenerProvincias()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter;
            // abro conexion
            cmd.Connection = conn.AbrirConexion();
            // establezco el tipo de comamdo a store procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "OBTENER_PROVINCIAS";
            // ejecuto y asigno al adaptador
            adapter = new SqlDataAdapter(cmd);
            // asignar los resultados al datatable
            adapter.Fill(dt);
            return dt;
        }

        public DataTable ObtenerCantones(int id_provincia)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter;
            // abro conexion
            cmd.Connection = conn.AbrirConexion();
            // establezco el tipo de comamdo a store procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "OBTENER_CANTONES";
            //añadir los parametros
            cmd.Parameters.Add("IdProvincia", SqlDbType.Int).Value = id_provincia;
            // ejecuto y asigno al adaptador
            adapter = new SqlDataAdapter(cmd);
            // asignar los resultados al datatable
            adapter.Fill(dt);
            return dt;
        }
        public bool InsertarCanton(string nombre_canton, int poblacion, int id_provincia)
        {
            string v_sql = "insert into TB_CANTON (nombre_canton, poblacion, id_provincia, estado) values('" + nombre_canton + "', " + poblacion + ", " + id_provincia + ", 'A')";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn.AbrirConexion();
            cmd.CommandText = v_sql;
            cmd.ExecuteNonQuery();
            conn.CerrarConexion();

            return true;
        }

        public bool ActualizarCanton(int id_canton, string nombre_canton, int poblacion, int id_provincia)
        {
            string v_sql = "update TB_CANTON set nombre_canton ='" + nombre_canton + "', poblacion = " + poblacion + " , id_provincia = " + id_provincia + " where id_canton = " + id_canton + ";";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn.AbrirConexion();
            cmd.CommandText = v_sql;
            cmd.ExecuteNonQuery();
            conn.CerrarConexion();

            return true;
        }

        public bool EliminarCanton(int id_canton)
        {
            string v_sql = "update TB_CANTON set estado = 'I' where id_canton = " + id_canton + ";";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn.AbrirConexion();
            cmd.CommandText = v_sql;
            cmd.ExecuteNonQuery();
            conn.CerrarConexion();

            return true;
        }


    }
}
