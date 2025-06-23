using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objCapaDatos = new CD_Usuario();

        public List<Usuario> Listar()
        {
            return objCapaDatos.Listar();
        }
        public int Registrar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.nombres) || string.IsNullOrWhiteSpace(obj.nombres))
            {
                mensaje = "Los nombres no pueden ser vacíos";
            }
            if (string.IsNullOrEmpty(obj.apellidos) || string.IsNullOrWhiteSpace(obj.apellidos))
            {
                mensaje = "Los apellidos no pueden ser vacíos";
            }
            if (string.IsNullOrEmpty(obj.usuario) || string.IsNullOrWhiteSpace(obj.usuario))
            {
                mensaje = "El usuario no puede ser vacío";
            }
            if (string.IsNullOrEmpty(obj.clave) || string.IsNullOrWhiteSpace(obj.clave))
            {
                mensaje = "La clave no puede ser vacía";
            }

            if (string.IsNullOrEmpty(mensaje)) 
            { 
                obj.clave = CN_Recursos.ConvertirSHA256(obj.clave);
                return objCapaDatos.Registrar(obj, out mensaje);
            }
            else
            {
                return 0;
            }
        }
        public bool Editar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.nombres) || string.IsNullOrWhiteSpace(obj.nombres))
            {
                mensaje = "Los nombres no pueden ser vacíos";
            }
            if (string.IsNullOrEmpty(obj.apellidos) || string.IsNullOrWhiteSpace(obj.apellidos))
            {
                mensaje = "Los apellidos no pueden ser vacíos";
            }
            if (string.IsNullOrEmpty(obj.usuario) || string.IsNullOrWhiteSpace(obj.usuario))
            {
                mensaje = "El usuario no puede ser vacío";
            }
            if (string.IsNullOrEmpty(obj.clave) || string.IsNullOrWhiteSpace(obj.clave))
            {
                mensaje = "La clave no puede ser vacía";
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                obj.clave = CN_Recursos.ConvertirSHA256(obj.clave); 
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
