using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto objCapaDatos = new CD_Producto();

        public List<Producto> Listar()
        {
            return objCapaDatos.Listar();
        }
        public int Registrar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                mensaje = "El nombre del producto no puede ser vacío";
            }
            if (obj.precio <= 0)
            {
                mensaje = "El precio del producto debe ser mayor a cero";
            }
            if (string.IsNullOrEmpty(obj.categoria) || string.IsNullOrWhiteSpace(obj.categoria))
            {
                mensaje = "La categoría del producto no puede ser vacía";
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
        public bool Editar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                mensaje = "El nombre del producto no puede ser vacío";
            }
            if (obj.precio <= 0)
            {
                mensaje = "El precio del producto debe ser mayor a cero";
            }
            if (string.IsNullOrEmpty(obj.categoria) || string.IsNullOrWhiteSpace(obj.categoria))
            {
                mensaje = "La categoría del producto no puede ser vacía";
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
