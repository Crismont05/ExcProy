using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor objCapaDatos = new CD_Proveedor();

        public List<Proveedor> Listar()
        {
            return objCapaDatos.Listar();
        }
        public int Registrar(Proveedor obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombres) || string.IsNullOrWhiteSpace(obj.nombres))
            {
                mensaje = "Los nombres del proveedor no pueden ser vacíos";
            }
            if (string.IsNullOrEmpty(obj.apellidos) || string.IsNullOrWhiteSpace(obj.apellidos))
            {
                mensaje = "Los apellidos del proveedor no pueden ser vacíos";
            }
            if (string.IsNullOrEmpty(obj.nombreORG) || string.IsNullOrWhiteSpace(obj.nombreORG))
            {
                mensaje = "El nombre de la organización del proveedor no puede ser vacío";
            }
            if (string.IsNullOrEmpty(mensaje))
            {
                return objCapaDatos.Registrar(obj, out mensaje);
            }
            else
            {
                return 0;
            }
        }
        public bool Editar(Proveedor obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombres) || string.IsNullOrWhiteSpace(obj.nombres))
            {
                mensaje = "Los nombres del proveedor no pueden ser vacíos";
            }
            if (string.IsNullOrEmpty(obj.apellidos) || string.IsNullOrWhiteSpace(obj.apellidos))
            {
                mensaje = "Los apellidos del proveedor no pueden ser vacíos";
            }
            if (string.IsNullOrEmpty(obj.nombreORG) || string.IsNullOrWhiteSpace(obj.nombreORG))
            {
                mensaje = "El nombre de la organización del proveedor no puede ser vacío";
            }
            if (string.IsNullOrEmpty(mensaje))
            {
                return objCapaDatos.Editar(obj, out mensaje);
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar(int id, out string mensaje)
        {
            return objCapaDatos.Eliminar(id, out mensaje);
        }
    }
}
