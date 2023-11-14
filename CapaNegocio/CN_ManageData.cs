using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class CN_ManageData
    {
        private CD_ManageData manejadorAlumno = new CD_ManageData();

        public DataTable getDataAlumno()
        {
            return manejadorAlumno.getDataAlummo();
        }

    }
}