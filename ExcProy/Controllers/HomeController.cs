using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcProy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inventario()
        {
            return View();
        }
        public ActionResult Ventas()
        { 
            return View();
        }
        public ActionResult Reportes()
        {
            return View();
        }
        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            lista = new CN_Usuario().Listar();

            return Json(new {data = lista}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarUsuario(Usuario obj)
        {
            object result;
            string mensaje = string.Empty;
            if (obj.idUsuario == 0)
            {
                result = new CN_Usuario().Registrar(obj, out mensaje);
            }
            else
            {
                result = new CN_Usuario().Editar(obj, out mensaje);
            }
            return Json(new { resultado = result, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {
            bool result = false;
            string mensaje = string.Empty;

            result = new CN_Usuario().Eliminar(id, out mensaje);

            return Json(new { resultado = result, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}