using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Inventario
    {
        private CD_Inventario objCapaDatos = new CD_Inventario();

        public List<Inventario> Listar()
        {
            return objCapaDatos.Listar();
        }
        public bool Eliminar(int id, out string mensaje)
        {
            return objCapaDatos.Eliminar(id, out mensaje);
        }
    }
}
