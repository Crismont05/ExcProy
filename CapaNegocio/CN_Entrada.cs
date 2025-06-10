using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Entrada
    {
        private CD_Entrada objCapaDatos = new CD_Entrada();
        public List<Entrada> Listar()
        {
            return objCapaDatos.Listar();
        }
        public int Registrar(Entrada obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.cantidad.ToString()) || string.IsNullOrWhiteSpace(obj.cantidad.ToString()))
            {
                mensaje = "la cantidad a entrar no puede ser vacía";
            }
            try
            {
                if (obj.cantidad <= 0)
                {
                    mensaje = "la cantidad no puede ser menor o igual que cero";
                }
            }
            catch
            {
                mensaje = "la cantidad debe ser un valor numérico";
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
        public bool Editar(Entrada obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.cantidad.ToString()) || string.IsNullOrWhiteSpace(obj.cantidad.ToString()))
            {
                mensaje = "La cantidad a entrar no puede ser vacía";
            }
            try
            {
                if (obj.cantidad <= 0)
                {
                    mensaje = "La cantidad no puede ser menor o igual que cero";
                }
            }
            catch
            {
                mensaje = "La cantidad debe ser un valor numérico";
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
            return objCapaDatos.Eliminar(id,out mensaje);
        }
    }
}
