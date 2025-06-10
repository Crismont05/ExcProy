using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Existencia
    {
        private CD_Existencia objCapaDatos = new CD_Existencia();
        public List<Existencia> Listar()
        {
            return objCapaDatos.Listar();
        }
    }
}
