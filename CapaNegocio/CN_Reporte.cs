using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Reporte
    {
        private CD_Reporte objCapaDatos = new CD_Reporte();

        public List<Reporte> Ventas(string fechadeinicio, string fechafin)
        {
            return objCapaDatos.Ventas(fechadeinicio, fechafin);
        }
        public Dashboard VerDashboard()
        {
            return objCapaDatos.VerDashboard();
        }


    }
}
