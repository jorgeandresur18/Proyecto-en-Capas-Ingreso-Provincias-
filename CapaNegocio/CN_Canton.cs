using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Canton
    {
        private CD_ManageData manejadorCanton = new CD_ManageData();
        private int id_canton, id_provincia, poblacion;
        private string nombre_canton;
        private char estado;

        public CN_Canton() { 
            id_canton = 0;
            id_provincia = 0;
            poblacion = 0;
            nombre_canton = string.Empty;
            estado = 'A';
        }

        public CN_Canton(int id_canton, int id_provincia, int poblacion, string nombre_canton, char estado)
        {
            this.id_canton = id_canton;
            this.id_provincia = id_provincia;
            this.poblacion = poblacion;
            this.nombre_canton = nombre_canton;
            this.estado = estado;
        }

        public int IdCanton
        {
            get { return id_canton; }
            set { id_canton = value; }
        }

        public int IdProvincia
        {
            get { return id_provincia; }
            set { id_provincia = value;}
        }

        public int Poblacion
        {
            get { return poblacion; } set { poblacion = value;}
        }

        public string NombreCanton
        {
            get { return nombre_canton;}
            set { nombre_canton = value;}
        }

        public char Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public DataTable ObtenerCantonesByProvincia(int id_provincia)
        {
            return manejadorCanton.ObtenerCantones(id_provincia);
        }

        public bool InsertarCanton()
        {
            
            return manejadorCanton.InsertarCanton(nombre_canton, poblacion, id_provincia);
        }

        public DataTable getListaCantones()
        {
            // Utiliza SP
            //return manejadorProvincia.ObtenerProvincias();

            return manejadorCanton.ObtenerCantones(id_provincia);
        }
        public bool ActualizarCanton()
        {
            return manejadorCanton.ActualizarCanton(id_canton, nombre_canton, poblacion, id_provincia);

        }

        public bool EliminarCanton()
        {
            return manejadorCanton.EliminarCanton(id_canton);

        }
    }
}
