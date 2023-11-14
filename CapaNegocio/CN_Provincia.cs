using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Provincia
    {
        private CD_ManageData manejadorProvincia = new CD_ManageData();
        private int id_provincia, poblacion, extension;
        private string nombre_provincia;
        private char estado;

        public CN_Provincia()
        {
            id_provincia = 0;
            poblacion = 0;
            extension = 0;
            nombre_provincia = string.Empty;
            estado = 'A';
        }

        public CN_Provincia(int id_provincia, int poblacion, int extension, string nombre_provincia, char estado)
        {
            this.id_provincia = id_provincia;
            this.poblacion = poblacion;
            this.extension = extension;
            this.nombre_provincia = nombre_provincia;
            this.estado = estado;
        }

        public int IdProvincia
        {
            get { return id_provincia; } set { id_provincia = value;}
        }

        public int Poblacion
        {
            get { return poblacion; } set {  poblacion = value; }
        }

        public int Extension
        {
            get { return extension; } set {  extension = value; }
        }

        public string NombreProvincia
        {
            get { return nombre_provincia;}
            set { nombre_provincia= value; }
        }

        public char Estado
        {
            get { return estado; } set {  estado = value; }
        }

        public bool InsertarProvincia()
        {
            return manejadorProvincia.InsertarProvincia(nombre_provincia, poblacion, extension);

        }

        public bool ActualizarProvincia()
        {
            return manejadorProvincia.ActualizarProvincia(id_provincia, nombre_provincia, poblacion, extension);

        }

        public bool EliminarProvincia()
        {
            return manejadorProvincia.EliminarProvincia(id_provincia);

        }

        public DataTable getListaProvincias()
        {
            // Utiliza SP
            return manejadorProvincia.ObtenerProvincias();
        }

    }
}
